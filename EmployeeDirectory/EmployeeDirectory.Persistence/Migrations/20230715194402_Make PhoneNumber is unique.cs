using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDirectory.Persistence.Migrations
{
    public partial class MakePhoneNumberisunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_PhoneNumber",
                table: "Employees",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_PhoneNumber",
                table: "Employees");
        }
    }
}
