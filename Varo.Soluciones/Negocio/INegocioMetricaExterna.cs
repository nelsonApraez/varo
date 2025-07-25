
namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using System.Collections.Generic;

    public interface INegocioMetricaExterna
    {
        IList<Metrica> ConsultarMetricas();

        void CrearValorMetrica(ValorMetricaProyecto valorMetricaProyecto);

        IList<ValorMetrica> ConsultarValorMetricaPorProyecto(int idProyecto);

    }
}

