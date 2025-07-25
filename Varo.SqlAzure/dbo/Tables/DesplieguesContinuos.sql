CREATE TABLE [DesplieguesContinuos]
(
	[Id] uniqueidentifier NOT NULL,
	[IdSolucion] uniqueidentifier NOT NULL,
	[Nombre] varchar(50) NULL,
	[UrlDespliegue] varchar(255) NULL
);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [DesplieguesContinuos] 
 ADD CONSTRAINT [PK_DesplieguesContinuos]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

CREATE NONCLUSTERED INDEX [IXFK_DesplieguesContinuos_Soluciones] 
 ON [DesplieguesContinuos] ([IdSolucion] ASC);
go

/* Create Foreign Key Constraints */

ALTER TABLE [DesplieguesContinuos] ADD CONSTRAINT [FK_DesplieguesContinuos_Soluciones]
	FOREIGN KEY ([IdSolucion]) REFERENCES [Soluciones] ([Id]) ON DELETE No Action ON UPDATE No Action;
go
