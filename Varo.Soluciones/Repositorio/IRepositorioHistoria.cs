namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System.Collections.Generic;

    public interface IRepositorioHistoria
    {
        IList<Historias> ObtenerPorMetricaAgil(int idMetricaAgil);

        void Crear(Historias historias);

        void Eliminar(int idMetricaAgil);
    }
}

