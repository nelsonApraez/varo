CREATE PROCEDURE [dbo].[uspPruebasSolucionSelectPorIdSolucion]
@idSolucion AS uniqueidentifier

AS

   SELECT TOP 1
		pruebas.Id,
		soluciones.Id AS [IdSolucion],
		soluciones.Nombre AS [NombreSolucion],
		pruebas.CasosDefinidos,
		pruebas.CasosAutomatizar,
		pruebas.CasosAutomatizados,
		pruebas.UrlDiseñoCasos,
		pruebas.UrlEvidencias,
		pruebas.UrlRepositorio,
		pruebas.UsuarioRedTecnico,
		pruebas.FechaCreacion,
		pruebas.EstaenPipeline,
		pruebas.Observaciones
	FROM [dbo].[PruebasSolucion] AS pruebas
   INNER JOIN [dbo].[Soluciones] AS soluciones ON pruebas.IdSolucion = soluciones.Id
   WHERE (pruebas.IdSolucion = @idSolucion)
