using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechVagas_EstagioTech.Objects.Enums;
using TechVagas_EstagioTech.Objects.Model.Entities;
using System.Text.Json.Serialization;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class CandidatoDto
    {
        [Key]
        public int CandidatoId { get; set; }

        public DateOnly DataCandidatura { get; set; }

        // AlunoId e VagaId são chaves estrangeiras para os respectivos modelos
        [ForeignKey("alunoid")]
        public int AlunoId { get; set; }

        // Não queremos incluir o objeto inteiro de Aluno ou Vaga na DTO, apenas os IDs
        public AlunoModel? Alunos { get; set; }

        [ForeignKey("vagaid")]
        public int VagaId { get; set; }

        public VagasModel? Vagas { get; set; }

        // O Status da Vaga como enum
        [EnumDataType(typeof(StatusVaga))]
        public StatusVaga StatusVaga { get; set; }
    }
}
