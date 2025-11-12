using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema_BD2.Models
{
    public class RoomOfCinema
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [Required(ErrorMessage = "O campo 'Disponibilidade' é obrigatório.")]
        public bool disponibility { get; set; }

        [Required(ErrorMessage = "Selecione uma sala.")]
        [Display(Name = "Sala")]
        public int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public Room? Room { get; set; }
    }
}
