CREATE TABLE [EstadosConsultoria]
(
	[Id] TINYINT NOT NULL , 
    [Nombre] VARCHAR(30) NOT NULL, 
    [NombreEN] VARCHAR(30) NULL
);
go

ALTER TABLE [EstadosConsultoria] 
 ADD CONSTRAINT [PK_EstadosConsultoria]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

ALTER TABLE [EstadosConsultoria] 
 ADD CONSTRAINT [AK_EstadosConsultoria_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC);
go
