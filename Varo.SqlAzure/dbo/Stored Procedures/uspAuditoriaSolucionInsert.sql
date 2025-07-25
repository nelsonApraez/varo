CREATE PROCEDURE [dbo].[uspAuditoriaSolucionInsert]
	@idSolucion             AS UNIQUEIDENTIFIER,	
	@urlAuditoria           AS VARCHAR(255),
	@calificacionAuditoria  AS DECIMAL(18,2),
	@fechaAuditoria         AS SMALLDATETIME,
	@procesoAuditoria       AS VARCHAR(500),
	@observacion            AS VARCHAR(500)
    
    AS BEGIN
        INSERT INTO [dbo].[AuditoriaSolucion]
		(
            [Id],
			[IdSolucion],
			[Url],
			[Calificacion],
			[Fecha],
			[Proceso],
			[Observacion]
        )
        VALUES
        (
            NEWID(),
			@idSolucion,	
			@urlAuditoria,
			@calificacionAuditoria,
			@fechaAuditoria,
			@procesoAuditoria,
			@observacion
        )
    END
GO
