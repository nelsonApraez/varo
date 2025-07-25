CREATE PROCEDURE [dbo].[uspAmbientesSolucionSelectPorIdSolucion]
	@idSolucion AS uniqueidentifier

    AS BEGIN   
        SELECT 
            AmbientesSolucion.Id,
    		Soluciones.Id AS IdSolucion,
    		AmbientesSolucion.IdTipoAmbiente,
    		TiposAmbiente.Nombre TipoAmbiente,
    		TiposAmbiente.NombreEN TipoAmbienteEN,
    		AmbientesSolucion.Ubicacion,
    		AmbientesSolucion.Responsable
    	FROM Soluciones
    	    INNER JOIN AmbientesSolucion ON Soluciones.Id = AmbientesSolucion.IdSolucion
    	    INNER JOIN TiposAmbiente     ON AmbientesSolucion.IdTipoAmbiente = TiposAmbiente.Id
        WHERE Soluciones.Id = @idSolucion
    END
