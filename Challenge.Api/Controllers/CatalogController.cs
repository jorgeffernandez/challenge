using Challenge.Application;
using System.Web.Http;

namespace Challenge.Api.Controllers
{
    public class CatalogController : ApiController
    {
        #region Private Properties

        private IApplicationAuthorization _applicationAuthorization;
        private IApplicationPhone _applicationPhone;

        #endregion

        #region Constructor

        public CatalogController(IApplicationAuthorization applicationAuthorization, IApplicationPhone applicationPhone)
        {
            _applicationAuthorization = applicationAuthorization;
            _applicationPhone = applicationPhone;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// Devuelve el listado de embarcaciones
        /// </summary>
        /// <param name="take">numero de registros a devolver</param>
        /// <param name="skip">numero de paginas a saltar</param>
        /// <returns>Response</returns>
        [HttpGet]
        public IHttpActionResult Phones(int take = 10, int skip = 0)
        {
            var items = _applicationPhone.GetPhones(take, skip, out int total);

            return Ok(items);
        }

        #endregion
    }
}