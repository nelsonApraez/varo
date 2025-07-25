namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;

    public interface IRepositorioHistoriayEsfuerzo
    {
        HistoriasyEsfuerzos ObtenerPorMetricaAgil(int idMetricaAgil);

        void Crear(HistoriasyEsfuerzos historiayEsfuerzo);

        void Eliminar(int idMetricaAgil);
    }
}

