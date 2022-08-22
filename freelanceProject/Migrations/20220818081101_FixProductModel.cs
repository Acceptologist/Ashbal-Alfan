using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace freelanceProject.Migrations
{
    public partial class FixProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAmountExist",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isTypeExist",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAmountExist",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isTypeExist",
                table: "Products");
        }
    }
}
