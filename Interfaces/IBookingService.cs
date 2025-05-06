using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;

namespace ApiRest.Interfaces
{
     public interface IBookingService
    {
        Task<Booking> CreateBookingAsync(Booking booking);
        Task<Booking> CancelBookingAsync(int bookingId);
        Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId);
    }
}