using Microsoft.EntityFrameworkCore.Migrations;

namespace Hermes.Api.Migrations
{
    public partial class editpro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identificacion",
                table: "Proveedores",
                newName: "NoIdentificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoIdentificacion",
                table: "Proveedores",
                newName: "Identificacion");
        }
    }
}
