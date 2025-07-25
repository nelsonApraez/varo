namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;

    public interface IRepositorioDefectoInterno
    {
        DefectosInternos ObtenerPorMetricaAgil(int idMetricaAgil);

        void Crear(DefectosInternos defectosInternos);

        void Eliminar(int idMetricaAgil);
    }
}

