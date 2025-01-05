using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalago.Migrations
{
    /// <inheritdoc />
    public partial class populandoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categoria(Nome, ImagemUrl) Values('Bebidas','Bebidas.jpg')");
            migrationBuilder.Sql("Insert into Categoria(Nome, ImagemUrl) Values('Lanches','Lanches.jpg')");
            migrationBuilder.Sql("Insert into Categoria(Nome, ImagemUrl) Values('Sobremesas','Sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
        }
    }
}
