using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuEduca01.Data.Migrations
{
    /// <inheritdoc />
    public partial class CadastroUsuario02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Usuarios",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdentityUserId",
                table: "Usuarios",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_AspNetUsers_IdentityUserId",
                table: "Usuarios",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_AspNetUsers_IdentityUserId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdentityUserId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Usuarios");
        }
    }
}
