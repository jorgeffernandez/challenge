import { actionTypes } from '../common/constants';
import { ErrorToken, TokenResult } from '../model';


export const errorTokenReducer = (state: ErrorToken = new ErrorToken(), action: any) => {
    switch (action.type) {
        case actionTypes.VALIDATE_TOKEN:
            return handleErrorToken(state, action.payload);
        case actionTypes.CLEAR_STATE_FROM_PARENT:
            return handleClearState(state);
    }
    return state;
};

const handleClearState = (state: ErrorToken) => {
    return new ErrorToken();
};

const handleErrorToken = (state: ErrorToken, payload: TokenResult) => {
    return {
        ...state,
        error: payload.errorMessage
    };
};
