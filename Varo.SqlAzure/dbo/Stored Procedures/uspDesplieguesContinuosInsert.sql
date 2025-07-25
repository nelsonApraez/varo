CREATE PROCEDURE [dbo].[uspDesplieguesContinuosInsert]

    @id As  uniqueidentifier,
	@idSolucion As uniqueidentifier,
	@nombre As varchar(50),
	@urlDespliegue As varchar(255)

AS

INSERT INTO dbo.DesplieguesContinuos(
		Id,
		IdSolucion,
		Nombre,
		UrlDespliegue)

	VALUES(
		@id,
		@idSolucion,
		@nombre,
		@urlDespliegue)
