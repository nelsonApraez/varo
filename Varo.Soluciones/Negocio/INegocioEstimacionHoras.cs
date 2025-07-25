namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Negocio;
    using System;
    using System.Collections.Generic;

    public interface INegocioEstimacionHoras : INegocioBase
    {
        void Crear(EstimacionHorasSolucion estimacionHorasSolucion);
        IList<EstimacionHorasSolucion> Consultar(Guid idSolucion);
    }
}

