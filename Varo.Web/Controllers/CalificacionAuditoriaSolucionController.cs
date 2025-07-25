namespace Varo.Web.Controllers
{
    using Varo.Maestros.Negocio;
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Web.Comun;
    using Varo.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web.Mvc;

    public class CalificacionAuditoriaSolucionController : BaseController
    {
        private readonly INegocioAuditoria negocioAuditoria;
        private readonly INegocioSoluciones negocioSoluciones;
        private readonly INegocioClientes negocioClientes;

        public CalificacionAuditoriaSolucionController()
        {
            this.negocioAuditoria = new NegocioAuditoria();
            this.negocioSoluciones = new NegocioSoluciones();
            this.negocioClientes = new NegocioClientes();

        }

        [HttpGet]
        public ActionResult ConsultarMultiple()
        {
            CalificacionAuditoriaSolucionViewModel calificacionAuditoriaViewModel = new CalificacionAuditoriaSolucionViewModel
            {
                ListaClientes = Comun.ConvertirListaClienteEnSelectListItem(negocioClientes.ConsultarClientes()),
                ListaSoluciones = Comun.ConvertirListaSolucionEnSelectListItem(negocioSoluciones.Consultar()),
            };

            return View(calificacionAuditoriaViewModel);
        }

        public ActionResult Consultar(Guid idSolucion)
        {
            CalificacionAuditoriaSolucionViewModel calificacionAuditoriaViewModel = new CalificacionAuditoriaSolucionViewModel();

            try
            {
                calificacionAuditoriaViewModel.calificacionAuditorias = new CalificacionAuditoria
                {
                    ListaCalificacionAuditorias = this.negocioAuditoria.Obtener(idSolucion)
                };
                calificacionAuditoriaViewModel.IdSolucion = idSolucion;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(calificacionAuditoriaViewModel);

        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Crear(CalificacionAuditoriaSolucionViewModel calificacionAuditoriaViewModel, FormCollection form)
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

                    calificacionAuditorias.IdSolucion = calificacionAuditoriaViewModel.IdSolucion;
                    calificacionAuditorias.ListaCalificacionAuditorias = listaAuditorias;

                    this.negocioAuditoria.Actualizar(calificacionAuditorias);
                    TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroModificado;
                }

                return RedirectToAction("Editar", "Solucion", new { id = calificacionAuditoriaViewModel.IdSolucion });
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Editar", "Solucion", new { id = calificacionAuditoriaViewModel.IdSolucion });
            }
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult CrearMultiples(CalificacionAuditoriaSolucionViewModel calificacionAuditoriaViewModel, FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<CalificacionAuditoria> listaAuditorias = new List<CalificacionAuditoria>();
                    CalificacionAuditoria calificacionAuditorias = new CalificacionAuditoria();

                    var ArrayUrl = Request.Form["Url"];
                    var ArrayCalificacion = Convert.ToDecimal(Request.Form["Calificacion"], CultureInfo.CurrentCulture);
                    var ArrayFecha = DateTime.Parse(Request.Form["Fecha"], CultureInfo.CurrentCulture);
                    var ArrayProceso = Request.Form["Proceso"];
                    var ArrayObservacion = Request.Form["Observacion"];
                    var ArraySolucion = Request.Form.GetValues("IdSolucion");

                    for (int i = 0; i < ArraySolucion.Length; i++)
                    {
                        CalificacionAuditoria itemCalificacionAuditorias = new CalificacionAuditoria();

                        itemCalificacionAuditorias.Url = ArrayUrl;
                        itemCalificacionAuditorias.Calificacion = ArrayCalificacion;
                        itemCalificacionAuditorias.Fecha = ArrayFecha;
                        itemCalificacionAuditorias.Proceso = ArrayProceso;
                        itemCalificacionAuditorias.Observacion = ArrayObservacion;
                        itemCalificacionAuditorias.IdSolucion = Guid.Parse(ArraySolucion[i]);
                        listaAuditorias.Add(itemCalificacionAuditorias);
                    }

                    calificacionAuditorias.IdSolucion = calificacionAuditoriaViewModel.IdSolucion;
                    calificacionAuditorias.ListaCalificacionAuditorias = listaAuditorias;

                    this.negocioAuditoria.Crear(calificacionAuditorias);
                    TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroCreado;
                }

                return RedirectToAction("ConsultarMultiple", "CalificacionAuditoriaSolucion");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("ConsultarMultiple", "CalificacionAuditoriaSolucion");
            }
        }
    }
}

