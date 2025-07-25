namespace Varo.Maestros.Negocio
{
    using Varo.Maestros.Entidades;

    public interface INegocioUsuarios
    {
        Usuario ObtenerInformacionUsuario(string userName);
    }
}

