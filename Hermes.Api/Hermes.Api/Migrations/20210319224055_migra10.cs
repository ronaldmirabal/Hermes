using Microsoft.EntityFrameworkCore.Migrations;

namespace Hermes.Api.Migrations
{
    public partial class migra10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_IdentificacionType_identificacionTypeId",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentificacionType",
                table: "IdentificacionType");

            migrationBuilder.RenameTable(
                name: "IdentificacionType",
                newName: "IdentificacionTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentificacionTypes",
                table: "IdentificacionTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_IdentificacionTypes_identificacionTypeId",
                table: "Clientes",
                column: "identificacionTypeId",
                principalTable: "IdentificacionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_IdentificacionTypes_identificacionTypeId",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentificacionTypes",
                table: "IdentificacionTypes");

            migrationBuilder.RenameTable(
                name: "IdentificacionTypes",
                newName: "IdentificacionType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentificacionType",
                table: "IdentificacionType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_IdentificacionType_identificacionTypeId",
                table: "Clientes",
                column: "identificacionTypeId",
                principalTable: "IdentificacionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
