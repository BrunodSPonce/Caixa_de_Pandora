using AutoMapper;
using Unidas.Inventario.Application.Interfaces;
using Unidas.Inventario.Application.Models;
using Unidas.Inventario.Domain.Interfaces.ExternalServices;

namespace Unidas.Inventario.Application.Services
{
    public class AcessoAppService : IAcessoAppService
    {
        private readonly IAcessoService _iAcessoService;
        private readonly IMapper _mapper;

        public AcessoAppService(IAcessoService iAcessoService, IMapper mapper)
        {
            _iAcessoService = iAcessoService;
            _mapper = mapper;

        }
        public object Login(Usuario usuario)
        {
            var usuarioDomain = _mapper.Map<Domain.Entities.Usuario>(usuario);          

           return _iAcessoService.Login(usuarioDomain);
        }
    }
}
