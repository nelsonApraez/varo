CREATE PROCEDURE [dbo].[uspEstimacionHorasSolucionSelectPorId]
	@idSolucion AS uniqueidentifier

    AS BEGIN
        SELECT 
            [Id],
            [IdSolucion],
            [Concepto],
            [HorasEstimadas],
            [HorasEjecutadas]
	    FROM [dbo].[EstimacionHorasSolucion]
	    WHERE [IdSolucion] = @idSolucion
    END
GO
