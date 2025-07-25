CREATE PROCEDURE [dbo].[uspEstimacionHorasConsultoriaDeletePorId]
	@idConsultoria AS uniqueidentifier

    AS BEGIN
        DELETE FROM [dbo].[EstimacionHorasConsultoria]
	        WHERE IdConsultoria = @idConsultoria
    END
GO
