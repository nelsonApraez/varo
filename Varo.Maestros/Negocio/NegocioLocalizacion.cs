namespace Varo.Maestros.Negocio
{
    using Varo.Maestros.Entidades;
    using Varo.Maestros.SistemasExternos;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class NegocioLocalizacion : NegocioBase, INegocioLocalizacion
    {
        private readonly IAdaptadorLocalizacion adaptadorLocalizacion;

        public NegocioLocalizacion() :
            this(
                new RepositorioBase(),
                new AdaptadorLocalizacion())
        { }

        public NegocioLocalizacion(
            IRepositorioBase repositorioBase,
            IAdaptadorLocalizacion adaptadorLocalizacion) :
            base(repositorioBase)
        {
            this.adaptadorLocalizacion = adaptadorLocalizacion;
        }

        public IList<Pais> ConsultarPaises()
        {
            return this.adaptadorLocalizacion.ConsultarPaises();
        }

        public Pais ObtenerPaisPorId(byte idPais)
        {
            IList<Pais> listaPaises = this.adaptadorLocalizacion.ConsultarPaises();

            return listaPaises.SingleOrDefault(pais => pais.Id == idPais);
        }

        public IList<string> ObtenerIdPaisPorNombre(string nombrePais)
        {
            IList<Pais> listaPaises = this.adaptadorLocalizacion.ConsultarPaises();
            IEnumerable<Pais> itemMaestro =
                listaPaises.Where(x => x.Name.ToUpperInvariant().Contains(nombrePais.ToUpperInvariant()));

            IList<string> listaIdPaises = new List<string>();

            foreach (var item in itemMaestro)
            {
                listaIdPaises.Add(item.Id.ToString(CultureInfo.CurrentCulture));
            }

            return listaIdPaises;
        }

        public IList<Departamento> ConsultarDepartamentos()
        {
            return this.adaptadorLocalizacion.ConsultarDepartamentos();
        }

        public IList<Departamento> ConsultarDepartamentosPorIdPais(byte idPais)
        {
            IList<Departamento> listaDepartamentos = this.adaptadorLocalizacion.ConsultarDepartamentosPorIdPais(idPais);

            return listaDepartamentos;
        }

        public Departamento ObtenerDepartamentoPorId(int idDepartamento)
        {
            IList<Departamento> listaDepartamentos = this.adaptadorLocalizacion.ConsultarDepartamentos();

            return listaDepartamentos.SingleOrDefault(departamento => departamento.Id == idDepartamento);
        }

        public IList<Ciudad> ConsultarCiudadesPorIdDepartamento(int idDepartamento)
        {
            IList<Ciudad> listaCiudades = this.adaptadorLocalizacion.ConsultarCiudadesPorIdDepartamento(idDepartamento);

            return listaCiudades;
        }

        public Ciudad ObtenerCiudadPorId(int idCiudad)
        {
            IList<Ciudad> listaCiudades = this.adaptadorLocalizacion.ConsultarCiudades();

            return listaCiudades.SingleOrDefault(ciudad => ciudad.Id == idCiudad);
        }

        public IList<string> ObtenerIdCiudadPorNombre(string nombreCiudad)
        {
            IList<Ciudad> listaCiudades = this.adaptadorLocalizacion.ConsultarCiudades();
            IEnumerable<Ciudad> itemMaestro =
                listaCiudades.Where(x => x.Name.ToUpperInvariant().Contains(nombreCiudad.ToUpperInvariant()));

            IList<string> listaIdCiudades = new List<string>();

            foreach (var item in itemMaestro)
            {
                listaIdCiudades.Add(item.Id.ToString(CultureInfo.CurrentCulture));
            }

            return listaIdCiudades;
        }
    }
}
