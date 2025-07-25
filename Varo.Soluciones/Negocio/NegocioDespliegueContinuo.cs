// -------------------------------------------------------------------------------
// <copyright file="NegocioSoluciones.cs" company="Company S.A.">
//     COPYRIGHT(C) 2018, Company S.A.
// </copyright>
// <author>Developer</author>
// <email>developer@company.com</email>
// <date>09/08/2018</date>
// <summary>Implementa las funcionalidades de negocio para las soluciones.</summary>
// -------------------------------------------------------------------------------

namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;

    public class NegocioDespliegueContinuo : NegocioBase, INegocioDespliegueContinuo
    {
        private readonly IRepositorioDespliegueContinuo repositorioDespliegueContinuo;

        public NegocioDespliegueContinuo() :
            this(
                new RepositorioBase(),
                new RepositorioDespligueContinuo())
        { }

        public NegocioDespliegueContinuo(
            IRepositorioBase repositorioBase,
            IRepositorioDespliegueContinuo repositorioDespliegueContinuo) :
            base(repositorioBase)
        {
            this.repositorioDespliegueContinuo = repositorioDespliegueContinuo;
        }

        public void Crear(DesplieguesContinuos despliegueContinuo)
        {
            this.repositorioDespliegueContinuo.Crear(despliegueContinuo);
        }

        public void EliminarPorIdSolucion(Guid idSolucion)
        {
            this.repositorioDespliegueContinuo.EliminarPorIdSolucion(idSolucion);
        }

        public IList<DesplieguesContinuos> ConsultarPorIdSolucion(Guid idSolucion)
        {
            return this.repositorioDespliegueContinuo.ConsultarPorIdSolucion(idSolucion);
        }
    }
}

