namespace Varo.Consultorias.Negocio
{
    using Varo.Consultorias.Entidades;
    using Varo.Transversales.Negocio;
    using System;
    using System.Collections.Generic;
    public interface INegocioConsultoria : INegocioBase
    {
        IList<ConsultoriaInformacionBasica> Consultar(int numeroPagina, int tamanoPagina, string CheckEnEjecucion);

        IList<ConsultoriaInformacionBasica> ConsultarPorParametro(int numeroPagina, int tamanoPagina,
                                             string valorDeBusqueda, string CheckEnEjecucion);


        IList<Consultoria> Consultar();

        IList<Consultoria> Listar();

        Consultoria Obtener(Guid id);

        void Crear(Consultoria consultoria,
            TecnologiaConsultoria tecnologiaPorConsultoria);

        void Editar(Consultoria consultoria,
            TecnologiaConsultoria tecnologiaPorConsultoria);

        void Eliminar(Guid id);
    }
}

