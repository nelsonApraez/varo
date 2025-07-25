namespace Varo.Maestros.SistemasExternos
{
    using Varo.Maestros.Entidades;

    public interface IAdaptadorUsuarios
    {
        Usuario ObtenerInformacionUsuario(string userName);
    }
}

