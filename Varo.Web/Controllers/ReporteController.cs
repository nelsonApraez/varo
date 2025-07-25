namespace Varo.Web.Controllers
{
    using Varo.Transversales;
    using Varo.Transversales.Constantes;
    using System.Web.Mvc;

    public class ReporteController : BaseController
    {
        public ActionResult Consultorias()
        {
            ViewBag.RutaConsultorias = this.MultilenguajeReportes(
                ParametrosGenerales.RutaConsultoriasEN,
                ParametrosGenerales.RutaConsultoriasEN);
            return View();
        }

        public ActionResult Soluciones()
        {
            ViewBag.RutaSoluciones = this.MultilenguajeReportes(
                ParametrosGenerales.RutaSolucionesEN,
                ParametrosGenerales.RutaSolucionesEN);
            return View();
        }

        public ActionResult PracticasTecnicas()
        {
            ViewBag.RutaPracticasTecnicas = this.MultilenguajeReportes(
                ParametrosGenerales.RutaPracticasTecnicasEN,
                ParametrosGenerales.RutaPracticasTecnicasEN);
            return View();
        }

        public ActionResult CalidadCodigo()
        {
            ViewBag.RutaCalidadCodigo = this.MultilenguajeReportes(
                ParametrosGenerales.RutaCalidadCodigoEN,
                ParametrosGenerales.RutaCalidadCodigoEN);
            return View();
        }

        public ActionResult PruebasFuncionales()
        {
            ViewBag.RutaPruebasFuncionales = this.MultilenguajeReportes(
                ParametrosGenerales.RutaPruebasFuncionalesEN,
                ParametrosGenerales.RutaPruebasFuncionalesEN);
            return View();
        }

        public ActionResult MetricasAgiles()
        {
            ViewBag.RutaMetricasAgiles = this.MultilenguajeReportes(
                ParametrosGenerales.RutaMetricasAgilesEN,
                ParametrosGenerales.RutaMetricasAgilesEN);
            return View();
        }

        public ActionResult Hitos()
        {
            ViewBag.RutaHitos = this.MultilenguajeReportes(
                ParametrosGenerales.RutaHitosEN,
                ParametrosGenerales.RutaHitosEN);
            return View();
        }

        public ActionResult Auditorias()
        {
            ViewBag.RutaAuditorias = this.MultilenguajeReportes(
                ParametrosGenerales.RutaAuditoriasEN,
                ParametrosGenerales.RutaAuditoriasEN);
            return View();
        }

        public ActionResult Desempeno()
        {
            ViewBag.RutaDesempeno = this.MultilenguajeReportes(
                ParametrosGenerales.RutaDesempenoEN,
                ParametrosGenerales.RutaDesempenoEN);
            return View();
        }

        public ActionResult Seguridad()
        {
            ViewBag.RutaSeguridad = this.MultilenguajeReportes(
                ParametrosGenerales.RutaSeguridadEN,
                ParametrosGenerales.RutaSeguridadEN);
            return View();
        }

        public string MultilenguajeReportes(string RutaEs, string RutaEn)
        {
            if (ObtenerLenguaje.Equals(TransversalesConstantes.Espanol))
            {
                return RutaEs;
            }
            else
            {
                return RutaEn;
            }
        }
    }
}

