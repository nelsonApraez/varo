namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Negocio;
    using System;
    using System.Collections.Generic;

    public interface INegocioInspeccionContinua : INegocioBase
    {
        IList<InspeccionesContinuas> Consultar();
        ValorMetricaSolucion ConsultarValorMetricaPorSolucion(Guid idSolucion);

    }
}

