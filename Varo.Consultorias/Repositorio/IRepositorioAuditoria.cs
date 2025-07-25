namespace Varo.Consultorias.Repositorio
{
    using Varo.Consultorias.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioAuditoria
    {
        IList<CalificacionAuditoria> Obtener(Guid idConsultoria);
        CalificacionAuditoria ObtenerUltimaCalificacion(Guid idConsultoria);
        void Crear(CalificacionAuditoria auditoria);
        void Editar(CalificacionAuditoria auditoria);
        void Eliminar(Guid idConsultoria);
    }
}

