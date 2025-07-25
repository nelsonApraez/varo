CREATE PROCEDURE [dbo].[uspHistoriasInsert]
	@IdMetricaAgil AS INT,
	@Numero AS VARCHAR(10),
	@Nombre AS VARCHAR(500),
	@EsfuerzoEstimado AS DECIMAL(18,2),
	@EsfuerzoReal AS DECIMAL(18,2),
	@Observaciones AS VARCHAR(500)

AS

	INSERT INTO [dbo].[Historias]
			   ([IdMetricaAgil],
				[Numero],
				[Nombre],
				[EsfuerzoEstimado],
				[EsfuerzoReal],
				[Observaciones])
		 VALUES
			   (@IdMetricaAgil,
				@Numero,
				@Nombre,
				@EsfuerzoEstimado,
				@EsfuerzoReal,
				@Observaciones)
