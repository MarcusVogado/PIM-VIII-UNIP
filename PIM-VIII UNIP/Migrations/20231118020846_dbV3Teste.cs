using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM_VIII_UNIP.Migrations
{
    public partial class dbV3Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedores_Enderecos_EnderocID",
                table: "Vendedores");

            migrationBuilder.RenameColumn(
                name: "EnderocID",
                table: "Vendedores",
                newName: "EnderocoID");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedores_EnderocID",
                table: "Vendedores",
                newName: "IX_Vendedores_EnderocoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedores_Enderecos_EnderocoID",
                table: "Vendedores",
                column: "EnderocoID",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedores_Enderecos_EnderocoID",
                table: "Vendedores");

            migrationBuilder.RenameColumn(
                name: "EnderocoID",
                table: "Vendedores",
                newName: "EnderocID");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedores_EnderocoID",
                table: "Vendedores",
                newName: "IX_Vendedores_EnderocID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedores_Enderecos_EnderocID",
                table: "Vendedores",
                column: "EnderocID",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
