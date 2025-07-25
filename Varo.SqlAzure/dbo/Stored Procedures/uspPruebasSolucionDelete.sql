CREATE PROCEDURE [dbo].[uspPruebasSolucionDelete]
	@id AS uniqueidentifier
AS

	DELETE FROM PruebasSolucion
	WHERE Id = @id
