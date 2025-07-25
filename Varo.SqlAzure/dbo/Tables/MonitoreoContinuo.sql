CREATE TABLE [MonitoreoContinuo]
(
	[Id] uniqueidentifier NOT NULL,
	[IdSolucion] uniqueidentifier NOT NULL,
	[Nombre] varchar(50) NULL,
	[UrlMonitoreo] varchar(255) NULL
);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [MonitoreoContinuo] 
 ADD CONSTRAINT [PK_MonitoreoContinuo]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

CREATE NONCLUSTERED INDEX [IXFK_MonitoreoContinuo_Soluciones] 
 ON [MonitoreoContinuo] ([IdSolucion] ASC);
go

/* Create Foreign Key Constraints */

ALTER TABLE [MonitoreoContinuo] ADD CONSTRAINT [FK_MonitoreoContinuo_Soluciones]
	FOREIGN KEY ([IdSolucion]) REFERENCES [Soluciones] ([Id]) ON DELETE No Action ON UPDATE No Action;
go
