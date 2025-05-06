using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.DTOs
{
    public class RoomDto
    {
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
    }
}