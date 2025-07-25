CREATE TABLE [TiposTecnologia]
(
	[Id] tinyint NOT NULL,
	[Nombre] varchar(30) NOT NULL, 
    [NombreEN] VARCHAR(30) NULL
);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [TiposTecnologia] 
 ADD CONSTRAINT [PK_LenguajesDeProgramacion]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

CREATE NONCLUSTERED INDEX [UK_Nombre] 
 ON [TiposTecnologia] ([Nombre] ASC);
go
