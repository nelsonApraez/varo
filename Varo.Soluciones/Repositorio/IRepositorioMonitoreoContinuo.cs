namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioMonitoreoContinuo
    {
        void Crear(MonitoreosContinuos monitoreoContinuo);

        void EliminarPorIdSolucion(Guid idSolucion);

        IList<MonitoreosContinuos> ConsultarPorIdSolucion(Guid idSolucion);
    }
}

