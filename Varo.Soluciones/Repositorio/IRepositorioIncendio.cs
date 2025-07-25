namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;

    public interface IRepositorioIncendio
    {
        Incendios ObtenerPorMetricaAgil(int idMetricaAgil);
        void Crear(Incendios incendios);
        void Eliminar(int idMetricaAgil);
    }
}

