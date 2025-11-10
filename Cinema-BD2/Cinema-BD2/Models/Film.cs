using System.ComponentModel.DataAnnotations;

namespace Cinema_BD2.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Título Original' é obrigatório.")]
        [StringLength(200)]
        public string OriginalTitle { get; set; }

        [Required(ErrorMessage = "O campo 'Título' é obrigatório.")]
        [StringLength(200)]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo 'Duração' é obrigatório.")]
        public int Duration { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo 'Classificação' é obrigatório.")]
        public int ClassificationId { get; set; }

        public Classification Classification { get; set; }
        public ICollection<FilmGenre> FilmGenres { get; set; }
        public ICollection<FilmStudio> FilmStudios { get; set; }
    }
}
