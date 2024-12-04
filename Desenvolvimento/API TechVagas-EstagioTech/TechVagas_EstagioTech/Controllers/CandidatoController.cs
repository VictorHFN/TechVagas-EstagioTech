using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidatoService _candidatoService;

        // Construtor com a injeção de dependência do ICandidatoService
        public CandidatoController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        // Método para buscar todos os candidatos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidatoDto>>> Get()
        {
            var candidatoDto = await _candidatoService.BuscarTodosCandidatos();
            if (candidatoDto == null || !candidatoDto.Any())
            {
                return NotFound("Candidatos não encontrados.");
            }
            return Ok(candidatoDto);  // Retorna a lista de candidatos com status 200
        }

        // Método para buscar um candidato por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidatoDto>> GetById(int id)
        {
            var candidatoDto = await _candidatoService.BuscarPorId(id);
            if (candidatoDto == null)
            {
                return NotFound($"Candidato com ID {id} não encontrado.");
            }
            return Ok(candidatoDto);  // Retorna o candidato com status 200
        }

        // Método para adicionar um novo candidato
        [HttpPost]
        public async Task<ActionResult<CandidatoDto>> Post([FromBody] CandidatoDto candidatoDto)
        {
            if (candidatoDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            await _candidatoService.Adicionar(candidatoDto);
            return CreatedAtAction(nameof(GetById), new { id = candidatoDto.CandidatoId }, candidatoDto);  // Retorna o candidato criado com status 201
        }

        // Método para atualizar um candidato existente
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CandidatoDto candidatoDto)
        {
            if (id != candidatoDto.CandidatoId)
            {
                return BadRequest("ID do candidato não corresponde.");
            }

            var candidatoExistente = await _candidatoService.BuscarPorId(id);
            if (candidatoExistente == null)
            {
                return NotFound($"Candidato com ID {id} não encontrado.");
            }

            await _candidatoService.Atualizar(candidatoDto);
            return NoContent();  // Retorna 204 quando a atualização é bem-sucedida
        }

        // Método para apagar um candidato pelo ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var candidatoExistente = await _candidatoService.BuscarPorId(id);
            if (candidatoExistente == null)
            {
                return NotFound($"Candidato com ID {id} não encontrado.");
            }

            await _candidatoService.Apagar(id);
            return NoContent();  // Retorna 204 quando o candidato for apagado com sucesso
        }
    }
}
