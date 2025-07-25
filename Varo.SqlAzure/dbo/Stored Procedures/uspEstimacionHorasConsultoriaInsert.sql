CREATE PROCEDURE [dbo].[uspEstimacionHorasConsultoriaInsert]
	@id As  uniqueidentifier,
	@idConsultoria As uniqueidentifier,
	@concepto As varchar(500),
	@horasEstimadas As int,
	@horasEjecutadas As int

    AS BEGIN
        INSERT INTO [dbo].[EstimacionHorasConsultoria]
        (
            [Id],
            [IdConsultoria],
            [Concepto],
            [HorasEstimadas],
            [HorasEjecutadas]
        )
        VALUES
        (
            @id,
            @idConsultoria,
            @concepto,
            @horasEstimadas,
            @horasEjecutadas
        )
    END
GO
