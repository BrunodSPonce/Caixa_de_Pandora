using System;
using System.Collections.Generic;
using System.Linq;
using Unidas.Inventario.Domain;
using Unidas.Inventario.Domain.Entities;
using Unidas.Inventario.Domain.Interfaces.Repositories;

namespace Unidas.Inventario.Infra.Data.Repositories
{
    public class EquipamentoRepository : IEquipamentoRepository
    {
        public void Inserir(Equipamento equipamento)
        {
            throw new NotImplementedException();
        }

        public Equipamento ObterPorId(Guid id)
        {
            return ObterTodos().FirstOrDefault(e => e.Id == id);            
        }

        public IEnumerable<Equipamento> ObterTodos()
        {
            var equipamentos = new List<Equipamento>();

            equipamentos.Add(new Equipamento()
            {
                Id = Guid.Parse("ce1db1f9-ee11-4f61-a4b6-54cc8f3228ad"),
                Ambiente = "Homologação",
                Descricao = "Equipamento 1",
                Finalindade = "",
                Ip = "127.0.0.1",
                SistemaOperacional = "Linux"
            });
            equipamentos.Add(new Equipamento()
            {
                Id = Guid.Parse("5e8753fb-530d-4d28-af7e-4deecc50cd9a"),
                Ambiente = "Homologação",
                Descricao = "Equipamento 2",
                Finalindade = "",
                Ip = "127.0.0.1",
                SistemaOperacional = "Windowns"
            });
            equipamentos.Add(new Equipamento()
            {
                Id = Guid.Parse("27381ad9-3875-430b-97f4-d6d602630e91"),
                Ambiente = "Produção",
                Descricao = "Equipamento 3",
                Finalindade = "",
                Ip = "127.0.0.1",
                SistemaOperacional = "Linux"
            });
            equipamentos.Add(new Equipamento()
            {
                Id = Guid.Parse("96e4dff3-7a78-46a4-aa18-c4a9d96f6190"),
                Ambiente = "Homologação",
                Descricao = "Equipamento 4",
                Finalindade = "",
                Ip = "127.0.0.1",
                SistemaOperacional = "Windowns"
            });
            equipamentos.Add(new Equipamento()
            {
                Id = Guid.Parse("179542c5-2d00-47db-b021-9ef4185be759"),
                Ambiente = "Produção",
                Descricao = "Equipamento 5",
                Finalindade = "",
                Ip = "127.0.0.1",
                SistemaOperacional = "Windowns"
            });
            equipamentos.Add(new Equipamento()
            {
                Id = Guid.Parse("ea0d6e1a-3bb1-4e1e-9e1a-19efcfc75a7e"),
                Ambiente = "Homologação",
                Descricao = "Equipamento 6",
                Finalindade = "",
                Ip = "127.0.0.1",
                SistemaOperacional = "Windowns"
            });
            equipamentos.Add(new Equipamento()
            {
                Id = Guid.Parse("09468ae1-1ad7-49eb-b3a6-409c3e2f5f68"),
                Ambiente = "Homologação",
                Descricao = "Equipamento 7",
                Finalindade = "",
                Ip = "127.0.0.1",
                SistemaOperacional = "Linux"
            });
            equipamentos.Add(new Equipamento()
            {
                Id = Guid.Parse("de02c9c0-4935-4d83-9ac6-a6f86a09a482"),
                Ambiente = "Homologação",
                Descricao = "Equipamento 8",
                Finalindade = "",
                Ip = "127.0.0.1",
                SistemaOperacional = "Windowns"
            });
            equipamentos.Add(new Equipamento()
            {
                Id = Guid.Parse("6ba72bf0-f394-47e6-b2d9-daa78da9a8be"),
                Ambiente = "Homologação",
                Descricao = "Equipamento 8",
                Finalindade = "",
                Ip = "127.0.0.1",
                SistemaOperacional = "Windowns"
            });
            equipamentos.Add(new Equipamento()
            {
                Id = Guid.Parse("d0b00241-d0d7-4d57-8e1d-24f8a5978270"),
                Ambiente = "Homologação",
                Descricao = "Equipamento 9",
                Finalindade = "",
                Ip = "127.0.0.1",
                SistemaOperacional = "Windowns"
            });
            equipamentos.Add(new Equipamento()
            {
                Id = Guid.Parse("8dc94720-e1e7-4ab4-ac1c-85d2f56247f1"),
                Ambiente = "Homologação",
                Descricao = "Equipamento 10",
                Finalindade = "",
                Ip = "127.0.0.1",
                SistemaOperacional = "Windowns"
            });
            equipamentos.Add(new Equipamento()
            {
                Id = Guid.Parse("74a6d7b1-eb7e-4f9e-acbd-b0d7a2fde2d3"),
                Ambiente = "Homologação",
                Descricao = "Equipamento 11",
                Finalindade = "",
                Ip = "127.0.0.1",
                SistemaOperacional = "Windowns"
            });

            return equipamentos;
        }
    }
}
