
CREATE TABLE [dbo].[PruebasSolucion]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdSolucion] UNIQUEIDENTIFIER NOT NULL, 
    [CasosDefinidos] INT NOT NULL DEFAULT 0, 
    [CasosAutomatizar] INT NOT NULL DEFAULT 0, 
    [CasosAutomatizados] INT NOT NULL DEFAULT 0, 
    [UrlDiseñoCasos] VARCHAR(50) NULL,
    [UrlEvidencias] VARCHAR(50) NULL,
    [UrlRepositorio] VARCHAR(50) NULL,
    [UsuarioRedTecnico] VARCHAR(50) NOT NULL, 
    [FechaCreacion] SMALLDATETIME NOT NULL,
    [EstaenPipeline] BIT NULL,
    [Observaciones] VARCHAR(MAX) NULL,     
    CONSTRAINT [FK_PruebasSolucion_Soluciones] FOREIGN KEY ([IdSolucion]) REFERENCES [Soluciones]([Id]) 
)
