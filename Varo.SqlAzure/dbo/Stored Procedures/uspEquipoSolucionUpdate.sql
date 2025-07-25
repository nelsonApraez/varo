CREATE PROCEDURE [dbo].[uspEquiposSolucionesUpdate]

	@id As  uniqueidentifier,
	@nombre As varchar(500)

AS

UPDATE [dbo].[EquipoSolucion]
   SET [Nombre] = @nombre
 WHERE id = @id
