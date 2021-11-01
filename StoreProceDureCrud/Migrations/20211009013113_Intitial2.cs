using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreProceDureCrud.Migrations
{
    public partial class Intitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Profiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_GenderId",
                table: "Profiles",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Genders_GenderId",
                table: "Profiles",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Genders_GenderId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_GenderId",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "GenderId",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
