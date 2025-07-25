CREATE TABLE [TiposAmbiente]
(
	[Id] TINYINT NOT NULL,
	[Nombre] VARCHAR(50) NOT NULL, 
    [NombreEN] VARCHAR(50) NULL
);
GO

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [TiposAmbiente] ADD CONSTRAINT [PK_TiposAmbiente] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

ALTER TABLE [TiposAmbiente] ADD CONSTRAINT [UK_TiposAmbiente_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC);
GO

/* Create Table Comments */

EXEC sp_addextendedproperty 'MS_Description', 'Almacena la información de los ambientes de desarrollo.', 'Schema', [dbo], 'table', [TiposAmbiente];
GO

EXEC sp_addextendedproperty 'MS_Description', 'Identificador interno de la tabla.', 'Schema', [dbo], 'table', [TiposAmbiente], 'column', [Id];
GO

EXEC sp_addextendedproperty 'MS_Description', 'Nombre del ambiente.', 'Schema', [dbo], 'table', [TiposAmbiente], 'column', [Nombre];
GO

/* Initial records */

--INSERT INTO [dbo].[TiposAmbiente] ([Id], [Nombre], [NombreEN]) VALUES (1, 'DEV', 'DEV')
--INSERT INTO [dbo].[TiposAmbiente] ([Id], [Nombre], [NombreEN]) VALUES (2, 'TEST', 'TEST')
--INSERT INTO [dbo].[TiposAmbiente] ([Id], [Nombre], [NombreEN]) VALUES (3, 'PROD', 'PROD')
