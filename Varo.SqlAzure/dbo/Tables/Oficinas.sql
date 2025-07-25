CREATE TABLE [Oficinas]
(
	[Id] tinyint NOT NULL,    -- Identificador interno de la tabla.
	[Nombre] varchar(50)    -- Nombre de la oficina de dirección.
, 
    [NombreEN] VARCHAR(50) NULL, 
    [IdGsdc] TINYINT NULL);
GO

ALTER TABLE [Oficinas] ADD CONSTRAINT [FK_Oficinas_Gsdc]
	FOREIGN KEY ([IdGsdc]) REFERENCES [Gsdc] ([Id]) ON DELETE No Action ON UPDATE No Action;
go
/* Create Table Comments */

EXEC sp_addextendedproperty 'MS_Description', 'Almacena las oficinas de dirección (PMO) existentes.', 'Schema', [dbo], 'table', [Oficinas];
GO

EXEC sp_addextendedproperty 'MS_Description', 'Identificador interno de la tabla.', 'Schema', [dbo], 'table', [Oficinas], 'column', [Id];
GO

EXEC sp_addextendedproperty 'MS_Description', 'Nombre de la oficina de dirección.', 'Schema', [dbo], 'table', [Oficinas], 'column', [Nombre];
GO

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [Oficinas] 
 ADD CONSTRAINT [PK_Oficinas]
	PRIMARY KEY CLUSTERED ([Id]);
GO

ALTER TABLE [Oficinas] 
 ADD CONSTRAINT [UK_Oficinas_Nombre] UNIQUE NONCLUSTERED ([Nombre]);
GO
