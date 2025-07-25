CREATE PROCEDURE [dbo].[uspTecnologiasPorConsultoriasInsert] 
	
	@idConsultoria As uniqueidentifier,
	@idTecnologia As uniqueidentifier

AS

INSERT INTO dbo.TecnologiasPorConsultoria
           (IdConsultoria,
		   IdTecnologia)
     VALUES
           (@idConsultoria,
           @idTecnologia)
