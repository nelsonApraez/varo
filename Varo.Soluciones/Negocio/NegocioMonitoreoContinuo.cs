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

    public class NegocioMonitoreoContinuo : NegocioBase, INegocioMonitoreoContinuo
    {
        private readonly IRepositorioMonitoreoContinuo repositorioMonitoreoContinuo;

        public NegocioMonitoreoContinuo() :
            this(
                new RepositorioBase(),
                new RepositorioMonitoreoContinuo())
        { }

        public NegocioMonitoreoContinuo(
            IRepositorioBase repositorioBase,
            IRepositorioMonitoreoContinuo repositorioMonitoreoContinuo) :
            base(repositorioBase)
        {
            this.repositorioMonitoreoContinuo = repositorioMonitoreoContinuo;
        }

        public void Crear(MonitoreosContinuos monitoreoContinuo)
        {
            this.repositorioMonitoreoContinuo.Crear(monitoreoContinuo);
        }

        public void EliminarPorIdSolucion(Guid idSolucion)
        {
            this.repositorioMonitoreoContinuo.EliminarPorIdSolucion(idSolucion);
        }

        public IList<MonitoreosContinuos> ConsultarPorIdSolucion(Guid idSolucion)
        {
            return this.repositorioMonitoreoContinuo.ConsultarPorIdSolucion(idSolucion);
        }
    }
}

