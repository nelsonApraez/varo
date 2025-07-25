
namespace Varo.Soluciones.Entidades
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proporciona las propiedades necesarias para la clase MonitoreoContinuo
    /// </summary>
    public class MonitoreosContinuos
    {
        public Guid Id { get; set; }

        public Guid IdSolucion { get; set; }

        public string Nombre { get; set; }

        public string UrlMonitoreo { get; set; }

        public IList<MonitoreosContinuos> ListaMonitoreosContinuos { get; set; }
    }
}

