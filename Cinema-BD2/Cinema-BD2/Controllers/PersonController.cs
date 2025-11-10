using Cinema_BD2.Data;
using Cinema_BD2.Models;
using Cinema_BD2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema_BD2.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPerosonRepository _personRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly CinemaContext _cinemaContext;
        public PersonController(IPerosonRepository personRepository, IAddressRepository addressRepository, CinemaContext cinemaContext)
        {
            _personRepository = personRepository;
            _cinemaContext = cinemaContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pessoas = await _personRepository.GetAll();
            return View(pessoas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genders = _cinemaContext.Genders.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person, Address address)
        {
            if (await _personRepository.ExistsCpf(person.Cpf))
            {
                ModelState.AddModelError("CPF", "Já existe uma pessoa com este CPF.");
            }

            if (ModelState.IsValid)
            {
                _cinemaContext.Addresses.Add(address);
                await _cinemaContext.SaveChangesAsync();

                person.AddressId = address.Id;
                await _personRepository.Create(person);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Genders = _cinemaContext.Genders.ToList();
            return View(person);
        }
    }
}
