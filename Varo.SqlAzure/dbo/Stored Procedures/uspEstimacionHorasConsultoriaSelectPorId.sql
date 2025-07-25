CREATE PROCEDURE [dbo].[uspEstimacionHorasConsultoriaSelectPorId]
	@idConsultoria AS uniqueidentifier

    AS BEGIN
        SELECT 
            [Id],
            [IdConsultoria],
            [Concepto],
            [HorasEstimadas],
            [HorasEjecutadas]
	    FROM [dbo].[EstimacionHorasConsultoria]
	    WHERE [IdConsultoria] = @idConsultoria
    END
GO
