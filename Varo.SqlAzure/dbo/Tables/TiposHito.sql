CREATE TABLE [TiposHito]
(
	[Id] TINYINT NOT NULL IDENTITY,
	[Nombre] varchar(100), 
    [NombreEN] VARCHAR(100) NULL
);
GO

/* Create Table Comments */

EXEC sp_addextendedproperty 'MS_Description', 'Almacena lis tipos de hitos.', 'Schema', [dbo], 'table', [TiposHito];
GO

EXEC sp_addextendedproperty 'MS_Description', 'Identificador interno de la tabla.', 'Schema', [dbo], 'table', [TiposHito], 'column', [Id];
GO

EXEC sp_addextendedproperty 'MS_Description', 'Nombre del tipo de hito.', 'Schema', [dbo], 'table', [TiposHito], 'column', [Nombre];
GO

/* Create Foreign Key Constraints */

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [TiposHito] ADD CONSTRAINT [PK_TiposHito] PRIMARY KEY CLUSTERED ([Id]);
GO

ALTER TABLE [TiposHito] ADD CONSTRAINT [UK_TiposHito_Nombre] UNIQUE NONCLUSTERED ([Nombre]);
GO

/* Initial records */

--INSERT INTO [dbo].[TiposHito] ([Nombre],[NombreEN]) VALUES ('Información', 'Information')
--INSERT INTO [dbo].[TiposHito] ([Nombre],[NombreEN]) VALUES ('Documentación', 'Documentation')
--INSERT INTO [dbo].[TiposHito] ([Nombre],[NombreEN]) VALUES ('Practicas técnicas', 'Technical practices')
--INSERT INTO [dbo].[TiposHito] ([Nombre],[NombreEN]) VALUES ('Calidad de código', 'Code quality')
--INSERT INTO [dbo].[TiposHito] ([Nombre],[NombreEN]) VALUES ('Pruebas de IU', 'UI test')
--INSERT INTO [dbo].[TiposHito] ([Nombre],[NombreEN]) VALUES ('Compromisos', 'Commitments')
--INSERT INTO [dbo].[TiposHito] ([Nombre],[NombreEN]) VALUES ('Riesgos', 'Risks')
