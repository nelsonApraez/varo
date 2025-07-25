namespace Varo.Soluciones.Entidades
{
    using System;
    using System.Collections.Generic;
    using Varo.Transversales.Entidades;

    public class CalificacionAuditoria : CalificacionBase
    {
        public Guid IdSolucion { get; set; }
        public string Proceso { get; set; }
        public IList<CalificacionAuditoria> ListaCalificacionAuditorias { get; set; }

    }
}

