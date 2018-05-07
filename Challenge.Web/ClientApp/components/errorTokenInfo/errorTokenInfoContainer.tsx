import { connect } from 'react-redux';
import { ErrorTokenInfo } from './errorTokenInfo';
import { State } from '../../reducers/index';

const mapStateToProps = (state: State, ownProps: any) => {
    return {
        error: state.errorToken.error
    };
};

const mapDispatchToProps = (dispatch: any) => {
    return {

    };
};

export const ErrorTokenInfoContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(ErrorTokenInfo);
