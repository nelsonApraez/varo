CREATE PROCEDURE uspConsultoriaDelete

    @id AS uniqueidentifier

AS

    DELETE FROM dbo.Consultoria
	WHERE Id = @id
