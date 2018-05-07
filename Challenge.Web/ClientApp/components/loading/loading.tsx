import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Glyphicon } from 'react-bootstrap';

export class LoadingComponent extends React.Component<RouteComponentProps<{}>> {
    public render() {
        return (
            <div className="text-center">
                <div className="st-header">
                    <div className="fluid-cols">
                        <div className="expand-col text-ellipsis">
                            <div className="st-header__title">
                                <h4 className="text-info">
                                    <Glyphicon glyph="refresh" />
                                    &nbsp;Cargando
                                </h4>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
