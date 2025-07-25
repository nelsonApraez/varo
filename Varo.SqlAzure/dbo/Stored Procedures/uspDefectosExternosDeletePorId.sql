CREATE PROCEDURE [dbo].[uspDefectosExternosDeletePorId]
	@idMetricaAgil AS INT

AS

	DELETE FROM [dbo].[DefectosExternos]
	 WHERE IdMetricaAgil = @idMetricaAgil
