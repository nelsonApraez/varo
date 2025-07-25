namespace Varo.Soluciones.Entidades
{
    using System;
    using System.Collections.Generic;

    public class MetricasAgiles
    {
        public int Id { get; set; }

        public Guid IdSolucion { get; set; }

        public Guid IdEquipo { get; set; }

        public string NombreEquipo { get; set; }

        public string Sprint { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public IList<MetricasAgiles> ListaMetricasAgiles { get; set; }
    }
}

