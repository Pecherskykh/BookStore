using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DataAccess.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Currency",
                table: "PrintingEditions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Currency",
                table: "OrderItems",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PrintingEditionId",
                table: "AuthorInPrintingEditions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "AuthorId",
                table: "AuthorInPrintingEditions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorInPrintingEditions_AuthorId",
                table: "AuthorInPrintingEditions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorInPrintingEditions_PrintingEditionId",
                table: "AuthorInPrintingEditions",
                column: "PrintingEditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorInPrintingEditions_Authors_AuthorId",
                table: "AuthorInPrintingEditions",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorInPrintingEditions_PrintingEditions_PrintingEditionId",
                table: "AuthorInPrintingEditions",
                column: "PrintingEditionId",
                principalTable: "PrintingEditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorInPrintingEditions_Authors_AuthorId",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorInPrintingEditions_PrintingEditions_PrintingEditionId",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInPrintingEditions_AuthorId",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInPrintingEditions_PrintingEditionId",
                table: "AuthorInPrintingEditions");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "PrintingEditions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PrintingEditionId",
                table: "AuthorInPrintingEditions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "AuthorInPrintingEditions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "AuthorId1",
                table: "AuthorInPrintingEditions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PrintingEditionId1",
                table: "AuthorInPrintingEditions",
                type: "bigint",
                nullable: true);

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
    }
}
