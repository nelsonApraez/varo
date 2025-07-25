CREATE TABLE [DefectosExternos]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [IdMetricaAgil] INT NOT NULL, 
    [Reportados] INT NOT NULL, 
    [Cerrados] INT NOT NULL, 
    [Actuales] INT NOT NULL, 
    [Abiertos] INT NOT NULL, 
    [Densidad] DECIMAL(18, 2) NOT NULL, 
    [Observaciones] VARCHAR(500) NULL
)
GO
/* Create Foreign Key Constraints */
ALTER TABLE [DefectosExternos] ADD CONSTRAINT [FK_DefectosExternos_MetricasAgiles]
	FOREIGN KEY ([IdMetricaAgil]) REFERENCES [MetricasAgiles] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO
