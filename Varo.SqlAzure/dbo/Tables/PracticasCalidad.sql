CREATE TABLE [PracticasCalidad]
(
	[Id] uniqueidentifier NOT NULL,
	[IdSolucion] uniqueidentifier NOT NULL,
	[ControlDocumentacion] BIT NULL,
	[GestionTareas] bit NULL,
	[GestionErrores] bit NULL,
	[ControlCodigo] bit NULL,
	[PruebasUnitariasAutomatizadas] bit NULL,
	[PruebasFuncionalesAutomatizadas] bit NULL,
	[InspeccionContinua] bit NULL,
	[IntegracionContinua] bit NULL,
	[DespliegueContinuo] bit NULL,
	[MonitoreoContinuo] bit NULL,
	[SeguridadContinua] bit NULL,
	[RendimientoContinuo] bit NULL, 
    [InfraestructuraComoCodigo] BIT NULL, 
    [NotasControlDocumentacion] VARCHAR(2000) NULL, 
    [NotasGestionTareas] VARCHAR(2000) NULL, 
    [NotasGestionErrores] VARCHAR(2000) NULL, 
    [NotasControlCodigo] VARCHAR(2000) NULL, 
    [NotasPruebasUnitariasAutomatizadas] VARCHAR(2000) NULL, 
    [NotasPruebasFuncionalesAutomatizadas] VARCHAR(2000) NULL, 
    [NotasInspeccionContinua] VARCHAR(2000) NULL, 
    [NotasIntegracionContinua] VARCHAR(2000) NULL, 
    [NotasDespliegueContinuo] VARCHAR(2000) NULL, 
    [NotasMonitoreoContinuo] VARCHAR(2000) NULL,
	[NotasSeguridadContinua] VARCHAR(2000) NULL,
	[NotasRendimientoContinuo] VARCHAR(2000) NULL, 
    [NotasInfraestructuraComoCodigo] VARCHAR(2000) NULL
);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [PracticasCalidad] 
 ADD CONSTRAINT [PK_PracticasCalidad]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

CREATE NONCLUSTERED INDEX [IXFK_PracticasCalidad_Soluciones] 
 ON [PracticasCalidad] ([IdSolucion] ASC);
go

/* Create Foreign Key Constraints */

ALTER TABLE [PracticasCalidad] ADD CONSTRAINT [FK_PracticasCalidad_Soluciones]
	FOREIGN KEY ([IdSolucion]) REFERENCES [Soluciones] ([Id]) ON DELETE No Action ON UPDATE No Action;
go
