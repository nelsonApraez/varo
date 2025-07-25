CREATE TABLE [HistoriasyEsfuerzos]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [IdMetricaAgil] INT NOT NULL, 
    [HistoriasEstimadas] INT NOT NULL, 
    [HistoriasLogradas] INT NOT NULL, 
    [EsfuerzoEstimado] DECIMAL(18, 2) NOT NULL, 
    [EsfuerzoLogrado] DECIMAL(18, 2) NOT NULL, 
    [Observaciones] VARCHAR(500) NULL
)
GO
/* Create Foreign Key Constraints */
ALTER TABLE [HistoriasyEsfuerzos] ADD CONSTRAINT [FK_HistoriasyEsfuerzos_MetricasAgiles]
	FOREIGN KEY ([IdMetricaAgil]) REFERENCES [MetricasAgiles] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO
