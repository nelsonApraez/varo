namespace Varo.Api.Controllers
{
    using Varo.Api.Models;
    using Varo.Soluciones.Negocio;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    [Authorize]
    public class SolucionController : ApiController
    {
        private readonly NegocioSoluciones negocioSoluciones = new NegocioSoluciones();

        // GET: api/Solucion
        public IHttpActionResult Get()
        {
            IEnumerable<Solucion> listaSoluciones;
            var soluciones = this.negocioSoluciones.Consultar();

            listaSoluciones = from solucion in soluciones
                              select new Solucion
                              {
                                  Id = solucion.Id,
                                  Nombre = solucion.Nombre,
                                  IdEstado = solucion.Estado.Id,
                                  NombreEstado = solucion.Estado.Nombre,
                                  IdLineaNegocio = solucion.LineaNegocio.Id,
                                  NombreLineaNeogcio = solucion.LineaNegocio.Nombre,
                                  IdLineaTecnologica = solucion.LineaSolucion.Id,
                                  NombreLineaTecnologica = solucion.LineaSolucion.Nombre,
                                  IdMarcoTrabajo = solucion.MarcoTrabajo.Id,
                                  NombreMarcoTrabajo = solucion.MarcoTrabajo.Nombre,
                                  IdTipo = solucion.Tipo.Id,
                                  NombreTipo = solucion.Tipo.Nombre,
                                  IdOficina = solucion.Oficina.Id,
                                  NombreOficina = solucion.Oficina.Nombre,
                                  IdCliente = solucion.Cliente.Id,
                                  NombreCliente = solucion.Cliente.Name.Trim(),
                                  UsuarioRedGerente = solucion.UsuarioRedGerente,
                                  UsuarioRedResponsableTecnico = solucion.UsuarioRedResponsable,
                                  UsuarioRedScrumMaster = solucion.UsuarioRedScrumMaster,
                                  FechaCreacion = solucion.FechaCreacion,
                                  FechaCierre = solucion.FechaCierre,
                                  UrlDocumentacion = solucion.UrlDocumentacion,
                                  IdGsdc = solucion.Gsdc.Id,
                                  NombreGsdc = solucion.Gsdc.Nombre
                              };


            return Ok(listaSoluciones);
        }

        // GET: api/Solucion/5
        public IHttpActionResult Get(Guid id)
        {
            Solucion itemSolucion;
            var solucion = this.negocioSoluciones.Obtener(id);

            itemSolucion = new Solucion
            {
                Id = solucion.Id,
                Nombre = solucion.Nombre,
                IdEstado = solucion.Estado.Id,
                NombreEstado = solucion.Estado.Nombre,
                IdLineaNegocio = solucion.LineaNegocio.Id,
                NombreLineaNeogcio = solucion.LineaNegocio.Nombre,
                IdLineaTecnologica = solucion.LineaSolucion.Id,
                NombreLineaTecnologica = solucion.LineaSolucion.Nombre,
                IdMarcoTrabajo = solucion.MarcoTrabajo.Id,
                NombreMarcoTrabajo = solucion.MarcoTrabajo.Nombre,
                IdTipo = solucion.Tipo.Id,
                NombreTipo = solucion.Tipo.Nombre,
                IdOficina = solucion.Oficina.Id,
                NombreOficina = solucion.Oficina.Nombre,
                IdCliente = solucion.Cliente.Id,
                NombreCliente = solucion.Cliente.Name.Trim(),
                UsuarioRedGerente = solucion.UsuarioRedGerente,
                UsuarioRedResponsableTecnico = solucion.UsuarioRedResponsable,
                UsuarioRedScrumMaster = solucion.UsuarioRedScrumMaster
            };

            return Ok(itemSolucion);
        }

        // POST: api/Solucion
        public void Post([FromBody] SolucionAgregado solucion)
        {
            throw new NotSupportedException();
        }

        // PUT: api/Solucion/5
        public void Put(int id, [FromBody] string value)
        {
            throw new NotSupportedException();
        }

        // DELETE: api/Solucion/5
        public void Delete(int id)
        {
            throw new NotSupportedException();
        }
    }
}

