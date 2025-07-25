namespace Varo.Consultorias.Negocio
{
    using Varo.Consultorias.Entidades;
    using Varo.Maestros.Entidades;
    using System;
    using System.Collections.Generic;
    public interface INegocioTecnologiaConsultoria
    {
        void Crear(TecnologiaConsultoria tecnologiaConsultoria);

        IList<Tecnologia> ConsultarPorIdConsultoria(Guid idConsultoria);

        void EliminarPorIdConsultoria(Guid idConsultoria);
    }
}

