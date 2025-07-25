
namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioEquipoSolucion
    {
        IList<EquipoSolucion> Consultar(Guid idSolucion);

        void Crear(EquipoSolucion equipoSolucion);

        void Editar(EquipoSolucion equipoSolucion);

        void Eliminar(Guid idEquipo);

        void EliminarPorIdSolucion(Guid idSolucion);

        IList<MetricasAgiles> ConsultarMetricaPorIdEquipo(Guid idEquipo);
    }
}

