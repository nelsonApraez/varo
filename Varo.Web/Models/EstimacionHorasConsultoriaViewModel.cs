using Varo.Consultorias.Entidades;
using Varo.Transversales.Entidades;
using System;
using System.Collections.Generic;

namespace Varo.Web.Models
{
    public class EstimacionHorasConsultoriaViewModel : EstimacionHorasBase
    {
        public Guid IdConsultoria { get; set; }
        public IList<EstimacionHorasConsultoria> ListaEstimacionHorasConsultoria { get; set; }
        public EstimacionHorasConsultoria EstimacionHorasConsultoria { get; set; }
    }
}

