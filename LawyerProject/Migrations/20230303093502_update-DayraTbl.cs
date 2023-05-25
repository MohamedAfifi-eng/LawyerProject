using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawyerProject.Migrations
{
    public partial class updateDayraTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressOfGadwal",
                table: "Dayras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressOfJudgment",
                table: "Dayras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressOfSecertary",
                table: "Dayras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfSecertary",
                table: "Dayras",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressOfGadwal",
                table: "Dayras");

            migrationBuilder.DropColumn(
                name: "AddressOfJudgment",
                table: "Dayras");

            migrationBuilder.DropColumn(
                name: "AddressOfSecertary",
                table: "Dayras");

            migrationBuilder.DropColumn(
                name: "NameOfSecertary",
                table: "Dayras");
        }
    }
}
