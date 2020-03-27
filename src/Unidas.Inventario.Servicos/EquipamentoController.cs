using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Unidas.Base.Servicos.Api.Controllers;
using Unidas.Inventario.Application.Interfaces;
using Unidas.Inventario.Application.Models;

namespace Unidas.Inventario.Servicos
{
    [ApiVersion("1")]
    [Route("equipamentos")]
    public class EquipamentoController : ApiBaseController
    {
        private readonly IEquipamentoAppService _equipamentoAppService;
        public EquipamentoController(IEquipamentoAppService equipamentoAppService)
        {
            _equipamentoAppService = equipamentoAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {            
            return Ok(_equipamentoAppService.ObterTodos());
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(_equipamentoAppService.ObterPorId(id));
        }

        [HttpPut]
        [AllowAnonymous]
        public IActionResult Alterar([FromBody] Equipamento model)
        {
            return Ok(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Criar([FromBody]Equipamento model)
        {
            _equipamentoAppService.Inserir(model);
            return Created(string.Empty, model);
        }
    }
}
