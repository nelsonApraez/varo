//// --------------------------------------------------------------------------------
//// <copyright file="BaseController.cs">Company S.A.</copyright>
//// <author>Developer</author>
//// <email>developer@company.com</email>
//// <date>09/08/2018</date>
//// <summary>Proporciona funcionalidades gen�ricas para los controllers.</summary>
//// --------------------------------------------------------------------------------

namespace Varo.Web.Controllers
{
    using Elmah;
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
    using Varo.Transversales.Mensajes;
    using Varo.Web.ErrorHandler;
    using Varo.Web.Helpers;
    using Varo.Web.Models;
    // using Company.Framework.Mensajes; // Commented out during sanitization
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Proporciona funcionalidades gen�ricas para los controllers.
    /// </summary>
    [AiHandleError]
    public class BaseController : Controller
    {
        private readonly INegocioSoluciones negocioSoluciones;
        private readonly INegocioConsultoria negocioConsultorias;
        private readonly INegocioLocalizacion negocioLocalizacion;
        private readonly INegocioUsuarios negocioUsuarios;
        private readonly INegocioClientes negocioClientes;
        private readonly INegocioOficinas negocioOficinas;
        private readonly INegocioTecnologia negocioTecnologia;

        public BaseController()
        {
            this.negocioSoluciones = new NegocioSoluciones();
            this.negocioConsultorias = new NegocioConsultoria();
            this.negocioLocalizacion = new NegocioLocalizacion();
            this.negocioUsuarios = new NegocioUsuarios();
            this.negocioClientes = new NegocioClientes();
            this.negocioOficinas = new NegocioOficinas();
            this.negocioTecnologia = new NegocioTecnologia();
        }

        /// <summary>
        /// Registra de la excepci�n en el log de errores configurado.
        /// </summary>
        /// <param name="excepcion">Excepci�n a almacenar.</param>
        public void CapturarExcepcion(Exception excepcion)
        {
            if (excepcion.GetType() == typeof(NegocioExcepcion))
            {
                this.VisualizarMensajeNegocio(excepcion);
            }
            else
            {
                ErrorSignal.FromCurrentContext().Raise(excepcion);

                // this.MostrarMensaje(new Mensaje(CodigoMensaje.ErrorInesperado)); // Commented out during sanitization
            }
        }

        /// <summary>
        /// Visualiza un mensaje de excepci�n de negocio.
        /// </summary>
        /// <param name="excepcion">Excepci�n de negocio.</param>
        private void VisualizarMensajeNegocio(Exception excepcion)
        {
            this.MostrarMensaje(excepcion.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroPaginaActual"></param>
        /// <param name="terminoBusqueda"></param>
        /// <param name="filtroActual"></param>
        /// <param name="solucionesViewModel"></param>
        /// <param name="checkEnEjecucion"></param>
        /// <param name="enEjecucion"></param>
        /// <returns></returns>
        public IEnumerable<SolucionInformacionBasica> VerificarBusquedaYPaginador(
            int? numeroPaginaActual,
            string terminoBusqueda,
            string filtroActual,
            PaginadorViewModel<IEnumerable<SolucionesInformacionBasicaViewModel>> solucionesViewModel,
            string checkEnEjecucion,
            string enEjecucion)
        {
            int NumeroPaginaActual = Convert.ToInt16(numeroPaginaActual ?? 1, CultureInfo.CurrentCulture);
            string TerminoBuqueda = terminoBusqueda;
            string CheckEnEjecucion = checkEnEjecucion;

            if (TerminoBuqueda != null)
            {
                NumeroPaginaActual = 1;
            }
            else
            {
                TerminoBuqueda = filtroActual;
            }

            ViewBag.filtroActual = TerminoBuqueda;


            if (CheckEnEjecucion != null)
            {
                CheckEnEjecucion = "checked";
            }
            else
            {
                CheckEnEjecucion = NumeroPaginaActual == NumerosConstantes.Numero1 && enEjecucion != "checked" ? "" : enEjecucion;
            }

            ViewBag.enEjecucion = CheckEnEjecucion;

            IEnumerable<SolucionInformacionBasica> soluciones;
            if (string.IsNullOrEmpty(TerminoBuqueda))
            {
                soluciones = this.negocioSoluciones.Consultar(
                   NumeroPaginaActual,
                   ParametrosGenerales.CantidadDeTarjetasPorPagina,
                   CheckEnEjecucion);
            }
            else
            {
                soluciones = this.negocioSoluciones.ConsultarPorParametro(
                           NumeroPaginaActual,
                           ParametrosGenerales.CantidadDeTarjetasPorPagina,
                           TerminoBuqueda,
                           CheckEnEjecucion);
            }

            if (soluciones.Any())
            {
                solucionesViewModel.Paginador =
                new Paginador(
                    ViewBag.filtroActual,
                    ViewBag.enEjecucion,
                    soluciones.FirstOrDefault().ConteoTotalFilas,
                    NumeroPaginaActual,
                    ParametrosGenerales.CantidadDeTarjetasPorPagina);
            }

            return soluciones;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroPaginaActual"></param>
        /// <param name="terminoBusqueda"></param>
        /// <param name="filtroActual"></param>
        /// <param name="consultoriaViewModel"></param>
        /// <param name="checkEnEjecucion"></param>
        /// <param name="enEjecucion"></param>
        /// <returns></returns>
        public IEnumerable<ConsultoriaInformacionBasica> VerificarBusquedaYPaginador(
         int? numeroPaginaActual,
         string terminoBusqueda,
         string filtroActual,
         PaginadorViewModel<IEnumerable<ConsultoriaInformacionBasicaViewModel>> consultoriaViewModel,
         string checkEnEjecucion,
         string enEjecucion)
        {
            int NumeroPaginaActual = Convert.ToInt16(numeroPaginaActual ?? 1, CultureInfo.CurrentCulture);
            string TerminoBuqueda = terminoBusqueda;
            string CheckEnEjecucion = checkEnEjecucion;

            if (TerminoBuqueda != null)
            {
                NumeroPaginaActual = 1;
            }
            else
            {
                TerminoBuqueda = filtroActual;
            }

            ViewBag.filtroActual = TerminoBuqueda;


            if (CheckEnEjecucion != null)
            {
                CheckEnEjecucion = "checked";
            }
            else
            {
                CheckEnEjecucion = NumeroPaginaActual == NumerosConstantes.Numero1 && enEjecucion != "checked" ? "" : enEjecucion;
            }

            ViewBag.enEjecucion = CheckEnEjecucion;

            IEnumerable<ConsultoriaInformacionBasica> consultorias = null;

            if (string.IsNullOrEmpty(TerminoBuqueda))
            {
                consultorias = this.negocioConsultorias.Consultar(
                   NumeroPaginaActual,
                   ParametrosGenerales.CantidadDeTarjetasPorPagina,
                   CheckEnEjecucion);
            }
            else
            {
                consultorias = this.negocioConsultorias.ConsultarPorParametro(
                           NumeroPaginaActual,
                           ParametrosGenerales.CantidadDeTarjetasPorPagina,
                           TerminoBuqueda,
                           CheckEnEjecucion);
            }

            if (consultorias.Any())
            {
                consultoriaViewModel.Paginador =
                new Paginador(
                    ViewBag.filtroActual,
                    ViewBag.enEjecucion,
                    consultorias.FirstOrDefault().ConteoTotalFilas,
                    NumeroPaginaActual,
                    ParametrosGenerales.CantidadDeTarjetasPorPagina);
            }

            return consultorias;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ObtenerLenguaje
        {
            get
            {
                HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["lenguajes"];
                if (cookie != null && cookie.Value != null)
                {
                    return cookie.Value;
                }
                else
                {
                    return CultureInfo.InstalledUICulture.Parent.Name;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lenguaje"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CambiarIdioma(string lenguaje)
        {
            if (!string.IsNullOrEmpty(lenguaje))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lenguaje);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lenguaje);
            }
            HttpCookie cookie = new HttpCookie(name: "lenguajes");
            cookie.HttpOnly = true;
            cookie.Value = lenguaje;
            Response.Cookies.Add(cookie);
            return Redirect(Request.UrlReferrer.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemMaestro"></param>
        /// <param name="tiposMaestro"></param>
        /// <returns></returns>
        public string CambiarIdiomaPorNombre(ItemMaestro itemMaestro, string tiposMaestro)
        {
            string CampoMultilenguaje = ObtenerLenguaje.Equals(TransversalesConstantes.CulturaEspanol, StringComparison.OrdinalIgnoreCase) ?
                    itemMaestro.Nombre : this.negocioSoluciones.ConsultarPorMaestro(tiposMaestro,
                        this.ObtenerLenguaje).Single(x => x.Id == itemMaestro.Id).Nombre;

            return CampoMultilenguaje;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemMaestro"></param>
        /// <param name="tiposMaestro"></param>
        /// <returns></returns>
        public ItemMaestro CambiarIdiomaPorItemMaestro(ItemMaestro itemMaestro, string tiposMaestro)
        {
            ItemMaestro CampoMultilenguaje = ObtenerLenguaje.Equals(TransversalesConstantes.CulturaEspanol, StringComparison.OrdinalIgnoreCase) ?
                    itemMaestro : this.negocioSoluciones.ConsultarPorMaestro(tiposMaestro,
                        this.ObtenerLenguaje).Single(x => x.Id == itemMaestro.Id);

            return CampoMultilenguaje;
        }

        /// <summary>
        /// M�todo que valida si los campos de una lista vienen vacios.
        /// </summary>
        /// <param name="TituloVistaParcial">Titulo de la p�gina que se desea mostrar en el mensaje.</param>
        /// <param name="listaCampos">Lista de Request de la vista parcial que se quieren evaluar.</param>
        /// <param name="esRequerido">Valor booleano que valida si la lista es requerida. (valor por defecto false).</param>
        public void ValidarCamposVacios(string tituloVistaParcial, IList<string> listaCampos, bool saltarPrimeraLinea = false)
        {
            foreach (var campo in listaCampos)
            {
                string requestForm = Request.Form[campo];
                string[] arrayRequestForm = requestForm.Split(TransversalesConstantes.SeparadorComa);
                if (saltarPrimeraLinea)
                {
                    foreach (var item in arrayRequestForm.Skip(NumerosConstantes.Numero1))
                    {
                        if (string.IsNullOrEmpty(item))
                        {
                            throw new NegocioExcepcion(string.Format(CultureInfo.CurrentCulture, Recursos.Lenguaje.MensajeDatosIncompletos, tituloVistaParcial));
                        }
                    }
                }
                else
                {
                    foreach (var item in arrayRequestForm)
                    {
                        if (string.IsNullOrEmpty(item))
                        {
                            throw new NegocioExcepcion(string.Format(CultureInfo.CurrentCulture, Recursos.Lenguaje.MensajeDatosIncompletos, tituloVistaParcial));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Accion para consultar todos los clientes
        /// </summary>
        /// <returns>Los clientes</returns>
        [HttpGet]
        public ActionResult ConsultarClientes()
        {
            IEnumerable<Cliente> listaDeClientes;
            try
            {
                listaDeClientes = this.negocioClientes.ConsultarClientes();
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, listaDeClientes = listaDeClientes.OrderBy(x => x.Name) }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ConsultarSolucionPorIdCliente(int idCliente)
        {
            IEnumerable<Solucion> listaDeSoluciones;
            try
            {
                listaDeSoluciones = this.negocioSoluciones.ConsultarPorIdCliente(idCliente);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, listaDeClientes = listaDeSoluciones.OrderBy(x => x.Nombre) }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Accion para consultar todos los departamentos que tengas el id del pais
        /// </summary>
        /// <param name="idPais">Identificador del pais</param>
        /// <returns>Los departamentos que sean parte del identificador del pais</returns>
        [HttpGet]
        public ActionResult ConsultarDepartamentosPorIdPais(byte idPais)
        {
            IList<Departamento> listaDeDepartamentos;
            try
            {
                listaDeDepartamentos = this.negocioLocalizacion.ConsultarDepartamentosPorIdPais(idPais);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, listaDeDepartamentos = listaDeDepartamentos.OrderBy(x => x.Name) }, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Accion para consultar todos las ciudades que tengas el id del departamento
        /// </summary>
        /// <param name="idDepartamento">identificador del departamento</param>
        /// <returns>Las ciudades que sean parte del identificador del departamento</returns>
        [HttpGet]
        public ActionResult ConsultarCiudadesPorIdDepartamento(int idDepartamento)
        {
            IList<Ciudad> listaCiudades;
            try
            {
                listaCiudades = this.negocioLocalizacion.ConsultarCiudadesPorIdDepartamento(idDepartamento);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, listaCiudades = listaCiudades.OrderBy(x => x.Name) }, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGsdc"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ConsultarOficinasPorIdGsdc(byte idGsdc)
        {
            IList<ItemMaestro> listaOficinas;
            try
            {
                listaOficinas = this.negocioOficinas.ConsultarOficinaPorIdGsdc(idGsdc);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, listaOficinas = listaOficinas.OrderBy(x => x.Nombre) }, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioRed"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ObtenerNombreResponsablePorUsuarioRed(string usuarioRed)
        {
            string[] informacionUsuarioResponsable = new string[2];
            try
            {
                Usuario usuario = this.negocioUsuarios.ObtenerInformacionUsuario(usuarioRed);
                if (usuario != null)
                {
                    informacionUsuarioResponsable[0] = usuario.JobTitle;
                    informacionUsuarioResponsable[1] = usuario.DisplayName;
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, informacionUsuarioResponsable }, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idTipoTecnologia"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ConsultarTecnologiasPorIdTipoTecnologia(byte idTipoTecnologia)
        {
            IList<Tecnologia> listaTecnologia;
            try
            {
                listaTecnologia = this.negocioTecnologia.ConsultarPorTipoDeTecnologia(idTipoTecnologia);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, listaTecnologia = listaTecnologia.OrderBy(x => x.Nombre) }, JsonRequestBehavior.AllowGet);

        }
    }
}
