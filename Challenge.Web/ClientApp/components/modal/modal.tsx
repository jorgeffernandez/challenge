import * as React from 'react';
import { Modal } from 'react-bootstrap';
import { ModalStepsEnum } from '../../common/enum/modalStepsEnum';
import { ModalSpinner } from '../modalSpinner/ModalSpinner';
import { TokenResult, MobileEntity } from '../../model';
import { MobileDetailComponent } from '../catalog/mobileDetail';

interface Props {
    showModal: boolean;
    modalStep: ModalStepsEnum;
    modalSize: string;
    toggleModal: () => any;
    token: TokenResult;
    selectedMobile: MobileEntity;
}

export class ModalComponent extends React.Component<Props> {
    constructor(props) {
        super(props);
    }

    public render() {
        let modalSize;
        const notificacion = null;

        if (this.props.modalSize !== '') {
            modalSize = { bsSize: this.props.modalSize };
        }

        const closeBtn = <button type="button" className="close" onClick={this.props.toggleModal}>
            <span aria-hidden="true">×</span><span className="sr-only">Close</span>
        </button>;

        return (
            <Modal {...modalSize} show={this.props.showModal} backdrop="static" keyboard={false}>
                <Modal.Header>
                    {closeBtn}
                    {this.getModalTitle()}
                </Modal.Header>
                {this.getModalBody()}
            </Modal>
        );


    }

    private getModalTitle(): JSX.Element {

        const classModal = 'modal-title';

        switch (this.props.modalStep) {

            case ModalStepsEnum.MOBILE_DETAILS:
                return <Modal.Title componentClass="h4" className={classModal}>
                    <span className="mrm">Mas detalles</span>
                </Modal.Title>;
            default:
                break;
        }
        return null;
    }

    private getModalBody(): JSX.Element {

        switch (this.props.modalStep) {
            case ModalStepsEnum.MOBILE_DETAILS:
                return <Modal.Body>
                    <MobileDetailComponent mobile={this.props.selectedMobile} />
                </Modal.Body>;

            default:
                return <Modal.Body>
                </Modal.Body>;
        }
    }
}
