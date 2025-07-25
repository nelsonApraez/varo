namespace Varo.Maestros.Negocio
{
    using Varo.Maestros.Entidades;
    using System.Collections.Generic;

    public interface INegocioLocalizacion
    {
        IList<Pais> ConsultarPaises();

        Pais ObtenerPaisPorId(byte idPais);

        IList<string> ObtenerIdPaisPorNombre(string nombrePais);

        IList<Departamento> ConsultarDepartamentosPorIdPais(byte idPais);

        Departamento ObtenerDepartamentoPorId(int idDepartamento);

        IList<Ciudad> ConsultarCiudadesPorIdDepartamento(int idDepartamento);

        Ciudad ObtenerCiudadPorId(int idCiudad);

        IList<string> ObtenerIdCiudadPorNombre(string nombreCiudad);

        IList<Departamento> ConsultarDepartamentos();
    }
}

