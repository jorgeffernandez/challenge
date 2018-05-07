import { Challenge } from './package';
import { clearStateFromParent } from './common/actions/clearState';
import { store } from './store';
import './content/site.css';

export default {
    Challenge: {
        init: (config, returnJson) => {
            Challenge(config.token, config.idHtml);
        }
    },
    clearState: () => {
        store.dispatch(clearStateFromParent());
    }
};
