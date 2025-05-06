using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Seeders
{
    public class BookingSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasData(
                new Booking {
                    Id = 1,
                    UserId = 2,
                    RoomId = 1,
                    StartTime = DateTime.UtcNow.AddDays(1).AddHours(9),
                    EndTime = DateTime.UtcNow.AddDays(1).AddHours(11),
                    IsCancelled = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Booking {
                    Id = 2,
                    UserId = 2,
                    RoomId = 2,
                    StartTime = DateTime.UtcNow.AddDays(2).AddHours(14),
                    EndTime = DateTime.UtcNow.AddDays(2).AddHours(16),
                    IsCancelled = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Booking {
                    Id = 3,
                    UserId = 3,
                    RoomId = 3,
                    StartTime = DateTime.UtcNow.AddDays(3).AddHours(10),
                    EndTime = DateTime.UtcNow.AddDays(3).AddHours(12),
                    IsCancelled = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Booking {
                    Id = 4,
                    UserId = 3,
                    RoomId = 4,
                    StartTime = DateTime.UtcNow.AddDays(-1).AddHours(9),
                    EndTime = DateTime.UtcNow.AddDays(-1).AddHours(17),
                    IsCancelled = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-2)
                }
            );
        }
    }
}