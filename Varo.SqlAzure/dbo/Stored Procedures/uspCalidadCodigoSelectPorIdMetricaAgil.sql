CREATE PROCEDURE [dbo].[uspCalidadCodigoSelectPorIdMetricaAgil]
	@IdMetricaAgil AS int
AS

   SELECT CalidadCodigo.Id,
		MetricasAgiles.Id AS IdMetricaAgil,
		CalidadCodigo.Bugs,
		CalidadCodigo.Vulnerabilidades,
		CalidadCodigo.DeudaTecnica,
		CalidadCodigo.Cobertura,
		CalidadCodigo.Duplicado,
		CalidadCodigo.Observaciones
	FROM MetricasAgiles
	INNER JOIN CalidadCodigo
		ON MetricasAgiles.Id = CalidadCodigo.IdMetricaAgil
   WHERE MetricasAgiles.Id = @IdMetricaAgil
