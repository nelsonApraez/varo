namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface INegocioMetricaAgil
    {
        IList<MetricasAgiles> Consultar(Guid idSolucion);

        void Crear(MetricasAgiles metricasAgiles);
        void Actualizar(HistoriasyEsfuerzos historiasyEsfuerzos
                              , Historias historias
                              , DefectosInternos defectosInternos
                              , DefectosExternos defectosExternos
                              , Incendios incendios
                              , CalidadCodigo calidadCodigo
                              , AccionesMejora accionesMejora);
        IList<MetricasAgiles> ConsultarPorParametro(Guid idSolucion, string parametro);
    }
}

