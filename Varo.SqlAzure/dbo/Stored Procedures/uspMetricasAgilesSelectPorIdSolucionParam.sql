CREATE PROCEDURE [dbo].[uspMetricasAgilesSelectPorIdSolucionParam]
	@idSolucion AS uniqueidentifier,
	@ParametroBusqueda AS varchar(50)
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
   AND (
	   MetricasAgiles.Sprint LIKE '%'+@ParametroBusqueda+'%' or
	   EquipoSolucion.Nombre LIKE '%'+@ParametroBusqueda+'%' 
   )
   ORDER BY IdEquipo, Sprint ASC
