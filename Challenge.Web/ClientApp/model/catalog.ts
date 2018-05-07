import { MobileEntity } from '../model';

export class Catalog {
    mobiles: MobileEntity[];
    mobile: MobileEntity;

    constructor() {
        this.mobiles = [];
        this.mobile = new MobileEntity();
    }
}
