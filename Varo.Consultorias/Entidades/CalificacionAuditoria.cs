namespace Varo.Consultorias.Entidades
{
    using Varo.Transversales.Entidades;
    using System;
    using System.Collections.Generic;

    public class CalificacionAuditoria : CalificacionBase
    {
        public Guid IdConsultoria { get; set; }
        public string Proceso { get; set; }
        public IList<CalificacionAuditoria> ListaCalificacionAuditorias { get; set; }
    }
}

