CREATE PROCEDURE [dbo].[uspAccionesMejoraSelectPorIdSolucionParam]
    @IdSolucion AS uniqueidentifier,
    @ParametroBusqueda AS varchar(50)

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
        WHERE 
            MetricasAgiles.IdSolucion = @IdSolucion
            AND 
            (
                MetricasAgiles.Sprint               LIKE '%'+@ParametroBusqueda+'%' OR
                AccionesMejora.Accion               LIKE '%'+@ParametroBusqueda+'%' OR
                EstadosAccionesMejora.Nombre        LIKE '%'+@ParametroBusqueda+'%' OR
                EstadosAccionesMejora.NombreEN      LIKE '%'+@ParametroBusqueda+'%' OR
                ResponsablesAccionesMejora.Nombre   LIKE '%'+@ParametroBusqueda+'%' OR
                ResponsablesAccionesMejora.NombreEN LIKE '%'+@ParametroBusqueda+'%'
            )
   END
