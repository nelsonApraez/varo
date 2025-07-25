CREATE TABLE [dbo].[AuditoriaSolucion]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdSolucion] UNIQUEIDENTIFIER NOT NULL, 
    [Url] VARCHAR(255) NOT NULL, 
    [Calificacion] DECIMAL(18, 2) NULL, 
    [Fecha] SMALLDATETIME NOT NULL,
    [Proceso] VARCHAR(500) NULL,
    [Observacion] VARCHAR(500) NULL
)

go

ALTER TABLE [AuditoriaSolucion] ADD CONSTRAINT [FK_AuditoriaSolucion_Soluciones]
	FOREIGN KEY ([IdSolucion]) REFERENCES [Soluciones] ([Id]) ON DELETE No Action ON UPDATE No Action;
go
