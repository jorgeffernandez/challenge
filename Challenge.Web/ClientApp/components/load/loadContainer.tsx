import { connect } from 'react-redux';
import { validateTokenAction } from './actions';
import { State } from '../../reducers';
import { LoadComponent } from './load';

const mapStateToProps = (state: State, ownProps: any) => {
    return {
        token: state.token,
        tokenResult: state.tokenResult
    };
};

const mapDispatchToProps = (dispatch: any) => {
    return {
        validateToken: (token: string) => dispatch(validateTokenAction(token))
    };
};

export const LoadContainter = connect(
    mapStateToProps,
    mapDispatchToProps
)(LoadComponent);
