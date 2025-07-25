//// --------------------------------------------------------------------------------
//// <copyright file="SolucionController.cs">Company S.A.</copyright>
//// <author>Nelson Apraez</author>
//// <email>developer@company.com</email>
//// <date>09/09/2018</date>
//// <summary>Proporciona funcionalidades para visualizar, crear, eliminar y editar las soluciones</summary>
//// --------------------------------------------------------------------------------

namespace Varo.Web.Controllers
{
    using Varo.Consultorias.Entidades;
    using Varo.Consultorias.Negocio;
    using Varo.Maestros.Entidades;
    using Varo.Maestros.Negocio;
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Negocio;
    using Varo.Transversales;
    using Varo.Transversales.Constantes;
    using Varo.Transversales.Entidades;
    using Varo.Transversales.Excepciones;
    using Varo.Web.Helpers;
    using Varo.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    /// <summary>
    /// Proporciona funcionalidades para visualizar, crear, eliminar y editar las soluciones.
    /// </summary>
    /// 
    [SwitchableAuthorization]
    public class SolucionController : BaseController
    {
        private readonly INegocioSoluciones negocioSoluciones;
        private readonly INegocioIntegracionContinua negocioIntegracionContinua;
        private readonly INegocioInspeccionContinua negocioInspeccionContinua;
        private readonly INegocioDespliegueContinuo negocioDespliegueContinuo;
        private readonly INegocioMonitoreoContinuo negocioMonitoreoContinuo;
        private readonly INegocioTecnologia negocioTecnologia;
        private readonly INegocioTecnologiaSolucion negocioTecnologiaSolucion;
        private readonly INegocioPracticaCalidad negocioPracticaCalidad;
        private readonly INegocioLocalizacion negocioLocalizacion;
        private readonly INegocioUsuarios negocioUsuarios;
        private readonly INegocioClientes negocioClientes;
        private readonly INegocioConsultoria negocioConsultoria;
        private readonly INegocioTecnologiaConsultoria negocioTecnologiaConsultoria;
        private readonly INegocioMetricaSistemica negocioMetricaSistemica;
        private readonly Soluciones.Negocio.INegocioAuditoria negocioAuditoria;

        public SolucionController()
        {
            this.negocioSoluciones = new NegocioSoluciones();
            this.negocioIntegracionContinua = new NegocioIntegracionContinua();
            this.negocioInspeccionContinua = new NegocioInspeccionContinua();
            this.negocioDespliegueContinuo = new NegocioDespliegueContinuo();
            this.negocioMonitoreoContinuo = new NegocioMonitoreoContinuo();
            this.negocioTecnologia = new NegocioTecnologia();
            this.negocioTecnologiaSolucion = new NegocioTecnologiaSolucion();
            this.negocioPracticaCalidad = new NegocioPracticaCalidad();
            this.negocioAuditoria = new Soluciones.Negocio.NegocioAuditoria();
            this.negocioLocalizacion = new NegocioLocalizacion();
            this.negocioUsuarios = new NegocioUsuarios();
            this.negocioClientes = new NegocioClientes();
            this.negocioConsultoria = new NegocioConsultoria();
            this.negocioTecnologiaConsultoria = new NegocioTecnologiaConsultoria();
            this.negocioMetricaSistemica = new NegocioMetricaSistemica();
        }

        /// <summary>
        /// Accion usada para consultar las soluciones almacenadas, tambien se pueden consultar por un filtro si es enviado
        /// </summary>
        /// <param name="numeroPaginaActual">Numero de la pagina actual en la que se encuentre</param>
        /// <param name="terminoBusqueda">Representa el valor incial por el cual se realiza el filtro de busqueda</param>
        /// <param name="filtroActual">En este parametro se almacena el filtro de busqueda para que no se pierda en la paginacion</param>
        /// <returns>Una solucion view model con las soluciones encontradas</returns>
        [HttpGet]
        public ActionResult Consultar(
            int? numeroPaginaActual,
            string terminoBusqueda,
            string filtroActual,
            string checkEnEjecucion,
            string enEjecucion)
        {
            PaginadorViewModel<IEnumerable<SolucionesInformacionBasicaViewModel>> solucionesViewModel =
                new PaginadorViewModel<IEnumerable<SolucionesInformacionBasicaViewModel>>();

            try
            {
                IEnumerable<SolucionInformacionBasica> soluciones = VerificarBusquedaYPaginador(numeroPaginaActual, terminoBusqueda,
                   filtroActual, solucionesViewModel, checkEnEjecucion, enEjecucion);

                solucionesViewModel.EntidadViewModel = this.ConvertirSolucionesASolucionesViewModel(soluciones);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Soluciones", solucionesViewModel);
                }

                return View(solucionesViewModel);
            }
            catch (SolicitudAPIExcepcion)
            {
                return View("Error");
            }
            catch (JsonVacioExcepcion)
            {
                return View("Error");
            }
            catch (WebException ex)
            {
                return View("Error");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(solucionesViewModel);
        }


        /// <summary>
        /// Accion para obtener una solucion por su identificador
        /// </summary>
        /// <param name="id">Indentificador de la solucion para buscar</param>
        /// <returns>Retorna una solucion view model</returns>
        [HttpGet]
        public ActionResult ObtenerPorId(Guid id)
        {
            SolucionesViewModel solucionViewModel;
            try
            {
                solucionViewModel = this.ObtenerSolucion(id);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, solucionViewModel }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Accion para cargar los datos basicos para la creacion la solucion en la base de datos
        /// </summary>
        /// <returns>Una solucion vew model con los datos basicos cargados, o sea los maestros</returns>
        [HttpGet]
        public ActionResult Crear()
        {
            SolucionesViewModel solucionViewModel = new SolucionesViewModel();
            TecnologiasViewModel tecnologiasViewModel = new TecnologiasViewModel();
            solucionViewModel.TecnologiasViewModel = tecnologiasViewModel;
            solucionViewModel.MonitoreosContinuos = new MonitoreosContinuos();
            solucionViewModel.DesplieguesContinuos = new DesplieguesContinuos();
            solucionViewModel.ListaConsultoria = this.ConvertirListaConsultoriaEnSelectListItem(this.negocioConsultoria.Listar());

            try
            {
                solucionViewModel.RolGerente = "";
                solucionViewModel.RolResponsable = "";
                solucionViewModel.RolScrumMaster = "";
                solucionViewModel.ListaTipo =
                    this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.TiposDeSolucion, this.ObtenerLenguaje).ToRequiredSelectListItem();
                solucionViewModel.ListaLineaSolucion =
                    this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.LineaSolucion, this.ObtenerLenguaje).ToRequiredSelectListItem();
                solucionViewModel.ListaLineaNegocio =
                    this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.LineasNegocio, this.ObtenerLenguaje).ToRequiredSelectListItem();
                solucionViewModel.ListaGsdc =
                    this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.Gsdc, this.ObtenerLenguaje).ToRequiredSelectListItem();
                solucionViewModel.ListaUsoComercial =
                    this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.UsosComerciales, this.ObtenerLenguaje).ToRequiredSelectListItem();
                solucionViewModel.ListaEstados =
                    this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.EstadosSolucion, this.ObtenerLenguaje).ToRequiredSelectListItem();
                solucionViewModel.ListaMarcosTrabajo =
                    this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.MarcosDeTrabajo, this.ObtenerLenguaje).ToRequiredSelectListItem();
                solucionViewModel.ListaPais =
                    this.negocioLocalizacion.ConsultarPaises().ToRequiredSelectListItemPais();
                solucionViewModel.ListaOficinas = new List<SelectListItem>();
                solucionViewModel.ListaCliente = ConvertirListaClienteEnSelectListItem(this.negocioClientes.ConsultarClientes());
                solucionViewModel.TecnologiasViewModel.ListaTiposDeTecnologia =
                    this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.TiposDeTecnologia, this.ObtenerLenguaje).ToRequiredSelectListItem();
                solucionViewModel.TecnologiasViewModel.ListaTecnologias = new List<SelectListItem>();

                solucionViewModel.MonitoreosContinuos.ListaMonitoreosContinuos = new List<MonitoreosContinuos>();
                solucionViewModel.DesplieguesContinuos.ListaDeplieguesContinuos = new List<DesplieguesContinuos>();

                solucionViewModel.ListaInspeccionContinua = ConvertirListaInspeccionEnSelectListItem(this.negocioInspeccionContinua.Consultar());
                solucionViewModel.FechaCreacion = DateTime.Now;
                solucionViewModel.FechaCierre = null;

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            TempData["NuevaEdicion"] = "Nueva";
            return View(solucionViewModel);
        }

        /// <summary>
        /// Accion para capturar y almacenar la informacion ingresada para crear la solucion
        /// </summary>
        /// <param name="solucionViewModel">Informacion de la solucion ingresada</param>
        /// <param name="form">Toda la informacion del formulario ingresado, especialmente usado para capturar la informacion de las tablas</param>
        /// <returns>Retorna a la vista de crear solucion para indicar si fue creada la solucion</returns>
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Crear(SolucionesViewModel solucionViewModel, FormCollection form)
        {
            Solucion solucion;
            TecnologiaSolucion tecnologia;
            DesplieguesContinuos despliegueContinuo;
            MonitoreosContinuos monitoreoContinuo;
            IntegracionesContinuas integracionContinua;
            PracticasCalidad practicasCalidad;

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(solucionViewModel);
                }
                solucion = this.EstablecerSolucion(solucionViewModel);
                practicasCalidad = this.ObtenerPracticasCalidad(solucionViewModel);
                tecnologia = this.ObtenerTecnologias();
                despliegueContinuo = this.ObtenerDesplieguesContinuos();
                monitoreoContinuo = this.ObtenerMonitoreoContinuo();
                integracionContinua = this.ObtenerIntegracionesContinuas();

                this.negocioSoluciones.Crear(solucion, tecnologia, despliegueContinuo, monitoreoContinuo, integracionContinua, practicasCalidad);

                TempData["agregadaModificada"] = Recursos.Lenguaje.MensajeSolucionCreada;

                return RedirectToAction("Consultar");

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vista"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Editar(Guid id, string vista)
        {
            string nombreVista = vista;

            SolucionesViewModel solucionViewModel = new SolucionesViewModel();
            List<TecnologiasViewModel> listaTecnologiasViewModel = new List<TecnologiasViewModel>();
            IEnumerable<SelectListItem> listaTiposDeTecnologia = this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.TiposDeTecnologia, this.ObtenerLenguaje).ToRequiredSelectListItem();

            try
            {
                solucionViewModel = this.ObtenerSolucion(id);

                solucionViewModel.TecnologiasViewModel = new TecnologiasViewModel
                {
                    ListaTiposDeTecnologia = listaTiposDeTecnologia,
                    ListaTecnologias = new List<SelectListItem>()
                };

                IList<TecnologiaSolucion> listaTecnologia = this.negocioTecnologiaSolucion.ConsultarPorIdSolucion(id, this.ObtenerLenguaje);

                foreach (var itemTecnologia in listaTecnologia)
                {
                    TecnologiasViewModel tecnologiasViewModel = new TecnologiasViewModel();
                    tecnologiasViewModel.TipoTecnologia.Id = itemTecnologia.TipoTecnologia.Id;
                    tecnologiasViewModel.TipoTecnologia.Nombre = itemTecnologia.TipoTecnologia.Nombre;
                    tecnologiasViewModel.Tecnologia.Id = itemTecnologia.Id;
                    tecnologiasViewModel.Tecnologia.Nombre = itemTecnologia.Nombre;

                    tecnologiasViewModel.ListaTiposDeTecnologia = solucionViewModel.TecnologiasViewModel.ListaTiposDeTecnologia;
                    tecnologiasViewModel.ListaTecnologias =
                        ConvertirListaTecnologiaEnSelectListItem(
                            this.negocioTecnologia.ConsultarPorTipoDeTecnologia(itemTecnologia.TipoTecnologia.Id));

                    listaTecnologiasViewModel.Add(tecnologiasViewModel);
                }

                solucionViewModel.TecnologiasViewModel.ListaTecnologiasViewModel = listaTecnologiasViewModel;

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            if (nombreVista == null || nombreVista == string.Empty)
            {
                nombreVista = "_FormularioCreacionEdicion";
            }


            solucionViewModel.Vista = nombreVista;

            if (nombreVista.Equals("_VistaPrevia"))
            {
                if (string.IsNullOrEmpty(solucionViewModel.NombreGerente))
                {
                    solucionViewModel.NombreGerente = solucionViewModel.UsuarioRedGerente;
                }

                if (string.IsNullOrEmpty(solucionViewModel.NombreResponsable))
                {
                    solucionViewModel.NombreResponsable = solucionViewModel.UsuarioRedResponsable;
                }

                if (string.IsNullOrEmpty(solucionViewModel.NombreScrumMaster))
                {
                    solucionViewModel.NombreScrumMaster = solucionViewModel.UsuarioRedScrumMaster;
                }

                return PartialView(solucionViewModel);
            }
            else
            {
                TempData["NuevaEdicion"] = "Edicion";
                return View(solucionViewModel);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solucionViewModel"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Editar(SolucionesViewModel solucionViewModel, FormCollection form)
        {
            Solucion solucion;
            TecnologiaSolucion tecnologia;
            DesplieguesContinuos despliegueContinuo;
            MonitoreosContinuos monitoreoContinuo;
            IntegracionesContinuas integracionContinua;
            PracticasCalidad practicasCalidad;

            try
            {

                if (!ModelState.IsValid)
                {
                    return View(solucionViewModel);
                }

                solucion = this.EstablecerSolucion(solucionViewModel);
                practicasCalidad = this.ObtenerPracticasCalidad(solucionViewModel);
                tecnologia = this.ObtenerTecnologias();
                despliegueContinuo = this.ObtenerDesplieguesContinuos();
                monitoreoContinuo = this.ObtenerMonitoreoContinuo();
                integracionContinua = this.ObtenerIntegracionesContinuas();

                if (solucionViewModel != null)
                {
                    solucion.Id = solucionViewModel.Id;
                }

                this.negocioSoluciones.Editar(solucion, tecnologia, despliegueContinuo, monitoreoContinuo, integracionContinua, practicasCalidad);

                TempData["agregadaModificada"] = Recursos.Lenguaje.MensajeSolucionModificada;

                return RedirectToAction("Consultar");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Eliminar(Guid id)
        {
            try
            {
                this.negocioSoluciones.Eliminar(id);
            }
            catch (SqlException ex)
            {
                if (ex.Errors.Count > 0)
                {
                    if (ex.Errors[0].Number == 547)
                    {
                        this.CapturarExcepcion(new NegocioExcepcion(Recursos.Lenguaje.MensajeErrorEliminarSolucion));
                    }
                }
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, message = Recursos.Lenguaje.MensajeSolucionEliminada }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solucion"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Eliminar(Solucion solucion)
        {
            try
            {
                if (solucion != null)
                {
                    this.negocioSoluciones.Eliminar(solucion.Id);
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar");
        }

        [HttpGet]
        public ActionResult Clonar(Guid id, string vista)
        {
            string nombreVista = vista;

            SolucionesViewModel solucionViewModel = new SolucionesViewModel();
            List<TecnologiasViewModel> listaTecnologiasViewModel = new List<TecnologiasViewModel>();
            IEnumerable<SelectListItem> listaTiposDeTecnologia = this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.TiposDeTecnologia, this.ObtenerLenguaje).ToRequiredSelectListItem();

            try
            {
                solucionViewModel = this.ObtenerConsultoria(id);
                solucionViewModel.Id = Guid.NewGuid();
                solucionViewModel.TecnologiasViewModel = new TecnologiasViewModel();
                solucionViewModel.TecnologiasViewModel.ListaTiposDeTecnologia = listaTiposDeTecnologia;
                solucionViewModel.TecnologiasViewModel.ListaTecnologias = new List<SelectListItem>();

                IList<Tecnologia> listaTecnologia = this.negocioTecnologiaConsultoria.ConsultarPorIdConsultoria(id);

                foreach (var itemTecnologia in listaTecnologia)
                {
                    TecnologiasViewModel tecnologiasViewModel = new TecnologiasViewModel();
                    tecnologiasViewModel.TipoTecnologia.Id = itemTecnologia.TipoTecnologia.Id;
                    tecnologiasViewModel.TipoTecnologia.Nombre = itemTecnologia.TipoTecnologia.Nombre;
                    tecnologiasViewModel.Tecnologia.Id = itemTecnologia.Id;
                    tecnologiasViewModel.Tecnologia.Nombre = itemTecnologia.Nombre;

                    tecnologiasViewModel.ListaTiposDeTecnologia = solucionViewModel.TecnologiasViewModel.ListaTiposDeTecnologia;
                    tecnologiasViewModel.ListaTecnologias =
                        ConvertirListaTecnologiaEnSelectListItem(
                            this.negocioTecnologia.ConsultarPorTipoDeTecnologia(itemTecnologia.TipoTecnologia.Id));

                    listaTecnologiasViewModel.Add(tecnologiasViewModel);
                }

                solucionViewModel.TecnologiasViewModel.ListaTecnologiasViewModel = listaTecnologiasViewModel;

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            if (nombreVista == null || nombreVista == string.Empty)
            {
                nombreVista = "_FormularioCreacionEdicion";
            }


            solucionViewModel.Vista = nombreVista;

            if (nombreVista.Equals("_VistaPrevia"))
            {
                return PartialView(solucionViewModel);
            }
            else
            {
                TempData["NuevaEdicion"] = "Edicion";
                return View(solucionViewModel);
            }
        }

        /// <summary>
        /// Accion usada para obtener los indicadores de la soluion
        /// </summary>
        /// <param name="idSolucion">Identificador de la solucion</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VerResumen(Guid idSolucion)
        {
            try
            {
                ResumenSolucionViewModel resumenSolucionViewModel = new ResumenSolucionViewModel();

                Solucion solucion = this.negocioSoluciones.Obtener(idSolucion);

                resumenSolucionViewModel.NombreSolucion = solucion.Nombre;
                resumenSolucionViewModel.Cliente = solucion.Cliente.Name;
                resumenSolucionViewModel.LineaSolucion = CambiarIdiomaPorNombre(solucion.LineaSolucion, TiposMaestro.LineaSolucion);
                resumenSolucionViewModel.TipoSolucion = CambiarIdiomaPorNombre(solucion.Tipo, TiposMaestro.TiposDeSolucion);
                resumenSolucionViewModel.Tecnologias = this.negocioTecnologiaSolucion.ConsultarPorIdSolucion(idSolucion, this.ObtenerLenguaje);

                var calificacionAuditoria = this.negocioAuditoria.ObtenerUltimaCalificacion(idSolucion);

                if (calificacionAuditoria.Url != null)
                {
                    resumenSolucionViewModel.UrlAuditoria = calificacionAuditoria.Url;
                    resumenSolucionViewModel.CalificacionAuditoria = calificacionAuditoria.Calificacion.ToString();
                    resumenSolucionViewModel.FechaCalificacionAuditoria = calificacionAuditoria.Fecha;
                }

                CalificacionSeguridad calificacionSeguridad = this.negocioMetricaSistemica.ObtenerUltimaCalificacionSeguridad(idSolucion);

                if (calificacionSeguridad != null)
                {
                    resumenSolucionViewModel.UrlSeguridad = ParametrosGenerales.UrlWebSiteSombreroBlanco;
                    resumenSolucionViewModel.CalificacionSeguridad = calificacionSeguridad.Calificacion.ToString();
                    resumenSolucionViewModel.FechaCalificacionSeguridad = calificacionSeguridad.FechaFinalizacion;
                }


                /*Habilitar cuando se tenga sistema externos de analisis de desempeño

                CalificacionDesempeno calificacionDesempeno = this.negocioMetricaSistemica.ObtenerUltimaCalificacionDesempeño(idSolucion);

                if (calificacionDesempeno != null)
                {

                    resumenSolucionViewModel.UrlDesemepeno = calificacionDesempeno.Url;
                    resumenSolucionViewModel.CalificacionDesemepeno = calificacionDesempeno.Calificacion.ToString();
                    resumenSolucionViewModel.FechaCalificacionDesempeno = calificacionDesempeno.Fecha;
                }

                */

                resumenSolucionViewModel.RutaLogo = ParametrosGenerales.RutaImagenesTecnologia;

                PracticasCalidad practicasCalidad = this.negocioPracticaCalidad.ConsultarPorIdSolucion(solucion.Id);

                ValorMetricaSolucion valorMetrica = this.negocioInspeccionContinua.ConsultarValorMetricaPorSolucion(idSolucion);
                resumenSolucionViewModel.Bugs = valorMetrica.Bugs;
                resumenSolucionViewModel.Cobertura = Math.Round(valorMetrica.Cobertura, 2);
                resumenSolucionViewModel.Lineas = valorMetrica.Lineas.ToString("#,##", CultureInfo.CurrentCulture);
                resumenSolucionViewModel.Vulnerabilidades = valorMetrica.Vulnerabilidades;
                resumenSolucionViewModel.CodeSmell = Math.Round(valorMetrica.CodeSmell, 2);
                resumenSolucionViewModel.CodigoDuplicado = Math.Round(valorMetrica.CodigoDuplicado, 2);
                resumenSolucionViewModel.Hotspots = valorMetrica.Hotspots;

                resumenSolucionViewModel.Estado = CambiarIdiomaPorNombre(solucion.Estado, TiposMaestro.EstadosSolucion);
                resumenSolucionViewModel.Framework = CambiarIdiomaPorNombre(solucion.MarcoTrabajo, TiposMaestro.MarcosDeTrabajo);
                resumenSolucionViewModel.ControlArtefactos = this.ObtenerEstadoControlArtefactos(practicasCalidad.controlDocumentacion, practicasCalidad.controlCodigo);
                resumenSolucionViewModel.GestionBacklog = this.ObtenerEstadoGestionBacklog(practicasCalidad.gestionTareas, practicasCalidad.gestionErrores);
                resumenSolucionViewModel.IntegracionContinua = practicasCalidad.integracionContinua;
                resumenSolucionViewModel.InspeccionContinua = practicasCalidad.inspeccionContinua;
                resumenSolucionViewModel.PruebasUnitariasAutomatizadas = practicasCalidad.pruebasUnitariasAutomatizadas;
                resumenSolucionViewModel.PruebasFuncionalesAutomatizadas = practicasCalidad.pruebasFuncionalesAutomatizadas;
                resumenSolucionViewModel.DespliegueContinuo = practicasCalidad.despliegueContinuo;
                resumenSolucionViewModel.MonitoreoContinuo = practicasCalidad.monitoreoContinuo;
                resumenSolucionViewModel.SeguridadContinua = practicasCalidad.seguridadContinua;
                resumenSolucionViewModel.RendimientoContinuo = practicasCalidad.rendimientoContinuo;
                resumenSolucionViewModel.InfraestructuraComoCodigo = practicasCalidad.infraestructuraComoCodigo;

                this.negocioPracticaCalidad.EstablecerPracticas(practicasCalidad);
                resumenSolucionViewModel.ImagenNivelMadurez = this.negocioPracticaCalidad.ObtenerImagenNivelMadurez();

                return View(resumenSolucionViewModel);

            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }
            return View();
        }

        private IEnumerable<SolucionesInformacionBasicaViewModel> ConvertirSolucionesASolucionesViewModel(IEnumerable<SolucionInformacionBasica> soluciones)
        {

            IEnumerable<SolucionesInformacionBasicaViewModel> solucionesViewModel = from solucion in soluciones
                                                                                    select new SolucionesInformacionBasicaViewModel
                                                                                    {
                                                                                        id = solucion.Id,
                                                                                        nombreProyecto = solucion.Nombre,
                                                                                        nombreCliente = solucion.Cliente.Name,
                                                                                        nombreGerente = solucion.NombreGerente,
                                                                                        nombreResponsable = solucion.NombreResponsable,
                                                                                        nombreScrumMaster = solucion.NombreScrumMaster,
                                                                                        urlRepositorioCodigoFuente = solucion.UrlRepositorioCodigoFuente,
                                                                                        urlDocumentacion = solucion.UrlDocumentacion,
                                                                                        urlInspeccion = solucion.UrlInspeccion,
                                                                                        urlLeccionesAprendidas = solucion.UrlLeccionesAprendidas,
                                                                                        urlGestionAseguramientoCalidad = solucion.UrlGestionAseguramientoCalidad,
                                                                                        nombreLineaSolucion = CambiarIdiomaPorNombre(
                                                                                            solucion.LineaSolucion, TiposMaestro.LineaSolucion),
                                                                                        nombreEstado = CambiarIdiomaPorNombre(solucion.Estado,
                                                                                            TiposMaestro.EstadosSolucion)
                                                                                    };

            return solucionesViewModel;
        }

        private SolucionesViewModel ObtenerSolucion(Guid id)
        {
            SolucionesViewModel solucionViewModel = new SolucionesViewModel();

            Solucion solucion = this.negocioSoluciones.Obtener(id);

            solucionViewModel.ListaConsultoria = this.ConvertirListaConsultoriaEnSelectListItem(this.negocioConsultoria.Listar());
            solucionViewModel.Id = solucion.Id;
            solucionViewModel.NombreProyecto = solucion.Nombre;

            solucionViewModel.UsuarioRedGerente = solucion.UsuarioRedGerente;

            if (solucion != null && solucion.UsuarioRedGerente != null)
            {
                Usuario usuarioGerente = this.negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedGerente);
                solucionViewModel.NombreGerente = usuarioGerente.DisplayName;
                solucionViewModel.RolGerente = usuarioGerente.JobTitle;
            }

            solucionViewModel.UsuarioRedResponsable = solucion.UsuarioRedResponsable;

            if (solucion != null && solucion.UsuarioRedResponsable != null)
            {
                Usuario usuarioResponsable = this.negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedResponsable);
                solucionViewModel.NombreResponsable = usuarioResponsable.DisplayName;
                solucionViewModel.RolResponsable = usuarioResponsable.JobTitle;
            }

            solucionViewModel.UsuarioRedScrumMaster = solucion.UsuarioRedScrumMaster;

            if (solucion != null && solucion.UsuarioRedScrumMaster != null)
            {
                Usuario usuarioScrumMaster = this.negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedScrumMaster);
                solucionViewModel.NombreScrumMaster = usuarioScrumMaster.DisplayName;
                solucionViewModel.RolScrumMaster = usuarioScrumMaster.JobTitle;
            }

            solucionViewModel.Observacion = solucion.Observacion;
            solucionViewModel.Descripcion = solucion.Descripcion;
            solucionViewModel.UrlDocumentacion = solucion.UrlDocumentacion;
            solucionViewModel.UrlRepositorioCodigoFuente = solucion.UrlRepositorioCodigoFuente;
            solucionViewModel.UrlInspeccion = solucion.UrlInspeccion ?? TransversalesConstantes.CadenaVacia;
            solucionViewModel.UrlDiseno = solucion.UrlDiseno ?? TransversalesConstantes.CadenaVacia;
            solucionViewModel.UrlGestionTareas = solucion.UrlGestionTareas;
            solucionViewModel.UrlGestionIncidentes = solucion.UrlGestionIncidentes;
            solucionViewModel.UrlGestionAseguramientoCalidad = solucion.UrlGestionAseguramientoCalidad;
            solucionViewModel.UrlLeccionesAprendidas = solucion.UrlLeccionesAprendidas;
            solucionViewModel.UrlOportunidadCrm = solucion.UrlOportunidadCrm ?? TransversalesConstantes.CadenaVacia;
            solucionViewModel.UrlProyectoPsa = solucion.UrlProyectoPsa ?? TransversalesConstantes.CadenaVacia;
            solucionViewModel.NombreContactoCliente = solucion.NombreContactoCliente;
            solucionViewModel.TelefonoContactoCliente = solucion.TelefonoContactoCliente;
            solucionViewModel.CorreoContactoCliente = solucion.CorreoContactoCliente;
            solucionViewModel.LineaSolucion = CambiarIdiomaPorItemMaestro(solucion.LineaSolucion, TiposMaestro.LineaSolucion);
            solucionViewModel.LineaNegocio = CambiarIdiomaPorItemMaestro(solucion.LineaNegocio, TiposMaestro.LineasNegocio);
            solucionViewModel.UX = solucion.ExperienciaUsuario ? "checked" : "unchecked";
            solucionViewModel.Etiqueta = solucion.Etiqueta;
            solucionViewModel.MarcoTrabajo = CambiarIdiomaPorItemMaestro(solucion.MarcoTrabajo, TiposMaestro.MarcosDeTrabajo);
            solucionViewModel.Tipo = CambiarIdiomaPorItemMaestro(solucion.Tipo, TiposMaestro.TiposDeSolucion);
            solucionViewModel.Estado = CambiarIdiomaPorItemMaestro(solucion.Estado, TiposMaestro.EstadosSolucion);
            solucionViewModel.Oficina = CambiarIdiomaPorItemMaestro(solucion.Oficina, TiposMaestro.Oficinas);
            solucionViewModel.FechaCreacion = solucion.FechaCreacion;
            solucionViewModel.FechaCierre = solucion.FechaCierre == default(DateTime) ? null : solucion.FechaCierre;
            if (!string.IsNullOrEmpty(solucion.UsoComercial.Nombre))
            {
                solucionViewModel.UsoComercial = CambiarIdiomaPorItemMaestro(solucion.UsoComercial, TiposMaestro.UsosComerciales);
            }
            if (!string.IsNullOrEmpty(solucion.Gsdc.Nombre))
            {
                solucionViewModel.Gsdc = CambiarIdiomaPorItemMaestro(solucion.Gsdc, TiposMaestro.Gsdc);
            }

            solucionViewModel.Cliente = solucion.Cliente;
            solucionViewModel.Pais = solucion.Pais;
            solucionViewModel.ListaCliente = ConvertirListaClienteEnSelectListItem(this.negocioClientes.ConsultarClientes());
            solucionViewModel.ListaPais = this.negocioLocalizacion.ConsultarPaises().ToRequiredSelectListItemPais();
            solucionViewModel.DesplieguesContinuos = new DesplieguesContinuos();
            solucionViewModel.MonitoreosContinuos = new MonitoreosContinuos();
            solucionViewModel.IntegracionesContinuas = new IntegracionesContinuas();
            solucionViewModel.DesplieguesContinuos.ListaDeplieguesContinuos = this.negocioDespliegueContinuo.ConsultarPorIdSolucion(id);
            solucionViewModel.MonitoreosContinuos.ListaMonitoreosContinuos = this.negocioMonitoreoContinuo.ConsultarPorIdSolucion(id);
            var lista = this.negocioIntegracionContinua.ConsultarPorIdSolucion(id);
            solucionViewModel.ListaInspeccionContinua = ConvertirListaInspeccionEnSelectListItem(this.negocioInspeccionContinua.Consultar());
            solucionViewModel.IntegracionesContinuas.ListaIntegracionesContinuas = lista.Join(solucionViewModel.ListaInspeccionContinua,
            ar => ar.IdProyectoInspeccion.ToString(CultureInfo.CurrentCulture),
            ac => ac.Value,
            (ar, ac) => new { T1 = ar, T2 = ac })
            .Select(u => new IntegracionesContinuas
            {
                Id = u.T1.Id,
                IdProyectoInspeccion = u.T1.IdProyectoInspeccion,
                Nombre = u.T1.Nombre,
                UrlCompilacion = u.T1.UrlCompilacion,
                NombreProyectoInspeccion = u.T2.Text,
                IdSolucion = u.T1.IdSolucion
            }).ToList();
            solucionViewModel.ListaTipo =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.TiposDeSolucion, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaLineaSolucion =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.LineaSolucion, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaLineaNegocio =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.LineasNegocio, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaMarcosTrabajo =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.MarcosDeTrabajo, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaEstados =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.EstadosSolucion, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaOficinas =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.Oficinas, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaUsoComercial =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.UsosComerciales, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaGsdc =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.Gsdc, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.Consultoria = solucion.IdConsultoria;
            PracticasCalidad practicasCalidad = this.negocioPracticaCalidad.ConsultarPorIdSolucion(id);
            solucionViewModel.ControlDocumentacion = practicasCalidad.controlDocumentacion;
            solucionViewModel.GestionTareas = practicasCalidad.gestionTareas;
            solucionViewModel.GestionErrores = practicasCalidad.gestionErrores;
            solucionViewModel.ControlCodigo = practicasCalidad.controlCodigo;
            solucionViewModel.PruebasUnitariasAutomatizadas = practicasCalidad.pruebasUnitariasAutomatizadas;
            solucionViewModel.PruebasFuncionalesAutomatizadas = practicasCalidad.pruebasFuncionalesAutomatizadas;
            solucionViewModel.InspeccionContinua = practicasCalidad.inspeccionContinua;
            solucionViewModel.IntegracionContinua = practicasCalidad.integracionContinua;
            solucionViewModel.DespliegueContinuo = practicasCalidad.despliegueContinuo;
            solucionViewModel.MonitoreoContinuo = practicasCalidad.monitoreoContinuo;
            solucionViewModel.SeguridadContinua = practicasCalidad.seguridadContinua;
            solucionViewModel.RendimientoContinuo = practicasCalidad.rendimientoContinuo;
            solucionViewModel.InfraestructuraComoCodigo = practicasCalidad.infraestructuraComoCodigo;
            solucionViewModel.notasControlDocumentacion = practicasCalidad.notasControlDocumentacion;
            solucionViewModel.notasGestionTareas = practicasCalidad.notasGestionTareas;
            solucionViewModel.notasGestionErrores = practicasCalidad.notasGestionErrores;
            solucionViewModel.notasControlCodigo = practicasCalidad.notasControlCodigo;
            solucionViewModel.notasPruebasUnitariasAutomatizadas = practicasCalidad.notasPruebasUnitariasAutomatizadas;
            solucionViewModel.notasPruebasFuncionalesAutomatizadas = practicasCalidad.notasPruebasFuncionalesAutomatizadas;
            solucionViewModel.notasInspeccionContinua = practicasCalidad.notasInspeccionContinua;
            solucionViewModel.notasIntegracionContinua = practicasCalidad.notasIntegracionContinua;
            solucionViewModel.notasDespliegueContinuo = practicasCalidad.notasDespliegueContinuo;
            solucionViewModel.notasMonitoreoContinuo = practicasCalidad.notasMonitoreoContinuo;
            solucionViewModel.notasSeguridadContinua = practicasCalidad.notasSeguridadContinua;
            solucionViewModel.notasRendimientoContinuo = practicasCalidad.notasRendimientoContinuo;
            solucionViewModel.notasInfraestructuraComoCodigo = practicasCalidad.notasInfraestructuraComoCodigo;
            solucionViewModel.ObjetivoNegocio = solucion.ObjetivoNegocio;

            return solucionViewModel;
        }

        private SolucionesViewModel ObtenerConsultoria(Guid id)
        {
            SolucionesViewModel solucionViewModel = new SolucionesViewModel();

            Consultoria consultoria = this.negocioConsultoria.Obtener(id);

            solucionViewModel.Consultoria = consultoria.Id;

            solucionViewModel.UsuarioRedGerente = consultoria.UsuarioRedGerente;

            if (consultoria != null && consultoria.UsuarioRedGerente != null)
            {
                Usuario usuarioGerente = this.negocioUsuarios.ObtenerInformacionUsuario(consultoria.UsuarioRedGerente);
                solucionViewModel.NombreGerente = usuarioGerente.DisplayName;
                solucionViewModel.RolGerente = usuarioGerente.JobTitle;
            }

            solucionViewModel.Observacion = consultoria.Observacion;
            solucionViewModel.Descripcion = consultoria.Descripcion;
            solucionViewModel.UrlDocumentacion = consultoria.UrlDocumentacion;
            solucionViewModel.UrlDiseno = consultoria.UrlDiseno ?? TransversalesConstantes.CadenaVacia;
            solucionViewModel.UrlGestionTareas = consultoria.UrlGestionTareas;
            solucionViewModel.UrlGestionIncidentes = consultoria.UrlGestionIncidentes;
            solucionViewModel.UrlGestionAseguramientoCalidad = consultoria.UrlGestionAseguramientoCalidad;
            solucionViewModel.UrlLeccionesAprendidas = consultoria.UrlLeccionesAprendidas;
            solucionViewModel.UrlOportunidadCrm = consultoria.UrlOportunidadCrm ?? TransversalesConstantes.CadenaVacia;
            solucionViewModel.UrlProyectoPsa = consultoria.UrlProyectoPsa ?? TransversalesConstantes.CadenaVacia;
            solucionViewModel.NombreContactoCliente = consultoria.NombreContactoCliente;
            solucionViewModel.TelefonoContactoCliente = consultoria.TelefonoContactoCliente;
            solucionViewModel.CorreoContactoCliente = consultoria.CorreoContactoCliente;
            solucionViewModel.LineaNegocio = CambiarIdiomaPorItemMaestro(consultoria.LineaNegocio, TiposMaestro.LineasNegocio);
            solucionViewModel.Etiqueta = consultoria.Etiqueta;
            solucionViewModel.Estado = CambiarIdiomaPorItemMaestro(consultoria.Estado, TiposMaestro.EstadosSolucion);
            solucionViewModel.Oficina = CambiarIdiomaPorItemMaestro(consultoria.Oficina, TiposMaestro.Oficinas);
            solucionViewModel.FechaCreacion = consultoria.FechaCreacion;
            solucionViewModel.FechaCierre = consultoria.FechaCierre;
            if (!string.IsNullOrEmpty(consultoria.UsoComercial.Nombre))
            {
                solucionViewModel.UsoComercial = CambiarIdiomaPorItemMaestro(consultoria.UsoComercial, TiposMaestro.UsosComerciales);
            }
            if (!string.IsNullOrEmpty(consultoria.Gsdc.Nombre))
            {
                solucionViewModel.Gsdc = CambiarIdiomaPorItemMaestro(consultoria.Gsdc, TiposMaestro.Gsdc);
            }

            solucionViewModel.Cliente = consultoria.Cliente;
            solucionViewModel.Pais = consultoria.Pais;
            solucionViewModel.ListaConsultoria = this.ConvertirListaConsultoriaEnSelectListItem(this.negocioConsultoria.Listar());
            solucionViewModel.ListaCliente = ConvertirListaClienteEnSelectListItem(this.negocioClientes.ConsultarClientes());
            solucionViewModel.ListaPais = this.negocioLocalizacion.ConsultarPaises().ToRequiredSelectListItemPais();
            solucionViewModel.DesplieguesContinuos = new DesplieguesContinuos();
            solucionViewModel.MonitoreosContinuos = new MonitoreosContinuos();
            solucionViewModel.IntegracionesContinuas = new IntegracionesContinuas();
            solucionViewModel.DesplieguesContinuos.ListaDeplieguesContinuos = this.negocioDespliegueContinuo.ConsultarPorIdSolucion(id);
            solucionViewModel.MonitoreosContinuos.ListaMonitoreosContinuos = this.negocioMonitoreoContinuo.ConsultarPorIdSolucion(id);
            var lista = this.negocioIntegracionContinua.ConsultarPorIdSolucion(id);
            solucionViewModel.ListaInspeccionContinua = ConvertirListaInspeccionEnSelectListItem(this.negocioInspeccionContinua.Consultar());
            solucionViewModel.IntegracionesContinuas.ListaIntegracionesContinuas = lista.Join(solucionViewModel.ListaInspeccionContinua,
            ar => ar.IdProyectoInspeccion.ToString(CultureInfo.CurrentCulture),
            ac => ac.Value,
            (ar, ac) => new { T1 = ar, T2 = ac })
            .Select(u => new IntegracionesContinuas
            {
                Id = u.T1.Id,
                IdProyectoInspeccion = u.T1.IdProyectoInspeccion,
                Nombre = u.T1.Nombre,
                UrlCompilacion = u.T1.UrlCompilacion,
                NombreProyectoInspeccion = u.T2.Text,
                IdSolucion = u.T1.IdSolucion
            }).ToList();
            solucionViewModel.ListaTipo =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.TiposDeSolucion, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaLineaSolucion =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.LineaSolucion, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaLineaNegocio =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.LineasNegocio, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaMarcosTrabajo =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.MarcosDeTrabajo, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaEstados =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.EstadosSolucion, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaOficinas =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.Oficinas, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaUsoComercial =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.UsosComerciales, this.ObtenerLenguaje).ToRequiredSelectListItem();
            solucionViewModel.ListaGsdc =
                this.negocioSoluciones.ConsultarPorMaestro(TiposMaestro.Gsdc, this.ObtenerLenguaje).ToRequiredSelectListItem();
            PracticasCalidad practicasCalidad = this.negocioPracticaCalidad.ConsultarPorIdSolucion(id);
            solucionViewModel.ControlDocumentacion = practicasCalidad.controlDocumentacion;
            solucionViewModel.GestionTareas = practicasCalidad.gestionTareas;
            solucionViewModel.GestionErrores = practicasCalidad.gestionErrores;
            solucionViewModel.ControlCodigo = practicasCalidad.controlCodigo;
            solucionViewModel.PruebasUnitariasAutomatizadas = practicasCalidad.pruebasUnitariasAutomatizadas;
            solucionViewModel.PruebasFuncionalesAutomatizadas = practicasCalidad.pruebasFuncionalesAutomatizadas;
            solucionViewModel.InspeccionContinua = practicasCalidad.inspeccionContinua;
            solucionViewModel.IntegracionContinua = practicasCalidad.integracionContinua;
            solucionViewModel.DespliegueContinuo = practicasCalidad.despliegueContinuo;
            solucionViewModel.MonitoreoContinuo = practicasCalidad.monitoreoContinuo;
            solucionViewModel.ObjetivoNegocio = consultoria.ObjetivoNegocio;


            return solucionViewModel;
        }

        private Solucion EstablecerSolucion(SolucionesViewModel solucionViewModel)
        {
            Solucion solucion = new Solucion();
            solucion.ExperienciaUsuario = solucionViewModel.checkExperienciaUsuario == "true" ? true : false;
            solucion.Etiqueta = solucionViewModel.Etiqueta;
            solucion.Nombre = solucionViewModel.NombreProyecto;
            solucion.UsuarioRedGerente = solucionViewModel.UsuarioRedGerente;
            solucion.UsuarioRedResponsable = solucionViewModel.UsuarioRedResponsable;
            solucion.UsuarioRedScrumMaster = solucionViewModel.UsuarioRedScrumMaster;
            solucion.Observacion = solucionViewModel.Observacion;
            solucion.Descripcion = solucionViewModel.Descripcion;
            solucion.UrlDocumentacion = solucionViewModel.UrlDocumentacion ?? TransversalesConstantes.CadenaVacia;
            solucion.UrlRepositorioCodigoFuente = solucionViewModel.UrlRepositorioCodigoFuente ?? TransversalesConstantes.CadenaVacia;
            solucion.UrlInspeccion = solucionViewModel.UrlInspeccion ?? TransversalesConstantes.CadenaVacia;
            solucion.UrlDiseno = solucionViewModel.UrlDiseno ?? TransversalesConstantes.CadenaVacia;
            solucion.UrlGestionTareas = solucionViewModel.UrlGestionTareas ?? TransversalesConstantes.CadenaVacia;
            solucion.UrlGestionIncidentes = solucionViewModel.UrlGestionIncidentes ?? TransversalesConstantes.CadenaVacia;
            solucion.UrlGestionAseguramientoCalidad = solucionViewModel.UrlGestionAseguramientoCalidad ?? TransversalesConstantes.CadenaVacia;
            solucion.UrlLeccionesAprendidas = solucionViewModel.UrlLeccionesAprendidas ?? TransversalesConstantes.CadenaVacia;
            solucion.UrlOportunidadCrm = solucionViewModel.UrlOportunidadCrm ?? TransversalesConstantes.CadenaVacia;
            solucion.UrlProyectoPsa = solucionViewModel.UrlProyectoPsa ?? TransversalesConstantes.CadenaVacia;
            solucion.FechaCreacion = solucionViewModel.FechaCreacion;
            solucion.FechaCierre = solucionViewModel.FechaCierre;

            solucion.NombreContactoCliente = solucionViewModel.NombreContactoCliente ?? TransversalesConstantes.CadenaVacia;
            solucion.TelefonoContactoCliente = solucionViewModel.TelefonoContactoCliente;
            solucion.CorreoContactoCliente = solucionViewModel.CorreoContactoCliente ?? TransversalesConstantes.CadenaVacia;

            solucion.LineaSolucion.Id = Convert.ToByte(solucionViewModel.LineaSolucion.Id, CultureInfo.CurrentCulture);
            solucion.LineaNegocio.Id = Convert.ToByte(solucionViewModel.LineaNegocio.Id, CultureInfo.CurrentCulture);
            solucion.Tipo.Id = Convert.ToByte(solucionViewModel.Tipo.Id, CultureInfo.CurrentCulture);
            solucion.MarcoTrabajo.Id = Convert.ToByte(solucionViewModel.MarcoTrabajo.Id, CultureInfo.CurrentCulture);
            solucion.Estado.Id = solucionViewModel.Estado.Id;
            solucion.Oficina.Id = solucionViewModel.Oficina.Id;
            solucion.UsoComercial.Id = Convert.ToByte(solucionViewModel.UsoComercial.Id, CultureInfo.CurrentCulture);

            solucion.Cliente.Id = solucionViewModel.Cliente.Id;
            solucion.Pais.Id = solucionViewModel.Pais.Id;
            solucion.UsuarioRedLogueado = User.Identity.Name.Contains("@") ?
                User.Identity.Name.Substring(0, User.Identity.Name.IndexOf("@")) :
                User.Identity.Name;

            if (solucionViewModel.Consultoria != null)
                solucion.IdConsultoria = Guid.Parse(solucionViewModel.Consultoria.ToString());

            solucion.ObjetivoNegocio = solucionViewModel.ObjetivoNegocio;

            return solucion;
        }

        private PracticasCalidad ObtenerPracticasCalidad(SolucionesViewModel solucionViewModel)
        {
            PracticasCalidad practicasCalidad = new PracticasCalidad();

            practicasCalidad.controlDocumentacion = solucionViewModel.ControlDocumentacion;
            practicasCalidad.controlCodigo = solucionViewModel.ControlCodigo;
            practicasCalidad.gestionTareas = solucionViewModel.GestionTareas;
            practicasCalidad.gestionErrores = solucionViewModel.GestionErrores;
            practicasCalidad.pruebasUnitariasAutomatizadas = solucionViewModel.PruebasUnitariasAutomatizadas;
            practicasCalidad.pruebasFuncionalesAutomatizadas = solucionViewModel.PruebasFuncionalesAutomatizadas;
            practicasCalidad.integracionContinua = solucionViewModel.IntegracionContinua;
            practicasCalidad.inspeccionContinua = solucionViewModel.InspeccionContinua;
            practicasCalidad.despliegueContinuo = solucionViewModel.DespliegueContinuo;
            practicasCalidad.monitoreoContinuo = solucionViewModel.MonitoreoContinuo;
            practicasCalidad.seguridadContinua = solucionViewModel.SeguridadContinua;
            practicasCalidad.rendimientoContinuo = solucionViewModel.RendimientoContinuo;
            practicasCalidad.infraestructuraComoCodigo = solucionViewModel.InfraestructuraComoCodigo;
            practicasCalidad.notasControlDocumentacion = solucionViewModel.notasControlDocumentacion;
            practicasCalidad.notasControlCodigo = solucionViewModel.notasControlCodigo;
            practicasCalidad.notasGestionTareas = solucionViewModel.notasGestionTareas;
            practicasCalidad.notasGestionErrores = solucionViewModel.notasGestionErrores;
            practicasCalidad.notasPruebasUnitariasAutomatizadas = solucionViewModel.notasPruebasUnitariasAutomatizadas;
            practicasCalidad.notasPruebasFuncionalesAutomatizadas = solucionViewModel.notasPruebasFuncionalesAutomatizadas;
            practicasCalidad.notasIntegracionContinua = solucionViewModel.notasIntegracionContinua;
            practicasCalidad.notasInspeccionContinua = solucionViewModel.notasInspeccionContinua;
            practicasCalidad.notasDespliegueContinuo = solucionViewModel.notasDespliegueContinuo;
            practicasCalidad.notasMonitoreoContinuo = solucionViewModel.notasMonitoreoContinuo;
            practicasCalidad.notasSeguridadContinua = solucionViewModel.notasSeguridadContinua;
            practicasCalidad.notasRendimientoContinuo = solucionViewModel.notasRendimientoContinuo;
            practicasCalidad.notasInfraestructuraComoCodigo = solucionViewModel.notasInfraestructuraComoCodigo;

            return practicasCalidad;
        }

        private TecnologiaSolucion ObtenerTecnologias()
        {
            TecnologiaSolucion tecnologia = new TecnologiaSolucion();
            tecnologia.Tecnologias = new List<TecnologiaSolucion>();
            TecnologiaSolucion itemTecnologia;
            if (Request.Form.GetValues("itemIdTecnologia") == null)
            {
                return tecnologia;
            }

            var arrayTecnologiaSeleccionadas = Request.Form.GetValues("itemIdTecnologia");

            for (int i = (int)default; i < arrayTecnologiaSeleccionadas.Length; i++)
            {
                itemTecnologia = new TecnologiaSolucion();
                itemTecnologia.Id = Guid.Parse(arrayTecnologiaSeleccionadas[i]);

                tecnologia.Tecnologias.Add(itemTecnologia);
            }

            return tecnologia;
        }

        private DesplieguesContinuos ObtenerDesplieguesContinuos()
        {
            DesplieguesContinuos despliegueContinuo = new DesplieguesContinuos();
            despliegueContinuo.ListaDeplieguesContinuos = new List<DesplieguesContinuos>();
            DesplieguesContinuos itemDespliegueContinuo;
            if (Request.Form.GetValues("itemNombreDespliegue") == null)
            {
                return despliegueContinuo;
            }

            var arrayNombreDesplieguesContinuos = Request.Form.GetValues("itemNombreDespliegue");
            var arrayUrlDesplieguesContinuos = Request.Form.GetValues("itemUrlDespliegue");

            for (int i = (int)default; i < arrayNombreDesplieguesContinuos.Length; i++)
            {
                if (!string.IsNullOrEmpty(arrayNombreDesplieguesContinuos[i]))
                {
                    itemDespliegueContinuo = new DesplieguesContinuos();
                    itemDespliegueContinuo.Nombre = arrayNombreDesplieguesContinuos[i];
                    itemDespliegueContinuo.UrlDespliegue = arrayUrlDesplieguesContinuos[i];

                    despliegueContinuo.ListaDeplieguesContinuos.Add(itemDespliegueContinuo);
                }
            }

            return despliegueContinuo;
        }

        private MonitoreosContinuos ObtenerMonitoreoContinuo()
        {
            MonitoreosContinuos monitoreoContinuo = new MonitoreosContinuos();
            monitoreoContinuo.ListaMonitoreosContinuos = new List<MonitoreosContinuos>();
            MonitoreosContinuos itemMonitoreoContinuo;
            if (Request.Form.GetValues("itemNombreMonitoreo") == null)
            {
                return monitoreoContinuo;
            }

            var arrayNombreMonitoreoContinuo = Request.Form.GetValues("itemNombreMonitoreo");
            var arrayUrlMonitoreoContinuo = Request.Form.GetValues("itemUrlMonitoreo");

            for (int i = (int)default; i < arrayNombreMonitoreoContinuo.Length; i++)
            {
                if (!string.IsNullOrEmpty(arrayNombreMonitoreoContinuo[i]))
                {
                    itemMonitoreoContinuo = new MonitoreosContinuos();
                    itemMonitoreoContinuo.Nombre = arrayNombreMonitoreoContinuo[i];
                    itemMonitoreoContinuo.UrlMonitoreo = arrayUrlMonitoreoContinuo[i].ToString(CultureInfo.CurrentCulture);
                    monitoreoContinuo.ListaMonitoreosContinuos.Add(itemMonitoreoContinuo);
                }
            }

            return monitoreoContinuo;
        }

        private IntegracionesContinuas ObtenerIntegracionesContinuas()
        {
            IntegracionesContinuas integracionesContinuas = new IntegracionesContinuas();
            integracionesContinuas.ListaIntegracionesContinuas = new List<IntegracionesContinuas>();
            IntegracionesContinuas itemIntegracionesContinuas;
            if (Request.Form.GetValues("itemNombreCompilacion") == null)
            {
                return integracionesContinuas;
            }

            var arrayNombreIntegracionesContinuas = Request.Form.GetValues("itemNombreCompilacion");
            var arrayUrlCompilacionIntegracionesContinuas = Request.Form.GetValues("itemUrlCompilacion");
            var arrayIdProyectoIntegracionesContinuas = Request.Form.GetValues("itemIdProyectoInspeccion");

            for (int i = (int)default; i < arrayNombreIntegracionesContinuas.Length; i++)
            {
                if (!string.IsNullOrEmpty(arrayNombreIntegracionesContinuas[i]))
                {
                    itemIntegracionesContinuas = new IntegracionesContinuas();
                    itemIntegracionesContinuas.Nombre = arrayNombreIntegracionesContinuas[i];
                    itemIntegracionesContinuas.UrlCompilacion = arrayUrlCompilacionIntegracionesContinuas[i].ToString(CultureInfo.CurrentCulture);
                    itemIntegracionesContinuas.IdProyectoInspeccion = string.IsNullOrEmpty(
                        arrayIdProyectoIntegracionesContinuas[i]) ? (int)default : int.Parse(arrayIdProyectoIntegracionesContinuas[i], CultureInfo.CurrentCulture);

                    integracionesContinuas.ListaIntegracionesContinuas.Add(itemIntegracionesContinuas);
                }
            }

            return integracionesContinuas;
        }

        private IList<SelectListItem> ConvertirListaTecnologiaEnSelectListItem(IEnumerable<Tecnologia> listaTecnologia)
        {
            return listaTecnologia.ToList().ConvertAll(Tecnologia =>
            {
                return new SelectListItem
                {
                    Text = Tecnologia.Nombre,
                    Value = Tecnologia.Id.ToString()
                };
            });
        }

        private IList<SelectListItem> ConvertirListaClienteEnSelectListItem(IEnumerable<Cliente> listaCliente)
        {
            IList<SelectListItem> selectListItem =

            listaCliente.ToList().ConvertAll(Cliente =>
            {
                return new SelectListItem
                {
                    Text = Cliente.Name,
                    Value = Cliente.Id.ToString(CultureInfo.CurrentCulture)
                };
            });

            SelectListItem itemVacio = new SelectListItem();
            itemVacio.Value = string.Empty;
            itemVacio.Text = string.Empty;

            selectListItem.Insert(0, itemVacio);

            return selectListItem;
        }

        private IList<SelectListItem> ConvertirListaDepartamentoEnSelectListItem(IEnumerable<Departamento> listaDepartamento)
        {
            IList<SelectListItem> selectListItem =

            listaDepartamento.ToList().ConvertAll(Departamento =>
            {
                return new SelectListItem
                {
                    Text = Departamento.Name,
                    Value = Departamento.Id.ToString(CultureInfo.CurrentCulture)
                };
            });

            SelectListItem itemVacio = new SelectListItem();
            itemVacio.Value = string.Empty;
            itemVacio.Text = string.Empty;

            selectListItem.Insert(0, itemVacio);

            return selectListItem;
        }

        private IList<SelectListItem> ConvertirListaCiudadEnSelectListItem(IEnumerable<Ciudad> listaCiudad)
        {
            IList<SelectListItem> selectListItem =

            listaCiudad.ToList().ConvertAll(Ciudad =>
            {
                return new SelectListItem
                {
                    Text = Ciudad.Name,
                    Value = Ciudad.Id.ToString(CultureInfo.CurrentCulture)
                };
            });

            SelectListItem itemVacio = new SelectListItem();
            itemVacio.Value = string.Empty;
            itemVacio.Text = string.Empty;

            selectListItem.Insert(0, itemVacio);

            return selectListItem;
        }

        private IList<SelectListItem> ConvertirListaConsultoriaEnSelectListItem(IEnumerable<Consultoria> listaConsultoria)
        {
            IList<SelectListItem> selectListItem =

            listaConsultoria.ToList().ConvertAll(Consultoria =>
            {
                return new SelectListItem
                {
                    Text = Consultoria.Cliente.Name + " - " + Consultoria.Nombre,
                    Value = Consultoria.Id.ToString()
                };
            });

            SelectListItem itemVacio = new SelectListItem();
            itemVacio.Value = string.Empty;
            itemVacio.Text = string.Empty;

            selectListItem.Insert(0, itemVacio);

            return selectListItem;
        }

        private IList<SelectListItem> ConvertirListaInspeccionEnSelectListItem(IEnumerable<InspeccionesContinuas> listaInspeccion)
        {
            IList<SelectListItem> selectListItem =

            listaInspeccion.ToList().ConvertAll(Inspeccion =>
            {
                return new SelectListItem
                {
                    Text = Inspeccion.Nombre,
                    Value = Inspeccion.Id.ToString(CultureInfo.CurrentCulture)
                };
            });

            SelectListItem itemVacio = new SelectListItem();
            itemVacio.Value = "0";
            itemVacio.Text = string.Empty;

            selectListItem.Insert(0, itemVacio);

            return selectListItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controlDocumentacion"></param>
        /// <param name="controlCodigo"></param>
        /// <returns></returns>
        private bool? ObtenerEstadoControlArtefactos(bool? controlDocumentacion, bool? controlCodigo)
        {
            if (controlDocumentacion == null && controlCodigo == null)
            {
                return null;
            }

            if (controlDocumentacion == true && controlCodigo == true)
            {
                return true;
            }

            if ((controlDocumentacion == null || controlDocumentacion == true) && controlCodigo == true)
            {
                return true;
            }

            if ((controlCodigo == null || controlCodigo == true) && controlDocumentacion == true)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gestionTareas"></param>
        /// <param name="gestionErrores"></param>
        /// <returns></returns>
        private bool? ObtenerEstadoGestionBacklog(bool? gestionTareas, bool? gestionErrores)
        {
            if (gestionTareas == null && gestionErrores == null)
            {
                return null;
            }

            if (gestionTareas == true && gestionErrores == true)
            {
                return true;
            }

            if ((gestionTareas == null || gestionTareas == true) && gestionErrores == true)
            {
                return true;
            }

            if ((gestionErrores == null || gestionErrores == true) && gestionTareas == true)
            {
                return true;
            }

            return false;
        }

    }
}

