namespace Varo.Consultorias.Negocio
{
    using Varo.Consultorias.Entidades;
    using Varo.Consultorias.Repositorio;
    using Varo.Maestros.Entidades;
    using Varo.Maestros.Negocio;
    using Varo.Transversales.Excepciones;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Transactions;

    public class NegocioConsultoria : NegocioBase, INegocioConsultoria
    {
        private readonly IRepositorioConsultoria repositorioConsultoria;
        private readonly IRepositorioTecnologiaConsultoria repositorioTecnologiaConsultoria;
        private readonly INegocioUsuarios negocioUsuarios;
        private readonly INegocioClientes negocioClientes;
        private readonly INegocioLocalizacion negocioLocalizacion;

        public NegocioConsultoria() :
            this(
                new RepositorioBase(),
                new RepositorioConsultoria(),
                new NegocioUsuarios(),
                new NegocioClientes(),
                new NegocioLocalizacion(),
                new RepositorioTecnologiaConsultoria())
        { }

        public NegocioConsultoria(
            IRepositorioBase repositorioBase,
            IRepositorioConsultoria repositorioConsultoria,
            INegocioUsuarios negocioUsuarios,
            INegocioClientes negocioClientes,
            INegocioLocalizacion negocioLocalizacion,
            IRepositorioTecnologiaConsultoria repositorioTecnologiaConsultoria) :
            base(repositorioBase)
        {
            this.repositorioConsultoria = repositorioConsultoria;
            this.negocioUsuarios = negocioUsuarios;
            this.negocioClientes = negocioClientes;
            this.negocioLocalizacion = negocioLocalizacion;
            this.repositorioTecnologiaConsultoria = repositorioTecnologiaConsultoria;
        }

        public IList<ConsultoriaInformacionBasica> Consultar(int numeroPagina, int tamanoPagina, string CheckEnEjecucion)
        {
            IList<ConsultoriaInformacionBasica> listaConsultoria;

            listaConsultoria = this.repositorioConsultoria.Consultar(numeroPagina, tamanoPagina, CheckEnEjecucion);

            foreach (ConsultoriaInformacionBasica consultoria in listaConsultoria)
            {
                consultoria.Cliente.Name = negocioClientes.ObtenerClientePorId(consultoria.Cliente.Id).Name;

                if (consultoria.UsuarioRedGerente != null)
                {
                    var nombreGerente = negocioUsuarios.ObtenerInformacionUsuario(consultoria.UsuarioRedGerente).DisplayName;
                    consultoria.NombreGerente = !string.IsNullOrEmpty(nombreGerente) ? nombreGerente : consultoria.UsuarioRedGerente;

                }

                if (consultoria.UsuarioRedConsultor != null)
                {
                    var nombreConsultor = negocioUsuarios.ObtenerInformacionUsuario(consultoria.UsuarioRedConsultor).DisplayName;
                    consultoria.NombreConsultor = !string.IsNullOrEmpty(nombreConsultor) ? nombreConsultor : consultoria.UsuarioRedConsultor;
                }
            }

            return listaConsultoria;
        }

        public IList<ConsultoriaInformacionBasica> ConsultarPorParametro(int numeroPagina, int tamanoPagina,
                                           string valorDeBusqueda, string CheckEnEjecucion)
        {
            string[] vectorDeBusqueda = new string[4];

            vectorDeBusqueda[0] = valorDeBusqueda;

            vectorDeBusqueda[1] = String.Join(",", this.negocioLocalizacion.ObtenerIdCiudadPorNombre(valorDeBusqueda));

            vectorDeBusqueda[2] = String.Join(",", this.negocioClientes.ObtenerIdClientePorNombre(valorDeBusqueda));

            vectorDeBusqueda[3] = String.Join(",", this.negocioLocalizacion.ObtenerIdPaisPorNombre(valorDeBusqueda));

            IList<ConsultoriaInformacionBasica> listaConsultorias;

            listaConsultorias = this.repositorioConsultoria.ConsultarPorParametro(numeroPagina, tamanoPagina,
                                                                  vectorDeBusqueda, CheckEnEjecucion);

            foreach (ConsultoriaInformacionBasica consultoria in listaConsultorias)
            {
                consultoria.Cliente.Name = negocioClientes.ObtenerClientePorId(consultoria.Cliente.Id).Name;

                if (consultoria.UsuarioRedGerente != null)
                {
                    consultoria.NombreGerente = negocioUsuarios.ObtenerInformacionUsuario(consultoria.UsuarioRedGerente).DisplayName;
                }

                if (consultoria.UsuarioRedConsultor != null)
                {
                    consultoria.NombreConsultor = negocioUsuarios.ObtenerInformacionUsuario(consultoria.UsuarioRedConsultor).DisplayName;
                }
            }

            return listaConsultorias;
        }

        public IList<Consultoria> Consultar()
        {
            var listaConsultorias = this.repositorioConsultoria.Consultar();

            foreach (Consultoria consultoria in listaConsultorias)
            {
                consultoria.Cliente.Name = negocioClientes.ObtenerClientePorId(consultoria.Cliente.Id).Name;

            }

            return listaConsultorias;
        }

        public IList<Consultoria> Listar()
        {
            var listaConsultorias = this.repositorioConsultoria.Listar();

            foreach (Consultoria consultoria in listaConsultorias)
            {
                consultoria.Cliente.Name = negocioClientes.ObtenerClientePorId(consultoria.Cliente.Id).Name;

            }

            return listaConsultorias;
        }

        public Consultoria Obtener(Guid id)
        {
            Consultoria consultoria;

            consultoria = this.repositorioConsultoria.Obtener(id);

            if (consultoria.Nombre != null)
            {
                consultoria.Cliente.Name = negocioClientes.ObtenerClientePorId(consultoria.Cliente.Id).Name;
                consultoria.Pais.Nombre = negocioLocalizacion.ObtenerPaisPorId(consultoria.Pais.Id).Name;
            }

            return consultoria;
        }

        public void Crear(Consultoria consultoria,
            TecnologiaConsultoria tecnologiaPorConsultoria)
        {
            Guid idConsultoriaCreada;
            if (!this.ValidarExisteUsuarios(consultoria))
            {
                throw new NegocioExcepcion(Recursos.Lenguaje.MensajeErrorUsuarioNoExiste);
            }

            using (TransactionScope transactionScope = new TransactionScope())
            {
                idConsultoriaCreada = this.repositorioConsultoria.Crear(consultoria);

                if (tecnologiaPorConsultoria != null)
                {
                    tecnologiaPorConsultoria.IdConsultoria = idConsultoriaCreada;
                    this.repositorioTecnologiaConsultoria.Crear(tecnologiaPorConsultoria);
                }

                transactionScope.Complete();
            }
        }

        public void Editar(Consultoria consultoria,
            TecnologiaConsultoria tecnologiaPorConsultoria)
        {
            if (!this.ValidarExisteUsuarios(consultoria))
            {
                throw new NegocioExcepcion(Recursos.Lenguaje.MensajeErrorUsuarioNoExiste);
            }

            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.repositorioConsultoria.Editar(consultoria);

                this.repositorioTecnologiaConsultoria.EliminarPorIdConsultoria(consultoria.Id);
                this.repositorioTecnologiaConsultoria.Crear(tecnologiaPorConsultoria);

                transactionScope.Complete();
            }
        }

        public void Eliminar(Guid id)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.repositorioTecnologiaConsultoria.EliminarPorIdConsultoria(id);
                this.repositorioConsultoria.Eliminar(id);

                transactionScope.Complete();
            }
        }

        private bool ValidarExisteUsuarios(Consultoria consultoria)
        {

            if (consultoria != null && consultoria.UsuarioRedGerente != null)
            {
                Usuario usuarioGerente = this.negocioUsuarios.ObtenerInformacionUsuario(consultoria.UsuarioRedGerente);
                if (string.IsNullOrEmpty(usuarioGerente.DisplayName))
                    return false;
            }

            if (consultoria != null && consultoria.UsuarioRedConsultor != null)
            {
                Usuario usuarioConsultor = this.negocioUsuarios.ObtenerInformacionUsuario(consultoria.UsuarioRedConsultor);
                if (string.IsNullOrEmpty(usuarioConsultor.DisplayName))
                    return false;
            }

            return true;
        }
    }
}

