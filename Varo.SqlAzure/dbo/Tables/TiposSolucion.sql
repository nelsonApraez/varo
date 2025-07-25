CREATE TABLE [TiposSolucion]
(
	[Id] tinyint NOT NULL,    -- Identificador interno de la tabla.
	[Nombre] varchar(12) NOT NULL    -- Nombre de la descripci�n.
, 
    [NombreEN] VARCHAR(12) NULL);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [TiposSolucion] 
 ADD CONSTRAINT [PK_TiposSolucion]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

ALTER TABLE [TiposSolucion] 
 ADD CONSTRAINT [UK_TiposSolucion_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC);
go

/* Create Table Comments */

EXEC sp_addextendedproperty 'MS_Description', 'Almacena la informaci�n de los tipos de soluci�n que se manejan en company.', 'Schema', [dbo], 'table', [TiposSolucion];
go

EXEC sp_addextendedproperty 'MS_Description', 'Identificador interno de la tabla.', 'Schema', [dbo], 'table', [TiposSolucion], 'column', [Id];
go

EXEC sp_addextendedproperty 'MS_Description', 'Nombre de la descripci�n.', 'Schema', [dbo], 'table', [TiposSolucion], 'column', [Nombre];
go
