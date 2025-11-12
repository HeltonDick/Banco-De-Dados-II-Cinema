using Cinema_BD2.Data;

using Cinema_BD2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_BD2.Repository
{
    public class PersonRoleRepository : IPersonRoleRepository
    {
        private readonly CinemaContext _cinemaContext;
        public PersonRoleRepository(CinemaContext cinemaContext)
        {
            _cinemaContext = cinemaContext;
        }
        public async Task Create(PersonRole PersonRole)
        {
            await _cinemaContext.PersonRoles.AddAsync(PersonRole);
            await _cinemaContext.SaveChangesAsync();
        }

        public async Task Delete(PersonRole PersonRole)
        {
            _cinemaContext.Remove(PersonRole);
            await _cinemaContext.SaveChangesAsync();
        }

        public Task<List<PersonRole>?> GetAll()
        {
            var data = _cinemaContext.PersonRoles
                .Include(pr => pr.Person)
                .Include(pr => pr.Role)
                .ToListAsync();

            return data;
        }

        public Task<PersonRole?> GetById(int personId, int roleId)
        {
            var data = _cinemaContext.PersonRoles
                .Include(pr => pr.Person)
                .Include(pr => pr.Role)
                .Where(rp => rp.PersonId == personId && rp.RoleId == roleId)
                .FirstOrDefaultAsync();
            return data;
        }

        public async Task<PersonRole?> GetById(int id)
        {
            return await _cinemaContext.PersonRoles
                .Include(pr => pr.Person)
                .Include(pr => pr.Role)
                .FirstOrDefaultAsync(pr => pr.Id == id);
        }

        public async Task<List<PersonRole>?> GetByPersonId(int personId)
        {
            var data = await _cinemaContext.PersonRoles
                .Include(pr => pr.Person)
                .Include(pr => pr.Role)
                .Where(pr => pr.PersonId == personId)
                .ToListAsync();
            return data;
        }

        public async Task<List<PersonRole>?> GetByPersonName(string name)
        {
            var data = await _cinemaContext.PersonRoles
                .Include(pr => pr.Person)
                .Include(pr => pr.Role)
                .Where(pr => pr.Person!.Name!.ToLower().Contains(name.ToLower()))
                .ToListAsync();
            return data;
        }

        public async Task<List<PersonRole>?> GetByRoleId(int roleId)
        {
            var data = await _cinemaContext.PersonRoles
                .Include(pr => pr.Person)
                .Include(pr => pr.Role)
                .Where(pr => pr.RoleId == roleId)
                .ToListAsync();
            return data;
        }

        public async Task<List<PersonRole>?> GetByRoleName(string name)
        {
            var data = await _cinemaContext.PersonRoles
                .Include(pr => pr.Person)
                .Include(pr => pr.Role)
                .Where(pr => pr.Role!.Name!.ToLower().Contains(name.ToLower()))
                .ToListAsync();
            return data;
        }

        public async Task Update(PersonRole PersonRole)
        {
            _cinemaContext.PersonRoles.Update(PersonRole);
            await _cinemaContext.SaveChangesAsync();
        }
    }
}
