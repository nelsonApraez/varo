namespace Varo.Consultorias.Negocio
{
    using Varo.Consultorias.Entidades;
    using System;
    using System.Collections.Generic;

    public interface INegocioAuditoria
    {
        IList<CalificacionAuditoria> Obtener(Guid idConsultoria);

        CalificacionAuditoria ObtenerUltimaCalificacion(Guid idConsultoria);

        void Crear(CalificacionAuditoria auditoria);

        void Editar(CalificacionAuditoria auditoria);

        void Eliminar(Guid idConsultoria);
    }
}

