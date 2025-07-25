namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;

    public class NegocioTecnologiaSolucion : NegocioBase, INegocioTecnologiaSolucion
    {
        private readonly IRepositorioTecnologiaSolucion repositorioTecnologiaSolucion;

        public NegocioTecnologiaSolucion() :
            this(
                new RepositorioBase(),
                new RepositorioTecnologiaSolucion())
        { }

        public NegocioTecnologiaSolucion(
            IRepositorioBase repositorioBase,
            IRepositorioTecnologiaSolucion repositorioTecnologiaSolucion) :
            base(repositorioBase)
        {
            this.repositorioTecnologiaSolucion = repositorioTecnologiaSolucion;
        }

        public void Crear(TecnologiaSolucion tecnologia)
        {
            this.repositorioTecnologiaSolucion.Crear(tecnologia);
        }

        public void EliminarPorIdSolucion(Guid idSolucion)
        {
            this.repositorioTecnologiaSolucion.EliminarPorIdSolucion(idSolucion);
        }

        public IList<TecnologiaSolucion> ConsultarPorIdSolucion(Guid idSolucion, string lenguaje)
        {
            return this.repositorioTecnologiaSolucion.ConsultarPorIdSolucion(idSolucion, lenguaje);
        }
    }
}

