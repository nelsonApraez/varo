namespace Varo.Maestros.Negocio
{
    using Varo.Maestros.Repositorio;
    using Varo.Transversales.Entidades;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System.Collections.Generic;

    public class NegocioOficinas : NegocioBase, INegocioOficinas
    {
        private readonly IRepositorioOficinas repositorioOficina;

        public NegocioOficinas() :
            this(
                new RepositorioBase(),
                new RepositorioOficinas())
        { }

        public NegocioOficinas(
            IRepositorioBase repositorioBase,
            IRepositorioOficinas repositorioOficina) :
            base(repositorioBase)
        {
            this.repositorioOficina = repositorioOficina;
        }

        public IList<ItemMaestro> ConsultarOficinaPorIdGsdc(byte idGsdc)
        {
            var listaOficinas = this.repositorioOficina.ConsultarOficinaPorIdGsdc(idGsdc);

            return listaOficinas;
        }
    }
}

