using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Data;
using ApiRest.Interfaces;
using ApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Room> CreateAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return room;
        }


        public async Task<Room> GetByIdAsync(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime startTime, DateTime endTime)
        {
            var bookedRoomIds = await _context.Bookings
                .Where(b => !b.IsCancelled && 
                           ((b.StartTime < endTime && b.EndTime > startTime)))
                .Select(b => b.RoomId)
                .Distinct()
                .ToListAsync();

            return await _context.Rooms
                .Where(r => !bookedRoomIds.Contains(r.Id))
                .ToListAsync();
        }
    }
}