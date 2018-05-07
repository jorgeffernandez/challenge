import { actionTypes } from '../constants';
import { ClearStateEnum } from '../enum';

export const clearStateAction = (clearStateEnum: ClearStateEnum) => {
    switch (clearStateEnum) {
        case ClearStateEnum.FromAutocomplete:
            return handleFromAutoComplete();
        case ClearStateEnum.FromSecondChance:
            return handleFromSecondChance();
    }
    return clearStateFromParent();
};

export const clearStateFromParent = () => {
    return {
        type: actionTypes.CLEAR_STATE_FROM_PARENT
    };
};

export const handleFromAutoComplete = () => {
    return {
        type: actionTypes.CLEAR_STATE_FROM_AUTOCOMPLETE
    };
};

export const handleFromSecondChance = () => {
    return {
        type: actionTypes.CLEAR_STATE_FROM_SECOND_CHANCE
    };
};
