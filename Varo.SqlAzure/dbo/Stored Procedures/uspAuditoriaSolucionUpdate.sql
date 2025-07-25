CREATE PROCEDURE [dbo].[uspAuditoriaSolucionUpdate]
	@idSolucion             AS UNIQUEIDENTIFIER,	
	@urlAuditoria           AS VARCHAR(255),
	@calificacionAuditoria  AS DECIMAL(18,2),
	@fechaAuditoria         AS SMALLDATETIME,
	@procesoAuditoria       AS VARCHAR(500)
    
    AS BEGIN
        UPDATE [dbo].[AuditoriaSolucion]
            SET [Url] = @urlAuditoria,
	            [Calificacion] = @calificacionAuditoria,
	            [Fecha] = @fechaAuditoria,
	            [Proceso] = @procesoAuditoria
            WHERE [IdSolucion] = @idSolucion
    END
GO
