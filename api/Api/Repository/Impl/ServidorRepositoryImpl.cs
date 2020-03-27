using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository.Impl
{
    public class ServidorRepositoryImpl : ServidorRepository
    {
        private readonly SistemaInventarioContext _context;
        public ServidorRepositoryImpl(SistemaInventarioContext context)
        {
            _context = context;
        }
        public void Atualizar(Servidor servidor)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Servidor servidor)
        {
            _context.Servidores.Add(servidor);
            _context.SaveChanges();
        }

        public List<Servidor> ListarTodos()
        {
            return _context.Servidores.ToList();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }

        public Servidor SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
