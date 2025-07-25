namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;

    public interface INegocioCalidadCodigo
    {
        CalidadCodigo ObtenerPorMetricaAgil(int idMetricaAgil);

        void Crear(CalidadCodigo calidadCodigo);
    }
}

