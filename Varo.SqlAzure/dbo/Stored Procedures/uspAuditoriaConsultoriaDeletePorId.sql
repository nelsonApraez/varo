CREATE PROCEDURE [dbo].[uspAuditoriaConsultoriaDeletePorId]
    @idConsultoria  AS UNIQUEIDENTIFIER
    
    AS BEGIN
	    DELETE FROM AuditoriaConsultoria
	        WHERE IdConsultoria = @idConsultoria
    END
GO
