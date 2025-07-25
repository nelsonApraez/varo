CREATE PROCEDURE [dbo].[uspAccionesMejoraDeletePorId]
    @id AS INT
    
    AS BEGIN
	    DELETE FROM [dbo].[AccionesMejora]
	    WHERE Id = @id
    END
