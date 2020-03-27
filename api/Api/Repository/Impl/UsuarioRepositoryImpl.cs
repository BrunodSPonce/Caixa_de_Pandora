using Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository.Impl
{
    public class UsuarioRepositoryImpl : UsuarioRepository
    {
        private readonly SistemaInventarioContext _context;
        public UsuarioRepositoryImpl(SistemaInventarioContext context)
        {
            _context = context;
        }

        public Usuario BuscarUsuario(string login, string senha)
        {
            return _context.Usuarios.Where(u => u.Login == login && u.Senha == senha).FirstOrDefault();
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }
}
