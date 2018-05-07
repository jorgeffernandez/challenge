import { actionTypes } from '../../../common/constants';
import { MobileEntity } from '../../../model';
import { httpCallStartAction, finishHttpCall } from '../../../middlewares/';
import { catalogApi } from '../../../api/catalog';
import toastr from '../../../common/toastr';
import { store } from '../../../store';
import { ToastrType } from '../../../common/enum';

export const loadCatalogAction = (take: string) => (dispatcher: any) => {

    dispatcher(httpCallStartAction());

    catalogApi.loadCatalog(take).then((result) => {
        if (!result.isError) {
            dispatcher(loadCatalogCompleted(take, result.content));
        } else {
            toastr.show(result.errorContent, ToastrType.Error);
        }
        return result;
    }).then((result) => {
        dispatcher(finishHttpCall());
    });
};

const loadCatalogCompleted = (take: string, payload: MobileEntity[]) => ({
    type: actionTypes.LOAD_MOBILES_COMPLETED,
    payload: payload
});

