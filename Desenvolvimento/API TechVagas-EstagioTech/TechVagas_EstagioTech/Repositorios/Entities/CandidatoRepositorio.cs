using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Repositorios.Entities
{
    public class CandidatoRepositorio : ICandidatoRepositorio
    {
        private readonly DBContext _dbContext;

        public CandidatoRepositorio(DBContext candidatoDBContext)
        {
            _dbContext = candidatoDBContext;
        }

        public async Task<CandidatoModel> BuscarPorId(int id)
        {
            return await _dbContext.Candidatos.Where(x => x.CandidatoId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CandidatoModel>> BuscarTodosCandidatos()
        {
            return await _dbContext.Candidatos.ToListAsync();
        }

        public async Task<CandidatoModel> Adicionar(CandidatoModel candidatoModel)
        {
            _dbContext.Candidatos.Add(candidatoModel);
            await _dbContext.SaveChangesAsync();
            return candidatoModel; 
        }

        public async Task<CandidatoModel> Atualizar(CandidatoModel candidatoModel)
        {
            _dbContext.Entry(candidatoModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return candidatoModel; 
        }

        public async Task<bool> Apagar(int id)
        {
            var candidato = await BuscarPorId(id); 
            if (candidato == null) return false;  
            _dbContext.Candidatos.Remove(candidato);
            await _dbContext.SaveChangesAsync();
            return true;  
        }
    }
}
