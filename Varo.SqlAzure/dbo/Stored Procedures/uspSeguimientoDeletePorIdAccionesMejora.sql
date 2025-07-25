CREATE PROCEDURE [dbo].[uspSeguimientoDeletePorIdAccionesMejora]
	@idAccionesMejora AS INT
AS 

   DELETE FROM Seguimiento
	WHERE IdAccionesMejora = @idAccionesMejora


