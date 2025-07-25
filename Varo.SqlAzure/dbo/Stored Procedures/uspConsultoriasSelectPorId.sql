CREATE PROCEDURE [dbo].[uspConsultoriasSelectPorId]
	@id AS uniqueidentifier
AS
BEGIN
   	    
    SELECT  consultoria.Id,
			consultoria.Nombre,
			UsuarioRedGerente,
			UsuarioRedConsultor,
			consultoria.IdLineaConsultoria,
			lineaConsultoria.Nombre 'NombreLineaConsultoria',
			consultoria.IdLineaNegocio,
			lineaNegocio.Nombre 'NombreLineaNegocio',
			consultoria.IdEstado,
			estadosconsultoria.Nombre 'NombreEstadosConsultoria',
			consultoria.IdOficina,
			oficinas.Nombre 'NombreOficina', 
			consultoria.IdCliente,
			consultoria.IdPais,
			consultoria.IdDepartamento,
			consultoria.IdCiudad,
			consultoria.UrlDocumentacion,
			consultoria.UrlDiseno,
			consultoria.UrlGestionTareas,
			consultoria.UrlGestionIncidentes,
			consultoria.UrlGestionAseguramientoCalidad,
			consultoria.UrlLeccionesAprendidas,
            consultoria.UrlOportunidadCrm,
            consultoria.UrlProyectoPsa,
			consultoria.NombreContactoCliente,
			consultoria.CorreoContactoCliente,
			consultoria.TelefonoContactoCliente,
			consultoria.Observacion,
			consultoria.Descripcion,
			consultoria.Etiqueta,
            consultoria.FechaCreacion,
            consultoria.FechaCierre,
			consultoria.HorasEstimadas,
			consultoria.HorasEjecutadas,
			consultoria.IdUsosComerciales,
			UsosComerciales.Nombre 'NombreUsosComerciales', 
			oficinas.IdGsdc,
			Gsdc.Nombre 'NombreGsdc',
			consultoria.ObjetivoNegocio
	FROM dbo.Consultoria consultoria
	inner join LineaConsultoria lineaConsultoria
			on consultoria.IdLineaConsultoria = lineaConsultoria.Id
	inner join LineaNegocio lineaNegocio
			on consultoria.IdLineaNegocio = lineaNegocio.Id
	inner join Estadosconsultoria  estadosconsultoria
			on consultoria.IdEstado = estadosconsultoria.Id
	inner join Oficinas oficinas
			on consultoria.IdOficina = oficinas.Id
	left join UsosComerciales 
	        on consultoria.IdUsosComerciales = UsosComerciales.Id
	left join Gsdc 
	        on oficinas.IdGsdc = Gsdc.Id
	WHERE consultoria.Id = @id
END

GO
