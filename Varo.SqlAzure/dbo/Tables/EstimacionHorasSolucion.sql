CREATE TABLE [EstimacionHorasSolucion]
(
	[Id] uniqueidentifier NOT NULL,
	[IdSolucion] uniqueidentifier NOT NULL,
	[Concepto] varchar(500) NULL,
	[HorasEstimadas] int NULL,
	[HorasEjecutadas] int NULL
);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [EstimacionHorasSolucion] 
 ADD CONSTRAINT [PK_EstimacionHorasSolucion]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

CREATE NONCLUSTERED INDEX [IXFK_EstimacionHorasSolucion_Solucion] 
 ON [EstimacionHorasSolucion] ([IdSolucion] ASC);
go

/* Create Foreign Key Constraints */

ALTER TABLE [EstimacionHorasSolucion] ADD CONSTRAINT [FK_EstimacionHorasSolucion_Solucion]
	FOREIGN KEY ([IdSolucion]) REFERENCES [Soluciones] ([Id]) ON DELETE No Action ON UPDATE No Action;
go
