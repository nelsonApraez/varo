CREATE TABLE [EquipoSolucion]
(
	[Id] uniqueidentifier NOT NULL, 
    [Nombre] VARCHAR(500) NOT NULL, 
    [IdSolucion] UNIQUEIDENTIFIER NOT NULL
);
go

ALTER TABLE [EquipoSolucion] 
 ADD CONSTRAINT [PK_EquipoSolucion]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

ALTER TABLE [EquipoSolucion] ADD CONSTRAINT [FK_EquipoSolucion_Soluciones]
	FOREIGN KEY ([IdSolucion]) REFERENCES [Soluciones] ([Id]) ON DELETE No Action ON UPDATE No Action;
go

