CREATE PROCEDURE [dbo].[uspHitoInsert]
    @idSolucion AS uniqueidentifier,
    @IdTipo AS tinyint,
    @Descripcion AS varchar(8000),
    @FechaCierre AS smalldatetime,
    @IdEstado AS tinyint,
    @Observaciones AS varchar(8000)
    
    AS BEGIN
        INSERT INTO [dbo].[Hitos]
        (
            [Id],
            [IdSolucion],
            [IdTipo],
            [Descripcion],
            [FechaCierre],
            [IdEstado],
            [Observaciones]
        )
        VALUES
        (
            NEWID(),
            @IdSolucion,
            @IdTipo,
            @Descripcion,
            @FechaCierre,
            @IdEstado,
            @Observaciones
        )
    END
