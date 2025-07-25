CREATE PROCEDURE [dbo].[uspPruebasSolucionUpdate]
	@id As uniqueidentifier,	
	@casosDefinidos As int,
	@casosAutomatizar As int,
	@casosAutomatizados As int,
	@urlDiseñoCasos As varchar(50),
	@urlEvidencias As varchar(50),
	@urlRepositorio As varchar(50),
	@usuarioRedTecnico As varchar(50),
	@fechaCreacion As smalldatetime,
	@estaenPipeline As bit,
	@observaciones As varchar(max)

AS

UPDATE [dbo].[PruebasSolucion]
   SET 
	   [CasosDefinidos] = @casosDefinidos,
	   [CasosAutomatizar] = @casosAutomatizar,
	   [CasosAutomatizados] = @casosAutomatizados,
	   [UrlDiseñoCasos] = @urlDiseñoCasos,
	   [UrlEvidencias] = @urlEvidencias,
	   [UrlRepositorio] = @urlRepositorio,
	   [UsuarioRedTecnico] = @usuarioRedTecnico,
	   [FechaCreacion] = @fechaCreacion,
	   [EstaenPipeline] = @estaenPipeline,
	   [Observaciones] = @observaciones
 WHERE [Id] = @id
