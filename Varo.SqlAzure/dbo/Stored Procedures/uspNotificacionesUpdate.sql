CREATE PROCEDURE [dbo].[uspNotificacionesUpdate]
	@id AS tinyint,
	@valor AS VARCHAR(300)

AS

	UPDATE [dbo].[Notificaciones]
	   SET Valor = @valor
     WHERE Id=@id
