namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioMetricaAgil
    {
        IList<MetricasAgiles> Consultar(Guid idSolucion);
        void Crear(MetricasAgiles metricasAgiles);
        void Actualizar(MetricasAgiles metricasAgiles);
        void Eliminar(int idMetricaAgil);
        IList<MetricasAgiles> ConsultarPorParametro(Guid idSolucion, string parametro);
    }
}

