import { connect } from 'react-redux';
import { SpinnerComponent } from './spinner';
import { State } from '../../../reducers';

const mapStateToProps = (state: State) => ({
    showSpinner: state.http.inProgress,
});

export const SpinnerContainer = connect(
    mapStateToProps,
)(SpinnerComponent);
