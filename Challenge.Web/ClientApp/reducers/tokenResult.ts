import { actionTypes } from '../common/constants';
import { TokenResult } from '../model/';
import { TokenEnum } from '../common/enum';
import { store } from '../store';

const createEmptyToken = (): TokenResult => (new TokenResult());

export const tokenResultReducer = (state = createEmptyToken(), action) => {
    switch (action.type) {
        case actionTypes.VALIDATE_TOKEN:
            return handleTokenCompleted(state, action.payload);
        case actionTypes.GO_BACK:
            return handleGoBack(state, action.payload);
    }

    return state;
};

const handleTokenCompleted = (state: TokenResult, payload: TokenResult) => {
    return payload;
};

const handleGoBack = (state: TokenResult, payload: TokenEnum) => {
    return {
        ...state,
        activeComponent: TokenEnum.Loading,
    };
};
