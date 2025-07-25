CREATE PROCEDURE [dbo].[uspEstimacionHorasSolucionDeletePorId]
	@idSolucion AS uniqueidentifier

    AS BEGIN
        DELETE FROM [dbo].[EstimacionHorasSolucion]
	        WHERE IdSolucion = @idSolucion
    END
GO
