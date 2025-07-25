namespace Varo.Api.Controllers
{
    using Varo.Api.Models;
    using Varo.Api.Security;
    using Varo.Transversales;
    using System.Net;
    using System.Web.Http;

    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Autenticar(Credencial credencial)
        {
            if (credencial == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            if (credencial.Clave != ParametrosGenerales.API_KEY)
            {
                return Unauthorized();
            }


            var token = TokenJwt.Generar(credencial.Usuario);
            return Ok(token);
        }
    }
}

