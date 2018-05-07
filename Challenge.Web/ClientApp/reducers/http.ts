import { actionTypes } from '../common/constants';
import { HttpState } from '../model';

const newState = (): HttpState => ({
    callCount: 0,
    inProgress: false,
});

export const httpReducer = (state = newState(), action) => {
    switch (action.type) {
        case actionTypes.HTTP_CALL_START:
            return handleHttpCallStart(state, action.payload);
        case actionTypes.HTTP_CALL_END:
            return handleHttpCallEnd(state, action.payload);
        case actionTypes.HTTP_FINISH:
            break;
    }

    return state;
};

const handleHttpCallStart = (state: HttpState, payload): HttpState => ({
    callCount: state.callCount + 1,
    inProgress: true,
});

const handleHttpCallEnd = (state: HttpState, payload): HttpState => {
    const callCount = state.callCount - 1;

    return {
        callCount,
        inProgress: callCount > 0,
    };
};
