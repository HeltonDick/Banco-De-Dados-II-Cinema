using Cinema_BD2.Models;

namespace Cinema_BD2.Repository
{
    public interface IFilmRepository
    {
        public Task Create(Film film);
        public Task Update(Film film);
        public Task Delete(Film film);

        public Task<Film?> GetById(int id);
        public Task<List<Film>> GetAll();

        public Task<List<Film>> GetByTitle(string title);
        public Task<List<Film>> GetByOriginalTitle(string originalTitle);
        public Task<List<Film>> GetByClassificationId(int classificationId);
        public Task<List<Film>> GetByGenreId(int genreId);
        public Task<List<Film>> GetByStudioId(int studioId);
    }
}
