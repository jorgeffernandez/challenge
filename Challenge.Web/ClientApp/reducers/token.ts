import { actionTypes } from '../common/constants';
import { TokenEnum } from '../common/enum';

export const tokenReducer = (state = '', action) => {
    switch (action.type) {
        case actionTypes.ADD_TOKEN:
            return handleAddTokenCompleted(state, action.payload.token);
    }

    return state;
};

const handleAddTokenCompleted = (state: string, payload: string) => {
    return payload;
};
