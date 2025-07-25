// -------------------------------------------------------------------------------
// <copyright file="NegocioSoluciones.cs" company="Company S.A.">
//     COPYRIGHT(C) 2018, Company S.A.
// </copyright>
// <author>Developer</author>
// <email>developer@company.com</email>
// <date>09/08/2018</date>
// <summary>Implementa las funcionalidades de negocio para las soluciones.</summary>
// -------------------------------------------------------------------------------

namespace Varo.Soluciones.Negocio
{
    using Varo.Maestros.Entidades;
    using Varo.Maestros.Negocio;
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Constantes;
    using Varo.Transversales.Excepciones;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;
    using System.Transactions;

    public class NegocioSoluciones : NegocioBase, INegocioSoluciones
    {
        private readonly IRepositorioSolucion repositorioSolucion;
        private readonly IRepositorioDespliegueContinuo repositorioDespliegueContinuo;
        private readonly IRepositorioMonitoreoContinuo repositorioMonitoreoContinuo;
        private readonly IRepositorioIntegracionContinua repositorioIntegracionContinua;
        private readonly IRepositorioPracticaCalidad repositorioPracticaCalidad;
        private readonly IRepositorioTecnologiaSolucion repositorioTecnologiaSolucion;
        private readonly INegocioUsuarios negocioUsuarios;
        private readonly INegocioClientes negocioClientes;
        private readonly INegocioLocalizacion negocioLocalizacion;
        private readonly INegocioHito negocioHito;
        private readonly INegocioPrueba negocioPrueba;
        private readonly INegocioAuditoria negocioAuditoria;
        private readonly INegocioMetricaAgil negocioMetricaAgil;
        private readonly INegocioNotificaciones negocioNotificaciones;
        private readonly INegocioEmail365 negocioEmail365;
        private readonly int idTipoNotificacionCambioEstado = 1;
        private const int scrumban = 3;

        public NegocioSoluciones() :
            this(
                new RepositorioBase(),
                new RepositorioSolucion(),
                new RepositorioDespligueContinuo(),
                new RepositorioMonitoreoContinuo(),
                new RepositorioIntegracionContinua(),
                new RepositorioPracticaCalidad(),
                new RepositorioTecnologiaSolucion(),
                new NegocioUsuarios(),
                new NegocioClientes(),
                new NegocioLocalizacion(),
                new NegocioHito(),
                new NegocioPrueba(),
                new NegocioAuditoria(),
                new NegocioMetricaAgil(),
                new NegocioNotificaciones(),
                new NegocioEmail365())
        { }

        public NegocioSoluciones(
            IRepositorioBase repositorioBase,
            IRepositorioSolucion repositorioSolucion,
            IRepositorioDespliegueContinuo repositorioDespliegueContinuo,
            IRepositorioMonitoreoContinuo repositorioMonitoreoContinuo,
            IRepositorioIntegracionContinua repositorioIntegracionContinua,
            IRepositorioPracticaCalidad repositorioPracticaCalidad,
            IRepositorioTecnologiaSolucion repositorioTecnologiaSolucion,
            INegocioUsuarios negocioUsuarios,
            INegocioClientes negocioClientes,
            INegocioLocalizacion negocioLocalizacion,
            INegocioHito negocioHito,
            INegocioPrueba negocioPrueba,
            INegocioAuditoria negocioAuditoria,
            INegocioMetricaAgil negocioMetricaAgil,
            INegocioNotificaciones negocioNotificaciones,
            INegocioEmail365 negocioEmail365) :
            base(repositorioBase)
        {
            this.repositorioSolucion = repositorioSolucion;
            this.repositorioDespliegueContinuo = repositorioDespliegueContinuo;
            this.repositorioMonitoreoContinuo = repositorioMonitoreoContinuo;
            this.repositorioIntegracionContinua = repositorioIntegracionContinua;
            this.repositorioPracticaCalidad = repositorioPracticaCalidad;
            this.repositorioTecnologiaSolucion = repositorioTecnologiaSolucion;
            this.negocioUsuarios = negocioUsuarios;
            this.negocioClientes = negocioClientes;
            this.negocioLocalizacion = negocioLocalizacion;
            this.negocioHito = negocioHito;
            this.negocioPrueba = negocioPrueba;
            this.negocioAuditoria = negocioAuditoria;
            this.negocioMetricaAgil = negocioMetricaAgil;
            this.negocioNotificaciones = negocioNotificaciones;
            this.negocioEmail365 = negocioEmail365;
        }

        public IList<SolucionInformacionBasica> Consultar(int numeroPagina, int tamanoPagina, string CheckEnEjecucion)
        {
            IList<SolucionInformacionBasica> listaSoluciones;

            listaSoluciones = this.repositorioSolucion.Consultar(numeroPagina, tamanoPagina, CheckEnEjecucion);

            foreach (SolucionInformacionBasica solucion in listaSoluciones)
            {
                solucion.Cliente.Name = negocioClientes.ObtenerClientePorId(solucion.Cliente.Id).Name;

                if (solucion.UsuarioRedGerente != null)
                {
                    var nombreGerente = negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedGerente).DisplayName;
                    solucion.NombreGerente = !string.IsNullOrEmpty(nombreGerente) ? nombreGerente : solucion.UsuarioRedGerente;
                }

                if (solucion.UsuarioRedResponsable != null)
                {
                    var nombreResponsable = negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedResponsable).DisplayName;
                    solucion.NombreResponsable = !string.IsNullOrEmpty(nombreResponsable) ? nombreResponsable : solucion.UsuarioRedResponsable;
                }

                if (solucion.UsuarioRedScrumMaster != null)
                {
                    var nombreScrumMaster = negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedScrumMaster).DisplayName;
                    solucion.NombreScrumMaster = !string.IsNullOrEmpty(nombreScrumMaster) ? nombreScrumMaster : solucion.UsuarioRedScrumMaster;
                }
            }

            return listaSoluciones;
        }

        public IList<SolucionInformacionBasica> ConsultarPorParametro(int numeroPagina, int tamanoPagina,
                                             string valorDeBusqueda, string CheckEnEjecucion)
        {
            string[] vectorDeBusqueda = new string[4];

            vectorDeBusqueda[0] = valorDeBusqueda;

            vectorDeBusqueda[1] = String.Join(",", this.negocioLocalizacion.ObtenerIdCiudadPorNombre(valorDeBusqueda));

            vectorDeBusqueda[2] = String.Join(",", this.negocioClientes.ObtenerIdClientePorNombre(valorDeBusqueda));

            vectorDeBusqueda[3] = String.Join(",", this.negocioLocalizacion.ObtenerIdPaisPorNombre(valorDeBusqueda));

            IList<SolucionInformacionBasica> listaSoluciones;

            listaSoluciones = this.repositorioSolucion.ConsultarPorParametro(numeroPagina, tamanoPagina,
                                                                  vectorDeBusqueda, CheckEnEjecucion);

            foreach (SolucionInformacionBasica solucion in listaSoluciones)
            {
                solucion.Cliente.Name = negocioClientes.ObtenerClientePorId(solucion.Cliente.Id).Name;

                if (solucion.UsuarioRedGerente != null)
                {
                    solucion.NombreGerente = negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedGerente).DisplayName;
                }

                if (solucion.UsuarioRedResponsable != null)
                {
                    solucion.NombreResponsable = negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedResponsable).DisplayName;
                }

                if (solucion.UsuarioRedScrumMaster != null)
                {
                    solucion.NombreScrumMaster = negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedScrumMaster).DisplayName;
                }
            }

            return listaSoluciones;
        }

        public IList<Solucion> Consultar()
        {
            IList<Solucion> listaSoluciones;

            listaSoluciones = this.repositorioSolucion.Consultar();

            foreach (Solucion solucion in listaSoluciones)
            {
                solucion.Cliente.Name = negocioClientes.ObtenerClientePorId(solucion.Cliente.Id).Name;
            }

            return listaSoluciones;
        }

        public IList<Solucion> ConsultarPorIdCliente(int idCliente)
        {
            IList<Solucion> listaSoluciones;

            listaSoluciones = this.repositorioSolucion.ConsultarPorIdCliente(idCliente);

            foreach (Solucion solucion in listaSoluciones)
            {
                solucion.Cliente.Name = negocioClientes.ObtenerClientePorId(solucion.Cliente.Id).Name;
            }

            return listaSoluciones;
        }

        public Solucion Obtener(Guid id)
        {
            Solucion solucion;

            solucion = this.repositorioSolucion.Obtener(id);

            if (solucion != null)
            {
                solucion.Cliente.Name = negocioClientes.ObtenerClientePorId(solucion.Cliente.Id).Name;
                solucion.Pais.Nombre = negocioLocalizacion.ObtenerPaisPorId(solucion.Pais.Id).Name;
            }

            return solucion;
        }

        public Guid ObtenerIdSolucion(int IdMetricaAgil)
        {
            Guid idSolucion;

            idSolucion = this.repositorioSolucion.ObtenerIdSolucion(IdMetricaAgil);

            return idSolucion;
        }

        public void Crear(Solucion solucion,
            TecnologiaSolucion tecnologia,
            DesplieguesContinuos despliegueContinuo,
            MonitoreosContinuos monitoreoContinuo,
            IntegracionesContinuas integracionContinua,
            PracticasCalidad practicasCalidad)
        {
            Guid idSolucionCreada;

            if (!this.ValidarExisteUsuarios(solucion))
            {
                throw new NegocioExcepcion(Recursos.Lenguaje.MensajeErrorUsuarioNoExiste);
            }

            using (TransactionScope transactionScope = new TransactionScope())
            {
                idSolucionCreada = this.repositorioSolucion.Crear(solucion);

                if (tecnologia != null)
                {
                    tecnologia.Tecnologias.ToList().ForEach(c => c.IdSolucion = idSolucionCreada);
                }

                if (despliegueContinuo != null)
                {
                    despliegueContinuo.ListaDeplieguesContinuos.ToList().ForEach(c => c.IdSolucion = idSolucionCreada);
                }

                if (monitoreoContinuo != null)
                {
                    monitoreoContinuo.ListaMonitoreosContinuos.ToList().ForEach(c => c.IdSolucion = idSolucionCreada);
                }

                if (integracionContinua != null)
                {
                    integracionContinua.ListaIntegracionesContinuas.ToList().ForEach(c => c.IdSolucion = idSolucionCreada);
                }

                if (practicasCalidad != null)
                {
                    practicasCalidad.id = idSolucionCreada;
                }

                this.repositorioTecnologiaSolucion.Crear(tecnologia);
                this.repositorioDespliegueContinuo.Crear(despliegueContinuo);
                this.repositorioMonitoreoContinuo.Crear(monitoreoContinuo);
                this.repositorioIntegracionContinua.Crear(integracionContinua);
                this.repositorioPracticaCalidad.Crear(practicasCalidad);

                transactionScope.Complete();
            }
        }

        public void Editar(Solucion solucion,
            TecnologiaSolucion tecnologia,
            DesplieguesContinuos despliegueContinuo,
            MonitoreosContinuos monitoreoContinuo,
            IntegracionesContinuas integracionContinua,
            PracticasCalidad practicasCalidad)
        {
            if (!this.ValidarExisteUsuarios(solucion))
            {
                throw new NegocioExcepcion(Recursos.Lenguaje.MensajeErrorUsuarioNoExiste);
            }

            var solucionAnterior = this.Obtener(solucion.Id);

            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.repositorioSolucion.Editar(solucion);

                if (tecnologia != null)
                {
                    tecnologia.Tecnologias.ToList().ForEach(c => c.IdSolucion = solucion.Id);
                }

                if (despliegueContinuo != null)
                {
                    despliegueContinuo.ListaDeplieguesContinuos.ToList().ForEach(c => c.IdSolucion = solucion.Id);
                }

                if (monitoreoContinuo != null)
                {
                    monitoreoContinuo.ListaMonitoreosContinuos.ToList().ForEach(c => c.IdSolucion = solucion.Id);
                }

                if (integracionContinua != null)
                {
                    integracionContinua.ListaIntegracionesContinuas.ToList().ForEach(c => c.IdSolucion = solucion.Id);
                }

                if (practicasCalidad != null)
                {
                    practicasCalidad.id = solucion.Id;
                }

                this.repositorioTecnologiaSolucion.EliminarPorIdSolucion(solucion.Id);
                this.repositorioDespliegueContinuo.EliminarPorIdSolucion(solucion.Id);
                this.repositorioMonitoreoContinuo.EliminarPorIdSolucion(solucion.Id);
                this.repositorioIntegracionContinua.EliminarPorIdSolucion(solucion.Id);
                this.repositorioPracticaCalidad.EliminarPorIdSolucion(solucion.Id);

                this.repositorioTecnologiaSolucion.Crear(tecnologia);
                this.repositorioDespliegueContinuo.Crear(despliegueContinuo);
                this.repositorioMonitoreoContinuo.Crear(monitoreoContinuo);
                this.repositorioIntegracionContinua.Crear(integracionContinua);
                this.repositorioPracticaCalidad.Crear(practicasCalidad);

                if (solucion.Estado.Id != solucionAnterior.Estado.Id)
                {
                    EnviarNotificacionCambioEstado(solucionAnterior.Nombre, solucionAnterior.Cliente.Name.Trim());
                }

                transactionScope.Complete();
            }
        }

        public void Eliminar(Guid id)
        {
            if (this.ValidarListasSolucion(id))
            {
                throw new NegocioExcepcion("No se puede eliminar el proyecto. Verificar si existe información registrada.");
            }
            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.repositorioTecnologiaSolucion.EliminarPorIdSolucion(id);
                this.repositorioDespliegueContinuo.EliminarPorIdSolucion(id);
                this.repositorioMonitoreoContinuo.EliminarPorIdSolucion(id);
                this.repositorioIntegracionContinua.EliminarPorIdSolucion(id);
                this.repositorioPracticaCalidad.EliminarPorIdSolucion(id);
                this.repositorioSolucion.Eliminar(id);

                transactionScope.Complete();
            }
        }

        public bool EsSolucionScrumban(Guid idSolucion)
        {
            if (this.repositorioSolucion.Obtener(idSolucion).MarcoTrabajo.Id == scrumban)
            {
                return false;
            }
            return true;
        }

        private bool ValidarExisteUsuarios(Solucion solucion)
        {

            if (solucion != null && solucion.UsuarioRedGerente != null)
            {
                Usuario usuarioGerente = this.negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedGerente);
                if (string.IsNullOrEmpty(usuarioGerente.DisplayName))
                    return false;
            }

            if (solucion != null && solucion.UsuarioRedResponsable != null)
            {
                Usuario usuarioResponsable = this.negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedResponsable);
                if (string.IsNullOrEmpty(usuarioResponsable.DisplayName))
                    return false;
            }

            if (solucion != null && solucion.UsuarioRedScrumMaster != null)
            {
                Usuario usuarioScrumMaster = this.negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedScrumMaster);
                if (string.IsNullOrEmpty(usuarioScrumMaster.DisplayName))
                    return false;
            }

            return true;
        }

        private bool ValidarListasSolucion(Guid id)
        {
            var hitos = this.negocioHito.Obtener(id, string.Empty);
            if (hitos.Count > 0)
            {
                return true;
            }

            var pruebas = this.negocioPrueba.ConsultarPorIdSolucion(id);
            if (pruebas.FechaCreacion.HasValue)
            {
                return true;
            }

            var auditoria = this.negocioAuditoria.Obtener(id);
            if (auditoria.Count > 0)
            {
                return true;
            }

            var metricasAgiles = this.negocioMetricaAgil.Consultar(id);
            if (metricasAgiles.Count > 0)
            {
                return true;
            }

            return false;
        }

        private void EnviarNotificacionCambioEstado(string nombreSolucion, string clienteSolucion)
        {

            string subject = Recursos.Lenguaje.SubjectNotificacionEstado;
            string htmlContext = string.Format(Recursos.Lenguaje.MensajeNotificacionEstado,
                nombreSolucion, clienteSolucion);

            List<MailAddress> listaTo = new List<MailAddress>();
            var correos = this.negocioNotificaciones.ConsultarPorId(idTipoNotificacionCambioEstado);

            if (!String.IsNullOrEmpty(correos))
            {
                var listaCorreos = correos.Split(TransversalesConstantes.SeparadorPuntoComa);

                foreach (var itemListaCorreo in listaCorreos)
                {
                    listaTo.Add(new MailAddress(itemListaCorreo));
                }

                if (listaTo.Count > 0)
                {
                    negocioEmail365.EnviarCorreo(subject, htmlContext, listaTo);
                }
            }

        }
    }
}

