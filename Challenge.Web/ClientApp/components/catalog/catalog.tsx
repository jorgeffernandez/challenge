import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Glyphicon, OverlayTrigger, Tooltip } from 'react-bootstrap';
import { TokenEnum } from '../../common/enum';
import { classNamesFunction, filteredAssign } from 'office-ui-fabric-react/lib/Utilities';
import { debug } from 'util';
import { Catalog, TokenResult, MobileEntity } from './../../model';
import { MobileComponent } from '../catalog/mobile';
import { ModalContainer } from '../modal/modalContainer';


interface Props extends React.Props<CatalogComponent> {
    catalog: Catalog;
    loadCatalog: (take: string) => void;
    toggleMobileDetails: (mobile: MobileEntity) => void;
}

export interface IState {
}

export class CatalogComponent extends React.Component<Props> {

    constructor(props: Props) {
        super(props);

        this._onClick = this._onClick.bind(this);
    }

    private _onClick(id): void {

        let mobile: MobileEntity;
        this.props.catalog.mobiles.forEach(function (element) {
            if (element.mobile_id == id) {
                mobile = element;
            }
        });

        this.props.toggleMobileDetails(mobile);  
    }

    public componentWillMount() {
        this.props.loadCatalog('10');
    }

    public render() {

        return (
            <div id='demo' className='terminals-container'>
                <h1 className='page-title'>Catálogo de móviles</h1>
                <hr />
                <ul className='desktop terminals-list'>
                    {
                        this.props.catalog.mobiles.map((mobile: MobileEntity, index) =>
                           <MobileComponent onclick={this._onClick} key={index} mobile={mobile} />
                        )
                    }
                </ul>
                <ModalContainer />
            </div>
        );

    }
}
