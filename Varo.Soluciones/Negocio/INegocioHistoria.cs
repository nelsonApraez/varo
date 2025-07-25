namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using System.Collections.Generic;

    public interface INegocioHistoria
    {
        IList<Historias> ObtenerPorMetricaAgil(int idMetricaAgil);

        void Crear(Historias historias);
    }
}

