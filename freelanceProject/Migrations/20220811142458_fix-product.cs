using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace freelanceProject.Migrations
{
    public partial class fixproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceRange",
                table: "Products",
                newName: "Image5");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Products",
                newName: "Image4");

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "maxPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "minPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "maxPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "minPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Image5",
                table: "Products",
                newName: "PriceRange");

            migrationBuilder.RenameColumn(
                name: "Image4",
                table: "Products",
                newName: "Image");
        }
    }
}
