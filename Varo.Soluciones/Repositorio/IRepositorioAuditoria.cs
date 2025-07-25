namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioAuditoria
    {
        IList<CalificacionAuditoria> Obtener(Guid idSolucion);

        CalificacionAuditoria ObtenerUltimaCalificacion(Guid idSolucion);

        void Crear(CalificacionAuditoria auditoria);

        void Editar(CalificacionAuditoria auditoria);

        void Eliminar(Guid idSolucion);
    }
}

