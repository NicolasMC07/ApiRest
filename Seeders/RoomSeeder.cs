using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Seeders
{
    public class RoomSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room { 
                    Id = 1, 
                    Name = "Sala Manhattan",
                    Capacity = 6, 
                    Description = "Sala pequeña con vista al centro de la ciudad",
                    CreatedAt = DateTime.UtcNow
                },
                new Room { 
                    Id = 2, 
                    Name = "Sala Central",
                    Capacity = 12, 
                    Description = "Sala principal para reuniones importantes",
                    CreatedAt = DateTime.UtcNow
                },
                new Room { 
                    Id = 3, 
                    Name = "Oficina Silencio",
                    Capacity = 2, 
                    Description = "Oficina insonorizada para trabajo concentrado",
                    CreatedAt = DateTime.UtcNow
                },
                new Room { 
                    Id = 4, 
                    Name = "Área Colaborativa",
                    Capacity = 20, 
                    Description = "Espacio abierto con mesas compartidas",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}