using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.DTOs;
using ApiRest.Interfaces;
using ApiRest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDto dto)
        {
            try
            {
                var booking = new Booking
                {
                    UserId = dto.UserId,
                    RoomId = dto.RoomId,
                    StartTime = dto.StartTime,
                    EndTime = dto.EndTime,
                    IsCancelled = false,
                    CreatedAt = DateTime.UtcNow
                };

                var createdBooking = await _bookingService.CreateBookingAsync(booking);
                return Ok(createdBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            try
            {
                var cancelledBooking = await _bookingService.CancelBookingAsync(id);
                return Ok(cancelledBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetUserBookings(int userId)
        {
            var bookings = await _bookingService.GetUserBookingsAsync(userId);
            return Ok(bookings);
        }
    }
}