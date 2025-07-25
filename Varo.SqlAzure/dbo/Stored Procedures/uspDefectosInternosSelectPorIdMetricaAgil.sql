CREATE PROCEDURE [dbo].[uspDefectosInternosSelectPorIdMetricaAgil]
	@IdMetricaAgil AS int
AS

   SELECT DefectosInternos.Id,
		MetricasAgiles.Id AS IdMetricaAgil,
		DefectosInternos.Reportados,
		DefectosInternos.Cerrados,
		DefectosInternos.Actuales,
		DefectosInternos.Abiertos,
		DefectosInternos.Observaciones
	FROM MetricasAgiles
	INNER JOIN DefectosInternos
		ON MetricasAgiles.Id = DefectosInternos.IdMetricaAgil
   WHERE MetricasAgiles.Id = @IdMetricaAgil
