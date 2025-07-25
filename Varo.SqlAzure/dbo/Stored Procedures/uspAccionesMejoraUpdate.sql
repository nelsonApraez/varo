CREATE PROCEDURE [dbo].[uspAccionesMejoraUpdate]
	@Id AS INT,
	@Accion AS VARCHAR(500),
	@IdResponsable AS tinyint,
	@IdEstado AS tinyint,
	@Causa AS VARCHAR(500)

    AS BEGIN
	    UPDATE [dbo].[AccionesMejora]
            SET Accion = @Accion,
		        IdResponsable = @IdResponsable,
		        IdEstado = @IdEstado,
				Causa = @Causa
        WHERE Id = @Id
    END
