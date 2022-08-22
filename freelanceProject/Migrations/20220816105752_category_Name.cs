using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace freelanceProject.Migrations
{
    public partial class category_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category_Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_Name",
                table: "Products");
        }
    }
}
