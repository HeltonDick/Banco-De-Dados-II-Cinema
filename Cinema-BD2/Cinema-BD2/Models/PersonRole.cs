using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema_BD2.Models
{
    public class PersonRole
    {
        [Key]
        public int Id { get; set; }

        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public Person? Person { get; set; }

        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }

        public DateTime SignDate { get; set; } = DateTime.Now;

        public DateTime? CancelDate { get; set; }
    }
}
