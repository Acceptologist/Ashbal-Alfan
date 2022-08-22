using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace freelanceProject.Migrations
{
    public partial class fix_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contant",
                table: "Blogs",
                newName: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Blogs",
                newName: "Contant");
        }
    }
}
