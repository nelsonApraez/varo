CREATE PROCEDURE [dbo].[uspSeguimientoSelectPorIdAccionesMejora]
@IdAccionesMejora AS INT
AS

   SELECT Seguimiento.Id,
		AccionesMejora.Id AS IdAccionesMejora,
		Seguimiento.Observacion,
		Seguimiento.Fecha,
		Seguimiento.Usuario
	FROM AccionesMejora
	INNER JOIN Seguimiento
		ON AccionesMejora.Id = Seguimiento.IdAccionesMejora
   WHERE AccionesMejora.Id = @IdAccionesMejora
