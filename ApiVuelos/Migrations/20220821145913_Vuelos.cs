using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiVuelos.Migrations
{
    public partial class Vuelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ciudad",
                table: "ciudades",
                newName: "ciudad");

            migrationBuilder.CreateTable(
                name: "aerolinea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAerolinea = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aerolinea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vuelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVuelo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSalida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraLlegada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumVuelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoVuelo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vuelos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vuelosAerolinea",
                columns: table => new
                {
                    VueloId = table.Column<int>(type: "int", nullable: false),
                    AerolineaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vuelosAerolinea", x => new { x.VueloId, x.AerolineaId });
                    table.ForeignKey(
                        name: "FK_vuelosAerolinea_aerolinea_AerolineaId",
                        column: x => x.AerolineaId,
                        principalTable: "aerolinea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vuelosAerolinea_vuelos_VueloId",
                        column: x => x.VueloId,
                        principalTable: "vuelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vuelosCiudades",
                columns: table => new
                {
                    VueloId = table.Column<int>(type: "int", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vuelosCiudades", x => new { x.VueloId, x.CiudadId });
                    table.ForeignKey(
                        name: "FK_vuelosCiudades_ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vuelosCiudades_vuelos_VueloId",
                        column: x => x.VueloId,
                        principalTable: "vuelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vuelosAerolinea_AerolineaId",
                table: "vuelosAerolinea",
                column: "AerolineaId");

            migrationBuilder.CreateIndex(
                name: "IX_vuelosCiudades_CiudadId",
                table: "vuelosCiudades",
                column: "CiudadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "vuelosAerolinea");

            migrationBuilder.DropTable(
                name: "vuelosCiudades");

            migrationBuilder.DropTable(
                name: "aerolinea");

            migrationBuilder.DropTable(
                name: "vuelos");

            migrationBuilder.RenameColumn(
                name: "ciudad",
                table: "ciudades",
                newName: "Ciudad");
        }
    }
}
