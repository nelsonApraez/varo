CREATE PROCEDURE [dbo].[uspIncendiosDeletePorId]
	@idMetricaAgil AS INT

AS

	DELETE FROM [dbo].[Incendios]
	 WHERE IdMetricaAgil = @idMetricaAgil
