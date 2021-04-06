using Microsoft.EntityFrameworkCore.Migrations;

namespace Hermes.Api.Migrations
{
    public partial class nofact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoFactura",
                table: "Facturas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoFactura",
                table: "Facturas");
        }
    }
}
