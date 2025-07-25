CREATE PROCEDURE [dbo].[uspAmbientesSolucionInsert] 
    @idSolucion AS uniqueidentifier,	
	@idTipoAmbiente AS SMALLINT,
	@ubicacion AS VARCHAR(255),
	@responsable as VARCHAR(255)

    AS BEGIN
        INSERT INTO [dbo].[AmbientesSolucion]
        (
            [Id],
    		[IdSolucion],
    		[IdTipoAmbiente],
    		[Ubicacion],
    		[Responsable]
        )
    	VALUES
    	(
            NEWID(),
    		@idSolucion,	
    		@idTipoAmbiente,
    		@ubicacion,
    		@responsable
        )
    END
