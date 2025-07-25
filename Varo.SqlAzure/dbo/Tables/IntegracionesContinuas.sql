CREATE TABLE [IntegracionesContinuas]
(
	[Id] uniqueidentifier NOT NULL,
	[IdSolucion] uniqueidentifier NOT NULL,
	[Nombre] varchar(50) NOT NULL,
	[UrlCompilacion] varchar(255) NOT NULL,
	[UrlInspeccion] varchar(255) NULL, 
    [IdProyectoInspeccion] INT NULL, 
);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [IntegracionesContinuas] 
 ADD CONSTRAINT [PK_IntegracionesContinuas]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

CREATE NONCLUSTERED INDEX [IXFK_IntegracionesContinuas_Soluciones] 
 ON [IntegracionesContinuas] ([IdSolucion] ASC);
go

/* Create Foreign Key Constraints */

ALTER TABLE [IntegracionesContinuas] ADD CONSTRAINT [FK_IntegracionesContinuas_Soluciones]
	FOREIGN KEY ([IdSolucion]) REFERENCES [Soluciones] ([Id]) ON DELETE No Action ON UPDATE No Action;
go
