namespace Varo.Web.Controllers
{
    using Varo.Maestros.Negocio;
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Transversales.Entidades;
    using Varo.Web.Helpers;
    using Varo.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web.Mvc;

    public class HitosController : BaseController
    {
        private readonly INegocioHito negocioHito;
        private readonly INegocioSoluciones negocioSoluciones;
        private readonly INegocioUsuarios negocioUsuarios;

        public HitosController()
        {
            this.negocioHito = new NegocioHito();
            this.negocioSoluciones = new NegocioSoluciones();
            this.negocioUsuarios = new NegocioUsuarios();
        }

        public ActionResult Consultar(Guid idSolucion, string gerente, string responsable, string scrumMaster)
        {
            HitosViewModel hitosViewModel = new HitosViewModel();

            try
            {
                hitosViewModel.Hito = new Hito
                {
                    ListaHitos = this.negocioHito.Obtener(idSolucion, this.ObtenerLenguaje)
                };

                hitosViewModel.ListaTipo = this.negocioHito.ConsultarPorMaestro(TiposMaestro.TiposHito, this.ObtenerLenguaje).ToRequiredSelectListItem();

                hitosViewModel.ListaEstados = this.negocioHito.ConsultarPorMaestro(TiposMaestro.EstadosHito, this.ObtenerLenguaje).ToRequiredSelectListItem();

                hitosViewModel.IdSolucion = idSolucion;
                hitosViewModel.UsuarioRedGerente = gerente != null ?
                    negocioUsuarios.ObtenerInformacionUsuario(gerente).DisplayName + " <" + negocioUsuarios.ObtenerInformacionUsuario(gerente).Mail + ">" : string.Empty;
                hitosViewModel.UsuarioRedResponsable = responsable != null ?
                    negocioUsuarios.ObtenerInformacionUsuario(responsable).DisplayName + " <" + negocioUsuarios.ObtenerInformacionUsuario(responsable).Mail + ">" : string.Empty;
                hitosViewModel.UsuarioRedScrumMaster = scrumMaster != null ?
                    negocioUsuarios.ObtenerInformacionUsuario(scrumMaster).DisplayName + " <" + negocioUsuarios.ObtenerInformacionUsuario(scrumMaster).Mail + ">" : string.Empty;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(hitosViewModel);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Crear(HitosViewModel hitosViewModel, FormCollection form)
        {
            try
            {
                List<Hito> listaHito = new List<Hito>();
                Hito hito = new Hito();

                var ArrayIdTipo = Request.Form.GetValues("IdTipo");
                var ArrayDescripcion = Request.Form.GetValues("Descripcion");
                var ArrayFechaCierre = Request.Form.GetValues("FechaCierre");
                var ArrayEstado = Request.Form.GetValues("IdEstado");
                var ArrayObservaciones = Request.Form.GetValues("Observaciones");

                for (int i = 0; i < ArrayIdTipo.Length; i++)
                {
                    Hito itemHito = new Hito();

                    itemHito.Tipo.Id = Convert.ToByte(ArrayIdTipo[i].ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                    itemHito.Descripcion = ArrayDescripcion[i].ToString(CultureInfo.CurrentCulture);
                    itemHito.FechaCierre = Convert.ToDateTime(ArrayFechaCierre[i].ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                    itemHito.Estado.Id = Convert.ToByte(ArrayEstado[i].ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                    itemHito.Observaciones = ArrayObservaciones[i].ToString(CultureInfo.CurrentCulture);

                    listaHito.Add(itemHito);
                }

                hito.IdSolucion = hitosViewModel.IdSolucion;
                hito.ListaHitos = listaHito;

                this.negocioHito.Crear(hito);
                TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroModificado;

                return RedirectToAction("Editar", "Solucion", new { id = hitosViewModel.IdSolucion });
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Editar", "Solucion", new { id = hitosViewModel.IdSolucion });
            }
        }

        public void EnviarCorreo(Guid idSolucion, string emailArquitecto, string adicionales)
        {
            try
            {
                Solucion solucion = this.negocioSoluciones.Obtener(idSolucion);
                negocioHito.EnviarCorreo(solucion, emailArquitecto, adicionales, this.ObtenerLenguaje);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }
        }
    }
}

