CREATE PROCEDURE [dbo].[uspCalidadCodigoInsert]
	@IdMetricaAgil AS INT,
	@Bugs AS INT,
	@Vulnerabilidades AS INT,
	@DeudaTecnica AS DECIMAL(18,2),
	@Cobertura AS DECIMAL(18,2),
	@Duplicado AS DECIMAL(18,2),
	@Observaciones AS VARCHAR(500)

AS

	INSERT INTO [dbo].[CalidadCodigo]
			   ([IdMetricaAgil],
				Bugs,
				Vulnerabilidades,
				DeudaTecnica,
				Cobertura,
				Duplicado,
				[Observaciones])
		 VALUES
			   (@IdMetricaAgil,
				@Bugs,
				@Vulnerabilidades,
				@DeudaTecnica,
				@Cobertura,
				@Duplicado,
				@Observaciones)
