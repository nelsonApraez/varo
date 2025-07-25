CREATE PROCEDURE [dbo].[uspPruebasSolucionInsert]
	@idSolucion As uniqueidentifier,	
	@casosDefinidos As int,
	@casosAutomatizar As int,
	@casosAutomatizados As int,
	@urlDiseņoCasos As varchar(50),
	@urlEvidencias As varchar(50),
	@urlRepositorio As varchar(50),
	@usuarioRedTecnico As varchar(50),
	@fechaCreacion As smalldatetime,
	@estaenPipeline As bit,
	@observaciones As varchar(max)

AS

	INSERT INTO [dbo].[PruebasSolucion]
			   ([Id]
			   ,[IdSolucion]
			   ,[CasosDefinidos]
			   ,CasosAutomatizar
			   ,[CasosAutomatizados]
			   ,UrlDiseņoCasos
			   ,UrlEvidencias
			   ,UrlRepositorio
			   ,[UsuarioRedTecnico]
			   ,[FechaCreacion]
			   ,EstaenPipeline
			   ,[Observaciones])
		 VALUES
			   (NEWID(),
				@idSolucion,
				@casosDefinidos,
				@casosAutomatizar,
				@casosAutomatizados,
				@urlDiseņoCasos,
				@urlEvidencias,
				@urlRepositorio,
				@usuarioRedTecnico,
				@fechaCreacion,
				@estaenPipeline,
				@observaciones)
