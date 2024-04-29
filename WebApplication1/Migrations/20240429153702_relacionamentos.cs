using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class relacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assuntos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assuntos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompaniaDeCarros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniaDeCarros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doutores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doutores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeloDeCarros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", nullable: true),
                    CompaniaDeCarroId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloDeCarros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloDeCarros_CompaniaDeCarros_CompaniaDeCarroId",
                        column: x => x.CompaniaDeCarroId,
                        principalTable: "CompaniaDeCarros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    DoutorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Doutores_DoutorId",
                        column: x => x.DoutorId,
                        principalTable: "Doutores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EstudanteAssuntos",
                columns: table => new
                {
                    EstudanteId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssuntoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudanteAssuntos", x => new { x.EstudanteId, x.AssuntoId });
                    table.ForeignKey(
                        name: "FK_EstudanteAssuntos_Assuntos_AssuntoId",
                        column: x => x.AssuntoId,
                        principalTable: "Assuntos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EstudanteAssuntos_Estudantes_EstudanteId",
                        column: x => x.EstudanteId,
                        principalTable: "Estudantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstudanteAssuntos_AssuntoId",
                table: "EstudanteAssuntos",
                column: "AssuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloDeCarros_CompaniaDeCarroId",
                table: "ModeloDeCarros",
                column: "CompaniaDeCarroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_DoutorId",
                table: "Pacientes",
                column: "DoutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudanteAssuntos");

            migrationBuilder.DropTable(
                name: "ModeloDeCarros");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Assuntos");

            migrationBuilder.DropTable(
                name: "Estudantes");

            migrationBuilder.DropTable(
                name: "CompaniaDeCarros");

            migrationBuilder.DropTable(
                name: "Doutores");
        }
    }
}
