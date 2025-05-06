using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Seeders
{
    public class AuditLogSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>().HasData(
                new AuditLog
                {
                    Id = 1,
                    UserId = 1,
                    EntityName = "Room",
                    EntityId = 1,
                    Action = AuditAction.Create,
                    Timestamp = DateTime.UtcNow.AddDays(-3),
                    NewValues = "Room created: Sala Manhattan"
                },
                new AuditLog
                {
                    Id = 2,
                    UserId = 2,
                    EntityName = "Booking",
                    EntityId = 1,
                    Action = AuditAction.Create,
                    Timestamp = DateTime.UtcNow.AddDays(-1),
                    NewValues = "Booking created for room Sala Manhattan"
                },
                new AuditLog
                {
                    Id = 3,
                    UserId = 3,
                    EntityName = "Booking",
                    EntityId = 4,
                    Action = AuditAction.Update,
                    Timestamp = DateTime.UtcNow.AddHours(-2),
                    OldValues = "IsCancelled: false",
                    NewValues = "IsCancelled: true"
                }
            );
        }
    }
}