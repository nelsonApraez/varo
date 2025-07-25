CREATE PROCEDURE [dbo].[uspMarcosTrabajoSelectPorIdMetricasAgiles]
	@IdMetricaAgil AS INT
AS
BEGIN   
    SELECT  marcoTrabajo.Nombre, marcoTrabajo.Id
	FROM dbo.Soluciones solucion
	inner join dbo.MarcosTrabajo marcoTrabajo
			on solucion.IdMarcoTrabajo = marcoTrabajo.Id	
	inner join dbo.MetricasAgiles  metricaAgil
			on solucion.Id = metricaAgil.IdSolucion
	WHERE metricaAgil.Id = @IdMetricaAgil
END
GO
