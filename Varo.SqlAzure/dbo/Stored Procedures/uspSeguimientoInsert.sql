CREATE PROCEDURE [uspSeguimientoInsert]
	@idAccionesMejora As int,	
	@Observacion As varchar(500),
	@Fecha As smalldatetime,
	@Usuario As varchar(50)

AS

		INSERT INTO [dbo].[Seguimiento]
				   ([IdAccionesMejora]
				   ,[Observacion]
				   ,[Fecha]
				   ,[Usuario])
			 VALUES
				   (@idAccionesMejora,	
					@Observacion,
					@Fecha,
					@Usuario)
	
