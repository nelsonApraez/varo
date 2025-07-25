CREATE PROCEDURE [dbo].[uspConsultoriaSelect]
AS
   SELECT
		dbo.Consultoria.Id,
		dbo.Consultoria.Nombre,
		dbo.Consultoria.IdCliente,
		dbo.Consultoria.IdOficina,
		dbo.oficinas.Nombre  As NombreOficina, 
		dbo.EstadosConsultoria.Id AS IdEstado,
		dbo.EstadosConsultoria.NombreEN AS NombreEstadosConsultoria,
		dbo.Gsdc.Id AS IdGsdc,
		dbo.consultoria.IdLineaNegocio,
		dbo.lineaNegocio.Nombre  AS NombreLineaNegocio,
		dbo.Gsdc.NombreEN AS NombreGsdc,
		dbo.Consultoria.IdEstado,
		dbo.EstadosConsultoria.Nombre AS NombreEstado,
		dbo.Consultoria.UsuarioRedGerente,
		dbo.Consultoria.UsuarioRedConsultor
	FROM dbo.Consultoria
		INNER JOIN dbo.Oficinas ON dbo.Consultoria.IdOficina = dbo.Oficinas.Id 
		INNER JOIN dbo.Gsdc ON dbo.Oficinas.IdGsdc = dbo.Gsdc.Id
		INNER JOIN dbo.EstadosConsultoria ON dbo.Consultoria.IdEstado = dbo.EstadosConsultoria.Id
		INNER JOIN dbo.LineaNegocio on dbo.Consultoria.IdLineaNegocio = lineaNegocio.Id
