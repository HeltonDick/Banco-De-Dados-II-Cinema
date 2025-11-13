using System.ComponentModel.DataAnnotations;

namespace Cinema_BD2.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O número do local é obrigatório.")]
        [StringLength(10)]
        public string Number { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Logradouro é obrigatorio")]
        [StringLength(100)]
        public string Logradouro { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Reference { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido. Formato: 00000-000")]
        public string Cep { get; set; } = string.Empty;

        // Relações
        [Required]
        public int StreetId { get; set; }
        public Street? Street { get; set; }

        [Required]
        public int DistrictId { get; set; }
        public District? District { get; set; }

        public ICollection<Person>? People { get; set; }
    }
}
