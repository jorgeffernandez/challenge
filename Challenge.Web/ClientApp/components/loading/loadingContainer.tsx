import { connect } from 'react-redux';
import { LoadingComponent } from './loading';
import { State } from '../../reducers';


const mapStateToProps = (state: State, ownProps: any) => {
    return {};
};

const mapDispatchToProps = (dispatch: any) => {
    return {};
};

export const LoadingContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(LoadingComponent);
