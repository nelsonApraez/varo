CREATE PROCEDURE [dbo].[uspPracticasCalidadSelectPorIdSolucion]
	@idSolucion AS uniqueidentifier
AS

   SELECT
		Id,
		IdSolucion,
		ControlDocumentacion,
        GestionTareas,
        GestionErrores,
        ControlCodigo,
        PruebasUnitariasAutomatizadas,
        PruebasFuncionalesAutomatizadas,
        InspeccionContinua,
        IntegracionContinua,
        DespliegueContinuo,
        MonitoreoContinuo,
		SeguridadContinua,
		RendimientoContinuo,
        InfraestructuraComoCodigo,
        NotasControlDocumentacion,
        NotasGestionTareas,
		NotasGestionErrores,
		NotasControlCodigo,
		NotasPruebasUnitariasAutomatizadas,
		NotasPruebasFuncionalesAutomatizadas,
		NotasInspeccionContinua,
		NotasIntegracionContinua,
		NotasDespliegueContinuo,
		NotasMonitoreoContinuo,
		NotasSeguridadContinua,
		NotasRendimientoContinuo,
		NotasInfraestructuraComoCodigo

	FROM PracticasCalidad
   WHERE IdSolucion = @idSolucion
