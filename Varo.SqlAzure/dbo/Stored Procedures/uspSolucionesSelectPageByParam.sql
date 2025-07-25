CREATE PROCEDURE [dbo].[uspSolucionesSelectPageByParam]		

	@numeroPagina AS INT,  
    @tamanoPagina AS INT,
	@enEjecucion AS INT,
	@nombre As varchar(100)= null, 
	@usuarioRedGerente As varchar(50)= null,
	@usuarioRedResponsable As varchar(50)= null,
	@usuarioRedScrumMaster As varchar(50)= null,
	@nombreTipo As varchar(50)= null, 
	@nombreLineaSolucion As varchar(50)= null,
	@nombreLineaNegocio As varchar(50)= null,
	@nombreMarcoTrabajo As varchar(50)= null,
    @nombreEstado As varchar(50)= null,
    @nombreOficina As varchar(50)= null,        
    @nombreContactoCliente As varchar(100)= null,
	@idPais AS varchar(200)= null,
	@idCiudad AS varchar(200)= null,
	@idCliente As varchar(200)= null
	
AS
BEGIN
   	
	CREATE TABLE #TemporalSoluciones(
		Id uniqueidentifier,
		Nombre varchar(100),
		IdCliente int,
		UsuarioRedGerente varchar(50),
		UsuarioRedResponsable varchar(50),
		UsuarioRedScrumMaster varchar(50),
		UrlDocumentacion varchar(300),
		UrlRepositorioCodigoFuente varchar (300),
		UrlInspeccion varchar (300),
		UrlLeccionesAprendidas varchar (300),
	    UrlGestionAseguramientoCalidad varchar (300),
		IdOficina tinyint,
		NombreOficina varchar(50),
		IdTipo tinyint,
		NombreTipo varchar (50),
		IdEstado tinyint,
		NombreEstado varchar (50),
		IdLineaSolucion tinyint,
		NombreLineaSolucion varchar(50))
	
	INSERT INTO #TemporalSoluciones 
    (
        Id, 
        Nombre, 
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
        NombreOficina, 
        IdTipo, 
        NombreTipo, 
        IdEstado, 
        NombreEstado, 
        IdLineaSolucion, 
        NombreLineaSolucion
    )     
    SELECT
		solucion.Id,
		solucion.Nombre,
		solucion.IdCliente,
		solucion.usuarioRedGerente,
		solucion.UsuarioRedResponsable,
		solucion.UsuarioRedScrumMaster,
		solucion.UrlDocumentacion, 
		solucion.UrlRepositorioCodigoFuente,
		solucion.UrlInspeccion,
		solucion.UrlLeccionesAprendidas,
	    solucion.UrlGestionAseguramientoCalidad,
		solucion.IdOficina,
		oficinas.Nombre,
		solucion.IdTipo,
		tipoSolucion.Nombre,
		solucion.IdEstado,
		estadosSolucion.Nombre,
		solucion.IdLineaSolucion,
		LineaSolucion.Nombre
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
	WHERE		
		solucion.Nombre like '%' + @nombre + '%' or
		solucion.UsuarioRedGerente like '%' + @usuarioRedGerente + '%' or
		solucion.UsuarioRedResponsable like '%' + @usuarioRedResponsable + '%' or
		solucion.UsuarioRedScrumMaster like '%' + @usuarioRedScrumMaster + '%' or
		tipoSolucion.Nombre like '%' + @nombreTipo + '%' or
		LineaSolucion.Nombre like '%' + @nombreLineaSolucion + '%' or
		lineaNegocio.Nombre like '%' + @nombreLineaNegocio + '%' or
		estadosSolucion.Nombre like '%' + @nombreEstado + '%' or
		oficinas.Nombre like '%' + @nombreOficina + '%' or
		solucion.NombreContactoCliente like '%' + @nombreContactoCliente + '%' or
		marcosTrabajo.Nombre like '%' + @nombreMarcoTrabajo + '%'


	DECLARE @idPaisXML AS XML
	SET @idPaisXML = cast(('<a>'+replace(@idPais,',' ,'</a><a>')
                 +'</a>') AS XML)

	INSERT INTO #TemporalSoluciones
    (
        Id, 
        Nombre, 
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
        NombreOficina, 
        IdTipo, 
        NombreTipo, 
        IdEstado, 
        NombreEstado, 
        IdLineaSolucion, 
        NombreLineaSolucion
    )     
    SELECT
		solucion.Id,
		solucion.Nombre,
		solucion.IdCliente,
		solucion.usuarioRedGerente,
		solucion.UsuarioRedResponsable,
		solucion.UsuarioRedScrumMaster,
		solucion.UrlDocumentacion, 
		solucion.UrlRepositorioCodigoFuente,
		solucion.UrlInspeccion,
		solucion.UrlLeccionesAprendidas,
		solucion.UrlGestionAseguramientoCalidad,
		solucion.IdOficina,
		oficinas.Nombre,
		solucion.IdTipo,
		tipoSolucion.Nombre,
		solucion.IdEstado,
		estadosSolucion.Nombre,
		solucion.IdLineaSolucion,
		LineaSolucion.Nombre
	FROM dbo.Soluciones solucion
	INNER JOIN dbo.TiposSolucion tipoSolucion
			ON solucion.IdTipo = tipoSolucion.Id	
	INNER JOIN LineaSolucion 
			ON solucion.IdLineaSolucion = LineaSolucion.Id
	INNER JOIN EstadosSolucion  estadosSolucion
			ON solucion.IdEstado = estadosSolucion.Id
	INNER JOIN Oficinas oficinas
			ON solucion.IdOficina = oficinas.Id 
	WHERE IdPais IN
	(
		SELECT
		a.value('.', 'varchar(max)')
		FROM @idPaisXML.nodes('a') AS FN(a)
	)

	DECLARE @idCiudadXML AS XML
	SET @idCiudadXML = cast(('<a>'+replace(@idCiudad,',' ,'</a><a>')
                 +'</a>') AS XML)				 

	INSERT INTO #TemporalSoluciones
    (
        Id, 
        Nombre, 
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
        NombreOficina, 
        IdTipo, 
        NombreTipo, 
        IdEstado, 
        NombreEstado, 
        IdLineaSolucion,
        NombreLineaSolucion
    ) 
    SELECT
		solucion.Id,
		solucion.Nombre,
		solucion.IdCliente,
		solucion.usuarioRedGerente,
		solucion.UsuarioRedResponsable,
		solucion.UsuarioRedScrumMaster,
		solucion.UrlDocumentacion, 
		solucion.UrlRepositorioCodigoFuente,
		solucion.UrlInspeccion,
		solucion.UrlLeccionesAprendidas,
		solucion.UrlGestionAseguramientoCalidad,
		solucion.IdOficina,
		oficinas.Nombre,
		solucion.IdTipo,
		tipoSolucion.Nombre,
		solucion.IdEstado,
		estadosSolucion.Nombre,
		solucion.IdLineaSolucion,
		LineaSolucion.Nombre
	FROM dbo.Soluciones solucion
	INNER JOIN dbo.TiposSolucion tipoSolucion
			ON solucion.IdTipo = tipoSolucion.Id	
	INNER JOIN LineaSolucion 
			ON solucion.IdLineaSolucion = LineaSolucion.Id
	INNER JOIN EstadosSolucion  estadosSolucion
			ON solucion.IdEstado = estadosSolucion.Id
	INNER JOIN Oficinas oficinas
			ON solucion.IdOficina = oficinas.Id
	WHERE IdCiudad IN
	(
		SELECT
		a.value('.', 'varchar(max)')
		FROM @idCiudadXML.nodes('a') AS FN(a)
	)

	DECLARE @idClienteXML AS XML
	SET @idClienteXML = cast(('<a>'+replace(@idCliente,',' ,'</a><a>')
                 +'</a>') AS XML)

	INSERT INTO #TemporalSoluciones
    (
        Id, 
        Nombre, 
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
        NombreOficina, 
        IdTipo, 
        NombreTipo, 
        IdEstado, 
        NombreEstado, 
        IdLineaSolucion, 
        NombreLineaSolucion
    ) 
    SELECT
		solucion.Id,
		solucion.Nombre,
		solucion.IdCliente,
		solucion.usuarioRedGerente,
		solucion.UsuarioRedResponsable,
		solucion.UsuarioRedScrumMaster,
		solucion.UrlDocumentacion, 
		solucion.UrlRepositorioCodigoFuente,
		solucion.UrlInspeccion,
		solucion.UrlLeccionesAprendidas,
		solucion.UrlGestionAseguramientoCalidad,
		solucion.IdOficina,
		oficinas.Nombre,
		solucion.IdTipo,
		tipoSolucion.Nombre,
		solucion.IdEstado,
		estadosSolucion.Nombre,
		solucion.IdLineaSolucion,
		LineaSolucion.Nombre
	FROM dbo.Soluciones solucion
	INNER JOIN dbo.TiposSolucion tipoSolucion
			ON solucion.IdTipo = tipoSolucion.Id	
	INNER JOIN LineaSolucion 
			ON solucion.IdLineaSolucion = LineaSolucion.Id
	INNER JOIN EstadosSolucion  estadosSolucion
			ON solucion.IdEstado = estadosSolucion.Id
	INNER JOIN Oficinas oficinas
			ON solucion.IdOficina = oficinas.Id
	WHERE IdCliente IN
	(
		SELECT
		a.value('.', 'varchar(max)')
		FROM @idClienteXML.nodes('a') AS FN(a)
	);
    
	--Eliminacion de registros repetidos
	WITH cte
     AS (SELECT ROW_NUMBER() OVER (PARTITION BY Id
                                       ORDER BY ( SELECT 0)) RN
         FROM   #TemporalSoluciones)
    DELETE FROM cte
    WHERE  RN > 1;
	--Fin de eliminacion de repetidos

	IF(@enEjecucion = 1)
	BEGIN
		SELECT 
			Id,
			Nombre,
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
			NombreOficina,
			IdTipo,
			NombreTipo,
			IdEstado,
			NombreEstado,
			IdLineaSolucion,
			NombreLineaSolucion,
			COUNT(Id) OVER ( ) AS ConteoTotalFilas
		FROM #TemporalSoluciones
		WHERE IdEstado = @enEjecucion
		ORDER BY Nombre
		OFFSET (@numeroPagina - 1) * @tamanoPagina ROWS FETCH NEXT @tamanoPagina ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT 
			Id,
			Nombre,
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
			NombreOficina,
			IdTipo,
			NombreTipo,
			IdEstado,
			NombreEstado,
			IdLineaSolucion,
			NombreLineaSolucion,
		COUNT(Id) OVER ( ) AS ConteoTotalFilas
		FROM #TemporalSoluciones
		ORDER BY Nombre
		OFFSET (@numeroPagina - 1) * @tamanoPagina ROWS FETCH NEXT @tamanoPagina ROWS ONLY
	END

END
