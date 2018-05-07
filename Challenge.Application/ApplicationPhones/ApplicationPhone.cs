using Challenge.ApplicationEntities;
using Challenge.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.Application
{
    public class ApplicationPhone : IApplicationPhone
    {
        #region Private Properties

        private IPhonesRepository _phonesRepository;

        #endregion

        #region Constructor

        public ApplicationPhone(IPhonesRepository phonesRepository)
        {
           _phonesRepository = phonesRepository;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// Devuelve la lista de embarcaciones 
        /// </summary>
        /// <param name="take">tamaño de página</param>
        /// <param name="skip">página</param>
        /// <returns></returns>
        public List<PhonesDto> GetPhones(int take, int skip, out int total)
        {
            var phones = _phonesRepository.GetPhones(take, skip, out total);

            List<PhonesDto> response = new List<PhonesDto>();

            if (phones != null && phones.Count() > 0)
            {
                foreach (var phone in phones)
                {
                    response.Add(phone.GetDto());
                }
                
            }

            return response;
        }

        #endregion
    }
}
