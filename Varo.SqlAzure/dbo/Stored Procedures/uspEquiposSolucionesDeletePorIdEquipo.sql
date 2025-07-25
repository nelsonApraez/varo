CREATE PROCEDURE [dbo].[uspEquiposSolucionesDeletePorIdEquipo]
	@idEquipo AS uniqueidentifier
AS

	DELETE FROM EquipoSolucion
	WHERE Id = @idEquipo
