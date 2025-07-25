
CREATE TABLE [dbo].[Consultoria](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[UsuarioRedGerente] [varchar](50) NOT NULL,
	[UsuarioRedConsultor] [varchar](50) NOT NULL,
	[IdLineaConsultoria] [tinyint] NOT NULL,
	[IdLineaNegocio] [tinyint] NOT NULL,
	[IdEstado] [tinyint] NOT NULL,
	[IdOficina] [tinyint] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdPais] [tinyint] NOT NULL,
	[IdDepartamento] [int] NULL,
	[IdCiudad] [int] NULL,
	[UrlDocumentacion] [varchar](255) NOT NULL,
	[UrlDiseno] [varchar](255) NULL,
	[UrlGestionTareas] [varchar](255) NULL,
	[UrlGestionIncidentes] [varchar](255) NULL,
	[UrlGestionAseguramientoCalidad] [varchar](255) NULL,
	[UrlLeccionesAprendidas] [varchar](255) NULL,
    [UrlOportunidadCrm] [varchar](255) NULL,
    [UrlProyectoPsa] [varchar](255) NULL,
	[NombreContactoCliente] [varchar](100) NOT NULL,
	[CorreoContactoCliente] [varchar](70) NOT NULL,
	[TelefonoContactoCliente] [varchar](12) NULL,
	[FechaCreacionModificacion] [datetime] NOT NULL,
	[UsuarioRedCreacionModificacion] [varchar](50) NOT NULL,
	[Observacion] [varchar](2000) NULL,
	[Descripcion] [varchar](2000) NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaCierre] [datetime] NULL,
	[Etiqueta] [varchar](5000) NULL,
	[HorasEstimadas] INT NULL, 
    [HorasEjecutadas] INT NULL, 
    [IdUsosComerciales] TINYINT NULL , 
    [ObjetivoNegocio] INT NULL, 
    CONSTRAINT [PK_Consultoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Consultoria]  WITH CHECK ADD  CONSTRAINT [FK_Consultoria_EstadosConsultoria] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[EstadosConsultoria] ([Id])
GO

ALTER TABLE [dbo].[Consultoria] CHECK CONSTRAINT [FK_Consultoria_EstadosConsultoria]
GO

ALTER TABLE [dbo].[Consultoria]  WITH CHECK ADD  CONSTRAINT [FK_Consultoria_LineaNegocio] FOREIGN KEY([IdLineaNegocio])
REFERENCES [dbo].[LineaNegocio] ([Id])
GO

ALTER TABLE [dbo].[Consultoria] CHECK CONSTRAINT [FK_Consultoria_LineaNegocio]
GO

ALTER TABLE [dbo].[Consultoria]  WITH CHECK ADD  CONSTRAINT [FK_Consultoria_LineaConsultoria] FOREIGN KEY([IdLineaConsultoria])
REFERENCES [dbo].[LineaConsultoria] ([Id])
GO

ALTER TABLE [dbo].[Consultoria] CHECK CONSTRAINT [FK_Consultoria_LineaConsultoria]
GO

ALTER TABLE [dbo].[Consultoria]  WITH CHECK ADD  CONSTRAINT [FK_Consultoria_Oficinas] FOREIGN KEY([IdOficina])
REFERENCES [dbo].[Oficinas] ([Id])
GO

ALTER TABLE [dbo].[Consultoria] CHECK CONSTRAINT [FK_Consultoria_Oficinas]
GO

ALTER TABLE [Consultoria] ADD CONSTRAINT [FK_Consultoria_UsosComerciales]
	FOREIGN KEY ([IdUsosComerciales]) REFERENCES [UsosComerciales] ([Id]) ON DELETE No Action ON UPDATE No Action;
go
