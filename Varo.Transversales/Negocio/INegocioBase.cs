namespace Varo.Transversales.Negocio
{
    using Varo.Transversales.Entidades;
    using System.Collections.Generic;

    public interface INegocioBase
    {
        IEnumerable<ItemMaestro> ConsultarPorMaestro(string nombreMaestro, string lenguaje);
        ItemMaestro ConsultarPorMaestroId(string nombreMaestro, byte id, string lenguaje);
    }
}

