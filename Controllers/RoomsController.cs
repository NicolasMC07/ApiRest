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
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRooms([FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
        {
            var rooms = await _roomService.GetAvailableRoomsAsync(startTime, endTime);
            return Ok(rooms);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDto dto)
        {
            try
            {
                var room = new Room
                {
                    Name = dto.Name,
                    Capacity = dto.Capacity,
                    Description = dto.Description,
                    CreatedAt = DateTime.UtcNow
                };

                var createdRoom = await _roomService.CreateRoomAsync(room);
                return Ok(createdRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}