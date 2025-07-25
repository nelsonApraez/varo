CREATE PROCEDURE [dbo].[uspPruebasSolucionSelect]

AS

   SELECT
		pruebas.Id,
		soluciones.Id AS [IdSolucion],
		soluciones.Nombre AS [NombreSolucion],
		pruebas.CasosDefinidos,
		pruebas.CasosAutomatizados,
		pruebas.UsuarioRedTecnico,
		pruebas.FechaCreacion,
		pruebas.Observaciones
	FROM [dbo].[PruebasSolucion] AS pruebas
   INNER JOIN [dbo].[Soluciones] AS soluciones ON pruebas.IdSolucion = soluciones.Id
   ORDER BY pruebas.FechaCreacion
