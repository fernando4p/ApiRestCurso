using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestCurso.Migrations
{
    public partial class campopeso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "peso",
                table: "tb_produtos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "peso",
                table: "tb_produtos");
        }
    }
}
