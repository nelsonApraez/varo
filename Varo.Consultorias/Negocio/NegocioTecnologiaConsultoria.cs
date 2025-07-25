namespace Varo.Consultorias.Negocio
{
    using Varo.Consultorias.Entidades;
    using Varo.Consultorias.Repositorio;
    using Varo.Maestros.Entidades;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;

    public class NegocioTecnologiaConsultoria : NegocioBase, INegocioTecnologiaConsultoria
    {
        private readonly IRepositorioTecnologiaConsultoria repositorioTecnologiaConsultoria;

        public NegocioTecnologiaConsultoria() :
            this(
                new RepositorioBase(),
                new RepositorioTecnologiaConsultoria())
        { }

        public NegocioTecnologiaConsultoria(
            IRepositorioBase repositorioBase,
            IRepositorioTecnologiaConsultoria repositorioTecnologiaConsultoria) :
            base(repositorioBase)
        {
            this.repositorioTecnologiaConsultoria = repositorioTecnologiaConsultoria;
        }

        public void Crear(TecnologiaConsultoria tecnologiaConsultoria)
        {
            this.repositorioTecnologiaConsultoria.Crear(tecnologiaConsultoria);
        }

        public IList<Tecnologia> ConsultarPorIdConsultoria(Guid idConsultoria)
        {
            return this.repositorioTecnologiaConsultoria.ConsultarPorIdConsultoria(idConsultoria);
        }

        public void EliminarPorIdConsultoria(Guid idConsultoria)
        {
            this.repositorioTecnologiaConsultoria.EliminarPorIdConsultoria(idConsultoria);
        }
    }
}

