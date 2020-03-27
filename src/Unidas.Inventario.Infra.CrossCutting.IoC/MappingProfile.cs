using AutoMapper;
using Unidas.Inventario.Application.Models;

namespace Unidas.Inventario.Infra.CrossCutting.IoC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Equipamento, Domain.Entities.Equipamento>();
            CreateMap<Domain.Entities.Equipamento, Equipamento>();

            CreateMap<Usuario, Domain.Entities.Usuario>();
            CreateMap<Domain.Entities.Usuario, Usuario>();
        }
    }
}
