CREATE PROCEDURE [dbo].[uspDefectosInternosDeletePorId]
	@idMetricaAgil AS INT

AS

	DELETE FROM [dbo].[DefectosInternos]
	 WHERE IdMetricaAgil = @idMetricaAgil
