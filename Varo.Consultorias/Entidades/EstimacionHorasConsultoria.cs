namespace Varo.Consultorias.Entidades
{
    using System;
    using System.Collections.Generic;
    using Varo.Transversales.Entidades;

    /// <summary>
    /// Proporciona las propiedades necesarias para la clase EstimacionHoras
    /// </summary>
    public class EstimacionHorasConsultoria : EstimacionHorasBase
    {
        public Guid IdConsultoria { get; set; }
        public IList<EstimacionHorasConsultoria> ListaEstimacionHorasConsultoria { get; set; }
    }
}

