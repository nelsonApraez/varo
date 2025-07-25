CREATE TABLE [dbo].[AuditoriaConsultoria]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdConsultoria] UNIQUEIDENTIFIER NOT NULL, 
    [Url] VARCHAR(255) NOT NULL, 
    [Calificacion] DECIMAL(18, 2) NULL, 
    [Fecha] SMALLDATETIME NOT NULL,
    [Proceso] VARCHAR(500) NULL,
    [Observacion] VARCHAR(500) NULL
)

go

ALTER TABLE [AuditoriaConsultoria] ADD CONSTRAINT [FK_AuditoriaConsultoria_Consultoria]
	FOREIGN KEY ([IdConsultoria]) REFERENCES [Consultoria] ([Id]) ON DELETE No Action ON UPDATE No Action;
go
