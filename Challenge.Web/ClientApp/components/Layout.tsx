import * as React from 'react';
import { SpinnerContainer } from '../components/common/spinner/spinnerContainer';

export interface LayoutProps {
    children?: React.ReactNode;
}

export class Layout extends React.Component<LayoutProps> {
    public render() {
        return <div id="coverage-container">
            <div className="container-fluid">
                <SpinnerContainer />
                <div className="row">
                    <div className="col-sm-12">
                        {this.props.children}
                    </div>
                </div>
            </div>
        </div>;
    }
}
