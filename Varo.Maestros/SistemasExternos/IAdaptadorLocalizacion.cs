namespace Varo.Maestros.SistemasExternos
{
    using Varo.Maestros.Entidades;
    using System.Collections.Generic;

    public interface IAdaptadorLocalizacion
    {
        IList<Pais> ConsultarPaises();
        IList<Departamento> ConsultarDepartamentos();
        IList<Departamento> ConsultarDepartamentosPorIdPais(int idPais);
        IList<Ciudad> ConsultarCiudades();
        IList<Ciudad> ConsultarCiudadesPorIdDepartamento(int idDepartamento);
    }
}


