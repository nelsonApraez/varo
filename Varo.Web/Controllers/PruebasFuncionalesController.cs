namespace Varo.Web.Controllers
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Web.Models;
    using System;
    using System.Globalization;
    using System.Web.Mvc;

    public class PruebasFuncionalesController : BaseController
    {
        private readonly INegocioPrueba negocioPrueba;

        public PruebasFuncionalesController()
        {
            this.negocioPrueba = new NegocioPrueba();
        }

        public ActionResult Consultar(Guid idSolucion)
        {
            Prueba prueba;
            PruebasFuncionalesViewModel pruebasViewModel = new PruebasFuncionalesViewModel();

            try
            {
                prueba = this.negocioPrueba.ConsultarPorIdSolucion(idSolucion);
                pruebasViewModel = this.ConvertirPruebaAPruebaViewModel(prueba);
                pruebasViewModel.IdSolucion = idSolucion;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(pruebasViewModel);

        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Actualizar(PruebasFuncionalesViewModel pruebaViewModel, FormCollection form)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    Prueba prueba = new Prueba
                    {
                        IdSolucion = pruebaViewModel.IdSolucion,
                        CasosDefinidos = int.Parse(Request.Form["CasosDefinidos"], CultureInfo.CurrentCulture),
                        CasosAutomatizar = int.Parse(Request.Form["CasosaAutomatizar"], CultureInfo.CurrentCulture),
                        CasosAutomatizados = int.Parse(Request.Form["CasosAutomatizados"], CultureInfo.CurrentCulture),
                        UrlDiseñoCasos = Request.Form["UrlDiseñodeCasos"],
                        UrlEvidencias = Request.Form["UrlEvidencias"],
                        UrlRepositorio = Request.Form["UrlRepositorio"],
                        UsuarioRedTecnico = Request.Form["usuarioRedTecnico"],
                        FechaCreacion = DateTime.Parse(Request.Form["FechaCreacion"], CultureInfo.CurrentCulture)
                    };
                    if (Request.Form["checkEstaenPipeline"] != null)
                    {
                        prueba.EstaenPipeline = bool.Parse(Request.Form["checkEstaenPipeline"]);
                    }
                    prueba.Observaciones = Request.Form["Observaciones"];

                    if (Request.Form["Id"] == null || Request.Form["Id"] == Guid.Empty.ToString())
                    {
                        this.negocioPrueba.Crear(prueba);
                    }
                    else
                    {
                        prueba.Id = Guid.Parse(Request.Form["Id"]);
                        this.negocioPrueba.Editar(prueba);
                    }
                }

                TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroModificado;

                return RedirectToAction("Editar", "Solucion", new { id = pruebaViewModel.IdSolucion });
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Editar", "Solucion", new { id = pruebaViewModel.IdSolucion });
            }

        }

        private PruebasFuncionalesViewModel ConvertirPruebaAPruebaViewModel(Prueba prueba)
        {
            PruebasFuncionalesViewModel pruebasViewModel = new PruebasFuncionalesViewModel
            {
                Id = prueba.Id,
                CasosDefinidos = prueba.CasosDefinidos,
                CasosaAutomatizar = prueba.CasosAutomatizar,
                CasosAutomatizados = prueba.CasosAutomatizados,
                UrlDiseñodeCasos = prueba.UrlDiseñoCasos,
                UrlEvidencias = prueba.UrlEvidencias,
                UrlRepositorio = prueba.UrlRepositorio,
                CasosPendientes = prueba.CasosPendientes,
                UsuarioRedTecnico = prueba.UsuarioRedTecnico,
                NombreTecnico = prueba.NombreTecnico,
                FechaCreacion = prueba.FechaCreacion.HasValue ? prueba.FechaCreacion.Value : DateTime.Now,
                EstaenPipeline = prueba.EstaenPipeline ? "checked" : "unchecked",
                Observaciones = prueba.Observaciones
            };

            return pruebasViewModel;
        }
    }
}
