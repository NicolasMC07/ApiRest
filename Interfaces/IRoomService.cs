using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;

namespace ApiRest.Interfaces
{
    public interface IRoomService
    {
        Task<Room> CreateRoomAsync(Room room);
        Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime startTime, DateTime endTime);
    }
}