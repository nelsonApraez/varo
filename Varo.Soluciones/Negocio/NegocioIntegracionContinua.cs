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

    public class NegocioIntegracionContinua : NegocioBase, INegocioIntegracionContinua
    {
        private readonly IRepositorioIntegracionContinua repositorioIntegracionContinua;

        public NegocioIntegracionContinua() :
            this(
                new RepositorioBase(),
                new RepositorioIntegracionContinua())
        { }

        public NegocioIntegracionContinua(
            IRepositorioBase repositorioBase,
            IRepositorioIntegracionContinua repositorioIntegracionContinua) :
            base(repositorioBase)
        {
            this.repositorioIntegracionContinua = repositorioIntegracionContinua;
        }

        public void Crear(IntegracionesContinuas integracionContinua)
        {
            this.repositorioIntegracionContinua.Crear(integracionContinua);
        }

        public void EliminarPorIdSolucion(Guid idSolucion)
        {
            this.repositorioIntegracionContinua.EliminarPorIdSolucion(idSolucion);
        }

        public IList<IntegracionesContinuas> ConsultarPorIdSolucion(Guid idSolucion)
        {
            return this.repositorioIntegracionContinua.ConsultarPorIdSolucion(idSolucion);
        }
    }
}

