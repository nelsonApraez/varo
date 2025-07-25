namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;

    public interface IRepositorioCalidadCodigo
    {
        CalidadCodigo ObtenerPorMetricaAgil(int idMetricaAgil);

        void Crear(CalidadCodigo calidadCodigo);

        void Eliminar(int idMetricaAgil);
    }
}

