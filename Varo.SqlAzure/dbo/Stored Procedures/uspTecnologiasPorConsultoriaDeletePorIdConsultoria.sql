CREATE PROCEDURE [dbo].[uspTecnologiasPorConsultoriaDeletePorIdConsultoria]
	@idConsultoria As uniqueidentifier	

AS
	DELETE FROM dbo.TecnologiasPorConsultoria
	WHERE IdConsultoria = @idConsultoria
