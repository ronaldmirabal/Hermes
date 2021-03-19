using Microsoft.EntityFrameworkCore.Migrations;

namespace Hermes.Api.Migrations
{
    public partial class migra2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detallefacturas_Articulos_IdArticuloNavigationId",
                table: "Detallefacturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Detallefacturas_Facturas_IdFacturaNavigationId",
                table: "Detallefacturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_IdClienteNavigationId",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "IdArticulo",
                table: "Detallefacturas");

            migrationBuilder.DropColumn(
                name: "IdFactura",
                table: "Detallefacturas");

            migrationBuilder.RenameColumn(
                name: "IdClienteNavigationId",
                table: "Facturas",
                newName: "clienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Facturas_IdClienteNavigationId",
                table: "Facturas",
                newName: "IX_Facturas_clienteId");

            migrationBuilder.RenameColumn(
                name: "IdFacturaNavigationId",
                table: "Detallefacturas",
                newName: "FacturaId");

            migrationBuilder.RenameColumn(
                name: "IdArticuloNavigationId",
                table: "Detallefacturas",
                newName: "ArticuloId");

            migrationBuilder.RenameIndex(
                name: "IX_Detallefacturas_IdFacturaNavigationId",
                table: "Detallefacturas",
                newName: "IX_Detallefacturas_FacturaId");

            migrationBuilder.RenameIndex(
                name: "IX_Detallefacturas_IdArticuloNavigationId",
                table: "Detallefacturas",
                newName: "IX_Detallefacturas_ArticuloId");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Articulos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Articulos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Articulos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "categoriaId",
                table: "Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_categoriaId",
                table: "Articulos",
                column: "categoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Categorias_categoriaId",
                table: "Articulos",
                column: "categoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Detallefacturas_Articulos_ArticuloId",
                table: "Detallefacturas",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Detallefacturas_Facturas_FacturaId",
                table: "Detallefacturas",
                column: "FacturaId",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_clienteId",
                table: "Facturas",
                column: "clienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Categorias_categoriaId",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Detallefacturas_Articulos_ArticuloId",
                table: "Detallefacturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Detallefacturas_Facturas_FacturaId",
                table: "Detallefacturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_clienteId",
                table: "Facturas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_categoriaId",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "categoriaId",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "clienteId",
                table: "Facturas",
                newName: "IdClienteNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_Facturas_clienteId",
                table: "Facturas",
                newName: "IX_Facturas_IdClienteNavigationId");

            migrationBuilder.RenameColumn(
                name: "FacturaId",
                table: "Detallefacturas",
                newName: "IdFacturaNavigationId");

            migrationBuilder.RenameColumn(
                name: "ArticuloId",
                table: "Detallefacturas",
                newName: "IdArticuloNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_Detallefacturas_FacturaId",
                table: "Detallefacturas",
                newName: "IX_Detallefacturas_IdFacturaNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_Detallefacturas_ArticuloId",
                table: "Detallefacturas",
                newName: "IX_Detallefacturas_IdArticuloNavigationId");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Facturas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdArticulo",
                table: "Detallefacturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFactura",
                table: "Detallefacturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Detallefacturas_Articulos_IdArticuloNavigationId",
                table: "Detallefacturas",
                column: "IdArticuloNavigationId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Detallefacturas_Facturas_IdFacturaNavigationId",
                table: "Detallefacturas",
                column: "IdFacturaNavigationId",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_IdClienteNavigationId",
                table: "Facturas",
                column: "IdClienteNavigationId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
