CREATE TABLE [LineaNegocio]
(
	[Id] tinyint NOT NULL,
	[Nombre] varchar(30) NOT NULL, 
    [NombreEN] VARCHAR(30) NULL
);
GO

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [LineaNegocio] 
 ADD CONSTRAINT [PK_LineaNegocio]
	PRIMARY KEY CLUSTERED ([Id] ASC);
GO

ALTER TABLE [LineaNegocio] 
 ADD CONSTRAINT [UK_LineaNegocio_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC);
GO
