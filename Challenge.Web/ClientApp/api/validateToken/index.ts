import * as fecth from 'isomorphic-fetch';
import { TokenResult, RestResponse } from '../../model';
import { TokenEnum } from '../../common/enum';
import { SiteProps } from '../../model/config';
import { APIUrl } from '../../common/constants/api';
import rest from '../rest';

class TokenApi {
    validateTokenAPIAsync(token: string): Promise<RestResponse<TokenResult>> {
        const url = SiteProps.SiteURL + APIUrl.validateToken;
        const queryString = '?tkn=' + token;

        return rest.get<TokenResult>(url + queryString);
    }
}

export const tokenAPI = new TokenApi();
