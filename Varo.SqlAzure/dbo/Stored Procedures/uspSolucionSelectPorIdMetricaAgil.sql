CREATE PROCEDURE [dbo].[uspSolucionSelectPorIdMetricaAgil]
	
    @IdMetricaAgil AS INT
	
    AS
	BEGIN   
		SELECT  IdSolucion
		FROM dbo.MetricasAgiles
		WHERE Id = @IdMetricaAgil
	END
GO
