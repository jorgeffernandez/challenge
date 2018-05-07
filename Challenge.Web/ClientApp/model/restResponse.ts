import { ErrorContent } from './ErrorContent';

export interface RestResponse<T> {
    isError?: boolean;
    errorContent?: string,
    content?: T
}
