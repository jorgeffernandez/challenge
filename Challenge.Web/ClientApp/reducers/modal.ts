import { actionTypes } from '../common/constants';
import { Modal } from '../model/';
import { ModalStepsEnum } from '../common/enum';

export const modalReducer = (state: Modal = new Modal(), action: any) => {
    switch (action.type) {
        case actionTypes.TOGGLE_MODAL:
            return handleToggleModalAction(state);
        case actionTypes.CLEAR_STATE_FROM_PARENT:
            return handleClearState(state);
        case actionTypes.SET_MODAL_NEXT_STEP:
            return handleModal(state, action);
        case actionTypes.TOGGLE_MODAL_MOBILE_DETAILS:
            return handleModalDetails(state, action);
    }
    return state;
};

const handleClearState = (state: Modal) => {
    return new Modal();
};

const handleToggleModalAction = (state: Modal) => {
    return {
        ...state,
        show: !state.show
    };
};

const handleModal = (state: Modal, action: any) => {
    return {
        ...state,
        modalStep: action.modalStep
    };
};

const handleModalDetails = (state: Modal, action: any) => {
    return {
        ...state,
        modalStep: action.modalStep,
        selectedMobile: action.mobile
    };
};

