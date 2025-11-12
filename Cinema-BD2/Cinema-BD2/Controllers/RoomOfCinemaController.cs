using Cinema_BD2.Data;
using Cinema_BD2.Models;
using Cinema_BD2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Cinema_BD2.Controllers
{
    public class RoomOfCinemaController : Controller
    {
        private readonly IRoomOfCinemaRepository _roomOfCinemaRepository;
        private readonly IRoomRepository _roomRepository;
        public RoomOfCinemaController(IRoomOfCinemaRepository roomOfCinemaRepository, IRoomRepository roomRepository)
        {
            _roomOfCinemaRepository = roomOfCinemaRepository;
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var romOfCinema = await _roomOfCinemaRepository.GetAll();
            return View(romOfCinema);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.RoomId = new SelectList(await _roomRepository.GetAll(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomOfCinema roomOfCinema)
        {
            if (ModelState.IsValid)
            {
                await _roomOfCinemaRepository.Create(roomOfCinema);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.RoomId = new SelectList(await _roomRepository.GetAll(), "Id", "Name", roomOfCinema.RoomId);
            return View(roomOfCinema);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var roomOfCinema = await _roomOfCinemaRepository.GetById(id);
            if (roomOfCinema == null)
                return NotFound();

            await _roomOfCinemaRepository.Delete(roomOfCinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var roomOfCinema = await _roomOfCinemaRepository.GetById(id);
            if (roomOfCinema == null) return NotFound();

            var types = await _roomOfCinemaRepository.GetAll();
            ViewBag.RoomId = new SelectList(types, "Id", "Name", roomOfCinema.RoomId);

            return View(roomOfCinema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RoomOfCinema RoomOfCinema)
        {
            if (id != RoomOfCinema.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                var typesForInvalid = await _roomOfCinemaRepository.GetAll();
                ViewBag.RoomId = new SelectList(typesForInvalid, "Id", "Name", RoomOfCinema.RoomId);
                return View(RoomOfCinema);
            }

            try
            {
                await _roomOfCinemaRepository.Update(RoomOfCinema);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao atualizar a sala. Tente novamente.");
                var typesOnError = await _roomOfCinemaRepository.GetAll();

                ViewBag.RoomId = new SelectList(typesOnError, "Id", "Name", RoomOfCinema.RoomId);
                return View(RoomOfCinema);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
