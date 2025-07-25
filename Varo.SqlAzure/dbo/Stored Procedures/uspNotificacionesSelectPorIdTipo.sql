CREATE PROCEDURE [dbo].[uspNotificacionesSelectPorIdTipo]
@Id as int
AS
	
	SELECT Id,
		   Valor
	FROM Notificaciones
	WHERE Id = @Id
