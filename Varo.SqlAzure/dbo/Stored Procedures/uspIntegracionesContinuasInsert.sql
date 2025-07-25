CREATE PROCEDURE [dbo].[uspIntegracionesContinuasInsert]

	@id As  uniqueidentifier,
	@idSolucion As uniqueidentifier,
	@nombre As varchar(50),
	@urlCompilacion As varchar(255),
	@idProyectoInspeccion As int

AS

INSERT INTO IntegracionesContinuas(
		Id,
		IdSolucion,
		Nombre,
		UrlCompilacion,
		idProyectoInspeccion)

	VALUES(
		@id,
		@idSolucion,
		@nombre,
		@urlCompilacion,
		@idProyectoInspeccion)
