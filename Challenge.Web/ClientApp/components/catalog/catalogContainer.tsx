import { connect } from 'react-redux';
import { State } from '../../reducers';
import { CatalogComponent } from '../catalog/catalog';
import { loadCatalogAction } from './actions/loadCatalogAction';
import { showDetailsAction } from './actions/showDetailsAction';
import { MobileEntity } from './../../model';
import { toggleModalAction } from '../modal/actions/modal';

const mapStateToProps = (state: State, ownProps: any) => {
    return {
        catalog: state.catalog
    };
};
const mapDispatchToProps = (dispatch: any) => {
    return {
        loadCatalog: (take: string) => dispatch(loadCatalogAction(take)),
        toggleMobileDetails: (mobile: MobileEntity) => {
            dispatch(showDetailsAction(mobile));
            dispatch(toggleModalAction());
        },
    };
};

export const CatalogContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(CatalogComponent);
