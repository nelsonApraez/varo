CREATE PROCEDURE [dbo].[uspMetricasAgilesInsert]
	@id As int,
	@idSolucion As uniqueidentifier,	
	@sprint As varchar(500),
	@fechaInicial As smalldatetime,
	@fechaFinal As smalldatetime,
	@idEquipo As uniqueidentifier

AS

	IF @idEquipo != CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)
			BEGIN
			   INSERT INTO [dbo].[MetricasAgiles]
				   ([IdSolucion]
				   ,[Sprint]
				   ,[FechaInicial]
				   ,[FechaFinal]
				   ,[IdEquipo])
			 VALUES
				   (@idSolucion,	
					@sprint,
					@fechaInicial,
					@fechaFinal,
					@idEquipo)
			END
		ELSE
		    BEGIN
				INSERT INTO [dbo].[MetricasAgiles]
					   ([IdSolucion]
					   ,[Sprint]
					   ,[FechaInicial]
					   ,[FechaFinal])
				 VALUES
					   (@idSolucion,	
						@sprint,
						@fechaInicial,
						@fechaFinal)
			END
