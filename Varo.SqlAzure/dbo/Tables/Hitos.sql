CREATE TABLE [dbo].[Hitos]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdSolucion] UNIQUEIDENTIFIER NOT NULL, 
    [IdTipo] TINYINT NOT NULL, 
    [Descripcion] VARCHAR(8000) NOT NULL, 
    [FechaCierre] SMALLDATETIME NOT NULL,
    [IdEstado] TINYINT NOT NULL,
    [Observaciones] VARCHAR(8000) NOT NULL, 
)
GO

/* Create Foreign Key Constraints */
ALTER TABLE [Hitos] ADD CONSTRAINT [FK_Hito_TiposHito]
	FOREIGN KEY ([IdTipo]) REFERENCES TiposHito ([Id]) ON DELETE No Action ON UPDATE No Action;
GO

ALTER TABLE [Hitos] ADD CONSTRAINT [FK_Hito_Soluciones]
	FOREIGN KEY ([IdSolucion]) REFERENCES [Soluciones] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO

ALTER TABLE [Hitos] ADD CONSTRAINT [FK_Hito_EstadosHito]
	FOREIGN KEY ([IdEstado]) REFERENCES [EstadosHito] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO
