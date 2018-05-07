export class MobileEntity {
    id_i: number;
    mobile_id: string;
    name_nv: string;
    color_nv: string;
    size_nv: string;
    camera_nv: string;
    capacity_nv: string;
    cdn_url: string;
    description_nv: string;
    Total: number;
}


export const createDefaultMobileEntity = () => ({
    id_i: -1,
    mobile_id: '',
    name_nv: '',
    color_nv: '',
    size_nv: '',
    camera_nv: '',
    capacity_nv: '',
    cdn_url: '',
    description_nv: '',
    Total: -1
})