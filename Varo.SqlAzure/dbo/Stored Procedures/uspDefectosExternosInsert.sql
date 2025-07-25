CREATE PROCEDURE [dbo].[uspDefectosExternosInsert]
	@IdMetricaAgil AS INT,
	@Reportados AS INT,
	@Cerrados AS INT,
	@Actuales AS INT,
	@Abiertos AS INT,
	@Densidad AS DECIMAL(18,2),
	@Observaciones AS VARCHAR(500)

AS

	INSERT INTO [dbo].[DefectosExternos]
			   ([IdMetricaAgil],
				[Reportados],
				[Cerrados],
				[Actuales],
				[Abiertos],
				[Densidad],
				[Observaciones])
		 VALUES
			   (@IdMetricaAgil,
				@Reportados,
				@Cerrados,
				@Actuales,
				@Abiertos,
				@Densidad,
				@Observaciones)
