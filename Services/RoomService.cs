using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Interfaces;
using ApiRest.Models;

namespace ApiRest.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IAuditLogRepository _auditLogRepository;

        public RoomService(IRoomRepository roomRepository, IAuditLogRepository auditLogRepository)
        {
            _roomRepository = roomRepository;
            _auditLogRepository = auditLogRepository;
        }

        public async Task<Room> CreateRoomAsync(Room room)
        {
            var createdRoom = await _roomRepository.CreateAsync(room);

            // Log the action
            await _auditLogRepository.CreateAsync(new AuditLog
            {
                EntityName = "Room",
                EntityId = createdRoom.Id,
                Action = AuditAction.Create,
                NewValues = $"Room created with name: {createdRoom.Name}"
            });

            return createdRoom;
        }

        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime startTime, DateTime endTime)
        {
            return await _roomRepository.GetAvailableRoomsAsync(startTime, endTime);
        }
    }
}