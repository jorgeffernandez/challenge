import { actionTypes } from '../../../common/constants';
import { store } from '../../../store';
import { ToastrType, ToastrPosition, ModalStepsEnum } from '../../../common/enum';
import { MobileEntity } from './../../../model';

export const showDetailsAction = (mobile: MobileEntity) => {
    return {
        type: actionTypes.TOGGLE_MODAL_MOBILE_DETAILS,
        modalStep: ModalStepsEnum.MOBILE_DETAILS,
        mobile: mobile
    };
};
