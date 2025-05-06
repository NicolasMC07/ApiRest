using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Seeders
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@coworking.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    Username = "user1",
                    Email = "user1@test.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("User123!"),
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 3,
                    Username = "user2",
                    Email = "user2@test.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("User123!"),
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}