CREATE PROCEDURE [dbo].[uspAuditoriaConsultoriaSelectUltimaCalificacionPorId]
    @idConsultoria  AS UNIQUEIDENTIFIER

    AS BEGIN
	    SELECT 
            AuditoriaConsultoria.Id,
			AuditoriaConsultoria.IdConsultoria,
			AuditoriaConsultoria.Url,
			AuditoriaConsultoria.Calificacion,
			AuditoriaConsultoria.Fecha,
			AuditoriaConsultoria.Proceso
        FROM Consultoria
	        LEFT JOIN AuditoriaConsultoria ON AuditoriaConsultoria.IdConsultoria = consultoria.Id
        WHERE consultoria.Id = @idConsultoria
    END
GO
