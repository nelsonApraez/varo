namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;

    public interface INegocioDefectoExterno
    {
        DefectosExternos ObtenerPorMetricaAgil(int idMetricaAgil);

        void Crear(DefectosExternos defectosExternos);
    }
}

