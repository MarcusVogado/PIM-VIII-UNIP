using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM_VIII_UNIP.Migrations
{
    public partial class dbv4Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Produtos");
        }
    }
}
