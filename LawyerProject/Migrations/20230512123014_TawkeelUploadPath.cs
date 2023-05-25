using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawyerProject.Migrations
{
    public partial class TawkeelUploadPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Enemies_EnemyId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_EnemyId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "EnemyId",
                table: "Cases");

            migrationBuilder.AddColumn<string>(
                name: "TawkeelPath",
                table: "Tawkeels",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TawkeelPath",
                table: "Tawkeels");

            migrationBuilder.AddColumn<int>(
                name: "EnemyId",
                table: "Cases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_EnemyId",
                table: "Cases",
                column: "EnemyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Enemies_EnemyId",
                table: "Cases",
                column: "EnemyId",
                principalTable: "Enemies",
                principalColumn: "Id");
        }
    }
}
