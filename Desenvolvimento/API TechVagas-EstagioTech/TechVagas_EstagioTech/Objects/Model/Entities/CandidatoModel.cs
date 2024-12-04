using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TechVagas_EstagioTech.Objects.Enums;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TechVagas_EstagioTech.Objects.Model.Entities
{
    [Table("candidato")]
    public class CandidatoModel
    {
        [Column("candidatoid")]
        public int CandidatoId { get; set; }

        [Column("datacandidatura")]
        public DateOnly DataCandidatura { get; set; }

        [Column("statusvaga")]
        [EnumDataType(typeof(StatusVaga))]
        public StatusVaga StatusVaga { get; set; }

        // Foreign key para a tabela Aluno
        [Column("alunoid")]
        public int AlunoId { get; set; }  // Chave estrangeira para Aluno
        public AlunoModel Alunos { get; set; }  // Relacionamento com Aluno

        [Column("vagaid")]
        public int VagaId { get; set; }  // Chave estrangeira para Vaga
        public VagasModel Vagas { get; set; }  // Relacionamento com Vaga
    }
}
