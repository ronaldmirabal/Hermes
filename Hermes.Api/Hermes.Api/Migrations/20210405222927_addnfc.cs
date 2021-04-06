using Microsoft.EntityFrameworkCore.Migrations;

namespace Hermes.Api.Migrations
{
    public partial class addnfc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroNfc",
                table: "Facturas",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tipoComprobanteId",
                table: "Facturas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoComprobantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreNfc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoNfc = table.Column<int>(type: "int", nullable: false),
                    CantidadDisponible = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoComprobantes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_tipoComprobanteId",
                table: "Facturas",
                column: "tipoComprobanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_TipoComprobantes_tipoComprobanteId",
                table: "Facturas",
                column: "tipoComprobanteId",
                principalTable: "TipoComprobantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_TipoComprobantes_tipoComprobanteId",
                table: "Facturas");

            migrationBuilder.DropTable(
                name: "TipoComprobantes");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_tipoComprobanteId",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "NumeroNfc",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "tipoComprobanteId",
                table: "Facturas");
        }
    }
}
