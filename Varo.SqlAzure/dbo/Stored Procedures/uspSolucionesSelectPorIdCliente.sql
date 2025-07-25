CREATE PROCEDURE [dbo].[uspSolucionesSelectPorIdCliente]
	
    @idCliente AS INT

    AS
    BEGIN
        SELECT
		    Id,
		    IdCliente,
		    Nombre
	    FROM dbo.Soluciones
        WHERE IdCliente = @idCliente
		AND IdEstado = 1
    END
GO
