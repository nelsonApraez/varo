namespace Varo.Maestros.Repositorio
{
    using Varo.Transversales.Entidades;
    using System.Collections.Generic;

    public interface IRepositorioOficinas
    {
        IList<ItemMaestro> ConsultarOficinaPorIdGsdc(byte idGsdc);
    }
}

