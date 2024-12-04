using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TechVagas_EstagioTech.Objects.Enums;

namespace TechVagas_EstagioTech.Objects.Model.Entities
{
    [Table("candidato")]
    public class CandidatoModel
    {
        [Column("candidatoid")]
        public int CandidatoId { get; set; }

        // Foreign key para a tabela Aluno
        [Column("alunoid")]
        public int AlunoId { get; set; }
        public AlunoModel Alunos { get; set; } // Navegação para a tabela Aluno

        // Foreign key para a tabela Vaga
        [Column("vagaid")]
        public int VagaId { get; set; }
        public VagasModel Vagas { get; set; } // Navegação para a tabela Vaga

        [Column("statusvaga")]
        [EnumDataType(typeof(StatusVaga))]
        public StatusVaga StatusVaga { get; set; }
    }
}
