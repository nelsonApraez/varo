namespace Varo.Maestros.Negocio
{
    using Varo.Maestros.Entidades;
    using Varo.Maestros.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System.Collections.Generic;

    public class NegocioTecnologia : NegocioBase, INegocioTecnologia
    {
        private readonly IRepositorioTecnologia repositorioTecnologia;

        public NegocioTecnologia() :
            this(
                new RepositorioBase(),
                new RepositorioTecnologia())
        { }

        public NegocioTecnologia(
            IRepositorioBase repositorioBase,
            IRepositorioTecnologia repositorioTecnologia) :
            base(repositorioBase)
        {
            this.repositorioTecnologia = repositorioTecnologia;
        }

        public IList<Tecnologia> ConsultarPorTipoDeTecnologia(byte tipoDeTecnologia)
        {
            return this.repositorioTecnologia.ConsultarPorTipoDeTecnologia(tipoDeTecnologia);
        }
    }
}

