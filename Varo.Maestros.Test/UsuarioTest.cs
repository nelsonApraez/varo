namespace Varo.Maestros.Test
{
    using Varo.Maestros.Entidades;
    using Varo.Maestros.Negocio;
    using Varo.Maestros.SistemasExternos;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Summary description for SolucionesObtenerInformacionUsuarioTest
    /// </summary>
    [TestClass]
    public class UsuarioTest
    {
        private Mock<IAdaptadorUsuarios> adaptadorUsuarios = null;
        private INegocioUsuarios negocioUsuarios = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.adaptadorUsuarios = new Mock<IAdaptadorUsuarios>();

            this.negocioUsuarios =
                new NegocioUsuarios(this.adaptadorUsuarios.Object);
        }

        [TestMethod]
        public void ObtenerInformacionUsuarioTest()
        {
            Usuario usuarioActual;
            Usuario usuarioEsperado = new Usuario
            {
                DisplayName = "developer",
                UserPrincipalName = "developer@company.com"
            };

            this.adaptadorUsuarios.Setup(
                it => it
                .ObtenerInformacionUsuario(
                    It.IsAny<string>()))
                .Returns(
                    new Usuario
                    {
                        DisplayName = "developer",
                        UserPrincipalName = "developer@company.com"
                    }
                );

            usuarioActual = this.negocioUsuarios.ObtenerInformacionUsuario(It.IsAny<string>());


            Assert.AreEqual(usuarioEsperado.DisplayName, usuarioActual.DisplayName);
            Assert.AreEqual(usuarioEsperado.UserPrincipalName, usuarioActual.UserPrincipalName);
        }

        [TestMethod]
        public void ObtenerInformacionUsuarioSinResultadoTest()
        {
            Usuario usuarioActual;
            Usuario usuarioEsperado = new Usuario();

            this.adaptadorUsuarios.Setup(
                it => it
                .ObtenerInformacionUsuario(
                    It.IsAny<string>()))
                .Returns(
                    new Usuario()
                );

            usuarioActual = this.negocioUsuarios.ObtenerInformacionUsuario(It.IsAny<string>());

            Assert.AreEqual(usuarioEsperado.Id, usuarioActual.Id);
        }
    }
}

