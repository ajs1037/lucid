using Microsoft.EntityFrameworkCore.Migrations;

namespace lucid.Migrations
{
    public partial class updaterelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Team_TeamId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Team_TeamId",
                table: "Employee",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Team_TeamId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Team_TeamId",
                table: "Employee",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
