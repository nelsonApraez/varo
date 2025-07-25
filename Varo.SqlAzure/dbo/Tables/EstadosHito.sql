CREATE TABLE [EstadosHito]
(
	[Id] TINYINT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] VARCHAR(50) NOT NULL, 
    [NombreEN] VARCHAR(50) NOT NULL
)

/* Initial records */

--INSERT INTO [dbo].[EstadosHito] ([Nombre],[NombreEN]) VALUES ('Abierto','Open')
--INSERT INTO [dbo].[EstadosHito] ([Nombre],[NombreEN]) VALUES ('Cerrado','Closed')
