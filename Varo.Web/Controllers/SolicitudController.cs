using Varo.Transversales;
using System.Web.Mvc;

namespace Varo.Web.Controllers
{
    public class SolicitudController : Controller
    {
        public ActionResult RevisionEstimacion()
        {
            ViewBag.RutaRevisionEstimacion = ParametrosGenerales.RutaRevisionEstimacion;
            return View();
        }

        public ActionResult RevisionArquitectura()
        {
            ViewBag.RutaRevisionArquitectura = ParametrosGenerales.RutaRevisionArquitectura;
            return View();
        }
    }
}
