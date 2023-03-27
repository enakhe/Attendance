using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendance.Migrations
{
    public partial class SignInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "SignIn",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SignIn_StudentId",
                table: "SignIn",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SignIn_AspNetUsers_StudentId",
                table: "SignIn",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SignIn_AspNetUsers_StudentId",
                table: "SignIn");

            migrationBuilder.DropIndex(
                name: "IX_SignIn_StudentId",
                table: "SignIn");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "SignIn");
        }
    }
}
