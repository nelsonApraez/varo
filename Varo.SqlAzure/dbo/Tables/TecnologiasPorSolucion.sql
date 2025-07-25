CREATE TABLE [TecnologiasPorSolucion]
(
	[IdSolucion] uniqueidentifier NOT NULL,
	[IdTecnologia] uniqueidentifier NOT NULL
);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [TecnologiasPorSolucion] 
 ADD CONSTRAINT [PK_TecnologiasAplicacionPorSolucion]
	PRIMARY KEY CLUSTERED ([IdSolucion] ASC,[IdTecnologia] ASC);
go

CREATE NONCLUSTERED INDEX [IXFK_TecnologiasAplicacionPorSolucion_Soluciones] 
 ON [TecnologiasPorSolucion] ([IdSolucion] ASC);
go

CREATE NONCLUSTERED INDEX [IXFK_TecnologiasAplicacionPorSolucion_TecnologiasAplicacion] 
 ON [TecnologiasPorSolucion] ([IdTecnologia] ASC);
go

/* Create Foreign Key Constraints */

ALTER TABLE [TecnologiasPorSolucion] ADD CONSTRAINT [FK_TecnologiasAplicacionPorSolucion_Soluciones]
	FOREIGN KEY ([IdSolucion]) REFERENCES [Soluciones] ([Id]) ON DELETE No Action ON UPDATE No Action;
go

ALTER TABLE [TecnologiasPorSolucion] ADD CONSTRAINT [FK_TecnologiasAplicacionPorSolucion_TecnologiasAplicacion]
	FOREIGN KEY ([IdTecnologia]) REFERENCES [Tecnologias] ([Id]) ON DELETE No Action ON UPDATE No Action;
go
