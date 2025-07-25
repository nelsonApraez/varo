namespace Varo.Consultorias.Negocio
{
    using Varo.Consultorias.Entidades;
    using Varo.Transversales.Negocio;
    using System;
    using System.Collections.Generic;

    public interface INegocioEstimacionHoras : INegocioBase
    {
        void Crear(EstimacionHorasConsultoria estimacionHorasConsultoria);
        IList<EstimacionHorasConsultoria> Consultar(Guid idConsultoria);
    }
}

