using Varo.Consultorias.Entidades;
using Varo.Consultorias.Negocio;
using Varo.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

namespace Varo.Web.Controllers
{
    public class EstimacionHorasConsultoriaController : BaseController
    {
        private readonly INegocioEstimacionHoras negocioEstimacionHorasConsultoria;

        public EstimacionHorasConsultoriaController()
        {
            this.negocioEstimacionHorasConsultoria = new NegocioEstimacionHoras();

        }

        public ActionResult Consultar(Guid idConsultoria)
        {
            EstimacionHorasConsultoriaViewModel estimacionHorasConsultoriaViewModel = new EstimacionHorasConsultoriaViewModel();

            try
            {
                estimacionHorasConsultoriaViewModel.EstimacionHorasConsultoria = new EstimacionHorasConsultoria();
                estimacionHorasConsultoriaViewModel.EstimacionHorasConsultoria.ListaEstimacionHorasConsultoria = this.negocioEstimacionHorasConsultoria.Consultar(idConsultoria);
                estimacionHorasConsultoriaViewModel.IdConsultoria = idConsultoria;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(estimacionHorasConsultoriaViewModel);

        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Crear(EstimacionHorasConsultoriaViewModel estimacionHorasConsultoriaViewModel, FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EstimacionHorasConsultoria estimacionHorasConsultoria = new EstimacionHorasConsultoria();
                    IList<EstimacionHorasConsultoria> ListaEstimacionHorasConsultoria = new List<EstimacionHorasConsultoria>();

                    var arrayConcepto = Request.Form.GetValues("itemConcepto");
                    var arrayHorasEstimadas = Request.Form.GetValues("itemHorasEstimadas");
                    var arrayHorasEjecutadas = Request.Form.GetValues("itemHorasEjecutadas");

                    for (int i = (int)default; i < arrayConcepto.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(arrayConcepto[i]))
                        {
                            estimacionHorasConsultoria = new EstimacionHorasConsultoria();
                            estimacionHorasConsultoria.Concepto = arrayConcepto[i];
                            estimacionHorasConsultoria.HorasEstimadas = Convert.ToInt32(arrayHorasEstimadas[i], CultureInfo.CurrentCulture);
                            estimacionHorasConsultoria.HorasEjecutadas = Convert.ToInt32(arrayHorasEjecutadas[i], CultureInfo.CurrentCulture);
                            ListaEstimacionHorasConsultoria.Add(estimacionHorasConsultoria);
                        }
                    }

                    estimacionHorasConsultoria.IdConsultoria = estimacionHorasConsultoriaViewModel.IdConsultoria;
                    estimacionHorasConsultoria.ListaEstimacionHorasConsultoria = ListaEstimacionHorasConsultoria;

                    this.negocioEstimacionHorasConsultoria.Crear(estimacionHorasConsultoria);
                    TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroModificado;
                }

                return RedirectToAction("Editar", "Consultoria", new { id = estimacionHorasConsultoriaViewModel.IdConsultoria });
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Editar", "Consultoria", new { id = estimacionHorasConsultoriaViewModel.IdConsultoria });
            }
        }
    }
}

