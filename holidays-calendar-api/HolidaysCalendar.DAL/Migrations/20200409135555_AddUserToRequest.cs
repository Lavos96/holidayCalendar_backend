using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidaysCalendar.DAL.Migrations
{
    public partial class AddUserToRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employee",
                table: "Requests");
        }
    }
}
