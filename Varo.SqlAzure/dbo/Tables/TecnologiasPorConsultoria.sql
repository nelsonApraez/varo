CREATE TABLE [dbo].[TecnologiasPorConsultoria]
(
    [IdConsultoria] uniqueidentifier NOT NULL,
	[IdTecnologia] uniqueidentifier NOT NULL
);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [TecnologiasPorConsultoria] 
 ADD CONSTRAINT [PK_TecnologiasAplicacionPorConsultoria]
	PRIMARY KEY CLUSTERED ([IdConsultoria] ASC,[IdTecnologia] ASC);
go

CREATE NONCLUSTERED INDEX [IXFK_TecnologiasAplicacionPorConsultoria_Consultorias] 
 ON [TecnologiasPorConsultoria] ([IdConsultoria] ASC);
go

CREATE NONCLUSTERED INDEX [IXFK_TecnologiasAplicacionPorSolucion_TecnologiasAplicacion] 
 ON [TecnologiasPorConsultoria] ([IdTecnologia] ASC);
go

/* Create Foreign Key Constraints */

ALTER TABLE [TecnologiasPorConsultoria] ADD CONSTRAINT [FK_TecnologiasAplicacionPorConsultoria_Consultorias]
	FOREIGN KEY ([IdConsultoria]) REFERENCES [Consultoria] ([Id]) ON DELETE No Action ON UPDATE No Action;
go

ALTER TABLE [TecnologiasPorConsultoria] ADD CONSTRAINT [FK_TecnologiasAplicacionPorConsultorias_TecnologiasAplicacion]
	FOREIGN KEY ([IdTecnologia]) REFERENCES [Tecnologias] ([Id]) ON DELETE No Action ON UPDATE No Action;
go

