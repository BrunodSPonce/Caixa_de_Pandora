using System;
using System.Collections.Generic;
using Unidas.Inventario.Domain.Entities;

namespace Unidas.Inventario.Domain.Interfaces.Repositories
{
    public interface IEquipamentoRepository
    {
        IEnumerable<Equipamento> ObterTodos();
        Equipamento ObterPorId(Guid id);
        void Inserir(Equipamento equipamento);
    }
}
