using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuEduca01.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsercaoMedica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cardapios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeRefeicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredientes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calorias = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsercaoMedicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastroUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receitaMedica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notificacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsercaoMedicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsercaoMedicas_Usuarios_CadastroUsuarioId",
                        column: x => x.CadastroUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "CadastroUsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Avaliacaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuariosId = table.Column<int>(type: "int", nullable: false),
                    CadastroUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CardapioId = table.Column<int>(type: "int", nullable: false),
                    CardapioId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacaos_Cardapios_CardapioId1",
                        column: x => x.CardapioId1,
                        principalTable: "Cardapios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Avaliacaos_Usuarios_CadastroUsuarioId",
                        column: x => x.CadastroUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "CadastroUsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacaos_CadastroUsuarioId",
                table: "Avaliacaos",
                column: "CadastroUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacaos_CardapioId1",
                table: "Avaliacaos",
                column: "CardapioId1");

            migrationBuilder.CreateIndex(
                name: "IX_InsercaoMedicas_CadastroUsuarioId",
                table: "InsercaoMedicas",
                column: "CadastroUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacaos");

            migrationBuilder.DropTable(
                name: "InsercaoMedicas");

            migrationBuilder.DropTable(
                name: "Cardapios");
        }
    }
}
