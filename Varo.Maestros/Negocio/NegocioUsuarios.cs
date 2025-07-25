namespace Varo.Maestros.Negocio
{
    using Varo.Maestros.Entidades;
    using Varo.Maestros.SistemasExternos;

    public class NegocioUsuarios : INegocioUsuarios
    {
        private readonly IAdaptadorUsuarios adaptadorUsuarios;

        public NegocioUsuarios() :
            this(new AdaptadorUsuarios())
        { }

        public NegocioUsuarios(IAdaptadorUsuarios adaptadorUsuarios)
        {
            this.adaptadorUsuarios = adaptadorUsuarios;
        }

        public Usuario ObtenerInformacionUsuario(string userName)
        {
            return this.adaptadorUsuarios.ObtenerInformacionUsuario(userName);
        }
    }
}

