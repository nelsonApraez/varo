namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;

    public interface INegocioDefectoInterno
    {
        DefectosInternos ObtenerPorMetricaAgil(int idMetricaAgil);

        void Crear(DefectosInternos defectosInternos);
    }
}

