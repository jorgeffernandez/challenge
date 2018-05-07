using Challenge.ApplicationEntities;

namespace Challenge.Domain.Entities
{
    public partial class Phones : ITransformDto<PhonesDto>
    {
        public PhonesDto GetDto()
        {
            PhonesDto dto = new PhonesDto();

            dto.camera_nv = string.IsNullOrEmpty(this.camera_nv) ? string.Empty : this.camera_nv;
            dto.capacity_nv = string.IsNullOrEmpty(this.capacity_nv) ? string.Empty : this.capacity_nv;
            dto.cdn_url = this.cdn_url;
            dto.color_nv = this.color_nv;
            dto.id_i = this.id_i;
            dto.mobile_id = this.mobile_id;
            dto.name_nv = this.name_nv;
            dto.size_nv = string.IsNullOrEmpty(this.size_nv) ? string.Empty : this.size_nv;
            dto.description_nv = this.description_nv;

            return dto;
        }
    }
}
