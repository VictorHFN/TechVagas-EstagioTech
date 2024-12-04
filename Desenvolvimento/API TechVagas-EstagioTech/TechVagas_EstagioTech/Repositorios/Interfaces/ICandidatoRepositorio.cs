using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ICandidatoRepositorio
    {
        Task<IEnumerable<CandidatoModel>> BuscarTodosCandidatos();

        Task<CandidatoModel> BuscarPorId(int id);

        Task<CandidatoModel> Adicionar(CandidatoModel candidatoModel);

        Task<CandidatoModel> Atualizar(CandidatoModel candidatoMode);

        Task<bool> Apagar(int id);
    }
}
