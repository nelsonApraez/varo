using Varo.Soluciones.Entidades;
using Varo.Transversales.Entidades;
using System;
using System.Collections.Generic;

namespace Varo.Web.Models
{
    public class EstimacionHorasSolucionViewModel : EstimacionHorasBase
    {
        public Guid IdSolucion { get; set; }
        public IList<EstimacionHorasSolucion> ListaEstimacionHorasSolucion { get; set; }
        public EstimacionHorasSolucion EstimacionHorasSolucion { get; set; }
    }
}

