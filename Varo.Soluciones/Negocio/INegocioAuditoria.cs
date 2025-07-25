namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface INegocioAuditoria
    {
        IList<CalificacionAuditoria> Obtener(Guid idSolucion);
        CalificacionAuditoria ObtenerUltimaCalificacion(Guid idSolucion);
        void Actualizar(CalificacionAuditoria auditoria);
        void Crear(CalificacionAuditoria auditoria);
        void Editar(CalificacionAuditoria auditoria);
        void Eliminar(Guid idSolucion);
    }
}

