namespace Varo.Transversales.Repositorio
{
    using Varo.Transversales.Entidades;
    using System.Collections.Generic;

    public interface IRepositorioBase
    {
        IEnumerable<ItemMaestro> ConsultarPorMaestro(string nombreMaestro, string lenguaje);
        ItemMaestro ConsultarPorMaestroId(string nombreMaestro, byte id, string lenguaje);
    }
}

