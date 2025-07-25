
namespace Varo.Soluciones.Entidades
{
    using System;
    using System.Collections.Generic;
    public class ValorMetricaProyecto
    {
        public Proyecto Proyecto { get; set; }

        public int Ano { get; set; }

        public int Mes { get; set; }

        public DateTime FechaAnalisis { get; set; }

        public IList<ValorMetricaExterna> ListadoValorMetrica { get; set; }
    }
}

