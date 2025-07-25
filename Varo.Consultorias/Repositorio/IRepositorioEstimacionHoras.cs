namespace Varo.Consultorias.Repositorio
{
    using Varo.Consultorias.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioEstimacionHoras
    {
        void Crear(EstimacionHorasConsultoria estimacionHorasConsultoria);
        void Eliminar(Guid idConsultoria);
        IList<EstimacionHorasConsultoria> Consultar(Guid idConsultoria);
    }
}

