namespace Varo.Transversales.Negocio
{
    using Varo.Transversales.Entidades;
    using Varo.Transversales.Repositorio;
    using System.Collections.Generic;

    public class NegocioBase : INegocioBase
    {
        private readonly IRepositorioBase repositorioBase;

        public NegocioBase() :
            this(new RepositorioBase())
        { }

        public NegocioBase(IRepositorioBase repositorioBase)
        {
            this.repositorioBase = repositorioBase;
        }

        public IEnumerable<ItemMaestro> ConsultarPorMaestro(string nombreMaestro, string lenguaje)
        {
            return this.repositorioBase.ConsultarPorMaestro(nombreMaestro, lenguaje);
        }

        public ItemMaestro ConsultarPorMaestroId(string nombreMaestro, byte id, string lenguaje)
        {
            return this.repositorioBase.ConsultarPorMaestroId(nombreMaestro, id, lenguaje);
        }
    }
}

