using Cinema_BD2.Data;
using Cinema_BD2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_BD2.Repository
{
    public class RoomOfCinemaRepository : IRoomOfCinemaRepository
    {
        private readonly CinemaContext _cinemaContext;
        public RoomOfCinemaRepository(CinemaContext cinemaContext)
        {
            _cinemaContext = cinemaContext;
        }

        public async Task Create(RoomOfCinema RoomOfCinema)
        {
            await _cinemaContext.RoomOfCinemas.AddAsync(RoomOfCinema);
            await _cinemaContext.SaveChangesAsync();
        }

        public Task Delete(RoomOfCinema RoomOfCinema)
        {
            _cinemaContext.RoomOfCinemas.Remove(RoomOfCinema);
            return _cinemaContext.SaveChangesAsync();
        }

        public async Task<List<RoomOfCinema>> GetAll()
        {
            return await _cinemaContext.RoomOfCinemas
                .Include(r => r.Room)
                .ToListAsync();
        }

        public async Task<RoomOfCinema?> GetById(int id)
        {
            return await _cinemaContext.RoomOfCinemas
                .Include(r => r.Room)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task Update(RoomOfCinema RoomOfCinema)
        {
            _cinemaContext.RoomOfCinemas.Update(RoomOfCinema);
            await _cinemaContext.SaveChangesAsync();
        }
    }
}
