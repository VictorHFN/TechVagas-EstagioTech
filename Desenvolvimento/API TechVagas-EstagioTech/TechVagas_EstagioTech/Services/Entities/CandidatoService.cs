using AutoMapper;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

public class CandidatoService : ICandidatoService
{
    private readonly ICandidatoRepositorio _candidatoRepositorio;
    private readonly IMapper _mapper;

    public CandidatoService(ICandidatoRepositorio candidatoRepositorio, IMapper mapper)
    {
        _candidatoRepositorio = candidatoRepositorio;
        _mapper = mapper;
    }

    public async Task<CandidatoDto> BuscarPorId(int id)
    {
        var candidatos = await _candidatoRepositorio.BuscarPorId(id);
        return _mapper.Map<CandidatoDto>(candidatos);
    }

    public async Task<IEnumerable<CandidatoDto>> BuscarTodosCandidatos()
    {
        var candidatos = await _candidatoRepositorio.BuscarTodosCandidatos();
        return _mapper.Map<IEnumerable<CandidatoDto>>(candidatos);
    }

    public async Task Adicionar(CandidatoDto candidatoDto)
    {
        var candidatos = _mapper.Map<CandidatoModel>(candidatoDto);
        await _candidatoRepositorio.Adicionar(candidatos);
        candidatoDto.CandidatoId = candidatos.CandidatoId;
    }

    public async Task Atualizar(CandidatoDto candidatoDto)
    {
        var candidatos = _mapper.Map<CandidatoModel>(candidatoDto);
        await _candidatoRepositorio.Atualizar(candidatos);
    }

    public async Task Apagar(int id)
    {
        await _candidatoRepositorio.Apagar(id);
    }
}
