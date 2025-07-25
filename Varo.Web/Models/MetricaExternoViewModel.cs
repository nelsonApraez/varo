
namespace Varo.Web.Models
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class MetricaExternoViewModel
    {

        public string IdOrigenProyecto { get; set; }

        public IEnumerable<SelectListItem> ListaProyectos { get; set; }

        public int IdProyecto { get; set; }

        public int Ano { get; set; }

        public int Mes { get; set; }

        public DateTime FechaAnalisis { get; set; }

        public IList<Metrica> ListadoMetricas { get; set; }

        public IList<ValorMetrica> ListadoValorMetricasFechas { get; set; }

        public IList<ValorMetrica> ListadoValorMetricas { get; set; }

        public string Vista { get; set; }
    }
}

