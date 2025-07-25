CREATE PROCEDURE [dbo].[uspMetricasAgilesSelectPorIdSolucion]
	@idSolucion AS uniqueidentifier
AS

    SELECT MetricasAgiles.Id,
		MetricasAgiles.IdSolucion AS IdSolucion,
		MetricasAgiles.Sprint,
		MetricasAgiles.FechaInicial,
		MetricasAgiles.FechaFinal,
		MetricasAgiles.IdEquipo,
		EquipoSolucion.Nombre AS NombreEquipo
	FROM  MetricasAgiles
	LEFT JOIN EquipoSolucion
	ON EquipoSolucion.Id = MetricasAgiles.IdEquipo
   WHERE MetricasAgiles.IdSolucion = @idSolucion
   ORDER BY IdEquipo, FechaInicial ASC
