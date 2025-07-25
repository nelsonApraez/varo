CREATE PROCEDURE [dbo].[uspConsultoriasSelectPage]
	@numeroPagina AS INT,  
    @tamanoPagina AS INT,
	@enEjecucion AS INT
AS
BEGIN
   	    
	SELECT  
			dbo.Consultoria.Id,
			dbo.Consultoria.Nombre,
			IdCliente,
			UsuarioRedGerente,
			UsuarioRedConsultor,
			UrlDocumentacion,
			UrlGestionAseguramientoCalidad,
			UrlLeccionesAprendidas,
			IdOficina,
			dbo.Oficinas.Nombre AS [NombreOficina],
			IdEstado,
			dbo.EstadosConsultoria.Nombre AS [NombreEstado],
			IdLineaConsultoria,
			dbo.LineaConsultoria.Nombre AS [NombreLineaConsultoria],
			COUNT(dbo.Consultoria.Id) OVER ( ) AS ConteoTotalFilas			
		FROM dbo.Consultoria
			INNER JOIN dbo.Oficinas ON dbo.Consultoria.IdOficina = dbo.Oficinas.Id 
			INNER JOIN dbo.EstadosConsultoria ON dbo.Consultoria.IdEstado = dbo.EstadosConsultoria.Id
			INNER JOIN dbo.LineaConsultoria ON dbo.Consultoria.IdLineaConsultoria = dbo.LineaConsultoria.Id
		WHERE IdEstado = @enEjecucion or @enEjecucion=0
		ORDER BY dbo.Consultoria.Nombre
		OFFSET (@numeroPagina - 1) * @tamanoPagina ROWS FETCH NEXT @tamanoPagina ROWS ONLY
END
