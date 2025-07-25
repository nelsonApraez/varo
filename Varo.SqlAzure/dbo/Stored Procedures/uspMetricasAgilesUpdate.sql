CREATE PROCEDURE [dbo].[uspMetricasAgilesUpdate]
	@id As int,
	@idSolucion As uniqueidentifier,	
	@sprint As varchar(500),
	@fechaInicial As smalldatetime,
	@fechaFinal As smalldatetime,
	@idEquipo As uniqueidentifier

AS

		UPDATE MetricasAgiles
		   SET Sprint = @sprint,
		       FechaInicial = @fechaInicial,
			   FechaFinal = @fechaFinal
		 WHERE Id = @id

		 IF @idEquipo != CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)
			BEGIN
			   UPDATE MetricasAgiles SET IdEquipo = @idEquipo WHERE Id = @id
			END
