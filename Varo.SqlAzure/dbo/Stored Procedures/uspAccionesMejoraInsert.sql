CREATE PROCEDURE [dbo].[uspAccionesMejoraInsert]
    @IdMetricaAgil AS INT,
    @Accion AS VARCHAR(500),
    @IdResponsable AS tinyint,
    @IdEstado AS tinyint,
	@Causa AS VARCHAR(500)
    
    AS BEGIN
        INSERT INTO [dbo].[AccionesMejora]
        (
            IdMetricaAgil,
    	    Accion,
			Causa,
            IdResponsable,
            IdEstado
        )
        VALUES
        (
            @IdMetricaAgil,
    	    @Accion,
			@Causa,
            @IdResponsable,
    	    @IdEstado
        )
    END
