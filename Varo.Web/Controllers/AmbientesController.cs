namespace Varo.Web.Controllers
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Transversales.Entidades;
    using Varo.Web.Helpers;
    using Varo.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web.Mvc;

    public class AmbientesController : BaseController
    {
        private readonly INegocioAmbientes negocioAmbientes;

        public AmbientesController()
        {
            this.negocioAmbientes = new NegocioAmbientes();
        }

        public ActionResult Consultar(Guid idSolucion)
        {
            AmbientesViewModel ambientesViewModel = new AmbientesViewModel();

            try
            {
                ambientesViewModel.Ambientes = new Ambientes
                {
                    ListaAmbientes = this.negocioAmbientes.Consultar(idSolucion, this.ObtenerLenguaje)
                };
                ambientesViewModel.ListaTipoAmbiente = this.negocioAmbientes.ConsultarPorMaestro(TiposMaestro.TiposAmbiente, this.ObtenerLenguaje).ToRequiredSelectListItem();

                ambientesViewModel.IdSolucion = idSolucion;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(ambientesViewModel);

        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Crear(AmbientesViewModel ambientesViewModel, FormCollection form)
        {
            try
            {
                List<Ambientes> listaAmbientes = new List<Ambientes>();
                Ambientes ambientes = new Ambientes();

                var ArrayTipoAmbiente = Request.Form.GetValues("IdTipoAmbiente");
                var ArrayUbicacion = Request.Form.GetValues("Ubicacion");
                var ArrayResponsable = Request.Form.GetValues("Responsable");

                for (int i = 0; i < ArrayTipoAmbiente.Length; i++)
                {
                    Ambientes itemAmbientes = new Ambientes();

                    itemAmbientes.TipoAmbiente.Id = Convert.ToByte(ArrayTipoAmbiente[i].ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                    itemAmbientes.Ubicacion = ArrayUbicacion[i].ToString(CultureInfo.CurrentCulture);
                    itemAmbientes.Responsable = ArrayResponsable[i].ToString(CultureInfo.CurrentCulture);

                    listaAmbientes.Add(itemAmbientes);
                }

                ambientes.IdSolucion = ambientesViewModel.IdSolucion;
                ambientes.ListaAmbientes = listaAmbientes;

                this.negocioAmbientes.Crear(ambientes);
                TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroModificado;

                return RedirectToAction("Editar", "Solucion", new { id = ambientesViewModel.IdSolucion });
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Editar", "Solucion", new { id = ambientesViewModel.IdSolucion });
            }
        }
    }
}

