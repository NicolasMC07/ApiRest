using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Models
{
    public enum AuditAction
    {
        Create,
        Update,
        Delete
    }

    public class AuditLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? EntityName { get; set; }
        public int EntityId { get; set; }
        public AuditAction Action { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        
        public User? User { get; set; }
    }
}