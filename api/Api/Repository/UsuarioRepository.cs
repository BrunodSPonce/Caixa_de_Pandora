using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository
{
    public interface UsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        Usuario BuscarUsuario(string login, string senha);
        
    }
}
