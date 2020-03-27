using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Api.Repository;
using Api.Repository.Impl;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public LoginController(SistemaInventarioContext context)
        {
            _usuarioRepository = new UsuarioRepositoryImpl(context);
        }

        [HttpPost]
        public ActionResult<dynamic> Login([FromBody] Usuario usuario)
        {
            try
            {
                var user = _usuarioRepository.BuscarUsuario(usuario.Login, usuario.Senha);


                if (user == null)
                {
                    return NotFound(new { message = "Usuario ou senha invalidos" });
                }
                else if (user.Login != usuario.Login && user.Senha != usuario.Senha)
                {
                    return Unauthorized(new { message = "Usuario ou senha Incorretos" });
                }
                else
                {
                    var token = TokenService.GenerateToken(user.Login, user.Senha);
                    return new
                    {
                        login = user.Login,
                        token
                    };
                }
                
            }
            catch (Exception ex)
            {

                return NotFound("Ocorreu um erro na solicitação, por gentileza contate o administrador do sistema" + ex);
            }
            
        }

    }
}