CREATE PROCEDURE [dbo].[uspConsultoriasSelectPageByParam]		

	@numeroPagina AS INT,  
    @tamanoPagina AS INT,
	@enEjecucion AS INT,
	@nombre As varchar(100)= null, 
	@usuarioRedGerente As varchar(50)= null,
	@usuarioRedConsultor As varchar(50)= null,
	@nombreLineaConsultoria As varchar(50)= null,
	@nombreLineaNegocio As varchar(50)= null,
    @nombreEstado As varchar(50)= null,
    @nombreOficina As varchar(50)= null,        
    @nombreContactoCliente As varchar(100)= null,
	@idPais AS varchar(200)= null,
	@idCiudad AS varchar(200)= null,
	@idCliente As varchar(200)= null
	
AS
BEGIN
   	
	CREATE TABLE #TemporalConsultorias(
		Id uniqueidentifier,
		Nombre varchar(100),
		IdCliente int,
		UsuarioRedGerente varchar(50),
		UsuarioRedConsultor varchar(50),
		UrlDocumentacion varchar(300),
		UrlGestionAseguramientoCalidad varchar(300),
	    UrlLeccionesAprendidas varchar(300),
		IdOficina tinyint,
		NombreOficina varchar(50),
		IdEstado tinyint,
		NombreEstado varchar (50),
		IdLineaConsultoria tinyint,
		NombreLineaConsultoria varchar(50))
	
	INSERT INTO #TemporalConsultorias (Id, Nombre, IdCliente, UsuarioRedGerente, UsuarioRedConsultor, UrlDocumentacion, 
										UrlGestionAseguramientoCalidad,UrlLeccionesAprendidas, IdOficina, NombreOficina,IdEstado, NombreEstado, IdLineaConsultoria, NombreLineaConsultoria)     
    SELECT
		consultoria.Id,
		consultoria.Nombre,
		consultoria.IdCliente,
		consultoria.usuarioRedGerente,
		consultoria.UsuarioRedConsultor,
		consultoria.UrlDocumentacion, 
		consultoria.UrlGestionAseguramientoCalidad,
		consultoria.UrlLeccionesAprendidas,
		consultoria.IdOficina,
		oficinas.Nombre,
		consultoria.IdEstado,
		estadosconsultoria.Nombre,
		consultoria.IdLineaConsultoria,
		lineaConsultoria.Nombre
	FROM dbo.Consultoria consultoria
	INNER JOIN LineaConsultoria lineaConsultoria
			ON consultoria.IdLineaConsultoria = lineaConsultoria.Id
	INNER JOIN LineaNegocio lineaNegocio
			ON consultoria.IdLineaNegocio = lineaNegocio.Id
	INNER JOIN EstadosConsultoria  estadosconsultoria
			ON consultoria.IdEstado = estadosconsultoria.Id
	INNER JOIN Oficinas oficinas
			ON consultoria.IdOficina = oficinas.Id 
	WHERE		
		consultoria.Nombre like '%' + @nombre + '%' or
		consultoria.UsuarioRedGerente like '%' +	@usuarioRedGerente + '%' or
		consultoria.UsuarioRedConsultor like '%' +	@usuarioRedConsultor + '%' or
		lineaConsultoria.Nombre like '%' + @nombreLineaConsultoria + '%' or
		lineaNegocio.Nombre like '%' + @nombreLineaNegocio + '%' or
		estadosconsultoria.Nombre like '%' + @nombreEstado + '%' or
		oficinas.Nombre like '%' + @nombreOficina + '%' or
		consultoria.NombreContactoCliente like '%' + @nombreContactoCliente + '%' 


	DECLARE @idPaisXML AS XML
	SET @idPaisXML = cast(('<a>'+replace(@idPais,',' ,'</a><a>')
                 +'</a>') AS XML)

	INSERT INTO #TemporalConsultorias (Id, Nombre, IdCliente, UsuarioRedGerente, UsuarioRedConsultor, UrlDocumentacion, 
										UrlGestionAseguramientoCalidad,UrlLeccionesAprendidas, IdOficina, NombreOficina,IdEstado, NombreEstado, IdLineaConsultoria, NombreLineaConsultoria)     
    SELECT
		consultoria.Id,
		consultoria.Nombre,
		consultoria.IdCliente,
		consultoria.usuarioRedGerente,
		consultoria.UsuarioRedConsultor,
		consultoria.UrlDocumentacion,
		consultoria.UrlGestionAseguramientoCalidad,
		consultoria.UrlLeccionesAprendidas,
		consultoria.IdOficina,
		oficinas.Nombre,
		consultoria.IdEstado,
		estadosconsultoria.Nombre,
		consultoria.IdLineaConsultoria,
		lineaConsultoria.Nombre
	FROM dbo.Consultoria consultoria
	INNER JOIN LineaConsultoria lineaConsultoria
			ON consultoria.IdLineaConsultoria = lineaConsultoria.Id
	INNER JOIN EstadosConsultoria  estadosconsultoria
			ON consultoria.IdEstado = estadosconsultoria.Id
	INNER JOIN Oficinas oficinas
			ON consultoria.IdOficina = oficinas.Id 
	WHERE IdPais IN
	(
		SELECT
		a.value('.', 'varchar(max)')
		FROM @idPaisXML.nodes('a') AS FN(a)
	)

	DECLARE @idCiudadXML AS XML
	SET @idCiudadXML = cast(('<a>'+replace(@idCiudad,',' ,'</a><a>')
                 +'</a>') AS XML)				 

	INSERT INTO #TemporalConsultorias (Id, Nombre, IdCliente, UsuarioRedGerente, UsuarioRedConsultor, UrlDocumentacion,UrlGestionAseguramientoCalidad,UrlLeccionesAprendidas, 
										IdOficina, NombreOficina,IdEstado, NombreEstado, IdLineaConsultoria, NombreLineaConsultoria)     
    SELECT
		consultoria.Id,
		consultoria.Nombre,
		consultoria.IdCliente,
		consultoria.usuarioRedGerente,
		consultoria.UsuarioRedConsultor,
		consultoria.UrlDocumentacion,
		consultoria.UrlGestionAseguramientoCalidad,
		consultoria.UrlLeccionesAprendidas,
		consultoria.IdOficina,
		oficinas.Nombre,
		consultoria.IdEstado,
		estadosconsultoria.Nombre,
		consultoria.IdLineaConsultoria,
		lineaConsultoria.Nombre
	FROM dbo.consultoria consultoria
	INNER JOIN LineaConsultoria lineaConsultoria
			ON consultoria.IdLineaConsultoria = lineaConsultoria.Id
	INNER JOIN EstadosConsultoria  estadosconsultoria
			ON consultoria.IdEstado = estadosconsultoria.Id
	INNER JOIN Oficinas oficinas
			ON consultoria.IdOficina = oficinas.Id
	WHERE IdCiudad IN
	(
		SELECT
		a.value('.', 'varchar(max)')
		FROM @idCiudadXML.nodes('a') AS FN(a)
	)

	DECLARE @idClienteXML AS XML
	SET @idClienteXML = cast(('<a>'+replace(@idCliente,',' ,'</a><a>')
                 +'</a>') AS XML)

	INSERT INTO #TemporalConsultorias (Id, Nombre, IdCliente, UsuarioRedGerente, UsuarioRedConsultor, UrlDocumentacion, UrlGestionAseguramientoCalidad,UrlLeccionesAprendidas, 
										IdOficina, NombreOficina,IdEstado, NombreEstado, IdLineaConsultoria, NombreLineaConsultoria)     
    SELECT
		consultoria.Id,
		consultoria.Nombre,
		consultoria.IdCliente,
		consultoria.usuarioRedGerente,
		consultoria.UsuarioRedConsultor,
		consultoria.UrlDocumentacion,
		consultoria.UrlGestionAseguramientoCalidad,
		consultoria.UrlLeccionesAprendidas,
		consultoria.IdOficina,
		oficinas.Nombre,
		consultoria.IdEstado,
		estadosconsultoria.Nombre,
		consultoria.IdLineaConsultoria,
		lineaConsultoria.Nombre
	FROM dbo.Consultoria consultoria
	INNER JOIN LineaConsultoria lineaConsultoria
			ON consultoria.IdLineaConsultoria = lineaConsultoria.Id
	INNER JOIN EstadosConsultoria  estadosconsultoria
			ON consultoria.IdEstado = estadosconsultoria.Id
	INNER JOIN Oficinas oficinas
			ON consultoria.IdOficina = oficinas.Id
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
         FROM   #TemporalConsultorias)
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
			UsuarioRedConsultor,
			UrlDocumentacion,
			UrlGestionAseguramientoCalidad,
		    UrlLeccionesAprendidas,
			IdOficina,
			NombreOficina,
			IdEstado,
			NombreEstado,
			IdLineaConsultoria,
			NombreLineaConsultoria,
			COUNT(Id) OVER ( ) AS ConteoTotalFilas
		FROM #TemporalConsultorias
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
			UsuarioRedConsultor,
			UrlDocumentacion,
			UrlGestionAseguramientoCalidad,
		    UrlLeccionesAprendidas,
			IdOficina,
			NombreOficina,
			IdEstado,
			NombreEstado,
			IdLineaConsultoria,
			NombreLineaConsultoria,
			COUNT(Id) OVER ( ) AS ConteoTotalFilas
		FROM #TemporalConsultorias
		ORDER BY Nombre
		OFFSET (@numeroPagina - 1) * @tamanoPagina ROWS FETCH NEXT @tamanoPagina ROWS ONLY
	END

END
