namespace Varo.Api.Controllers
{
    using Varo.Api.Models;
    using Varo.Consultorias.Negocio;
    using Varo.Soluciones.Negocio;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    [Authorize]
    public class OperacionController : ApiController
    {
        private readonly INegocioSoluciones negocioSoluciones;
        private readonly INegocioConsultoria negocioConsultoria;

        public OperacionController()
        {
            this.negocioSoluciones = new NegocioSoluciones();
            this.negocioConsultoria = new NegocioConsultoria();

        }
        // GET: api/Operacion
        public IHttpActionResult Get()
        {
            List<Operacion> listaOperaciones = new List<Operacion>();
            var soluciones = this.negocioSoluciones.Consultar();
            var consultorias = this.negocioConsultoria.Listar();

            var listaSoluciones = from solucion in soluciones
                                  select new Operacion
                                  {
                                      Id = solucion.Id,
                                      Nombre = solucion.Nombre,
                                      IdTipo = byte.Parse(VaroResources.IdTipoSolution),
                                      NombreTipo = VaroResources.NombreTipoSolution,
                                      IdEstado = solucion.Estado.Id,
                                      NombreEstado = solucion.Estado.Nombre,
                                      IdLineaNegocio = solucion.LineaNegocio.Id,
                                      NombreLineaNegocio = solucion.LineaNegocio.Nombre,
                                      IdOficina = solucion.Oficina.Id,
                                      NombreOficina = solucion.Oficina.Nombre,
                                      IdCliente = solucion.Cliente.Id,
                                      NombreCliente = solucion.Cliente.Name.Trim(),
                                      UsuarioRedGerente = solucion.UsuarioRedGerente,
                                      UsuarioRedResponsableTecnico = solucion.UsuarioRedResponsable,
                                      UsuarioRedScrumMaster = solucion.UsuarioRedScrumMaster
                                  };

            var listaConsultorias = from consultoria in consultorias
                                    select new Operacion
                                    {
                                        Id = consultoria.Id,
                                        Nombre = consultoria.Nombre,
                                        IdTipo = byte.Parse(VaroResources.IdTipoAdvisory),
                                        NombreTipo = VaroResources.NombreTipoAdvisory,
                                        IdEstado = consultoria.Estado.Id,
                                        NombreEstado = consultoria.Estado.Nombre,
                                        IdLineaNegocio = consultoria.LineaNegocio.Id,
                                        NombreLineaNegocio = consultoria.LineaNegocio.Nombre,
                                        IdOficina = consultoria.Oficina.Id,
                                        NombreOficina = consultoria.Oficina.Nombre,
                                        IdCliente = consultoria.Cliente.Id,
                                        NombreCliente = consultoria.Cliente.Name.Trim(),
                                        UsuarioRedGerente = consultoria.UsuarioRedGerente,
                                        UsuarioRedResponsableTecnico = consultoria.UsuarioRedConsultor,
                                        UsuarioRedScrumMaster = null
                                    };
            listaOperaciones.AddRange(listaSoluciones);
            listaOperaciones.AddRange(listaConsultorias);
            return Ok(listaOperaciones);
        }

    }
}

