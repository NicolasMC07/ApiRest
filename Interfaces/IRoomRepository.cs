using ApiRest.Models;

namespace ApiRest.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> GetByIdAsync(int id);
        Task<Room> CreateAsync(Room room);
        Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime startTime, DateTime endTime);
    }
}