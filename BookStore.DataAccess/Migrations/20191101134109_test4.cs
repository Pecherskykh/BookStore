using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DataAccess.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "PrintingEditions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrintingEditionId",
                table: "AuthorInPrintingEditions",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "AuthorInPrintingEditions",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "AuthorId1",
                table: "AuthorInPrintingEditions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PrintingEditionId1",
                table: "AuthorInPrintingEditions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorInPrintingEditions_AuthorId1",
                table: "AuthorInPrintingEditions",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorInPrintingEditions_PrintingEditionId1",
                table: "AuthorInPrintingEditions",
                column: "PrintingEditionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorInPrintingEditions_Authors_AuthorId1",
                table: "AuthorInPrintingEditions",
                column: "AuthorId1",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorInPrintingEditions_PrintingEditions_PrintingEditionId1",
                table: "AuthorInPrintingEditions",
                column: "PrintingEditionId1",
                principalTable: "PrintingEditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorInPrintingEditions_Authors_AuthorId1",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorInPrintingEditions_PrintingEditions_PrintingEditionId1",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInPrintingEditions_AuthorId1",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInPrintingEditions_PrintingEditionId1",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropColumn(
                name: "PrintingEditionId1",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "PrintingEditions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "PrintingEditionId",
                table: "AuthorInPrintingEditions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "AuthorId",
                table: "AuthorInPrintingEditions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
