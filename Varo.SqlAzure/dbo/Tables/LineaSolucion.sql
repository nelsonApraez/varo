CREATE TABLE [LineaSolucion]
(
	[Id] tinyint NOT NULL,
	[Nombre] varchar(30) NOT NULL, 
    [NombreEN] VARCHAR(30) NULL
);
go

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [LineaSolucion] 
 ADD CONSTRAINT [PK_LineaSolucion]
	PRIMARY KEY CLUSTERED ([Id] ASC);
go

ALTER TABLE [LineaSolucion] 
 ADD CONSTRAINT [UK_LineaSolucion_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC);
go
