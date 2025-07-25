namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;

    public interface IRepositorioPracticaCalidad
    {
        void Crear(PracticasCalidad practicasCalidad);

        void EliminarPorIdSolucion(Guid idSolucion);

        PracticasCalidad ConsultarPorIdSolucion(Guid idSolucion);
    }
}

