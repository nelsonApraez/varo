using System.Collections.Generic;

namespace Varo.Soluciones.SistemasExternos
{
    using Varo.Soluciones.Entidades;

    public interface IAdaptadorSonarExterno
    {
        IList<Proyecto> ConsultarProyectos();

        IList<Metrica> ConsultarMetricas();

        void CrearValorMetrica(ValorMetricaProyecto valorMetricaProyecto);

        void ActualizarProyecto(Proyecto proyecto);

        void InactivarProyecto(Proyecto proyecto);

        void CrearProyecto(Proyecto proyecto);

        IList<ValorMetrica> ConsultarValorMetricas(int idProyecto);

        IList<Proyecto> ConsultarProyectoPorParametro(FiltroProyecto filtroProyecto);
    }
}

