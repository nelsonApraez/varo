CREATE TABLE [Historias]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [IdMetricaAgil] INT NOT NULL, 
    [Numero] VARCHAR(10) NOT NULL, 
    [Nombre] VARCHAR(500) NOT NULL, 
    [EsfuerzoEstimado] DECIMAL(18, 2) NOT NULL, 
    [EsfuerzoReal] DECIMAL(18, 2) NOT NULL, 
    [Observaciones] VARCHAR(500) NULL
)
GO
/* Create Foreign Key Constraints */
ALTER TABLE [Historias] ADD CONSTRAINT [FK_Historias_MetricasAgiles]
	FOREIGN KEY ([IdMetricaAgil]) REFERENCES [MetricasAgiles] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO
