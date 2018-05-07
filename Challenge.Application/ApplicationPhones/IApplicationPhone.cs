using Challenge.ApplicationEntities;
using System.Collections.Generic;

namespace Challenge.Application
{
    public interface IApplicationPhone
    {
        List<PhonesDto> GetPhones(int take, int skip, out int total);
    }
}
