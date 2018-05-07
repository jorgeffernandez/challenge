import { connect } from 'react-redux';
import { toggleModalAction } from '../modal/actions/modal';
import { State } from '../../reducers';
import { ModalComponent } from './modal';
import { stat } from 'fs';
import { MobileEntity } from '../../model';

const mapStateToProps = (state: State, ownProps: any) => {
    return {
        showModal: state.modal.show,
        modalStep: state.modal.modalStep,
        modalSize: state.modal.modalSize,
        token: state.tokenResult,
        selectedMobile: state.modal.selectedMobile
    };
};

const mapDispatchToProps = (dispatch: any) => {
    return {
        toggleModal: () => {
            return dispatch(toggleModalAction());
        }
    };
};

export const ModalContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(ModalComponent);
