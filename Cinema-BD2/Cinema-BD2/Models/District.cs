using System.ComponentModel.DataAnnotations;

namespace Cinema_BD2.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; } = string.Empty;
        public ICollection<Address>? Addresses  { get; set; }
    }
}
