using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Cinema_BD2.Models
{
    public class FilmViewModel
    {
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

        [Required(ErrorMessage = "Selecione ao menos um gênero.")]
        public List<int> SelectedGenreIds { get; set; } = new();

        [Required(ErrorMessage = "Selecione ao menos um estúdio.")]
        public List<int> SelectedStudioIds { get; set; } = new();

        // Dropdown lists
        public IEnumerable<SelectListItem> Classifications { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> Studios { get; set; }
    }
}
