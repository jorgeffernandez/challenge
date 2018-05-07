import { TokenEnum } from '../common/enum';

export class TokenResult {
    action: TokenEnum;
    urlCss: string;
    state: string;
    sessionId: string;
    accessToken: string;

    errorMessage: string;

    constructor() {
        this.action = TokenEnum.Loading;
        this.urlCss = '';
        this.state = '';
        this.sessionId = '';
        this.accessToken = '';

        this.errorMessage = '';
    }
}
