using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawyerProject.Migrations
{
    public partial class EnemyAndClientTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Enemies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnemyLawyer",
                table: "Enemies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "National",
                table: "Enemies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Enemies",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalNo",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFinished",
                table: "AdministrativeWorks",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "EnemyLawyer",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "National",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "NationalNo",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFinished",
                table: "AdministrativeWorks",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
