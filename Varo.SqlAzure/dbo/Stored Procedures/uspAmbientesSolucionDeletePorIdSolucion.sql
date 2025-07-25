CREATE PROCEDURE [dbo].[uspAmbientesSolucionDeletePorIdSolucion]
	@idSolucion AS uniqueidentifier

    AS BEGIN
    	DELETE FROM [dbo].[AmbientesSolucion]
    	WHERE IdSolucion = @idSolucion
    END
