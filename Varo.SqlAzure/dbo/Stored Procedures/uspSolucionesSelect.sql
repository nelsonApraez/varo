CREATE PROCEDURE [dbo].[uspSolucionesSelect]

    AS
    BEGIN
   	    SELECT  
            solucion.Id,
			solucion.Nombre,
			solucion.Descripcion,
			solucion.Observacion,
			solucion.IdTipo,
			tipoSolucion.Nombre             'NombreTipoSolucion',
			solucion.IdMarcoTrabajo,
			marcosTrabajo.Nombre            'NombreMarcosTrabajo',
			solucion.IdLineaSolucion     'IdLineaSolucion',
			LineaSolucion.Nombre         'NombreLineaSolucion',
			solucion.IdLineaNegocio,
			lineaNegocio.Nombre             'NombreLineaNegocio',
			solucion.IdEstado,
			estadosSolucion.Nombre          'NombreEstadosSolucion',
			solucion.IdOficina,
			oficinas.Nombre                 'NombreOficina',
			solucion.IdCliente,
			solucion.HorasEstimadas,
			solucion.HorasEjecutadas,
			solucion.IdUsosComerciales,
			UsosComerciales.Nombre          'NombreUsosComerciales', 
			oficinas.IdGsdc,
			Gsdc.Nombre                     'NombreGsdc',
			solucion.UsuarioRedGerente,
			solucion.UsuarioRedResponsable,
			solucion.UsuarioRedScrumMaster
        FROM dbo.Soluciones solucion
	        INNER JOIN dbo.TiposSolucion tipoSolucion       
                ON solucion.IdTipo = tipoSolucion.Id	
	        INNER JOIN MarcosTrabajo  marcosTrabajo         
                ON solucion.IdMarcoTrabajo = marcosTrabajo.Id
	        INNER JOIN LineaSolucion     
                ON solucion.IdLineaSolucion = LineaSolucion.Id
	        INNER JOIN LineaNegocio lineaNegocio            
                ON solucion.IdLineaNegocio = lineaNegocio.Id
	        INNER JOIN EstadosSolucion  estadosSolucion     
                ON solucion.IdEstado = estadosSolucion.Id
	        INNER JOIN Oficinas oficinas                    
                ON solucion.IdOficina = oficinas.Id
	        LEFT JOIN UsosComerciales                       
                ON solucion.IdUsosComerciales = UsosComerciales.Id
	        LEFT JOIN Gsdc                                  
                ON oficinas.IdGsdc = Gsdc.Id
    END
GO
