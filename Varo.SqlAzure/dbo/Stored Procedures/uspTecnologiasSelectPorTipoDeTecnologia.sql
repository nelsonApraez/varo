CREATE PROCEDURE [dbo].[uspTecnologiasSelectPorTipoDeTecnologia] 
	
	@idTipoTecnologia As tinyint

AS
    SELECT  Id,
			Nombre,
			Logo		
	FROM dbo.Tecnologias
	WHERE IdTipoTecnologia = @idTipoTecnologia
