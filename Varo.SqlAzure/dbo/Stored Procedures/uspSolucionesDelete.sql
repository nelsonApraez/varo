CREATE PROCEDURE uspSolucionesDelete

    @id AS UNIQUEIDENTIFIER

    AS
    BEGIN
        DELETE FROM dbo.Soluciones
	    WHERE Id = @id
    END
GO
