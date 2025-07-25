CREATE TABLE [dbo].[AccionesMejora]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [IdMetricaAgil] INT NOT NULL, 
    [Accion] VARCHAR(500) NOT NULL, 
    [IdResponsable] TINYINT NOT NULL, 
    [IdEstado] TINYINT NOT NULL,
	[Causa] VARCHAR(500) NULL 
)
GO
/* Create Foreign Key Constraints */
ALTER TABLE [AccionesMejora] ADD CONSTRAINT [FK_AccionesMejora_MetricasAgiles]
	FOREIGN KEY ([IdMetricaAgil]) REFERENCES [MetricasAgiles] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO
ALTER TABLE [AccionesMejora] ADD CONSTRAINT [FK_AccionesMejora_ResponsablesAccionesMejora]
	FOREIGN KEY ([IdResponsable]) REFERENCES [ResponsablesAccionesMejora] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO
ALTER TABLE [AccionesMejora] ADD CONSTRAINT [FK_AccionesMejora_EstadosAccionesMejora]
	FOREIGN KEY ([IdEstado]) REFERENCES [EstadosAccionesMejora] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO
