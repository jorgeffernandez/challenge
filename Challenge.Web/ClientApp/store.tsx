import { Store, createStore, compose, applyMiddleware } from 'redux';
import reduxThunk from 'redux-thunk';
import { httpMiddleware } from './middlewares';
import { createLogger } from 'redux-logger';
import { stateReducer, State } from './reducers';

const loggerMiddleware = createLogger();
const composeEnhancers = (window as any).__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const middlewares = [
    reduxThunk,
    httpMiddleware,
    loggerMiddleware
];
export const store: Store<State> = createStore(
    stateReducer,
    composeEnhancers(
        applyMiddleware(...middlewares)
    )
);
