CREATE PROCEDURE [dbo].[uspHitoSelectPorIdSolucion]
	@idSolucion AS uniqueidentifier
    
    AS BEGIN
        SELECT 
            Hitos.Id,
		    Hitos.IdSolucion AS IdSolucion,
		    Hitos.IdTipo AS IdTipo,
		    TiposHito.Nombre AS TipoHito,
		    TiposHito.NombreEN AS TipoHitoEN,
		    Hitos.Descripcion,
		    Hitos.FechaCierre,
		    Hitos.IdEstado,
		    EstadosHito.Nombre AS Estado,
		    EstadosHito.NombreEN AS EstadoEN,
		    Hitos.Observaciones
	    FROM Soluciones
	        INNER JOIN Hitos       ON Soluciones.Id = Hitos.IdSolucion
	        INNER JOIN TiposHito   ON TiposHito.Id = Hitos.IdTipo
	        INNER JOIN EstadosHito ON EstadosHito.Id = Hitos.IdEstado
        WHERE Soluciones.Id = @idSolucion
    END
