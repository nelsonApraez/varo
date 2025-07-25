namespace Varo.Soluciones.Negocio
{
    using Varo.Maestros.Entidades;
    using Varo.Maestros.Negocio;
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;

    public class NegocioPrueba : NegocioBase, INegocioPrueba
    {
        private readonly IRepositorioPrueba repositorioPrueba;
        private readonly INegocioUsuarios negocioUsuario;

        public NegocioPrueba() :
            this(
                new RepositorioBase(),
                new RepositorioPrueba(),
                new NegocioUsuarios())
        { }

        public NegocioPrueba(
            IRepositorioBase repositorioBase,
            IRepositorioPrueba repositorioPrueba,
            INegocioUsuarios negocioUsuario) : base(repositorioBase)
        {
            this.repositorioPrueba = repositorioPrueba;
            this.negocioUsuario = negocioUsuario;
        }

        public IList<Prueba> Consultar()
        {
            IList<Prueba> listaPrueba;

            listaPrueba = this.repositorioPrueba.Consultar();

            foreach (Prueba prueba in listaPrueba)
            {
                prueba.CasosPendientes = this.CalcularCasosPendientes(prueba.CasosDefinidos, prueba.CasosAutomatizados);

                if (prueba.UsuarioRedTecnico != null)
                {
                    prueba.NombreTecnico = this.ObtenerNombrePorUsuarioRed(prueba.UsuarioRedTecnico);
                }
            }

            return listaPrueba;
        }

        public Prueba ConsultarPorIdSolucion(Guid idSolucion)
        {
            Prueba prueba;

            prueba = this.repositorioPrueba.ConsultarPorIdSolucion(idSolucion);
            prueba.CasosPendientes = this.CalcularCasosPendientes(prueba.CasosDefinidos, prueba.CasosAutomatizados);

            if (prueba.UsuarioRedTecnico != null)
            {
                prueba.NombreTecnico = this.ObtenerNombrePorUsuarioRed(prueba.UsuarioRedTecnico);
            }

            return prueba;
        }

        public Prueba Obtener(Guid id)
        {
            Prueba prueba;

            prueba = this.repositorioPrueba.Obtener(id);
            prueba.CasosPendientes = this.CalcularCasosPendientes(prueba.CasosDefinidos, prueba.CasosAutomatizados);

            if (prueba.UsuarioRedTecnico != null)
            {
                prueba.NombreTecnico = this.ObtenerNombrePorUsuarioRed(prueba.UsuarioRedTecnico);
            }

            return prueba;
        }

        public void Crear(Prueba prueba)
        {
            this.repositorioPrueba.Crear(prueba);
        }

        public void Editar(Prueba prueba)
        {
            if (prueba.Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(prueba.Id));
            }

            this.repositorioPrueba.Editar(prueba);
        }

        public void Eliminar(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            this.repositorioPrueba.Eliminar(id);
        }

        private int CalcularCasosPendientes(int casosDefinidos, int casosAutomatizados)
        {
            return casosDefinidos - casosAutomatizados;
        }

        private string ObtenerNombrePorUsuarioRed(string usuarioRed)
        {
            Usuario usuario;
            usuario = this.negocioUsuario.ObtenerInformacionUsuario(usuarioRed);
            return usuario.DisplayName;
        }
    }
}

