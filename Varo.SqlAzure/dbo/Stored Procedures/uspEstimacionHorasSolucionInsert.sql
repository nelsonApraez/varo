CREATE PROCEDURE [dbo].[uspEstimacionHorasSolucionInsert]
	@id As  uniqueidentifier,
	@idSolucion As uniqueidentifier,
	@concepto As varchar(500),
	@horasEstimadas As int,
	@horasEjecutadas As int

    AS BEGIN
        INSERT INTO [dbo].[EstimacionHorasSolucion]
        (
            [Id],
            [IdSolucion],
            [Concepto],
            [HorasEstimadas],
            [HorasEjecutadas]
        )
        VALUES
        (
            @id,
            @idSolucion,
            @concepto,
            @horasEstimadas,
            @horasEjecutadas
        )
    END
GO
