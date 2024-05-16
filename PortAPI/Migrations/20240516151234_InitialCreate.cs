using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arrivees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomNavire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateHeureArrivee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PortOrigine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terminal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCargaison = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrivees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomNavire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateHeureDepart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PortDestination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCargaison = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arrivees");

            migrationBuilder.DropTable(
                name: "Departs");
        }
    }
}
