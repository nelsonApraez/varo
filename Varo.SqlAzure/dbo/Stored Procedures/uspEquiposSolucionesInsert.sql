CREATE PROCEDURE [dbo].[uspEquiposSolucionesInsert]

	@id As  uniqueidentifier,
	@idSolucion As uniqueidentifier,
	@nombre As varchar(500)

AS

INSERT INTO EquipoSolucion(
		Id,
		IdSolucion,
		Nombre)

	VALUES(
		@id,
		@idSolucion,
		@nombre)
