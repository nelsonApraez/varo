CREATE PROCEDURE [dbo].[uspHitoDeletePorIdSolucion]
	@idSolucion AS uniqueidentifier
    
    AS BEGIN
    	DELETE FROM Hitos
    	WHERE IdSolucion = @idSolucion
    END
