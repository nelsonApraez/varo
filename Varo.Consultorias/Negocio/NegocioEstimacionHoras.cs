namespace Varo.Consultorias.Negocio
{
    using Varo.Consultorias.Entidades;
    using Varo.Consultorias.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;

    public class NegocioEstimacionHoras : NegocioBase, INegocioEstimacionHoras
    {
        private readonly IRepositorioEstimacionHoras repositorioEstimacionHorasConsultoria;

        public NegocioEstimacionHoras() : this(new RepositorioBase(), new RepositorioEstimacionHoras())
        { }

        public NegocioEstimacionHoras(
            IRepositorioBase repositorioBase,
            IRepositorioEstimacionHoras repositorioEstimacionHorasConsultoria) :
            base(repositorioBase)
        {
            this.repositorioEstimacionHorasConsultoria = repositorioEstimacionHorasConsultoria;
        }

        public void Crear(EstimacionHorasConsultoria estimacionHorasConsultoria)
        {
            this.repositorioEstimacionHorasConsultoria.Eliminar(estimacionHorasConsultoria.IdConsultoria);
            this.repositorioEstimacionHorasConsultoria.Crear(estimacionHorasConsultoria);
        }

        public IList<EstimacionHorasConsultoria> Consultar(Guid idConsultoria)
        {
            return this.repositorioEstimacionHorasConsultoria.Consultar(idConsultoria);
        }
    }
}

