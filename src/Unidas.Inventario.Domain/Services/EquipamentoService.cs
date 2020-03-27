

using Unidas.Inventario.Domain.Entities;
using Unidas.Inventario.Domain.Interfaces.Repositories;
using Unidas.Inventario.Domain.Interfaces.Services;

namespace Unidas.Inventario.Domain.Services
{
    public class EquipamentoService : IEquipamentoService
    {
        private readonly IEquipamentoRepository _equipamentoRepository;

        public EquipamentoService(IEquipamentoRepository equipamentoRepository)
        {
            _equipamentoRepository = equipamentoRepository;
        }
        public void Inserir(Equipamento equipamento)
        {

            if (equipamento.VerificarFinalidadeTeste())
                _equipamentoRepository.Inserir(equipamento);
        }
    }
}
