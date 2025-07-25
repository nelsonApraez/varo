CREATE TABLE [LineaConsultoria]
(
	[Id] TINYINT NOT NULL , 
    [Nombre] VARCHAR(30) NOT NULL, 
    [NombreEN] VARCHAR(30) NULL
);
go

ALTER TABLE [LineaConsultoria] 
 ADD CONSTRAINT [PK_LineaConsultoria]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

ALTER TABLE [LineaConsultoria] 
 ADD CONSTRAINT [AK_LineaConsultoria_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC);
go
