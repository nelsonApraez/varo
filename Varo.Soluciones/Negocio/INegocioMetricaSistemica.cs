namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using System;

    public interface INegocioMetricaSistemica
    {
        CalificacionDesempeno ObtenerUltimaCalificacionDesempe�o(Guid idSolucion);

        CalificacionSeguridad ObtenerUltimaCalificacionSeguridad(Guid idSolucion);


    }
}

