import 'core-js/fn/object/assign';
import 'core-js/fn/promise';
import 'core-js/es6/map';
import 'core-js/es6/set';
import 'core-js/es6/string';
import 'core-js/fn/array';
import 'whatwg-fetch';

import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import { ConnectedRouter } from 'react-router-redux';
import * as RoutesModule from './routes';
import * as es6 from 'es6-promise';
import { createBrowserHistory } from 'history';
import { store } from './store';
import { SiteProps } from './model';
import { actionTypes } from './common/constants';
import injectTapEventPlugin from 'react-tap-event-plugin';


const routes = RoutesModule.routes;
const history = createBrowserHistory();



export function Challenge(token: string, idHtml: string) {
    SiteProps.SiteURL = '__API__';

    store.dispatch({
        type: actionTypes.ADD_TOKEN,
        payload: {
            token
        }
    });

    try {
        injectTapEventPlugin();
    }
    catch (e) {

    }


    ReactDOM.render(
        <AppContainer>
            <Provider store={store} >
                <ConnectedRouter history={history} children={routes} />
            </Provider>
        </AppContainer>,
        document.getElementById(idHtml));
}
