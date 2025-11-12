using Cinema_BD2.Models;
using Cinema_BD2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Cinema_BD2.Controllers
{
    public class PersonRoleController : Controller
    {
        private readonly IPersonRoleRepository _personRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPerosonRepository _personRepository;
        public PersonRoleController(IPersonRoleRepository personRoleRepository, IRoleRepository roleRepository, IPerosonRepository personRepository)
        {
            _personRoleRepository = personRoleRepository;
            _roleRepository = roleRepository;
            _personRepository = personRepository;
        }

        public async Task<IActionResult> Index() 
        {
            var list = await _personRoleRepository.GetAll();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.PersonId = new SelectList(await _personRepository.GetAll(), "Id", "Name");
            ViewBag.RoleId = new SelectList(await _roleRepository.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonRole personRole)
        {
            if (ModelState.IsValid)
            {
                await _personRoleRepository.Create(personRole);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.PersonId = new SelectList(await _personRepository.GetAll(), "Id", "Name", personRole.PersonId);
            ViewBag.RoleId = new SelectList(await _roleRepository.GetAll(), "Id", "Name", personRole.RoleId);
            return View(personRole);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var pr = await _personRoleRepository.GetById(id);
            if (pr == null) return NotFound();

            ViewBag.PersonId = new SelectList(await _personRepository.GetAll(), "Id", "Name", pr.PersonId);
            ViewBag.RoleId = new SelectList(await _roleRepository.GetAll(), "Id", "Name", pr.RoleId);

            return View(pr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonRole personRole)
        {
            if (ModelState.IsValid)
            {
                await _personRoleRepository.Update(personRole);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.PersonId = new SelectList(await _personRepository.GetAll(), "Id", "Name", personRole.PersonId);
            ViewBag.RoleId = new SelectList(await _roleRepository.GetAll(), "Id", "Name", personRole.RoleId);
            return View(personRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var pr = await _personRoleRepository.GetById(id);
            if (pr != null)
            {
                await _personRoleRepository.Delete(pr);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
