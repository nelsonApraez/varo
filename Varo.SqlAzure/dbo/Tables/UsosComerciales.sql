CREATE TABLE [UsosComerciales]
(
	[Id] tinyint NOT NULL,   
	[Nombre] varchar(50),
	[NombreEN] VARCHAR(50) NULL
);
GO

ALTER TABLE [UsosComerciales] 
 ADD CONSTRAINT [PK_UsosComerciales]
	PRIMARY KEY CLUSTERED ([Id]);
GO

ALTER TABLE [UsosComerciales] 
 ADD CONSTRAINT [UK_UsosComerciales_Nombre] UNIQUE NONCLUSTERED ([Nombre]);
GO
