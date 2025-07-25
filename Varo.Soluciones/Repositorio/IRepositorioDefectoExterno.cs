namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;

    public interface IRepositorioDefectoExterno
    {
        DefectosExternos ObtenerPorMetricaAgil(int idMetricaAgil);

        void Crear(DefectosExternos defectosExternos);

        void Eliminar(int idMetricaAgil);
    }
}

