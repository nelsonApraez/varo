CREATE PROCEDURE [dbo].[uspHistoriasyEsfuerzosInsert]
	@IdMetricaAgil AS INT,
	@HistoriasEstimadas AS INT,
	@HistoriasLogradas AS INT,
	@EsfuerzoEstimado AS DECIMAL(18,2),
	@EsfuerzoLogrado AS DECIMAL(18,2),
	@Observaciones AS VARCHAR(500)

AS

	INSERT INTO [dbo].[HistoriasyEsfuerzos]
			   ([IdMetricaAgil],
				[HistoriasEstimadas],
				[HistoriasLogradas],
				[EsfuerzoEstimado],
				[EsfuerzoLogrado],
				[Observaciones])
		 VALUES
			   (@IdMetricaAgil,
				@HistoriasEstimadas,
				@HistoriasLogradas,
				@EsfuerzoEstimado,
				@EsfuerzoLogrado,
				@Observaciones)
