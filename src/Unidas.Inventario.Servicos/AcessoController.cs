using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Unidas.Base.Servicos.Api.Controllers;
using Unidas.Inventario.Application.Interfaces;
using Unidas.Inventario.Application.Models;

namespace Unidas.Inventario.Servicos
{
    [ApiVersion("1")]
    [Route("acessos")]
    public class AcessoController : ApiBaseController
    {
        private readonly IAcessoAppService _iAcessoService;
        public AcessoController(IAcessoAppService iAcessoService)
        {
            _iAcessoService = iAcessoService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            return Ok(_iAcessoService.Login(usuario));
        }
    }
}