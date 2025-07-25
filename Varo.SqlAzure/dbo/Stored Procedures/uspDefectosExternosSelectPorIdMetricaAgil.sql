CREATE PROCEDURE [dbo].[uspDefectosExternosSelectPorIdMetricaAgil]
	@IdMetricaAgil AS int
AS

   SELECT DefectosExternos.Id,
		MetricasAgiles.Id AS IdMetricaAgil,
		DefectosExternos.Reportados,
		DefectosExternos.Cerrados,
		DefectosExternos.Actuales,
		DefectosExternos.Abiertos,
		DefectosExternos.Densidad,
		DefectosExternos.Observaciones
	FROM MetricasAgiles
	INNER JOIN DefectosExternos
		ON MetricasAgiles.Id = DefectosExternos.IdMetricaAgil
   WHERE MetricasAgiles.Id = @IdMetricaAgil
