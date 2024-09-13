using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Desafio.Model
{
    public class Aluno
    {
        [Key]
        public long Id { get; set; } // Use 'long' se for bigint no banco de dados

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A idade é obrigatória.")]
        [Range(0, 120, ErrorMessage = "A idade deve estar entre 0 e 120.")]
        [JsonPropertyName("idade")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "A nota N1 é obrigatória.")]
        [Range(0, 10, ErrorMessage = "A nota N1 deve estar entre 0 e 10.")]
        [JsonPropertyName("n1")]
        public double N1 { get; set; }

        [Required(ErrorMessage = "A nota N2 é obrigatória.")]
        [Range(0, 10, ErrorMessage = "A nota N2 deve estar entre 0 e 10.")]
        [JsonPropertyName("n2")]
        public double N2 { get; set; }

        [Required(ErrorMessage = "O professor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do professor não pode ter mais de 100 caracteres.")]
        [JsonPropertyName("professor")]
        public string Professor { get; set; }

        [Required(ErrorMessage = "A sala é obrigatória.")]
        [Range(1, 10000, ErrorMessage = "O número da sala deve estar entre 1 e 10000.")]
        [JsonPropertyName("sala")]
        public int Sala { get; set; } // Usado como número inteiro
    }
}
