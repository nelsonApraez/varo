namespace Varo.Maestros.Negocio
{
    using Varo.Transversales.Entidades;
    using System.Collections.Generic;

    public interface INegocioOficinas
    {
        IList<ItemMaestro> ConsultarOficinaPorIdGsdc(byte idGsdc);
    }
}

