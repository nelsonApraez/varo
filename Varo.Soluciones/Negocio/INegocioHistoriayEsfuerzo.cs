namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;

    public interface INegocioHistoriayEsfuerzo
    {
        HistoriasyEsfuerzos ObtenerPorMetricaAgil(int idMetricaAgil);

        void Crear(HistoriasyEsfuerzos historiayEsfuerzo);
    }
}

