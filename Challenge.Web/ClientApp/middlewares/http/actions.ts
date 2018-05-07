import { actionTypes } from '../../common/constants';

export const httpCallStartAction = () => ({
    type: actionTypes.HTTP_CALL_START,
});

export const httpCallEndAction = () => ({
    type: actionTypes.HTTP_CALL_END,
});

export const finishHttpCall = () => {
    return {
        type: actionTypes.HTTP_FINISH,
        meta: {
            httpEnd: true
        }
    };
};
