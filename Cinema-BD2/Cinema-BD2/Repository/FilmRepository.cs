using Cinema_BD2.Data;
using Cinema_BD2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_BD2.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private readonly CinemaContext _cinemaContext;
        public FilmRepository(CinemaContext context)
        {
            _cinemaContext = context;
        }
        public async Task Create(Film film)
        {
            _cinemaContext.Films.Add(film);
            await _cinemaContext.SaveChangesAsync();
        }

        public async Task Delete(Film film) {
            _cinemaContext.Films.Remove(film);
            await _cinemaContext.SaveChangesAsync();
        }

        public async Task<List<Film>> GetAll()
        {
            return await _cinemaContext.Films
                .Include(f => f.Classification)
                .Include(f => f.FilmGenres).ThenInclude(fg => fg.Genre)
                .Include(f => f.FilmStudios).ThenInclude(fs => fs.Studio)
                .ToListAsync();
        }

        public async Task<List<Film>> GetByClassificationId(int classificationId)
        {
            return await _cinemaContext.Films
                .Where(f => f.ClassificationId == classificationId)
                .Include(f => f.Classification)
                .Include(f => f.FilmGenres).ThenInclude(fg => fg.Genre)
                .Include(f => f.FilmStudios).ThenInclude(fs => fs.Studio)
                .ToListAsync();
        }

        public async Task<List<Film>> GetByGenreId(int genreId)
        {
            return await _cinemaContext.Films
                .Where(f => f.FilmGenres.Any(fg => fg.GenreId == genreId))
                .Include(f => f.Classification)
                .Include(f => f.FilmGenres).ThenInclude(fg => fg.Genre)
                .Include(f => f.FilmStudios).ThenInclude(fs => fs.Studio)
                .ToListAsync();
        }

        public async Task<Film?> GetById(int id)
        {
            return await _cinemaContext.Films
                  .Include(f => f.Classification)
                  .Include(f => f.FilmGenres).ThenInclude(fg => fg.Genre)
                  .Include(f => f.FilmStudios).ThenInclude(fs => fs.Studio)
                  .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<Film>> GetByOriginalTitle(string originalTitle)
        {
            return await _cinemaContext.Films
                .Where(f => f.OriginalTitle.Contains(originalTitle))
                .Include(f => f.Classification)
                .Include(f => f.FilmGenres).ThenInclude(fg => fg.Genre)
                .Include(f => f.FilmStudios).ThenInclude(fs => fs.Studio)
                .ToListAsync();
        }

        public async Task<List<Film>> GetByStudioId(int studioId)
        {
            return await _cinemaContext.Films
                .Where(f => f.FilmStudios.Any(fs => fs.StudioId == studioId))
                .Include(f => f.Classification)
                .Include(f => f.FilmGenres).ThenInclude(fg => fg.Genre)
                .Include(f => f.FilmStudios).ThenInclude(fs => fs.Studio)
                .ToListAsync();
        }

        public async Task<List<Film>> GetByTitle(string title)
        {
            return await _cinemaContext.Films
                .Where(f => f.Title.Contains(title))
                .Include(f => f.Classification)
                .Include(f => f.FilmGenres).ThenInclude(fg => fg.Genre)
                .Include(f => f.FilmStudios).ThenInclude(fs => fs.Studio)
                .ToListAsync();
        }

        public async Task Update(Film film)
        {
            _cinemaContext.Films.Update(film);
            await _cinemaContext.SaveChangesAsync();
        }
    }
}
