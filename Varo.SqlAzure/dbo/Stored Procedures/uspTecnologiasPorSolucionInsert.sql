CREATE PROCEDURE [dbo].[uspTecnologiasPorSolucionInsert] 
	
	@idSolucion As uniqueidentifier,
	@idTecnologia As uniqueidentifier

AS

INSERT INTO dbo.TecnologiasPorSolucion
           (IdSolucion,
		   IdTecnologia)
     VALUES
           (@idSolucion,
           @idTecnologia)
