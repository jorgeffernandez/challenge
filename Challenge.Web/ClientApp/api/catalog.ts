import rest from './rest';
import { SiteProps } from '../model/config';
import { APIUrl } from '../common/constants/api';
import { RestResponse, MobileEntity } from '../model';

class CatalogApi {
    loadCatalog(take: string): Promise<RestResponse<MobileEntity[]>> {
        const url = `${SiteProps.SiteURL}${APIUrl.loadCatalog}${take}`;
        return rest.get<MobileEntity[]>(url);
    }
}

export const catalogApi = new CatalogApi();
