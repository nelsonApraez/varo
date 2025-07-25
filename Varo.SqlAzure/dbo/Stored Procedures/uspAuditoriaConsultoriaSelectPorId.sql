CREATE PROCEDURE [dbo].[uspAuditoriaConsultoriaSelectPorId]
    @idConsultoria  AS UNIQUEIDENTIFIER
    
    AS BEGIN
        SELECT 
            AuditoriaConsultoria.Id,
		    Consultoria.Id AS IdConsultoria,
		    AuditoriaConsultoria.Url,
		    AuditoriaConsultoria.Calificacion,
		    AuditoriaConsultoria.Fecha,
		    AuditoriaConsultoria.Proceso,
		    AuditoriaConsultoria.Observacion
        FROM Consultoria
	        INNER JOIN AuditoriaConsultoria ON Consultoria.Id = AuditoriaConsultoria.IdConsultoria
        WHERE Consultoria.Id = @idConsultoria
        ORDER BY Fecha DESC
    END
GO
