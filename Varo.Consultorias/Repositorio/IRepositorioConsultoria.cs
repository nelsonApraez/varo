

namespace Varo.Consultorias.Repositorio
{
    using Varo.Consultorias.Entidades;
    using System;
    using System.Collections.Generic;
    public interface IRepositorioConsultoria
    {
        IList<ConsultoriaInformacionBasica> Consultar(int numeroPagina, int tamanoPagina, string CheckEnEjecucion);

        IList<ConsultoriaInformacionBasica> ConsultarPorParametro(int numeroPagina, int tamanoPagina,
           string[] vectorDeBusqueda, string CheckEnEjecucion);

        IList<Consultoria> Consultar();

        IList<Consultoria> Listar();

        Consultoria Obtener(Guid id);

        Guid Crear(Consultoria consultoria);

        void Editar(Consultoria consultoria);

        void Eliminar(Guid id);
    }
}

