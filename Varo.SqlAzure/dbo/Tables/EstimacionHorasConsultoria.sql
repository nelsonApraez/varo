CREATE TABLE [EstimacionHorasConsultoria]
(
	[Id] uniqueidentifier NOT NULL,
	[IdConsultoria] uniqueidentifier NOT NULL,
	[Concepto] varchar(500) NULL,
	[HorasEstimadas] int NULL,
	[HorasEjecutadas] int NULL
);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [EstimacionHorasConsultoria] 
 ADD CONSTRAINT [PK_EstimacionHorasConsultoria]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

CREATE NONCLUSTERED INDEX [IXFK_EstimacionHorasConsultoria_Consultoria] 
 ON [EstimacionHorasConsultoria] ([IdConsultoria] ASC);
go

/* Create Foreign Key Constraints */

ALTER TABLE [EstimacionHorasConsultoria] ADD CONSTRAINT [FK_EstimacionHorasConsultoria_Consultoria]
	FOREIGN KEY ([IdConsultoria]) REFERENCES [Consultoria] ([Id]) ON DELETE No Action ON UPDATE No Action;
go
