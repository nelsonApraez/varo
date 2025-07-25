CREATE TABLE [ResponsablesAccionesMejora]
(
	[Id] TINYINT NOT NULL, 
    [Nombre] VARCHAR(50) NOT NULL, 
    [NombreEN] VARCHAR(50) NULL 
);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [ResponsablesAccionesMejora] 
 ADD CONSTRAINT [PK_ResponsablesAccionesMejora]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

ALTER TABLE [ResponsablesAccionesMejora] 
 ADD CONSTRAINT [UK_ResponsablesAccionesMejora_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC);
GO

/* Initial records */

--INSERT INTO [dbo].[ResponsablesAccionesMejora] ([Id], [Nombre], [NombreEN]) VALUES (1, 'Dueño del Producto', 'Product Owner')
--INSERT INTO [dbo].[ResponsablesAccionesMejora] ([Id], [Nombre], [NombreEN]) VALUES (2, 'Maestro Scrum', 'Scrum Master')
--INSERT INTO [dbo].[ResponsablesAccionesMejora] ([Id], [Nombre], [NombreEN]) VALUES (3, 'Equipo de Desarrollo', 'Development Team')
--INSERT INTO [dbo].[ResponsablesAccionesMejora] ([Id], [Nombre], [NombreEN]) VALUES (4, 'Interesado', 'Stakeholder')
