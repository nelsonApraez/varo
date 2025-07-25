CREATE PROCEDURE [dbo].[uspSolucionesSelectPage]

	@numeroPagina AS INT,  
    @tamanoPagina AS INT,
	@enEjecucion AS INT

    AS
    BEGIN
        IF(@enEjecucion = 1)
	    BEGIN
		    SELECT  
			    dbo.Soluciones.Id,
			    dbo.Soluciones.Nombre,
			    IdCliente,
			    UsuarioRedGerente,
			    UsuarioRedResponsable,
			    UsuarioRedScrumMaster,
			    UrlDocumentacion,
			    UrlRepositorioCodigoFuente,
			    UrlInspeccion,
				UrlLeccionesAprendidas,
				UrlGestionAseguramientoCalidad,
			    IdOficina,
			    dbo.Oficinas.Nombre         AS [NombreOficina],
			    IdTipo,
			    dbo.TiposSolucion.Nombre    AS [NombreTipo],
			    IdEstado,
			    dbo.EstadosSolucion.Nombre  AS [NombreEstado],
			    IdLineaSolucion ,
			    dbo.LineaSolucion.Nombre AS [NombreLineaSolucion],
			    COUNT(dbo.Soluciones.Id) OVER ( ) AS ConteoTotalFilas			
		    FROM dbo.Soluciones
			    INNER JOIN dbo.Oficinas         
                    ON dbo.Soluciones.IdOficina = dbo.Oficinas.Id 
			    INNER JOIN dbo.TiposSolucion    
                    ON dbo.Soluciones.IdTipo = dbo.TiposSolucion.Id 
			    INNER JOIN dbo.EstadosSolucion  
                    ON dbo.Soluciones.IdEstado = dbo.EstadosSolucion.Id
			    INNER JOIN dbo.LineaSolucion 
                    ON dbo.Soluciones.IdLineaSolucion = dbo.LineaSolucion.Id
		    WHERE IdEstado = @enEjecucion
		    ORDER BY dbo.Soluciones.Nombre
		        OFFSET (@numeroPagina - 1) * @tamanoPagina ROWS FETCH NEXT @tamanoPagina ROWS ONLY
        END
	    ELSE
	    BEGIN
		    SELECT  
			    dbo.Soluciones.Id,
			    dbo.Soluciones.Nombre,
			    IdCliente,
			    UsuarioRedGerente,
			    UsuarioRedResponsable,
			    UsuarioRedScrumMaster,
			    UrlDocumentacion,
			    UrlRepositorioCodigoFuente,
			    UrlInspeccion,
				UrlLeccionesAprendidas,
				UrlGestionAseguramientoCalidad,
			    IdOficina,
			    dbo.Oficinas.Nombre         AS [NombreOficina],
			    IdTipo,
			    dbo.TiposSolucion.Nombre    AS [NombreTipo],
			    IdEstado,
			    dbo.EstadosSolucion.Nombre  AS [NombreEstado],
			    IdLineaSolucion,
			    dbo.LineaSolucion.Nombre AS [NombreLineaSolucion],
			    COUNT(dbo.Soluciones.Id) OVER ( ) AS ConteoTotalFilas			
            FROM dbo.Soluciones
			    INNER JOIN dbo.Oficinas         
                    ON dbo.Soluciones.IdOficina = dbo.Oficinas.Id 
			    INNER JOIN dbo.TiposSolucion    
                    ON dbo.Soluciones.IdTipo = dbo.TiposSolucion.Id 
			    INNER JOIN dbo.EstadosSolucion  
                    ON dbo.Soluciones.IdEstado = dbo.EstadosSolucion.Id
			    INNER JOIN dbo.LineaSolucion 
                    ON dbo.Soluciones.IdLineaSolucion = dbo.LineaSolucion.Id
		    ORDER BY dbo.Soluciones.Nombre
		        OFFSET (@numeroPagina - 1) * @tamanoPagina ROWS FETCH NEXT @tamanoPagina ROWS ONLY
	    END
    END
GO
