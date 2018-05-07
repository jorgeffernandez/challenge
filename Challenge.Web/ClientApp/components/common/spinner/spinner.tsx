import * as React from 'react';
import { BounceLoader } from 'react-spinners';

interface Props {
    showSpinner: boolean;
}

export const SpinnerComponent: React.StatelessComponent<Props> = (props) => {
    return (
        props.showSpinner ?
            <div className="spinner-overlay" >
            <div className="spinner" >
        <BounceLoader
                        size={ 100 }
    color = { '#88c23f'}
    loading = { props.showSpinner }
        />
        </div>
        </div>
            : null
    );
};
