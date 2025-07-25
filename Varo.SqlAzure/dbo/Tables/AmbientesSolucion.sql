CREATE TABLE [dbo].[AmbientesSolucion]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [IdSolucion] UNIQUEIDENTIFIER NOT NULL, 
    [IdTipoAmbiente] TINYINT NOT NULL, 
    [Ubicacion] VARCHAR(255) NOT NULL, 
    [Responsable] VARCHAR(255) NOT NULL, 
    CONSTRAINT [PK_AmbientesSolucion] PRIMARY KEY ([Id]) 
)

GO

ALTER TABLE [AmbientesSolucion] ADD CONSTRAINT [FK_AmbientesSolucion_Soluciones]
	FOREIGN KEY ([IdSolucion]) REFERENCES [Soluciones] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO

ALTER TABLE [AmbientesSolucion] ADD CONSTRAINT [FK_AmbientesSolucion_Ambientes]
	FOREIGN KEY ([IdTipoAmbiente]) REFERENCES [TiposAmbiente] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO
