namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioEstimacionHoras
    {
        void Crear(EstimacionHorasSolucion estimacionHorasSolucion);

        IList<EstimacionHorasSolucion> Consultar(Guid idSolucion);

        void Eliminar(Guid idSolucion);

    }
}

