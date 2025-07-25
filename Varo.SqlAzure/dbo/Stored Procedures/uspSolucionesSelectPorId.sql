CREATE PROCEDURE [dbo].[uspSolucionesSelectPorId]

    @id AS UNIQUEIDENTIFIER

    AS
    BEGIN
        SELECT  
            solucion.Id,
		    solucion.Nombre,
		    UsuarioRedGerente,
		    UsuarioRedResponsable,
		    UsuarioRedScrumMaster,
		    solucion.IdTipo,
		    tipoSolucion.Nombre                     'NombreTipoSolucion',
		    solucion.IdMarcoTrabajo,
		    marcosTrabajo.Nombre                    'NombreMarcosTrabajo',
		    solucion.IdLineaSolucion,
		    LineaSolucion.Nombre                 'NombreLineaSolucion',
		    solucion.IdLineaNegocio,
		    lineaNegocio.Nombre                     'NombreLineaNegocio',
		    solucion.IdEstado,
		    estadosSolucion.Nombre                  'NombreEstadosSolucion',
		    solucion.IdOficina,
		    oficinas.Nombre                         'NombreOficina', 
		    solucion.IdCliente,
		    solucion.IdPais,
		    solucion.IdDepartamento,
		    solucion.IdCiudad,
		    solucion.UrlRepositorioCodigoFuente,
		    solucion.UrlDocumentacion,
		    solucion.UrlInspeccion,
		    solucion.UrlDiseno,
		    solucion.UrlGestionTareas,
		    solucion.UrlGestionIncidentes,
		    solucion.UrlGestionAseguramientoCalidad,
		    solucion.UrlLeccionesAprendidas,
            solucion.UrlOportunidadCrm,
            solucion.UrlProyectoPsa,
		    solucion.NombreContactoCliente,
		    solucion.CorreoContactoCliente,
		    solucion.TelefonoContactoCliente,
		    solucion.Observacion,
		    solucion.Descripcion,
		    solucion.ExperienciaUsuario,
		    solucion.Etiqueta,
            solucion.FechaCreacion,
            solucion.FechaCierre,
		    solucion.HorasEstimadas,
		    solucion.HorasEjecutadas,
		    solucion.IdUsosComerciales,
		    UsosComerciales.Nombre                  'NombreUsosComerciales', 
		    oficinas.IdGsdc,
		    Gsdc.Nombre                             'NombreGsdc',
            solucion.IdConsultoria,
			solucion.ObjetivoNegocio
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
	    WHERE solucion.Id = @id
    END
GO
