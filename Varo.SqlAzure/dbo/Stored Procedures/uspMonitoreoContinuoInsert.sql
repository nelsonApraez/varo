CREATE PROCEDURE [dbo].[uspMonitoreoContinuoInsert]

    @id As  uniqueidentifier,
	@idSolucion As uniqueidentifier,
	@nombre As varchar(50),
	@urlMonitoreo As varchar(255)

AS

INSERT INTO dbo.MonitoreoContinuo(
		Id,
		IdSolucion,
		Nombre,
		UrlMonitoreo)

	VALUES(
		@id,
		@idSolucion,
		@nombre,
		@urlMonitoreo)
