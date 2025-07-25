CREATE PROCEDURE [dbo].[uspIncendiosInsert]
	@IdMetricaAgil AS INT,
	@Reportados AS INT,
	@Solucionados AS INT,
	@Observaciones AS VARCHAR(500)

AS

	INSERT INTO [dbo].[Incendios]
			   ([IdMetricaAgil],
				[Reportados],
				[Solucionados],
				[Observaciones])
		 VALUES
			   (@IdMetricaAgil,
				@Reportados,
				@Solucionados,
				@Observaciones)
