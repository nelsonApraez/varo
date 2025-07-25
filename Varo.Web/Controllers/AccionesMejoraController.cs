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
    using System.Linq;
    using System.Web.Mvc;

    public class AccionesMejoraController : BaseController
    {
        private readonly INegocioSoluciones negocioSoluciones;
        private readonly INegocioAccionMejora negocioAccionMejora;
        private readonly INegocioSeguimiento negocioSeguimiento;
        private const int estadoCerrado = 2;
        public AccionesMejoraController()
        {
            this.negocioAccionMejora = new NegocioAccionMejora();
            this.negocioSeguimiento = new NegocioSeguimiento();
            this.negocioSoluciones = new NegocioSoluciones();
        }

        [HttpGet]
        public ActionResult Consultar(Guid idSolucion, string terminoBusqueda, string filtroActual)
        {
            AccionesMejoraViewModel accionesMejoraViewModel = new AccionesMejoraViewModel();

            try
            {
                accionesMejoraViewModel.AccionesMejora.ListaAccionesMejora =
                    this.VerificarBusquedaYPaginadorAcciones(idSolucion, terminoBusqueda, filtroActual).ToList();
                accionesMejoraViewModel.IdSolucion = idSolucion;

                AccionesMejora AccionesMejora = new AccionesMejora();
                ItemMaestro responsable = new ItemMaestro();
                if (AccionesMejora.Responsable != null)
                {
                    responsable.Id = AccionesMejora.Responsable.Id;
                }
                accionesMejoraViewModel.Responsable = responsable;
                ItemMaestro estado = new ItemMaestro();
                if (AccionesMejora.Estado != null)
                {
                    estado.Id = AccionesMejora.Estado.Id;
                }
                accionesMejoraViewModel.Estado = estado;
                accionesMejoraViewModel.ListaResponsablesAccionesMejora = this.negocioSoluciones.ConsultarPorMaestro(
                    TiposMaestro.ResponsablesAccionesMejora,
                    this.ObtenerLenguaje).ToRequiredSelectListItem().Where(i => i.Value != "");
                accionesMejoraViewModel.ListaEstadosAccionesMejora = this.negocioSoluciones.ConsultarPorMaestro(
                    TiposMaestro.EstadosAccionesMejora,
                    this.ObtenerLenguaje).ToRequiredSelectListItem().Where(i => i.Value != "");
                TempData["estadoCerrado"] = estadoCerrado;
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_AccionesMejora", accionesMejoraViewModel);
                }

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }
            return View(accionesMejoraViewModel);
        }
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Editar(AccionesMejoraViewModel accionesMejoraViewModel, FormCollection form)
        {
            List<AccionesMejora> listaAccionesMejora = new List<AccionesMejora>();
            try
            {
                AccionesMejora accionesMejora = new AccionesMejora();
                var ArrayId = Request.Form.GetValues("itemId");
                var ArrayAccionMejora = Request.Form.GetValues("itemAccionMejora");
                var ArrayCausa = Request.Form.GetValues("itemCausa");
                var ArrayResponsable = Request.Form.GetValues("itemIdResponsable");
                var ArrayEstado = Request.Form.GetValues("itemIdEstado");
                if (Request.Form.GetValues("itemAccionMejora") != null)
                {
                    for (int i = 0; i < ArrayAccionMejora.Length; i++)
                    {
                        AccionesMejora itemAccionesMejora = new AccionesMejora();
                        if (ArrayId != null && ArrayId.Count() >= i + 1)
                        {
                            itemAccionesMejora.Id = int.Parse(ArrayId[i].ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                        }
                        itemAccionesMejora.Accion = ArrayAccionMejora[i].ToString(CultureInfo.CurrentCulture);
                        itemAccionesMejora.Causa = ArrayCausa[i].ToString(CultureInfo.CurrentCulture);
                        itemAccionesMejora.Responsable.Id = (byte)int.Parse(ArrayResponsable[i].ToString(
                            CultureInfo.CurrentCulture),
                            CultureInfo.CurrentCulture);
                        itemAccionesMejora.Estado.Id = (byte)int.Parse(ArrayEstado[i].ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                        listaAccionesMejora.Add(itemAccionesMejora);
                    }
                }

                accionesMejora.ListaAccionesMejora = listaAccionesMejora;

                this.negocioAccionMejora.Editar(accionesMejora);
                TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroModificado;
                return RedirectToAction("Consultar", "AccionesMejora", new { idSolucion = accionesMejoraViewModel.IdSolucion });

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar", "AccionesMejora", new { idSolucion = accionesMejoraViewModel.IdSolucion });
            }
        }
        public ActionResult Obtener(Guid idSolucion, int id, int idEstado)
        {
            SeguimientoViewModel seguimientoViewModel = new SeguimientoViewModel();
            try
            {
                seguimientoViewModel.seguimiento.ListaSeguimiento = this.negocioSeguimiento.Consultar(id);
                seguimientoViewModel.IdAccionesMejora = id;
                seguimientoViewModel.IdSolucion = idSolucion;
                TempData["estadoCerrado"] = idEstado == estadoCerrado ? 1 : 0;

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }
            return View(seguimientoViewModel);
        }
        public ActionResult ObtenerVistaPrevia(Guid idSolucion, int id)
        {
            SeguimientoViewModel seguimientoViewModel = new SeguimientoViewModel();
            try
            {
                seguimientoViewModel.seguimiento.ListaSeguimiento = this.negocioSeguimiento.Consultar(id);
                seguimientoViewModel.IdAccionesMejora = id;
                seguimientoViewModel.IdSolucion = idSolucion;
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }
            return View(seguimientoViewModel);
        }
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Crear(SeguimientoViewModel seguimientoViewModel, FormCollection form)
        {
            List<Seguimiento> listaSeguimiento = new List<Seguimiento>();
            try
            {
                Seguimiento seguimiento = new Seguimiento();


                var ArrayId = Request.Form.GetValues("itemId");
                var ArrayObservacion = Request.Form.GetValues("itemObservacion");
                var ArrayFecha = Request.Form.GetValues("itemFecha");
                var ArrayUsuario = Request.Form.GetValues("itemUsuario");

                for (int i = 0; i < ArrayObservacion.Length; i++)
                {
                    Seguimiento itemSeguimiento = new Seguimiento();
                    if (ArrayId != null && ArrayId.Count() >= i + 1)
                    {
                        itemSeguimiento.Id = int.Parse(ArrayId[i].ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                    }
                    itemSeguimiento.IdAccionesMejora = seguimientoViewModel.IdAccionesMejora;
                    itemSeguimiento.Observacion = ArrayObservacion[i].ToString(CultureInfo.CurrentCulture);
                    itemSeguimiento.Fecha = string.IsNullOrEmpty(ArrayFecha[i]) ?
                        itemSeguimiento.Fecha = DateTime.Now :
                        itemSeguimiento.Fecha = DateTime.ParseExact(ArrayFecha[i], "MM/dd/yyyy", null);

                    if (ArrayUsuario[i] != "")
                    {
                        itemSeguimiento.Usuario = ArrayUsuario[i].ToString(CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        itemSeguimiento.Usuario = User.Identity.Name.Contains("@") ?
                            itemSeguimiento.Usuario = User.Identity.Name.Substring(0, User.Identity.Name.IndexOf("@")) :
                            itemSeguimiento.Usuario = User.Identity.Name;
                    }
                    listaSeguimiento.Add(itemSeguimiento);
                }

                seguimiento.IdAccionesMejora = seguimientoViewModel.IdAccionesMejora;
                seguimiento.ListaSeguimiento = listaSeguimiento;

                this.negocioSeguimiento.Crear(seguimiento);
                TempData["MensajeCrearModulos"] = Recursos.Lenguaje.MensajeRegistroModificado;
                return RedirectToAction("Consultar", "AccionesMejora", new { idSolucion = seguimientoViewModel.IdSolucion });

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar", "AccionesMejora", new { idSolucion = seguimientoViewModel.IdSolucion });
            }
        }

        public IEnumerable<AccionesMejora> VerificarBusquedaYPaginadorAcciones(
            Guid idSolucion,
            string terminoBusqueda,
            string filtroActual)
        {
            string parametroBusqueda = terminoBusqueda;

            ViewBag.filtroActualProyecto = parametroBusqueda;


            IEnumerable<AccionesMejora> accionesMejoras;
            if (string.IsNullOrEmpty(parametroBusqueda))
            {
                accionesMejoras = this.negocioAccionMejora.ConsultarPorSolucion(
                   idSolucion,
                   this.ObtenerLenguaje);
            }
            else
            {
                accionesMejoras = this.negocioAccionMejora.ConsultarPorSolucionParametroBusqueda(
                           idSolucion,
                           parametroBusqueda,
                           this.ObtenerLenguaje);
            }

            return accionesMejoras;
        }
    }
}

