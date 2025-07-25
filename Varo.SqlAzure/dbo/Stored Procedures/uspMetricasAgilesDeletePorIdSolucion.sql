CREATE PROCEDURE [dbo].[uspMetricasAgilesDeletePorIdSolucion]
	@idMetricaAgil AS int
AS 

   DELETE MetricasAgiles
     FROM MetricasAgiles
	WHERE Id = @idMetricaAgil
	  


