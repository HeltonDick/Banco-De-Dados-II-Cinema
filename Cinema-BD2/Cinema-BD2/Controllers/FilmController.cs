using Cinema_BD2.Models;
using Cinema_BD2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Cinema_BD2.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IStudioRepository _studioRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IClassificationRepository _classificationRepository;
        public FilmController(
            IFilmRepository filmRepository,
            IStudioRepository studioRepository,
            IGenreRepository genreRepository,
            IClassificationRepository classificationRepository)
        {
            _filmRepository = filmRepository;
            _studioRepository = studioRepository;
            _genreRepository = genreRepository;
            _classificationRepository = classificationRepository;
        }

        public async Task<IActionResult> Index()
        {
            var films = await _filmRepository.GetAll();
            return View(films);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new FilmViewModel
            {
                Classifications = (await _classificationRepository.GetAll())
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.MinAge.ToString() }),

                Genres = (await _genreRepository.GetAll())
                    .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name }),

                Studios = (await _studioRepository.GetAll())
                    .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FilmViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Classifications = (await _classificationRepository.GetAll())
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.MinAge.ToString() });

                viewModel.Genres = (await _genreRepository.GetAll())
                    .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name });

                viewModel.Studios = (await _studioRepository.GetAll())
                    .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name });

                return View(viewModel);
            }

            var film = new Film
            {
                OriginalTitle = viewModel.OriginalTitle,
                Title = viewModel.Title,
                Duration = viewModel.Duration,
                Description = viewModel.Description,
                ClassificationId = viewModel.ClassificationId,
                FilmGenres = viewModel.SelectedGenreIds.Select(id => new FilmGenre { GenreId = id }).ToList(),
                FilmStudios = viewModel.SelectedStudioIds.Select(id => new FilmStudio { StudioId = id }).ToList()
            };

            await _filmRepository.Update(film);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var film = await _filmRepository.GetById(id);
            if (film == null) return NotFound();

            var viewModel = new FilmViewModel
            {
                Id = film.Id,
                OriginalTitle = film.OriginalTitle,
                Title = film.Title,
                Duration = film.Duration,
                Description = film.Description,
                ClassificationId = film.ClassificationId,
                SelectedGenreIds = film.FilmGenres.Select(fg => fg.GenreId).ToList(),
                SelectedStudioIds = film.FilmStudios.Select(fs => fs.StudioId).ToList(),
                Classifications = (await _classificationRepository.GetAll())
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.MinAge.ToString() }),
                Genres = (await _genreRepository.GetAll())
                    .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name }),
                Studios = (await _studioRepository.GetAll())
                    .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FilmViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Classifications = (await _classificationRepository.GetAll())
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.MinAge.ToString() });
                viewModel.Genres = (await _genreRepository.GetAll())
                    .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name });
                viewModel.Studios = (await _studioRepository.GetAll())
                    .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name });
                return View(viewModel);
            }

            var film = await _filmRepository.GetById(viewModel.Id);
            if (film == null) return NotFound();

            film.OriginalTitle = viewModel.OriginalTitle;
            film.Title = viewModel.Title;
            film.Duration = viewModel.Duration;
            film.Description = viewModel.Description;
            film.ClassificationId = viewModel.ClassificationId;

            film.FilmGenres = viewModel.SelectedGenreIds.Select(id => new FilmGenre { FilmId = film.Id, GenreId = id }).ToList();
            film.FilmStudios = viewModel.SelectedStudioIds.Select(id => new FilmStudio { FilmId = film.Id, StudioId = id }).ToList();

            await _filmRepository.Update(film);
            return RedirectToAction(nameof(Index));
        }
    }
}
