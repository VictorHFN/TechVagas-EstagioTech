using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TechVagas_EstagioTech.Objects.Enums;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class CandidatoDto
    {
        [Key]
        public int CandidatoId { get; set; }

        [ForeignKey("alunoid")]
        public int AlunoId { get; set; }
        public AlunoModel? Alunos { get; set; }

        [ForeignKey("vagasid")]
        public int VagaId { get; set; }
        public VagasModel? Vagas { get; set; } // Navegação para a tabela Vaga

        [EnumDataType(typeof(StatusVaga))]
        public StatusVaga StatusVaga { get; set; }
    }
}
