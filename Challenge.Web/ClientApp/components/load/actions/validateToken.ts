import { tokenAPI } from '../../../api';
import { actionTypes } from '../../../common/constants';
import { TokenResult, RestResponse } from '../../../model';
import { TokenEnum } from '../../../common/enum';
import { httpCallStartAction, finishHttpCall } from '../../../middlewares/';

export const validateTokenAction = (token: string) => (dispatcher: any) => {
    dispatcher(httpCallStartAction());

    //Implementariamos una llamada segura validando un token
    //No requerido en el Challenge

    dispatcher(finishHttpCall());

};

const initTokenErrorResult = (value: string): TokenResult => (new TokenResult());


const validateTokenCompleted = (result: TokenResult) => ({
    type: actionTypes.VALIDATE_TOKEN,
    payload: result
});


