using Varo.Soluciones.Entidades;
using Varo.Soluciones.Negocio;
using Varo.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

namespace Varo.Web.Controllers
{
    public class EstimacionHorasSolucionController : BaseController
    {
        private readonly INegocioEstimacionHoras negocioEstimacionHoras;

        public EstimacionHorasSolucionController()
        {
            this.negocioEstimacionHoras = new NegocioEstimacionHoras();

        }

        public ActionResult Consultar(Guid idSolucion)
        {
            EstimacionHorasSolucionViewModel estimacionHorasSolucionViewModel = new EstimacionHorasSolucionViewModel();

            try
            {
                estimacionHorasSolucionViewModel.EstimacionHorasSolucion = new EstimacionHorasSolucion();
                estimacionHorasSolucionViewModel.EstimacionHorasSolucion.ListaEstimacionHorasSolucion = this.negocioEstimacionHoras.Consultar(idSolucion);
                estimacionHorasSolucionViewModel.IdSolucion = idSolucion;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(estimacionHorasSolucionViewModel);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Crear(EstimacionHorasSolucionViewModel estimacionHorasSolucionViewModel, FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EstimacionHorasSolucion estimacionHorasSolucion = new EstimacionHorasSolucion();
                    IList<EstimacionHorasSolucion> ListaEstimacionHoras = new List<EstimacionHorasSolucion>();

                    var arrayConcepto = Request.Form.GetValues("itemConcepto");
                    var arrayHorasEstimadas = Request.Form.GetValues("itemHorasEstimadas");
                    var arrayHorasEjecutadas = Request.Form.GetValues("itemHorasEjecutadas");

                    for (int i = (int)default; i < arrayConcepto.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(arrayConcepto[i]))
                        {
                            estimacionHorasSolucion = new EstimacionHorasSolucion();
                            estimacionHorasSolucion.Concepto = arrayConcepto[i];
                            estimacionHorasSolucion.HorasEstimadas = Convert.ToInt32(arrayHorasEstimadas[i], CultureInfo.CurrentCulture);
                            estimacionHorasSolucion.HorasEjecutadas = Convert.ToInt32(arrayHorasEjecutadas[i], CultureInfo.CurrentCulture);
                            ListaEstimacionHoras.Add(estimacionHorasSolucion);
                        }
                    }

                    estimacionHorasSolucion.IdSolucion = estimacionHorasSolucionViewModel.IdSolucion;
                    estimacionHorasSolucion.ListaEstimacionHorasSolucion = ListaEstimacionHoras;

                    this.negocioEstimacionHoras.Crear(estimacionHorasSolucion);
                    TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroModificado;
                }

                return RedirectToAction("Editar", "Solucion", new { id = estimacionHorasSolucionViewModel.IdSolucion });
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Editar", "Solucion", new { id = estimacionHorasSolucionViewModel.IdSolucion });
            }
        }
    }
}

