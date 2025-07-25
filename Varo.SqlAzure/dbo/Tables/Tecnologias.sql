CREATE TABLE [Tecnologias]
(
	[Id] uniqueidentifier NOT NULL,
	[IdTipoTecnologia] tinyint NOT NULL,
	[Nombre] varchar(30) NOT NULL,
	[Logo] varchar(50) NULL
);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [Tecnologias] 
 ADD CONSTRAINT [PK_TecnologiasAplicacion]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

CREATE NONCLUSTERED INDEX [IXFK_Tecnologias_TiposTecnologia] 
 ON [Tecnologias] ([IdTipoTecnologia] ASC);
go

CREATE NONCLUSTERED INDEX [UK_Nombre] 
 ON [Tecnologias] ([Nombre] ASC);
go

/* Create Foreign Key Constraints */

ALTER TABLE [Tecnologias] ADD CONSTRAINT [FK_Tecnologias_TiposTecnologia]
	FOREIGN KEY ([IdTipoTecnologia]) REFERENCES [TiposTecnologia] ([Id]) ON DELETE No Action ON UPDATE No Action;
go
