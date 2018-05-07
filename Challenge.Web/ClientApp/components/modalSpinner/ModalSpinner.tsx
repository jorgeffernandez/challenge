import * as React from 'react';
import { ClipLoader } from 'react-spinners';

interface Props {
    showSpinner: boolean;
}

export const ModalSpinner: React.StatelessComponent = () => {
    return (
        <div className="modal-spinner">
            <ClipLoader
                size={100}
                color={'#88c23f'}
            />
        </div>
    );
};
