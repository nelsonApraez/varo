CREATE TABLE [MetricasAgiles]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
    [IdSolucion] UNIQUEIDENTIFIER NOT NULL,
    [Sprint] VARCHAR(500) NOT NULL, 
    [FechaInicial] SMALLDATETIME NOT NULL, 
    [FechaFinal] SMALLDATETIME NOT NULL, 
    [IdEquipo] UNIQUEIDENTIFIER NULL
)
GO
/* Create Foreign Key Constraints */
ALTER TABLE [MetricasAgiles] ADD CONSTRAINT [FK_MetricasAgiles_Soluciones]
	FOREIGN KEY ([IdSolucion]) REFERENCES [Soluciones] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO

ALTER TABLE [MetricasAgiles] ADD CONSTRAINT [FK_MetricasAgiles_Equipo]
	FOREIGN KEY ([IdEquipo]) REFERENCES [EquipoSolucion] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO
