CREATE PROCEDURE [dbo].[uspAuditoriaSolucionSelectPorId]
    @idSolucion     AS UNIQUEIDENTIFIER
    
    AS BEGIN
        SELECT 
            AuditoriaSolucion.Id,
		    Soluciones.Id AS IdSolucion,
		    AuditoriaSolucion.Url,
		    AuditoriaSolucion.Calificacion,
		    AuditoriaSolucion.Fecha,
		    AuditoriaSolucion.Proceso,
		    AuditoriaSolucion.Observacion
            FROM Soluciones Soluciones
	            INNER JOIN AuditoriaSolucion AuditoriaSolucion ON Soluciones.Id = AuditoriaSolucion.IdSolucion
            WHERE Soluciones.Id = @idSolucion
            ORDER BY Fecha DESC
    END
GO
