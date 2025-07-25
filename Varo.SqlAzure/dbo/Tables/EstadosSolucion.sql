CREATE TABLE [EstadosSolucion]
(
	[Id] tinyint NOT NULL,    -- Identificador interno de la tabla.
	[Nombre] varchar(30) NOT NULL    -- Nombre del estado.
, 
    [NombreEN] VARCHAR(30) NULL);
go
/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [EstadosSolucion] 
 ADD CONSTRAINT [PK_EstadosSolucion]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

ALTER TABLE [EstadosSolucion] 
 ADD CONSTRAINT [UK_EstadosSolucion_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC);
go

/* Create Table Comments */

EXEC sp_addextendedproperty 'MS_Description', 'Almacena la información de los estados que maneja una solución.', 'Schema', [dbo], 'table', [EstadosSolucion];
go

EXEC sp_addextendedproperty 'MS_Description', 'Identificador interno de la tabla.', 'Schema', [dbo], 'table', [EstadosSolucion], 'column', [Id];
go

EXEC sp_addextendedproperty 'MS_Description', 'Nombre del estado.', 'Schema', [dbo], 'table', [EstadosSolucion], 'column', [Nombre];
go
