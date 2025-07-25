CREATE TABLE [Soluciones]
(
	[Id] uniqueidentifier NOT NULL,    -- Identificador interno de la tabla.
	[Nombre] varchar(100) NOT NULL,
	[UsuarioRedGerente] varchar(50) NOT NULL,
	[UsuarioRedResponsable] varchar(50) NOT NULL,
	[UsuarioRedScrumMaster] VARCHAR(50) NULL,
	[IdTipo] tinyint NOT NULL,
	[IdMarcoTrabajo] tinyint NOT NULL,
	[IdLineaSolucion] tinyint NOT NULL,
	[IdLineaNegocio] tinyint NOT NULL,
	[IdEstado] tinyint NOT NULL,
	[IdOficina] tinyint NOT NULL,
	[IdCliente] int NOT NULL,
	[IdPais] tinyint NOT NULL,
	[IdDepartamento] int NULL,
	[IdCiudad] int NULL,
	[UrlRepositorioCodigoFuente] varchar(255) NOT NULL,
	[UrlDocumentacion] varchar(255) NOT NULL,
	[UrlDiseno] [varchar](255) NULL,
	[UrlGestionTareas] [varchar](255) NULL,
	[UrlGestionIncidentes] [varchar](255) NULL,
	[UrlGestionAseguramientoCalidad] [varchar](255) NULL,
	[UrlLeccionesAprendidas] [varchar](255) NULL,
	[UrlInspeccion] varchar(255) NULL,
    [UrlOportunidadCrm] [varchar](255) NULL,
    [UrlProyectoPsa] [varchar](255) NULL,
	[NombreContactoCliente] varchar(100) NOT NULL,
	[CorreoContactoCliente] varchar(70) NOT NULL,
	[TelefonoContactoCliente] varchar(12) NULL,
	[FechaCreacionModificacion] datetime NOT NULL,
	[UsuarioRedCreacionModificacion] varchar(50) NOT NULL, 
    [Observacion] VARCHAR(2000) NULL, 
    [Descripcion] VARCHAR(2000) NULL, 
    [FechaCreacion] DATETIME NULL, 
    [FechaCierre] DATETIME NULL, 
    [ExperienciaUsuario] BIT NULL, 
    [Etiqueta] VARCHAR(5000) NULL, 
    [HorasEstimadas] INT NULL, 
    [HorasEjecutadas] INT NULL,
    [IdUsosComerciales] TINYINT NULL, 
    [IdConsultoria] UNIQUEIDENTIFIER NULL, 
    [ObjetivoNegocio] INT NULL, 
);
GO

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [Soluciones] 
 ADD CONSTRAINT [PK_Soluciones]
	PRIMARY KEY CLUSTERED ([Id] ASC);
GO

CREATE NONCLUSTERED INDEX [IXFK_Soluciones_EstadosSolucion] 
 ON [Soluciones] ([IdEstado] ASC);
GO

CREATE NONCLUSTERED INDEX [IXFK_Soluciones_LineaSolucion] 
 ON [Soluciones] ([IdLineaSolucion] ASC);
GO

CREATE NONCLUSTERED INDEX [IXFK_Soluciones_MarcosTrabajo] 
 ON [Soluciones] ([IdMarcoTrabajo] ASC);
GO

CREATE NONCLUSTERED INDEX [IXFK_Soluciones_Oficinas] 
 ON [Soluciones] ([IdOficina] ASC);
GO

CREATE NONCLUSTERED INDEX [IXFK_Soluciones_TiposSolucion] 
 ON [Soluciones] ([IdTipo] ASC);
GO

CREATE NONCLUSTERED INDEX [IXFK_Soluciones_LineaNegocio] 
 ON [Soluciones] ([IdLineaNegocio] ASC);
GO

/* Create Foreign Key Constraints */

ALTER TABLE [Soluciones] ADD CONSTRAINT [FK_Soluciones_EstadosSolucion]
	FOREIGN KEY ([IdEstado]) REFERENCES [EstadosSolucion] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO

ALTER TABLE [Soluciones] ADD CONSTRAINT [FK_Soluciones_LineaNegocio]
	FOREIGN KEY ([IdLineaNegocio]) REFERENCES [LineaNegocio] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO

ALTER TABLE [Soluciones] ADD CONSTRAINT [FK_Soluciones_LineaSolucion]
	FOREIGN KEY ([IdLineaSolucion]) REFERENCES [LineaSolucion] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO

ALTER TABLE [Soluciones] ADD CONSTRAINT [FK_Soluciones_MarcosTrabajo]
	FOREIGN KEY ([IdMarcoTrabajo]) REFERENCES [MarcosTrabajo] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO

ALTER TABLE [Soluciones] ADD CONSTRAINT [FK_Soluciones_Oficinas]
	FOREIGN KEY ([IdOficina]) REFERENCES [Oficinas] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO

ALTER TABLE [Soluciones] ADD CONSTRAINT [FK_Soluciones_TiposSolucion]
	FOREIGN KEY ([IdTipo]) REFERENCES [TiposSolucion] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO

ALTER TABLE [Soluciones] ADD CONSTRAINT [FK_Soluciones_UsosComerciales]
	FOREIGN KEY ([IdUsosComerciales]) REFERENCES [UsosComerciales] ([Id]) ON DELETE No Action ON UPDATE No Action;
GO

/* Create Table Comments */

EXEC sp_addextendedproperty 'MS_Description', 'Almacena las soluciones existentes en company.', 'Schema', [dbo], 'table', [Soluciones];
GO

EXEC sp_addextendedproperty 'MS_Description', 'Identificador interno de la tabla.', 'Schema', [dbo], 'table', [Soluciones], 'column', [Id];
GO
