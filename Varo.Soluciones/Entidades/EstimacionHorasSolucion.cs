namespace Varo.Soluciones.Entidades
{
    using Varo.Transversales.Entidades;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proporciona las propiedades necesarias para la clase EstimacionHoras
    /// </summary>
    public class EstimacionHorasSolucion : EstimacionHorasBase
    {
        public Guid IdSolucion { get; set; }
        public IList<EstimacionHorasSolucion> ListaEstimacionHorasSolucion { get; set; }
    }
}

