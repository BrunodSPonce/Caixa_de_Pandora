

using System.Threading.Tasks;
using Unidas.Inventario.Domain.Entities;

namespace Unidas.Inventario.Domain.Interfaces.ExternalServices
{
    public interface IAcessoService
    {
        object Login(Usuario usuario);
    }
}
