CREATE PROCEDURE [dbo].[uspAuditoriaSolucionSelectUltimaCalificacionPorId]
	@idSolucion     AS UNIQUEIDENTIFIER
    
    AS BEGIN
	    SELECT 
            auditoria.Id,
			auditoria.IdSolucion,
			auditoria.Url,
			auditoria.Calificacion,
			auditoria.Fecha,
			auditoria.Proceso
        FROM dbo.Soluciones solucion
            LEFT JOIN AuditoriaSolucion auditoria ON auditoria.idSolucion = solucion.Id
        WHERE solucion.Id = @idSolucion
    END
GO
