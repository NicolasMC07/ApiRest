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
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> CreateAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.Room)
                .OrderByDescending(b => b.StartTime)
                .ToListAsync();
        }

        public async Task<Booking> UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<bool> IsRoomAvailableAsync(int roomId, DateTime startTime, DateTime endTime, int? bookingId = null)
        {
            var query = _context.Bookings
                .Where(b => !b.IsCancelled && 
                            b.RoomId == roomId && 
                            ((b.StartTime < endTime && b.EndTime > startTime)));

            if (bookingId.HasValue)
            {
                query = query.Where(b => b.Id != bookingId.Value);
            }

            return !await query.AnyAsync();
        }
    }
}