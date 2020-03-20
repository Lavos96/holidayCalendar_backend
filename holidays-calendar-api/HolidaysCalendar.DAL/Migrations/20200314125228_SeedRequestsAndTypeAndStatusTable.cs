using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidaysCalendar.DAL.Migrations
{
    public partial class SeedRequestsAndTypeAndStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Statuses (Name) Values ('Zgłoszony')");
            migrationBuilder
                .Sql("INSERT INTO Statuses (Name) Values ('Zaakceptowany')");
            migrationBuilder
                .Sql("INSERT INTO Statuses (Name) Values ('Odrzucony')");
            migrationBuilder
                .Sql("INSERT INTO Statuses (Name) Values ('Anulowany')");

            migrationBuilder
                .Sql("INSERT INTO Types (Name) Values ('Urlop wypoczynkowy')");
            migrationBuilder
                .Sql("INSERT INTO Types (Name) Values ('Urlop bezpłatny')");
            migrationBuilder
                .Sql("INSERT INTO Types (Name) Values ('Urlop macierzyński')");
            migrationBuilder
                .Sql("INSERT INTO Types (Name) Values ('Urlop tacierzyński')");
            migrationBuilder
                .Sql("INSERT INTO Types (Name) Values ('Urlop ojcowski')");
            migrationBuilder
                .Sql("INSERT INTO Types (Name) Values ('Urlop rodzicielski')");
            migrationBuilder
                .Sql("INSERT INTO Types (Name) Values ('Urlop wychowawczy')");
            migrationBuilder
                .Sql("INSERT INTO Types (Name) Values ('Urlop na żądanie')");
            migrationBuilder
                .Sql("INSERT INTO Types (Name) Values ('Urlop okolicznościowy')");

            migrationBuilder
                .Sql("INSERT INTO Requests (StartDate, EndDate, Reason, Requested, LastChange, TypeId, StatusId) Values ((SELECT getdate()), (SELECT dateadd(dd,5,getdate())), 'Test1', (SELECT getdate()), (SELECT getdate()), (SELECT Id From Types Where Name = 'Urlop bezpłatny'), (SELECT Id FROM Statuses WHERE Name = 'Zgłoszony'))");

            migrationBuilder
                .Sql("INSERT INTO Requests (StartDate, EndDate, Reason, Requested, LastChange, TypeId, StatusId) Values ((SELECT Getdate()), (SELECT dateadd(dd,10,getdate())), 'Test2', (SELECT Getdate()), (SELECT Getdate()), (SELECT id FROM Types WHERE Name = 'Urlop na żądanie'), (SELECT id FROM Statuses WHERE Name = 'Zaakceptowany'))");

            migrationBuilder
                .Sql("INSERT INTO Requests (StartDate, EndDate, Reason, Requested, LastChange, TypeId, StatusId) Values ((SELECT Getdate()), (SELECT dateadd(dd,15,getdate())), 'Test3', (SELECT Getdate()), (SELECT Getdate()), (SELECT id FROM Types WHERE Name = 'Urlop wypoczynkowy'), (SELECT id FROM Statuses WHERE Name = 'Odrzucony'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM Requests");

            migrationBuilder
                .Sql("DELETE FROM Types");

            migrationBuilder
                .Sql("DELETE FROM Statuses");
        }
    }
}
