namespace Varo.Web.Controllers
{
    using Varo.Consultorias.Entidades;
    using Varo.Consultorias.Negocio;
    using Varo.Maestros.Entidades;
    using Varo.Maestros.Negocio;
    using Varo.Transversales.Constantes;
    using Varo.Transversales.Entidades;
    using Varo.Transversales.Excepciones;
    using Varo.Web.Comun;
    using Varo.Web.Helpers;
    using Varo.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    [SwitchableAuthorization]
    public class ConsultoriaController : BaseController
    {
        private readonly INegocioConsultoria negocioConsultoria;
        private readonly INegocioTecnologiaConsultoria negocioTecnologiaConsultoria;
        private readonly INegocioTecnologia negocioTecnologia;
        private readonly INegocioLocalizacion negocioLocalizacion;
        private readonly INegocioUsuarios negocioUsuarios;
        private readonly INegocioClientes negocioClientes;

        public ConsultoriaController()
        {
            this.negocioConsultoria = new NegocioConsultoria();
            this.negocioTecnologiaConsultoria = new NegocioTecnologiaConsultoria();
            this.negocioTecnologia = new NegocioTecnologia();
            this.negocioLocalizacion = new NegocioLocalizacion();
            this.negocioUsuarios = new NegocioUsuarios();
            this.negocioClientes = new NegocioClientes();
        }

        [HttpGet]
        public ActionResult Consultar(
            int? numeroPaginaActual,
            string terminoBusqueda,
            string filtroActual,
            string checkEnEjecucion,
            string enEjecucion)
        {
            PaginadorViewModel<IEnumerable<ConsultoriaInformacionBasicaViewModel>> consultoriaViewModel =
                new PaginadorViewModel<IEnumerable<ConsultoriaInformacionBasicaViewModel>>();

            try
            {
                IEnumerable<ConsultoriaInformacionBasica> consultoria = this.VerificarBusquedaYPaginador
                   (numeroPaginaActual, terminoBusqueda, filtroActual, consultoriaViewModel, checkEnEjecucion
                   , enEjecucion);

                consultoriaViewModel.EntidadViewModel = this.ConvertirConsultoriasAConsultoriasViewModel(consultoria);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Consultoria", consultoriaViewModel);
                }

                return View(consultoriaViewModel);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(consultoriaViewModel);
        }

        [HttpGet]
        public ActionResult Editar(Guid id, string vista)
        {
            string nombreVista = vista;

            ConsultoriaViewModel consultoriaViewModel = new ConsultoriaViewModel();
            List<TecnologiasViewModel> listaTecnologiasViewModel = new List<TecnologiasViewModel>();
            IEnumerable<SelectListItem> listaTiposDeTecnologia = this.negocioConsultoria.ConsultarPorMaestro(TiposMaestro.TiposDeTecnologia, this.ObtenerLenguaje).ToRequiredSelectListItem();

            try
            {
                consultoriaViewModel = this.ObtenerConsultoria(id);

                consultoriaViewModel.TecnologiasViewModel = new TecnologiasViewModel
                {
                    ListaTiposDeTecnologia = listaTiposDeTecnologia,
                    ListaTecnologias = new List<SelectListItem>()
                };

                IList<Tecnologia> listaTecnologia = this.negocioTecnologiaConsultoria.ConsultarPorIdConsultoria(id);

                foreach (var itemTecnologia in listaTecnologia)
                {
                    TecnologiasViewModel tecnologiasViewModel = new TecnologiasViewModel();
                    tecnologiasViewModel.TipoTecnologia.Id = itemTecnologia.TipoTecnologia.Id;
                    tecnologiasViewModel.TipoTecnologia.Nombre = itemTecnologia.TipoTecnologia.Nombre;
                    tecnologiasViewModel.Tecnologia.Id = itemTecnologia.Id;
                    tecnologiasViewModel.Tecnologia.Nombre = itemTecnologia.Nombre;

                    tecnologiasViewModel.ListaTiposDeTecnologia = consultoriaViewModel.TecnologiasViewModel.ListaTiposDeTecnologia;
                    tecnologiasViewModel.ListaTecnologias = Comun.ConvertirListaTecnologiaEnSelectListItem(
                            this.negocioTecnologia.ConsultarPorTipoDeTecnologia(itemTecnologia.TipoTecnologia.Id));

                    listaTecnologiasViewModel.Add(tecnologiasViewModel);
                }

                consultoriaViewModel.TecnologiasViewModel.ListaTecnologiasViewModel = listaTecnologiasViewModel;

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            if (nombreVista == null || nombreVista == string.Empty)
            {
                nombreVista = "_FormularioCreacionEdicion";
            }


            consultoriaViewModel.Vista = nombreVista;

            if (nombreVista.Equals("_VistaPrevia"))
            {
                if (string.IsNullOrEmpty(consultoriaViewModel.NombreGerente))
                {
                    consultoriaViewModel.NombreGerente = consultoriaViewModel.UsuarioRedGerente;
                }

                if (string.IsNullOrEmpty(consultoriaViewModel.NombreConsultor))
                {
                    consultoriaViewModel.NombreConsultor = consultoriaViewModel.UsuarioRedConsultor;
                }

                return PartialView(consultoriaViewModel);
            }
            else
            {
                TempData["NuevaEdicion"] = "Edicion";
                return View(consultoriaViewModel);
            }

        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Editar(ConsultoriaViewModel consultoriaViewModel, FormCollection form)
        {
            Consultoria consultoria;
            TecnologiaConsultoria tecnologiaPorConsultoria;

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(consultoriaViewModel);
                }

                consultoria = this.EstablecerConsultoria(consultoriaViewModel);
                tecnologiaPorConsultoria = this.ObtenerTecnologias();

                if (consultoriaViewModel != null)
                {
                    consultoria.Id = consultoriaViewModel.Id;
                }

                tecnologiaPorConsultoria.IdConsultoria = consultoria.Id;
                this.negocioConsultoria.Editar(consultoria, tecnologiaPorConsultoria);

                TempData["agregadaModificada"] = Recursos.Lenguaje.MensajeConsultoriaModificada;

                return RedirectToAction("Consultar");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        [HttpGet]
        public ActionResult Crear()
        {
            ConsultoriaViewModel consultoriaViewModel = new ConsultoriaViewModel();
            TecnologiasViewModel tecnologiasViewModel = new TecnologiasViewModel();
            consultoriaViewModel.TecnologiasViewModel = tecnologiasViewModel;

            try
            {

                consultoriaViewModel.RolConsultor = string.Empty;
                consultoriaViewModel.ListaLineaConsultoria =
                    this.negocioConsultoria.ConsultarPorMaestro(TiposMaestro.LineasConsultoria, this.ObtenerLenguaje).ToRequiredSelectListItem();
                consultoriaViewModel.ListaLineaNegocio =
                    this.negocioConsultoria.ConsultarPorMaestro(TiposMaestro.LineasNegocio, this.ObtenerLenguaje).ToRequiredSelectListItem();
                consultoriaViewModel.ListaOficinas = new List<SelectListItem>();
                consultoriaViewModel.ListaEstados =
                    this.negocioConsultoria.ConsultarPorMaestro(TiposMaestro.EstadosConsultoria, this.ObtenerLenguaje).ToRequiredSelectListItem();
                consultoriaViewModel.ListaPais =
                    this.negocioLocalizacion.ConsultarPaises().ToRequiredSelectListItemPais();
                consultoriaViewModel.ListaCliente = Comun.ConvertirListaClienteEnSelectListItem(this.negocioClientes.ConsultarClientes());
                consultoriaViewModel.ListaGsdc =
                    this.negocioConsultoria.ConsultarPorMaestro(TiposMaestro.Gsdc, this.ObtenerLenguaje).ToRequiredSelectListItem();
                consultoriaViewModel.ListaUsoComercial =
                    this.negocioConsultoria.ConsultarPorMaestro(TiposMaestro.UsosComerciales, this.ObtenerLenguaje).ToRequiredSelectListItem();
                consultoriaViewModel.TecnologiasViewModel.ListaTiposDeTecnologia =
                    this.negocioConsultoria.ConsultarPorMaestro(TiposMaestro.TiposDeTecnologia, this.ObtenerLenguaje).ToRequiredSelectListItem();
                consultoriaViewModel.TecnologiasViewModel.ListaTecnologias = new List<SelectListItem>();
                consultoriaViewModel.FechaCreacion = DateTime.Now;
                consultoriaViewModel.FechaCierre = null;

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            TempData["NuevaEdicion"] = "Nueva";
            return View(consultoriaViewModel);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Crear(ConsultoriaViewModel consultoriaViewModel, FormCollection form)
        {
            Consultoria consultoria;
            TecnologiaConsultoria tecnologiaPorConsultoria;

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(consultoriaViewModel);
                }

                consultoria = this.EstablecerConsultoria(consultoriaViewModel);
                tecnologiaPorConsultoria = this.ObtenerTecnologias();

                this.negocioConsultoria.Crear(consultoria, tecnologiaPorConsultoria);

                TempData["agregadaModificada"] = Recursos.Lenguaje.MensajeConsultoriaCreada;

                return RedirectToAction("Consultar");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        [HttpGet]
        public ActionResult Eliminar(Guid id)
        {
            try
            {
                this.negocioConsultoria.Eliminar(id);
            }
            catch (SqlException ex)
            {
                if (ex.Errors.Count > 0)
                {
                    if (ex.Errors[0].Number == 547)
                    {
                        this.CapturarExcepcion(new NegocioExcepcion(Recursos.Lenguaje.MensajeErrorEliminarConsultoria));
                    }
                }
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, message = Recursos.Lenguaje.MensajeConsultoriaEliminada }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Eliminar(Consultoria consultoria)
        {
            try
            {
                if (consultoria != null)
                {
                    this.negocioConsultoria.Eliminar(consultoria.Id);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        private ConsultoriaViewModel ObtenerConsultoria(Guid id)
        {
            ConsultoriaViewModel consultoriaViewModel = new ConsultoriaViewModel();

            Consultoria consultoria = this.negocioConsultoria.Obtener(id);

            consultoriaViewModel.Id = consultoria.Id;
            consultoriaViewModel.NombreProyecto = consultoria.Nombre;

            consultoriaViewModel.UsuarioRedGerente = consultoria.UsuarioRedGerente;

            if (consultoria != null && consultoria.UsuarioRedGerente != null)
            {
                Usuario usuarioGerente = this.negocioUsuarios.ObtenerInformacionUsuario(consultoria.UsuarioRedGerente);
                consultoriaViewModel.NombreGerente = usuarioGerente.DisplayName;
                consultoriaViewModel.RolGerente = usuarioGerente.JobTitle;
            }

            consultoriaViewModel.UsuarioRedConsultor = consultoria.UsuarioRedConsultor;

            if (consultoria != null && consultoria.UsuarioRedConsultor != null)
            {
                Usuario usuarioConsultor = this.negocioUsuarios.ObtenerInformacionUsuario(consultoria.UsuarioRedConsultor);
                consultoriaViewModel.NombreConsultor = usuarioConsultor.DisplayName;
                consultoriaViewModel.RolConsultor = usuarioConsultor.JobTitle;
            }

            consultoriaViewModel.Observacion = consultoria.Observacion;
            consultoriaViewModel.Descripcion = consultoria.Descripcion;
            consultoriaViewModel.UrlDocumentacion = consultoria.UrlDocumentacion;
            consultoriaViewModel.UrlDiseno = consultoria.UrlDiseno ?? TransversalesConstantes.CadenaVacia;
            consultoriaViewModel.UrlGestionTareas = consultoria.UrlGestionTareas;
            consultoriaViewModel.UrlGestionIncidentes = consultoria.UrlGestionIncidentes;
            consultoriaViewModel.UrlGestionAseguramientoCalidad = consultoria.UrlGestionAseguramientoCalidad;
            consultoriaViewModel.UrlLeccionesAprendidas = consultoria.UrlLeccionesAprendidas;
            consultoriaViewModel.UrlOportunidadCrm = consultoria.UrlOportunidadCrm ?? TransversalesConstantes.CadenaVacia;
            consultoriaViewModel.UrlProyectoPsa = consultoria.UrlProyectoPsa ?? TransversalesConstantes.CadenaVacia;
            consultoriaViewModel.NombreContactoCliente = consultoria.NombreContactoCliente;
            consultoriaViewModel.TelefonoContactoCliente = consultoria.TelefonoContactoCliente;
            consultoriaViewModel.CorreoContactoCliente = consultoria.CorreoContactoCliente;
            consultoriaViewModel.LineaConsultoria = CambiarIdiomaPorItemMaestro(consultoria.LineaConsultoria, TiposMaestro.LineasConsultoria);
            consultoriaViewModel.LineaNegocio = CambiarIdiomaPorItemMaestro(consultoria.LineaNegocio, TiposMaestro.LineasNegocio);
            consultoriaViewModel.Etiqueta = consultoria.Etiqueta;
            consultoriaViewModel.Estado = CambiarIdiomaPorItemMaestro(consultoria.Estado, TiposMaestro.EstadosConsultoria);
            consultoriaViewModel.Oficina = consultoria.Oficina;
            consultoriaViewModel.Cliente = consultoria.Cliente;
            consultoriaViewModel.Pais = consultoria.Pais;
            consultoriaViewModel.ListaCliente = Comun.ConvertirListaClienteEnSelectListItem(this.negocioClientes.ConsultarClientes());
            consultoriaViewModel.ListaPais = this.negocioLocalizacion.ConsultarPaises().ToRequiredSelectListItemPais();
            if (!string.IsNullOrEmpty(consultoria.UsoComercial.Nombre))
            {
                consultoriaViewModel.UsoComercial = CambiarIdiomaPorItemMaestro(consultoria.UsoComercial, TiposMaestro.UsosComerciales);
            }
            if (!string.IsNullOrEmpty(consultoria.Gsdc.Nombre))
            {
                consultoriaViewModel.Gsdc = CambiarIdiomaPorItemMaestro(consultoria.Gsdc, TiposMaestro.Gsdc);
            }

            consultoriaViewModel.ListaLineaConsultoria =
                this.negocioConsultoria.ConsultarPorMaestro(TiposMaestro.LineasConsultoria, this.ObtenerLenguaje).ToRequiredSelectListItem();
            consultoriaViewModel.ListaLineaNegocio =
                this.negocioConsultoria.ConsultarPorMaestro(TiposMaestro.LineasNegocio, this.ObtenerLenguaje).ToRequiredSelectListItem();
            consultoriaViewModel.ListaEstados =
                this.negocioConsultoria.ConsultarPorMaestro(TiposMaestro.EstadosConsultoria, this.ObtenerLenguaje).ToRequiredSelectListItem();
            consultoriaViewModel.ListaOficinas =
                this.negocioConsultoria.ConsultarPorMaestro(TiposMaestro.Oficinas, this.ObtenerLenguaje).ToRequiredSelectListItem();
            consultoriaViewModel.ListaUsoComercial =
                this.negocioConsultoria.ConsultarPorMaestro(TiposMaestro.UsosComerciales, this.ObtenerLenguaje).ToRequiredSelectListItem();
            consultoriaViewModel.ListaGsdc =
                this.negocioConsultoria.ConsultarPorMaestro(TiposMaestro.Gsdc, this.ObtenerLenguaje).ToRequiredSelectListItem();
            consultoriaViewModel.FechaCreacion = consultoria.FechaCreacion;
            consultoriaViewModel.FechaCierre = consultoria.FechaCierre == default(DateTime) ? null : consultoria.FechaCierre;
            consultoriaViewModel.ObjetivoNegocio = consultoria.ObjetivoNegocio;

            return consultoriaViewModel;
        }

        private Consultoria EstablecerConsultoria(ConsultoriaViewModel consultoriaViewModel)
        {
            Consultoria consultoria = new Consultoria();
            consultoria.Etiqueta = consultoriaViewModel.Etiqueta;
            consultoria.Nombre = consultoriaViewModel.NombreProyecto;
            consultoria.UsuarioRedGerente = consultoriaViewModel.UsuarioRedGerente;
            consultoria.UsuarioRedConsultor = consultoriaViewModel.UsuarioRedConsultor;
            consultoria.Observacion = consultoriaViewModel.Observacion;
            consultoria.Descripcion = consultoriaViewModel.Descripcion;
            consultoria.UrlDocumentacion = consultoriaViewModel.UrlDocumentacion;
            consultoria.UrlDiseno = consultoriaViewModel.UrlDiseno ?? TransversalesConstantes.CadenaVacia;
            consultoria.UrlGestionTareas = consultoriaViewModel.UrlGestionTareas;
            consultoria.UrlGestionIncidentes = consultoriaViewModel.UrlGestionIncidentes;
            consultoria.UrlGestionAseguramientoCalidad = consultoriaViewModel.UrlGestionAseguramientoCalidad;
            consultoria.UrlLeccionesAprendidas = consultoriaViewModel.UrlLeccionesAprendidas;
            consultoria.UrlOportunidadCrm = consultoriaViewModel.UrlOportunidadCrm ?? TransversalesConstantes.CadenaVacia;
            consultoria.UrlProyectoPsa = consultoriaViewModel.UrlProyectoPsa ?? TransversalesConstantes.CadenaVacia;
            consultoria.FechaCreacion = consultoriaViewModel.FechaCreacion;
            consultoria.FechaCierre = consultoriaViewModel.FechaCierre;
            consultoria.NombreContactoCliente = consultoriaViewModel.NombreContactoCliente;
            consultoria.TelefonoContactoCliente = consultoriaViewModel.TelefonoContactoCliente;
            consultoria.CorreoContactoCliente = consultoriaViewModel.CorreoContactoCliente;
            consultoria.LineaConsultoria.Id = Convert.ToByte(consultoriaViewModel.LineaConsultoria.Id, CultureInfo.CurrentCulture);
            consultoria.LineaNegocio.Id = Convert.ToByte(consultoriaViewModel.LineaNegocio.Id, CultureInfo.CurrentCulture);
            consultoria.Estado.Id = consultoriaViewModel.Estado.Id;
            consultoria.Oficina.Id = consultoriaViewModel.Oficina.Id;
            consultoria.Cliente.Id = consultoriaViewModel.Cliente.Id;
            consultoria.Pais.Id = consultoriaViewModel.Pais.Id;
            consultoria.UsuarioRedLogueado = User.Identity.Name.Contains("@") ?
                User.Identity.Name.Substring(0, User.Identity.Name.IndexOf("@")) :
                User.Identity.Name;
            consultoria.UsoComercial.Id = Convert.ToByte(consultoriaViewModel.UsoComercial.Id, CultureInfo.CurrentCulture);
            consultoria.ObjetivoNegocio = consultoriaViewModel.ObjetivoNegocio;
            return consultoria;
        }

        private TecnologiaConsultoria ObtenerTecnologias()
        {
            TecnologiaConsultoria tecnologiasPorConsultoria = new TecnologiaConsultoria();
            tecnologiasPorConsultoria.Tecnologias = new List<Tecnologia>();
            Tecnologia itemTecnologia;

            string tecnologiaSeleccionadas = Request.Form["itemIdTecnologia"];
            if (!string.IsNullOrEmpty(tecnologiaSeleccionadas))
            {
                string[] arrayTecnologiaSeleccionadas = tecnologiaSeleccionadas.Split(',');

                for (int i = 0; i < arrayTecnologiaSeleccionadas.Length; i++)
                {
                    itemTecnologia = new Tecnologia();
                    itemTecnologia.Id = Guid.Parse(arrayTecnologiaSeleccionadas[i]);

                    tecnologiasPorConsultoria.Tecnologias.Add(itemTecnologia);
                }
            }

            return tecnologiasPorConsultoria;
        }

        private IEnumerable<ConsultoriaInformacionBasicaViewModel> ConvertirConsultoriasAConsultoriasViewModel(IEnumerable<ConsultoriaInformacionBasica> consultorias)
        {

            IEnumerable<ConsultoriaInformacionBasicaViewModel> consultoriaViewModel =
                from consultoria in consultorias
                select new ConsultoriaInformacionBasicaViewModel
                {
                    Id = consultoria.Id,
                    NombreProyecto = consultoria.Nombre,
                    NombreCliente = consultoria.Cliente.Name,
                    NombreGerente = consultoria.NombreGerente,
                    NombreResponsable = consultoria.NombreConsultor,
                    UrlDocumentacion = consultoria.UrlDocumentacion,
                    UrlGestionAseguramientoCalidad = consultoria.UrlGestionAseguramientoCalidad,
                    UrlLeccionesAprendidas = consultoria.UrlLeccionesAprendidas,
                    NombreLineaConsultoria = CambiarIdiomaPorNombre(consultoria.LineaConsultoria, TiposMaestro.LineasConsultoria),
                    NombreEstado = CambiarIdiomaPorNombre(consultoria.Estado, TiposMaestro.EstadosSolucion)

                };

            return consultoriaViewModel;
        }
    }
}

