using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema_BD2.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Descrição' é obrigatório.")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O campo 'Capacidade' é obrigatório.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Selecione um tipo de sala.")]
        [Display(Name = "Tipo de Sala")]
        public int TypeOfRoomId { get; set; }

        [ForeignKey("TypeOfRoomId")]
        public TypeOfRoom? TypeOfRoom { get; set; }
    }
}
