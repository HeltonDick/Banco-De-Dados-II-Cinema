using System.ComponentModel.DataAnnotations;

namespace Cinema_BD2.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
