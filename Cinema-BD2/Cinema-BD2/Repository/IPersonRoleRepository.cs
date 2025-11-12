using Cinema_BD2.Models;

namespace Cinema_BD2.Repository
{
    public interface IPersonRoleRepository
    {
        Task Create(PersonRole personRole);
        Task Update(PersonRole personRole);
        Task Delete(PersonRole personRole);

        Task<List<PersonRole>> GetAll();
        Task<PersonRole?> GetById(int id);
        Task<List<PersonRole>> GetByPersonId(int personId);
    }
}
