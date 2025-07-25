namespace Varo.Soluciones.SistemasExternos
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IAdaptadorInspeccionTecnica
    {
        IList<InspeccionesContinuas> ConsultarProyectos();
        ValorMetricaSolucion ConsultarValorMetricaPorSolucion(Guid idSolucion);
    }
}

