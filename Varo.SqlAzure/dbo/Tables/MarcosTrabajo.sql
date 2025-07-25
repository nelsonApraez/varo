CREATE TABLE [MarcosTrabajo]
(
	[Id] tinyint NOT NULL,
	[Nombre] varchar(20) NOT NULL, 
    [NombreEN] VARCHAR(20) NULL
);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [MarcosTrabajo] 
 ADD CONSTRAINT [PK_MarcosTrabajo]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

ALTER TABLE [MarcosTrabajo] 
 ADD CONSTRAINT [UK_MarcosTrabajo_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC);
go
