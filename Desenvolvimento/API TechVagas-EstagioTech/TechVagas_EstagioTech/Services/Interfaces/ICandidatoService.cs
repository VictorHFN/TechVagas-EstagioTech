using TechVagas_EstagioTech.Objects.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface ICandidatoService
    {
        Task<IEnumerable<CandidatoDto>> BuscarTodosCandidatos();

        Task<CandidatoDto> BuscarPorId(int id);

        Task Adicionar(CandidatoDto candidatoDto);

        Task Atualizar(CandidatoDto candidatoDto);

        Task Apagar(int id);
    }
}
