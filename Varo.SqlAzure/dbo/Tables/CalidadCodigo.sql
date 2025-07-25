CREATE TABLE [CalidadCodigo]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [IdMetricaAgil] INT NOT NULL, 
    [Bugs] INT NOT NULL, 
    [Vulnerabilidades] INT NOT NULL, 
    [DeudaTecnica] DECIMAL(18, 2) NOT NULL, 
    [Cobertura] DECIMAL(18, 2) NOT NULL, 
    [Duplicado] DECIMAL(18, 2) NOT NULL, 
    [Observaciones] VARCHAR(500) NULL
)
GO
/* Create Foreign Key Constraints */
ALTER TABLE [CalidadCodigo] ADD CONSTRAINT [FK_CalidadCodigo_MetricasAgiles]
	FOREIGN KEY ([IdMetricaAgil]) REFERENCES [MetricasAgiles] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO
