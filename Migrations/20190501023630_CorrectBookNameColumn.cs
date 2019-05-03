using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD_Razor_2_1.Migrations
{
    public partial class CorrectBookNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Names",
                table: "Books",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Books",
                newName: "Names");
        }
    }
}
