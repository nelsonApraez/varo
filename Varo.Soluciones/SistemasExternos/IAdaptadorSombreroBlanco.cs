
namespace Varo.Soluciones.SistemasExternos
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IAdaptadorSombreroBlanco
    {
        IList<CalificacionSeguridad> ObtenerCalificacionSeguridad(Guid idSolucion);
    }
}

