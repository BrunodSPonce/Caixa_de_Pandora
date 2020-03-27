using System;
using System.Collections.Generic;
using Unidas.Inventario.Application.Models;

namespace Unidas.Inventario.Application.Interfaces
{
    public interface IEquipamentoAppService
    {
        IEnumerable<Equipamento> ObterTodos();
        Equipamento ObterPorId(Guid id);
        void Inserir(Equipamento equipamento);
    }
}
