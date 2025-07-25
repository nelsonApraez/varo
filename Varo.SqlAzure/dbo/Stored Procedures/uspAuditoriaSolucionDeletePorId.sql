CREATE PROCEDURE [dbo].[uspAuditoriaSolucionDeletePorId]
	@idSolucion     AS UNIQUEIDENTIFIER
    
    AS BEGIN
	    DELETE FROM AuditoriaSolucion
	        WHERE IdSolucion = @idSolucion
    END
GO
