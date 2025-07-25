CREATE PROCEDURE [dbo].[uspPracticasCalidadInsert]
	
	@idSolucion As uniqueidentifier,	
	@controlDocumentacion As bit,
	@gestionTareas As bit,
	@gestionErrores As bit,
	@controlCodigo As bit,
	@pruebasUnitariasAutomatizadas As bit,
	@pruebasFuncionalesAutomatizadas As bit,
	@inspeccionContinua As bit,
	@integracionContinua As bit,
	@despliegueContinuo As bit,
	@monitoreoContinuo As bit,
	@seguridadContinua As bit,
	@rendimientoContinuo As bit,
	@infraestructuraComoCodigo As bit,
	@notasControlDocumentacion As varchar(2000),
	@notasGestionTareas As varchar(2000),
	@notasGestionErrores As varchar(2000),
	@notasControlCodigo As varchar(2000),
	@notasPruebasUnitariasAutomatizadas As varchar(2000),
	@notasPruebasFuncionalesAutomatizadas As varchar(2000),
	@notasInspeccionContinua As varchar(2000),
	@notasIntegracionContinua As varchar(2000),
	@notasDespliegueContinuo As varchar(2000),
	@notasMonitoreoContinuo As varchar(2000),
	@notasSeguridadContinua As varchar(2000),
	@notasRendimientoContinuo As varchar(2000),
	@notasInfraestructuraComoCodigo As varchar(2000)
AS

INSERT INTO [dbo].[PracticasCalidad]
           ([Id]
           ,[IdSolucion]
           ,[ControlDocumentacion]
           ,[GestionTareas]
           ,[GestionErrores]
           ,[ControlCodigo]
           ,[PruebasUnitariasAutomatizadas]
           ,[PruebasFuncionalesAutomatizadas]
           ,[InspeccionContinua]
           ,[IntegracionContinua]
           ,[DespliegueContinuo]
           ,[MonitoreoContinuo]
		   ,[SeguridadContinua]
		   ,[RendimientoContinuo]
		   ,[InfraestructuraComoCodigo]
		   ,[NotasControlDocumentacion]
		   ,[NotasGestionTareas]
		   ,[NotasGestionErrores]
		   ,[NotasControlCodigo]
		   ,[NotasPruebasUnitariasAutomatizadas]
		   ,[NotasPruebasFuncionalesAutomatizadas]
		   ,[NotasInspeccionContinua]
		   ,[NotasIntegracionContinua]
		   ,[NotasDespliegueContinuo]
		   ,[NotasMonitoreoContinuo]
		   ,[NotasSeguridadContinua]
		   ,[NotasRendimientoContinuo]
		   ,[NotasInfraestructuraComoCodigo])
     VALUES
           (NEWID(),
			@idSolucion,	
			@controlDocumentacion,
			@gestionTareas,
			@gestionErrores,
			@controlCodigo,
			@pruebasUnitariasAutomatizadas,
			@pruebasFuncionalesAutomatizadas,
			@inspeccionContinua,
			@integracionContinua,
			@despliegueContinuo,
			@monitoreoContinuo,
			@seguridadContinua,
			@rendimientoContinuo,
			@infraestructuraComoCodigo,
			@notasControlDocumentacion,
			@notasGestionTareas,
			@notasGestionErrores,
			@notasControlCodigo,
			@notasPruebasUnitariasAutomatizadas,
			@notasPruebasFuncionalesAutomatizadas,
			@notasInspeccionContinua,
			@notasIntegracionContinua,
			@notasDespliegueContinuo,
			@notasMonitoreoContinuo,
			@notasSeguridadContinua,
			@notasRendimientoContinuo,
			@notasInfraestructuraComoCodigo )

