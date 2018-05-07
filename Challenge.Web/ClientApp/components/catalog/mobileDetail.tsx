import * as React from 'react';
import { MobileEntity } from '../../model';

export interface IInputDateState {
}


interface Props extends React.Props<MobileDetailComponent> {
    mobile: MobileEntity;
}




export class MobileDetailComponent extends React.Component<Props>{
    constructor(props: Props) {
        super(props);
    }

    public render() {
        return (
            <div id='demo' className='ng-tns-c28-5'>
                <div className='columns-container'>
                    <div className='terminal-detail-left-column'>
                        <div className="left-column-container">
                            <div className="left-column-content">
                                <div className="terminal-detail-carousel-container">
                                    <div className="image-container">
                                        <img alt={this.props.mobile.name_nv} src={this.props.mobile.cdn_url} />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="terminal-detail-right-column">
                        <div className="right-column-container">
                            <h1>{this.props.mobile.name_nv}</h1>
                            <div className="description">
                                <p>{this.props.mobile.description_nv}</p>
                                <span className="characteristics">Ver todas las características</span>
                            </div>

                            <div className="terminal-options">
                                <div className="portability ng-star-inserted">
                                    <h4>Portabilidad</h4>
                                    <p>Para poder llevarte este móvil tienes que traerte a Yoigo tu número actual de móvil</p>
                                </div>
                            </div>
                            <div className="price-resume price-resume-header">
                                <div className="banner headline2 ng-star-inserted">
                                    Escoge tu tarifa
                                        </div>
                            </div>
                            <div className="price-resume price-resume-module">
                                <div className="tariff-info">
                                    <span className="section-title"><span className="ng-star-inserted">Tarifa recomendada</span></span>
                                    <div className="columns">
                                        <div className="left-column">
                                            <p className="name">LA SINFÍN 25 GB</p>
                                            <span className="details-link">Detalles de tu tarifa</span>
                                            <button>
                                                Cambiar tarifa
                                                            <div className="loader-wr">
                                                    <div className="loader-spinner"></div>
                                                </div>
                                            </button>
                                        </div>
                                        <div className="right-column">
                                            <p className="price">25,60 €/mes</p>
                                            <span className="price-info ng-star-inserted">durante 6 meses</span>
                                            <span className="price-info no-offer-price ng-star-inserted"><span className="ng-star-inserted">después: </span>32,00 €/mes</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
