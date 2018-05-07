import { combineReducers } from 'redux';
import { localeReducer } from 'react-localize-redux';
import { httpReducer } from './http';
import { tokenResultReducer } from './tokenResult';
import { tokenReducer } from './token';
import { errorTokenReducer } from './errorToken';
import { TokenResult, ErrorToken, HttpState, Modal, Catalog } from '../model';
import { modalReducer } from './modal';
import { catalogReducer } from './catalog';


export interface State {
    tokenResult: TokenResult;
    token: string;
    errorToken: ErrorToken;
    http: HttpState;
    modal: Modal,
    catalog: Catalog
}

export const stateReducer = combineReducers<State>({
    http: httpReducer,
    tokenResult: tokenResultReducer,
    token: tokenReducer,
    errorToken: errorTokenReducer,
    modal: modalReducer,
    catalog: catalogReducer
});
