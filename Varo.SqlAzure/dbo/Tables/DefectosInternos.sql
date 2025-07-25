CREATE TABLE [DefectosInternos]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [IdMetricaAgil] INT NOT NULL, 
    [Reportados] INT NOT NULL, 
    [Cerrados] INT NOT NULL, 
    [Actuales] INT NOT NULL, 
    [Abiertos] INT NOT NULL, 
    [Observaciones] VARCHAR(500) NULL
)
GO
/* Create Foreign Key Constraints */
ALTER TABLE [DefectosInternos] ADD CONSTRAINT [FK_DefectosInternos_MetricasAgiles]
	FOREIGN KEY ([IdMetricaAgil]) REFERENCES [MetricasAgiles] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO
