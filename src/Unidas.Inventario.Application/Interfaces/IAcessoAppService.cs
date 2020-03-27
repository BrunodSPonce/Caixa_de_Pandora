using Unidas.Inventario.Application.Models;

namespace Unidas.Inventario.Application.Interfaces
{
    public interface IAcessoAppService
    {
        object Login(Usuario usuario);
    }
}
