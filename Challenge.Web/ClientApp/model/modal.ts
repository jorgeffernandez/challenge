import { ModalStepsEnum } from '../common/enum/modalStepsEnum';
import { MobileEntity } from './';

export class Modal {
    show: boolean;
    modalStep: ModalStepsEnum;
    modalSize: string;
    selectedMobile: MobileEntity;

    constructor() {
        this.show = false;
        this.modalStep = ModalStepsEnum.LOADING;
        this.modalSize = '';
        this.selectedMobile = new MobileEntity();
    }
}
