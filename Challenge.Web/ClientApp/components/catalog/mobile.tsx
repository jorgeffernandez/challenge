import * as React from 'react';
import { MobileEntity } from '../../model';

export interface IInputDateState {
}


interface Props extends React.Props<MobileComponent> {
    mobile: MobileEntity;
    onclick: any;
}




export class MobileComponent extends React.Component<Props>{
    constructor(props: Props) {
        super(props);

        this._onClick = this._onClick.bind(this);
    }

    private _onClick(event: any) {
        this.props.onclick(event.currentTarget.dataset.id);
    }

    public render() {
        return (
            <li className='terminal-item ng-star-inserted'>
                <a id={this.props.mobile.mobile_id}>
                    <div className='big'>
                        <div className='terminal-card-wrapper'>
                            <img className='terminal-image' src={this.props.mobile.cdn_url} alt={this.props.mobile.name_nv} />
                            <div className='terminal-details'>
                                <div className='fixed-height-info'>
                                    <h3 className='terminal-title'>{this.props.mobile.name_nv}</h3>
                                    <div className='colors-palette'>
                                        <span className='terminal-color ng-star-inserted'></span>
                                        <span className='terminal-color ng-star-inserted'></span>
                                        <span className='terminal-color ng-star-inserted'></span>
                                    </div>
                                </div>
                                <div className='terminal-info'>
                                    <div className='terminal-feature'>
                                        <span className='info-title'>Pantalla</span>
                                        <span className='info-data'>{this.props.mobile.size_nv}"</span>
                                    </div>
                                    <div className='terminal-feature'>
                                        <span className='info-title'>Cámara</span>
                                        <span className='info-data'>{this.props.mobile.camera_nv}</span>
                                    </div>
                                    <div className='terminal-feature'>
                                        <span className='info-title'>Capacidad</span>
                                        <span className='info-data'>{this.props.mobile.capacity_nv}</span>
                                    </div>
                                </div>
                            </div>
                            <div className='terminal-tariff' onClick={this._onClick} data-id={this.props.mobile.mobile_id}>
                                <div className='tariff-info tariff-installment tariff-info-full'>
                                    <span className='tariff-name ng-star-inserted'>Llévatelo</span>
                                </div>
                                <div className='tariff-info tariff-info-full ng-star-inserted'>
                                    <span className='tariff-title invisible'>0 Plazos</span>
                                    <span className='tariff-price'>
                                        <span className='tariff-price-value ng-star-inserted'>¡GRATIS!</span>
                                    </span>
                                </div>
                            </div>

                        </div>
                    </div>
                    <a className='more-info-label'>Más información</a>
                </a>
            </li>
        );
    }
}
