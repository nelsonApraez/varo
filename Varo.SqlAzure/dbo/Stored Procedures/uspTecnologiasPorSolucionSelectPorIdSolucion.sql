CREATE PROCEDURE [dbo].[uspTecnologiasPorSolucionSelectPorIdSolucion]	
	@idSolucion AS uniqueidentifier 			
AS   	    
    SELECT
		tecnologiasPorSolucion.IdTecnologia,
		tecnologias.IdTipoTecnologia,
		tipo.Nombre NombreTipo,
		tipo.NombreEN NombreTipoEN,
		tecnologias.Logo,
		tecnologias.Nombre			    
	FROM dbo.TecnologiasPorSolucion tecnologiasPorSolucion
	INNER JOIN dbo.Tecnologias tecnologias
			ON tecnologiasPorSolucion.IdTecnologia = tecnologias.Id	
    INNER JOIN dbo.tiposTecnologia tipo
			ON tecnologias.IdTipoTecnologia = tipo.id
	WHERE		
		tecnologiasPorSolucion.IdSolucion = @idSolucion
	ORDER BY tecnologias.IdTipoTecnologia


GO
