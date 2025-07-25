namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Negocio;
    using System;
    using System.Collections.Generic;

    public interface INegocioMonitoreoContinuo : INegocioBase
    {
        void Crear(MonitoreosContinuos monitoreoContinuo);

        void EliminarPorIdSolucion(Guid idSolucion);

        IList<MonitoreosContinuos> ConsultarPorIdSolucion(Guid idSolucion);

    }
}

