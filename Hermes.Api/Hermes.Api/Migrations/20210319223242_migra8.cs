using Microsoft.EntityFrameworkCore.Migrations;

namespace Hermes.Api.Migrations
{
    public partial class migra8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "identificacionTypeId",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentificacionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificacionType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_identificacionTypeId",
                table: "Clientes",
                column: "identificacionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_IdentificacionType_identificacionTypeId",
                table: "Clientes",
                column: "identificacionTypeId",
                principalTable: "IdentificacionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_IdentificacionType_identificacionTypeId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "IdentificacionType");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_identificacionTypeId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "identificacionTypeId",
                table: "Clientes");
        }
    }
}
