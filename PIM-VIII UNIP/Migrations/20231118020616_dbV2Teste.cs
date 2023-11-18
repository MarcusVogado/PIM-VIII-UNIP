using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM_VIII_UNIP.Migrations
{
    public partial class dbV2Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Enderecos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "Enderecos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
