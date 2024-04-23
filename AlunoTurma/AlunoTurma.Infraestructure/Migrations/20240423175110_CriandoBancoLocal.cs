using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlunoTurma.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBancoLocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    Usuario = table.Column<string>(type: "NVARCHAR", maxLength: 45, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeTurma = table.Column<string>(type: "NVARCHAR", maxLength: 45, nullable: false),
                    Ano = table.Column<int>(type: "INT", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "aluno_turma",
                columns: table => new
                {
                    aluno_id = table.Column<int>(type: "INTEGER", nullable: false),
                    turma_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno_turma", x => new { x.aluno_id, x.turma_id });
                    table.ForeignKey(
                        name: "fk_aluno_turma_1_idx",
                        column: x => x.aluno_id,
                        principalTable: "Aluno",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_turma_1_idx",
                        column: x => x.turma_id,
                        principalTable: "Turma",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_aluno_turma_turma_id",
                table: "aluno_turma",
                column: "turma_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aluno_turma");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Turma");
        }
    }
}
