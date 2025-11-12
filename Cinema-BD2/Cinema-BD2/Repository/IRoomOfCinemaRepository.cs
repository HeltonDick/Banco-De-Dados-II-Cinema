using Cinema_BD2.Data;
using Cinema_BD2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_BD2.Repository
{
    public interface IRoomOfCinemaRepository
    {
        Task Create(RoomOfCinema RoomOfCinema);
        Task Update(RoomOfCinema RoomOfCinema);
        Task Delete(RoomOfCinema RoomOfCinema);

        Task<RoomOfCinema?> GetById(int id);
        Task<List<RoomOfCinema>> GetAll();

    }
}
