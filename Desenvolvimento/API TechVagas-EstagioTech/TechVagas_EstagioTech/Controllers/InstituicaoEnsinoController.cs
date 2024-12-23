﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;
using TechVagas_EstagioTech.Services.Middleware;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoEnsinoController : ControllerBase
    {
        private readonly IInstituicaoEnsinoService _instituicaoEnsinoService;

        public InstituicaoEnsinoController(IInstituicaoEnsinoService instituicaoEnsinoService)
        {
            _instituicaoEnsinoService = instituicaoEnsinoService;
        }

        [HttpGet]
        [Access(1)]
        public async Task<ActionResult<IEnumerable<InstituicaoEnsinoDto>>> Get()
        {
            var instituicaoEnsinoDto = await _instituicaoEnsinoService.BuscarTodasInstituicoes();
            if (instituicaoEnsinoDto == null) return NotFound("Instituições não encontradas!");
            return Ok(instituicaoEnsinoDto);
        }

        [HttpGet("{id:int}", Name = "ObterInstituicao")]
        [Access(1)]
        public async Task<ActionResult<InstituicaoEnsinoDto>> Get(int id)
        {
            var instituicaoEnsinoDto = await _instituicaoEnsinoService.BuscarPorId(id);
            if (instituicaoEnsinoDto == null) return NotFound("Instituição não encontrada");
            return Ok(instituicaoEnsinoDto);
        }

        [HttpPost]
        [Access(1)]
        public async Task<ActionResult> Post([FromBody] InstituicaoEnsinoDto instituicaoEnsinoDto)
        {
            if (instituicaoEnsinoDto is null) return BadRequest("Dado inválido!");
            await _instituicaoEnsinoService.Adicionar(instituicaoEnsinoDto);
            return new CreatedAtRouteResult("ObterInstituicao", new { id = instituicaoEnsinoDto.idInstituicaoEnsino }, instituicaoEnsinoDto);
        }

        [HttpPut("{id:int}")]
        [Access(1)]
        public async Task<ActionResult> Put([FromBody] InstituicaoEnsinoDto instituicaoEnsinoDto)
        {
            if (instituicaoEnsinoDto is null) return BadRequest("Dado invalido!");
            await _instituicaoEnsinoService.Atualizar(instituicaoEnsinoDto);
            return Ok(instituicaoEnsinoDto);
        }

        [HttpDelete("{id:int}")]
        [Access(1)]
        public async Task<ActionResult<VagasDto>> Delete(int id)
        {
            var instituicaoEnsinoDto = await _instituicaoEnsinoService.BuscarPorId(id);
            if (instituicaoEnsinoDto == null) return NotFound("Instituições não econtradas!");
            await _instituicaoEnsinoService.Apagar(id);
            return Ok(instituicaoEnsinoDto);
        }
    }
}
