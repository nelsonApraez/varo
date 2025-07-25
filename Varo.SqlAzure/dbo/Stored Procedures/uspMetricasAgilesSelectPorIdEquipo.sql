CREATE PROCEDURE [dbo].[uspMetricasAgilesSelectPorIdEquipo]
	 @idEquipo AS uniqueidentifier
AS

   SELECT
		Id,
		Sprint
	FROM MetricasAgiles
	WHERE IdEquipo = @idEquipo
