CREATE TABLE [Seguimiento]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [IdAccionesMejora] INT NOT NULL, 
    [Observacion] VARCHAR(500) NOT NULL, 
    [Fecha] DATETIME NOT NULL, 
    [Usuario] VARCHAR(50) NOT NULL 
)
GO
/* Create Foreign Key Constraints */
ALTER TABLE [Seguimiento] ADD CONSTRAINT [FK_Seguimiento_AccionesMejora]
	FOREIGN KEY ([IdAccionesMejora]) REFERENCES [AccionesMejora] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO
