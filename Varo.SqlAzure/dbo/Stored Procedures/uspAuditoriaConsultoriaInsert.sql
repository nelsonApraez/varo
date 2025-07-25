CREATE PROCEDURE [dbo].[uspAuditoriaConsultoriaInsert]
    @idConsultoria          AS UNIQUEIDENTIFIER,	
    @urlAuditoria           AS VARCHAR(255),
    @calificacionAuditoria  AS DECIMAL(18,2),
    @fechaAuditoria         AS SMALLDATETIME,
    @procesoAuditoria       AS VARCHAR(500),
    @observacion            AS VARCHAR(500)
    
    AS BEGIN
        INSERT INTO [dbo].[AuditoriaConsultoria]
	    (
            [Id],
	    	[IdConsultoria],
	    	[Url],
	    	[Calificacion],
	    	[Fecha],
	    	[Proceso],
	    	[Observacion]
        )
        VALUES
        (
            NEWID(),
	    	@idConsultoria,	
	    	@urlAuditoria,
	    	@calificacionAuditoria,
	    	@fechaAuditoria,
	    	@procesoAuditoria,
	    	@observacion
        )
    END
GO
