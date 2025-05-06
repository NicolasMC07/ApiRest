using ApiRest.Interfaces;
using ApiRest.Models;

namespace ApiRest.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAuditLogRepository _auditLogRepository;

        public BookingService(
            IBookingRepository bookingRepository,
            IRoomRepository roomRepository,
            IUserRepository userRepository,
            IAuditLogRepository auditLogRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _userRepository = userRepository;
            _auditLogRepository = auditLogRepository;
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            // Validate user exists
            var user = await _userRepository.GetByIdAsync(booking.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Validate room exists
            var room = await _roomRepository.GetByIdAsync(booking.RoomId);
            if (room == null)
            {
                throw new Exception("Room not found");
            }

            // Validate time (end time must be after start time)
            if (booking.EndTime <= booking.StartTime)
            {
                throw new Exception("End time must be after start time");
            }

            // Check if room is available
            var isAvailable = await _bookingRepository.IsRoomAvailableAsync(
                booking.RoomId, booking.StartTime, booking.EndTime);
            
            if (!isAvailable)
            {
                throw new Exception("Room is not available for the selected time slot");
            }

            var createdBooking = await _bookingRepository.CreateAsync(booking);

            // Log the action
            await _auditLogRepository.CreateAsync(new AuditLog
            {
                UserId = booking.UserId,
                EntityName = "Booking",
                EntityId = createdBooking.Id,
                Action = AuditAction.Create,
                NewValues = $"Booking created for room {room.Name} from {booking.StartTime} to {booking.EndTime}"
            });

            return createdBooking;
        }

        public async Task<Booking> CancelBookingAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking == null)
            {
                throw new Exception("Booking not found");
            }

            if (booking.IsCancelled)
            {
                throw new Exception("Booking is already cancelled");
            }

            // Optional: Add validation for cancellation time limit
            // if (booking.StartTime < DateTime.UtcNow.AddHours(24))
            // {
            //     throw new Exception("Cancellation must be made at least 24 hours in advance");
            // }

            booking.IsCancelled = true;
            var updatedBooking = await _bookingRepository.UpdateAsync(booking);

            // Log the action
            await _auditLogRepository.CreateAsync(new AuditLog
            {
                UserId = booking.UserId,
                EntityName = "Booking",
                EntityId = booking.Id,
                Action = AuditAction.Update,
                OldValues = "IsCancelled: false",
                NewValues = "IsCancelled: true"
            });

            return updatedBooking;
        }

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId)
        {
            return await _bookingRepository.GetUserBookingsAsync(userId);
        }
    }
}