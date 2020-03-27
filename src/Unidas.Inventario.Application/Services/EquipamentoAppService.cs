using AutoMapper;
using System;
using System.Collections.Generic;
using Unidas.Inventario.Application.Interfaces;
using Unidas.Inventario.Application.Models;
using Unidas.Inventario.Domain.Interfaces.Repositories;
using Unidas.Inventario.Domain.Interfaces.Services;

namespace Unidas.Inventario.Application.Services
{
    public class EquipamentoAppService : IEquipamentoAppService
    {
        private readonly IMapper _mapper;
        private readonly IEquipamentoRepository _equipamentoRepository;

        private readonly IEquipamentoService _equipamentoService;

        public EquipamentoAppService(IMapper mapper,
            IEquipamentoRepository equipamentoRepository,
            IEquipamentoService equipamentoService)
        {
            _equipamentoRepository = equipamentoRepository;
            _mapper = mapper;
            _equipamentoService = equipamentoService;
        }

        public Equipamento ObterPorId(Guid id)
        {
            return _mapper.Map<Equipamento>(_equipamentoRepository.ObterPorId(id));
        }

        public IEnumerable<Equipamento> ObterTodos()
        {
            return _mapper.Map<IEnumerable<Equipamento>>(_equipamentoRepository.ObterTodos());
        }
        public void Inserir(Equipamento equipamento)
        {            
            _equipamentoService.Inserir(_mapper.Map<Domain.Entities.Equipamento>(equipamento));
            //return _mapper.Map<IEnumerable<Equipamento>>(_equipamentoRepository.ObterTodos());
        }
    }
}
