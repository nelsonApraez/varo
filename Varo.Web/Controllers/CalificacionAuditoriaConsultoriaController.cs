namespace Varo.Web.Controllers
{
    using Varo.Consultorias.Entidades;
    using Varo.Consultorias.Negocio;
    using Varo.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web.Mvc;

    public class CalificacionAuditoriaConsultoriaController : BaseController
    {
        private readonly INegocioAuditoria negocioAuditoriaConsultoria;

        public CalificacionAuditoriaConsultoriaController()
        {
            this.negocioAuditoriaConsultoria = new NegocioAuditoria();

        }

        public ActionResult Consultar(Guid idConsultoria)
        {
            CalificacionAuditoriaConsultoriaViewModel calificacionAuditoriaConsultoriaViewModel = new CalificacionAuditoriaConsultoriaViewModel();

            try
            {
                calificacionAuditoriaConsultoriaViewModel.calificacionAuditorias = new CalificacionAuditoria();
                calificacionAuditoriaConsultoriaViewModel.calificacionAuditorias.ListaCalificacionAuditorias = this.negocioAuditoriaConsultoria.Obtener(idConsultoria);
                calificacionAuditoriaConsultoriaViewModel.IdConsultoria = idConsultoria;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(calificacionAuditoriaConsultoriaViewModel);

        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Crear(CalificacionAuditoriaConsultoriaViewModel calificacionAuditoriaConsultoriaViewModel, FormCollection form)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    List<CalificacionAuditoria> listaAuditorias = new List<CalificacionAuditoria>();
                    CalificacionAuditoria calificacionAuditorias = new CalificacionAuditoria();

                    var ArrayUrlCalificacionAuditorias = Request.Form.GetValues("Url");
                    var ArrayCalificacionAuditorias = Request.Form.GetValues("Calificacion");
                    var ArrayFechasAuditorias = Request.Form.GetValues("Fecha");
                    var ArrayProcesoAuditorias = Request.Form.GetValues("Proceso");
                    var ArrayObservacionAuditorias = Request.Form.GetValues("Observacion");

                    for (int i = 0; i < ArrayUrlCalificacionAuditorias.Length; i++)
                    {
                        CalificacionAuditoria itemCalificacionAuditorias = new CalificacionAuditoria();

                        itemCalificacionAuditorias.Url = ArrayUrlCalificacionAuditorias[i].ToString(CultureInfo.CurrentCulture);
                        itemCalificacionAuditorias.Calificacion = Convert.ToDecimal(ArrayCalificacionAuditorias[i].ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                        itemCalificacionAuditorias.Fecha = DateTime.Parse(ArrayFechasAuditorias[i].ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                        itemCalificacionAuditorias.Proceso = ArrayProcesoAuditorias[i].ToString(CultureInfo.CurrentCulture);
                        itemCalificacionAuditorias.Observacion = ArrayObservacionAuditorias[i].ToString(CultureInfo.CurrentCulture);
                        listaAuditorias.Add(itemCalificacionAuditorias);
                    }

                    calificacionAuditorias.ListaCalificacionAuditorias = listaAuditorias;
                    calificacionAuditorias.IdConsultoria = calificacionAuditoriaConsultoriaViewModel.IdConsultoria;

                    this.negocioAuditoriaConsultoria.Crear(calificacionAuditorias);
                    TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroModificado;
                }

                return RedirectToAction("Editar", "Consultoria", new { id = calificacionAuditoriaConsultoriaViewModel.IdConsultoria });
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Editar", "Consultoria", new { id = calificacionAuditoriaConsultoriaViewModel.IdConsultoria });
            }
        }

    }
}

