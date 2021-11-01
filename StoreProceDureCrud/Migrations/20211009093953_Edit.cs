using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreProceDureCrud.Migrations
{
    public partial class Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FavouriteHobbies_HobbyId",
                table: "FavouriteHobbies",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteHobbies_ProfileId",
                table: "FavouriteHobbies",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteHobbies_Hobbies_HobbyId",
                table: "FavouriteHobbies",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteHobbies_Profiles_ProfileId",
                table: "FavouriteHobbies",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteHobbies_Hobbies_HobbyId",
                table: "FavouriteHobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteHobbies_Profiles_ProfileId",
                table: "FavouriteHobbies");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteHobbies_HobbyId",
                table: "FavouriteHobbies");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteHobbies_ProfileId",
                table: "FavouriteHobbies");
        }
    }
}
