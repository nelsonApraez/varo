CREATE PROCEDURE [dbo].[uspNotificacionesSelect]
AS
	
	SELECT Id,
		   Valor,
		   Nombre,
		   NombreEN 
	FROM Notificaciones
