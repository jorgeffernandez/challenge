import { actionTypes } from '../common/constants';
import { TokenEnum } from '../common/enum';
import { Catalog, MobileEntity } from '../model';

export const catalogReducer = (state: Catalog = new Catalog(), action: any) => {
    switch (action.type) {
        case actionTypes.LOAD_MOBILES_COMPLETED:
            return handlerLoadCatalogCompleted(state, action.payload);
    }

    return state;
};

const handlerLoadCatalogCompleted = (state: Catalog, payload: MobileEntity[]) => {
    return {
        ...state,
        mobiles: payload
    };
};



