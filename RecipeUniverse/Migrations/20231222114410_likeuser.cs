using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeUniverse.Migrations
{
    /// <inheritdoc />
    public partial class likeuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLikes_Recipes_RecipeId",
                table: "RecipeLikes");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeLikes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RecipeLikes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLikes_UserId",
                table: "RecipeLikes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLikes_AspNetUsers_UserId",
                table: "RecipeLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLikes_Recipes_RecipeId",
                table: "RecipeLikes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLikes_AspNetUsers_UserId",
                table: "RecipeLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLikes_Recipes_RecipeId",
                table: "RecipeLikes");

            migrationBuilder.DropIndex(
                name: "IX_RecipeLikes_UserId",
                table: "RecipeLikes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RecipeLikes");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeLikes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLikes_Recipes_RecipeId",
                table: "RecipeLikes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
