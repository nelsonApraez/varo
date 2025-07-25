CREATE PROCEDURE [dbo].[uspAccionesMejoraSelectPorIdSolucion]
    @IdSolucion AS uniqueidentifier
    
    AS BEGIN
        SELECT 
            AccionesMejora.Id,
		    MetricasAgiles.IdSolucion,
		    MetricasAgiles.Sprint AS Sprint,
		    AccionesMejora.Accion,
			AccionesMejora.Causa,
		    ResponsablesAccionesMejora.Id AS IdResponsable,
		    ResponsablesAccionesMejora.Nombre AS NombreResponsable,
		    ResponsablesAccionesMejora.NombreEN AS NombreResponsableEN,
		    EstadosAccionesMejora.Id AS IdEstado,
		    EstadosAccionesMejora.Nombre AS NombreEstado,
		    EstadosAccionesMejora.NombreEN AS NombreEstadoEN
        FROM MetricasAgiles
	        INNER JOIN AccionesMejora
		        ON MetricasAgiles.Id = AccionesMejora.IdMetricaAgil
	        INNER JOIN ResponsablesAccionesMejora
		        ON AccionesMejora.IdResponsable = ResponsablesAccionesMejora.Id
	        INNER JOIN EstadosAccionesMejora
		        ON AccionesMejora.IdEstado = EstadosAccionesMejora.Id
        WHERE MetricasAgiles.IdSolucion = @IdSolucion
    END
