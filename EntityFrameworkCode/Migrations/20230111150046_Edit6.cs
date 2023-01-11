using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCode.Migrations
{
    public partial class Edit6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddOn",
                table: "Blogs",
                newName: "AddedOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddedOn",
                table: "Blogs",
                newName: "AddOn");
        }
    }
}
