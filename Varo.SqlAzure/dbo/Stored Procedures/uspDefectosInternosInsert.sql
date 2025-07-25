CREATE PROCEDURE [dbo].[uspDefectosInternosInsert]
	@IdMetricaAgil AS INT,
	@Reportados AS INT,
	@Cerrados AS INT,
	@Actuales AS INT,
	@Abiertos AS INT,
	@Observaciones AS VARCHAR(500)

AS

	INSERT INTO [dbo].[DefectosInternos]
			   ([IdMetricaAgil],
				[Reportados],
				[Cerrados],
				[Actuales],
				[Abiertos],
				[Observaciones])
		 VALUES
			   (@IdMetricaAgil,
				@Reportados,
				@Cerrados,
				@Actuales,
				@Abiertos,
				@Observaciones)
