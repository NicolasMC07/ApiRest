using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    EntityName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OldValues = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NewValues = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsCancelled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(2025, 5, 6, 22, 36, 20, 312, DateTimeKind.Utc).AddTicks(7079), "Sala pequeña con vista al centro de la ciudad", "Sala Manhattan" },
                    { 2, 12, new DateTime(2025, 5, 6, 22, 36, 20, 312, DateTimeKind.Utc).AddTicks(7103), "Sala principal para reuniones importantes", "Sala Central" },
                    { 3, 2, new DateTime(2025, 5, 6, 22, 36, 20, 312, DateTimeKind.Utc).AddTicks(7127), "Oficina insonorizada para trabajo concentrado", "Oficina Silencio" },
                    { 4, 20, new DateTime(2025, 5, 6, 22, 36, 20, 312, DateTimeKind.Utc).AddTicks(7260), "Espacio abierto con mesas compartidas", "Área Colaborativa" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 6, 22, 36, 20, 421, DateTimeKind.Utc).AddTicks(3415), "admin@coworking.com", "$2a$11$Fp5ZcduCeLF.tfgLaX9V2urkvLDHkpomT2VuLigwhAmwJ2SYORfGu", "admin" },
                    { 2, new DateTime(2025, 5, 6, 22, 36, 20, 529, DateTimeKind.Utc).AddTicks(9984), "user1@test.com", "$2a$11$i13CBPqHNRtYYn8YXfcu.uizhPB/mDdnGzhgPPaxaHsFJhd7HaA5i", "user1" },
                    { 3, new DateTime(2025, 5, 6, 22, 36, 20, 637, DateTimeKind.Utc).AddTicks(8524), "user2@test.com", "$2a$11$wUaSaZ8IrB6NpllEk2ebueulrV8UMrSj6.U2uYjtASF38r2gSwaqC", "user2" }
                });

            migrationBuilder.InsertData(
                table: "AuditLogs",
                columns: new[] { "Id", "Action", "EntityId", "EntityName", "NewValues", "OldValues", "Timestamp", "UserId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Room", "Room created: Sala Manhattan", null, new DateTime(2025, 5, 3, 22, 36, 20, 637, DateTimeKind.Utc).AddTicks(9149), 1 },
                    { 2, 0, 1, "Booking", "Booking created for room Sala Manhattan", null, new DateTime(2025, 5, 5, 22, 36, 20, 637, DateTimeKind.Utc).AddTicks(9172), 2 },
                    { 3, 1, 4, "Booking", "IsCancelled: true", "IsCancelled: false", new DateTime(2025, 5, 6, 20, 36, 20, 637, DateTimeKind.Utc).AddTicks(9196), 3 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CreatedAt", "EndTime", "IsCancelled", "RoomId", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 6, 22, 36, 20, 637, DateTimeKind.Utc).AddTicks(8925), new DateTime(2025, 5, 8, 9, 36, 20, 637, DateTimeKind.Utc).AddTicks(8915), false, 1, new DateTime(2025, 5, 8, 7, 36, 20, 637, DateTimeKind.Utc).AddTicks(8896), 2 },
                    { 2, new DateTime(2025, 5, 6, 22, 36, 20, 637, DateTimeKind.Utc).AddTicks(8978), new DateTime(2025, 5, 9, 14, 36, 20, 637, DateTimeKind.Utc).AddTicks(8964), false, 2, new DateTime(2025, 5, 9, 12, 36, 20, 637, DateTimeKind.Utc).AddTicks(8954), 2 },
                    { 3, new DateTime(2025, 5, 6, 22, 36, 20, 637, DateTimeKind.Utc).AddTicks(9025), new DateTime(2025, 5, 10, 10, 36, 20, 637, DateTimeKind.Utc).AddTicks(9011), false, 3, new DateTime(2025, 5, 10, 8, 36, 20, 637, DateTimeKind.Utc).AddTicks(9001), 3 },
                    { 4, new DateTime(2025, 5, 4, 22, 36, 20, 637, DateTimeKind.Utc).AddTicks(9072), new DateTime(2025, 5, 6, 15, 36, 20, 637, DateTimeKind.Utc).AddTicks(9058), true, 4, new DateTime(2025, 5, 6, 7, 36, 20, 637, DateTimeKind.Utc).AddTicks(9048), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_UserId",
                table: "AuditLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
