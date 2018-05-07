import { ErrorContent, RestResponse } from '../model';
import { store } from '../store';
import { apiVerbsEnum } from '../common/enum/apiVerbsEnum';

export default class Rest {
    static get<T>(url: string): Promise<RestResponse<T>> {
        return Rest.request<T>(apiVerbsEnum.GET, url);
    }

    static delete(url: string): Promise<RestResponse<void>> {
        return Rest.request<void>(apiVerbsEnum.DELETE, url);
    }

    static put<T>(url: string, data: Object | string): Promise<RestResponse<T>> {
        return Rest.request<T>(apiVerbsEnum.PUT, url, data);
    }

    static post<T>(url: string, data: Object | string): Promise<RestResponse<T>> {
        return Rest.request<T>(apiVerbsEnum.POST, url, data);
    }

    static patch<T>(url: string, data: Object | string): Promise<RestResponse<T>> {
        return Rest.request<T>(apiVerbsEnum.PATCH, url, data);
    }

    private static request<T>(method: apiVerbsEnum, url: string, data: Object | string = null): Promise<RestResponse<T>> {
        const bodyVerbs = [apiVerbsEnum.POST, apiVerbsEnum.PUT, apiVerbsEnum.PATCH];
        let isJsonResponse = false;
        let isBadRequest = false;
        const aJson = 'application/json';

        const headers = this.getHeaders(aJson, data);

        const params = { method: method.toString(), headers, body: undefined };

        if (bodyVerbs.some(x => x === method)) {
            params.body = JSON.stringify(data);
        }

        return fetch(url, params).then((response) => {
            if (!response.ok) {
                isBadRequest = true;
            }

            const responseContentType = response.headers.get('content-type');
            if (responseContentType && responseContentType.indexOf(aJson) !== -1) {
                isJsonResponse = true;
                return response.json();
            } else {
                return response.text();
            }
        }).then((responseContent: any) => {
            return {
                isError: isBadRequest,
                errorContent: isBadRequest ? responseContent : null,
                content: isBadRequest ? null : responseContent
            };
        }).catch((err: any) => {
            return {
                isError: true,
                errorContent: err.message,
                content: null
            };
        });
    }

    private static getHeaders(aJson: string, data: Object | string = null): Headers {
        const headers = new Headers();

        const accessToken = store.getState().tokenResult.accessToken;
        headers.set('Accept', aJson);
        if (accessToken !== '') {
            headers.set('AccessToken', accessToken);
            headers.set('Authorization', accessToken);
        }

        if (data) {
            if ((typeof data === 'object')) {
                headers.set('Content-Type', aJson);
            } else {
                headers.set('Content-Type', 'application/x-www-form-urlencoded');
            }
        }

        return headers;
    }
}
