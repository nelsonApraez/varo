CREATE TABLE [EstadosAccionesMejora]
(
	[Id] TINYINT NOT NULL, 
    [Nombre] VARCHAR(50) NOT NULL, 
    [NombreEN] VARCHAR(50) NULL 
)
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [EstadosAccionesMejora] 
 ADD CONSTRAINT [PK_EstadosAccionesMejora]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

ALTER TABLE [EstadosAccionesMejora] 
 ADD CONSTRAINT [UK_EstadosAccionesMejora_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC);
go
