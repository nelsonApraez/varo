namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;

    public interface INegocioIncendio
    {
        Incendios ObtenerPorMetricaAgil(int idMetricaAgil);

        void Crear(Incendios incendios);
    }
}

