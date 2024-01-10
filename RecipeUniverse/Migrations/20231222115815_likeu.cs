using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeUniverse.Migrations
{
    /// <inheritdoc />
    public partial class likeu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLikes_AspNetUsers_UserId",
                table: "RecipeLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLikes_Recipes_RecipeId",
                table: "RecipeLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeLikes",
                table: "RecipeLikes");

            migrationBuilder.RenameTable(
                name: "RecipeLikes",
                newName: "Likes");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeLikes_UserId",
                table: "Likes",
                newName: "IX_Likes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeLikes_RecipeId",
                table: "Likes",
                newName: "IX_Likes_RecipeId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Likes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Recipes_RecipeId",
                table: "Likes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Recipes_RecipeId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "RecipeLikes");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserId",
                table: "RecipeLikes",
                newName: "IX_RecipeLikes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_RecipeId",
                table: "RecipeLikes",
                newName: "IX_RecipeLikes_RecipeId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RecipeLikes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeLikes",
                table: "RecipeLikes",
                column: "Id");

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
    }
}
