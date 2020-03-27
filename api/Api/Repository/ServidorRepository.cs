using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository
{
    interface ServidorRepository
    {
        void Cadastrar(Servidor servidor);
        void Atualizar(Servidor servidor);
        void Remover(int id);
        Servidor SelecionarPorId(int id);
        List<Servidor> ListarTodos();
    }
}
