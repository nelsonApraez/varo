CREATE PROCEDURE [dbo].[uspTecnologiasPorConsutoriaSelectPorIdConsultoria]	
	@idConsultoria AS uniqueidentifier 			
AS   	    
    SELECT
		tecnologiasPorConsultoria.IdTecnologia,
		tecnologias.IdTipoTecnologia,
		tipo.nombre NombreTipo,
		tecnologias.Logo,
		tecnologias.Nombre			    
	FROM dbo.TecnologiasPorConsultoria tecnologiasPorConsultoria
	INNER JOIN dbo.Tecnologias tecnologias
			ON tecnologiasPorConsultoria.IdTecnologia = tecnologias.Id	
	INNER JOIN dbo.tiposTecnologia tipo
			ON tecnologias.IdTipoTecnologia = tipo.id
	WHERE		
		tecnologiasPorConsultoria.IdConsultoria = @idConsultoria
	ORDER BY tecnologias.IdTipoTecnologia

GO
