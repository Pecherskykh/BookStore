using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DataAccess.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorInPrintingEditions_Authors_AuthorId",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInPrintingEditions_AuthorId",
                table: "AuthorInPrintingEditions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AuthorInPrintingEditions_AuthorId",
                table: "AuthorInPrintingEditions",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorInPrintingEditions_Authors_AuthorId",
                table: "AuthorInPrintingEditions",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
