using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Seeders
{
    public class RoomTypeSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomTypeSeeder>().HasData(
                new Room
                {
                    Id = 1,
                    Name = "Sala de Reuniones Pequeña",
                    Description = "Sala ideal para reuniones de 4-6 personas, equipada con mesa y sillas."
                },
                new Room
                {
                    Id = 2,
                    Name = "Sala de Reuniones Grande",
                    Description = "Sala amplia para reuniones de hasta 12 personas, con pantalla y pizarra."
                },
                new Room
                {
                    Id = 3,
                    Name = "Oficina Privada",
                    Description = "Espacio privado para trabajo individual o en pareja, con escritorio y silla ergonómica."
                },
                new Room
                {
                    Id = 4,
                    Name = "Espacio de Coworking",
                    Description = "Área abierta con mesas compartidas para trabajo colaborativo."
                }
            );
        }
    }
}