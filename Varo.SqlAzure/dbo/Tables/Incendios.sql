CREATE TABLE [Incendios]
(
	[Id] INT IDENTITY(1,1), 
    [IdMetricaAgil] INT NOT NULL, 
    [Reportados] INT NOT NULL, 
    [Solucionados] INT NOT NULL, 
    [Observaciones] VARCHAR(500) NULL, 
    CONSTRAINT [PK_Incendios] PRIMARY KEY ([Id])
)
GO
/* Create Foreign Key Constraints */
ALTER TABLE [Incendios] ADD CONSTRAINT [FK_Incendios_MetricasAgiles]
	FOREIGN KEY ([IdMetricaAgil]) REFERENCES [MetricasAgiles] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO
