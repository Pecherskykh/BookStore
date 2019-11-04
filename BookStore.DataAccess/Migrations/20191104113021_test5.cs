using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DataAccess.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorInPrintingEditions_Authors_AuthorId1",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorInPrintingEditions_PrintingEditions_PrintingEditionId1",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId1",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_PrintingEditions_PrintingEditionId1",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId1",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_PrintingEditionId1",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInPrintingEditions_AuthorId1",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInPrintingEditions_PrintingEditionId1",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "PrintingEditionId1",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropColumn(
                name: "PrintingEditionId1",
                table: "AuthorInPrintingEditions");

            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "PrintingEditions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "TransactionId",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "PaymentId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "PrintingEditionId",
                table: "OrderItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "OrderItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Count",
                table: "OrderItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Amount",
                table: "OrderItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PrintingEditionId",
                table: "OrderItems",
                column: "PrintingEditionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_PrintingEditions_PrintingEditionId",
                table: "OrderItems",
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

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_PrintingEditions_PrintingEditionId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_PrintingEditionId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInPrintingEditions_AuthorId",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInPrintingEditions_PrintingEditionId",
                table: "AuthorInPrintingEditions");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "PrintingEditions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "PrintingEditionId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "OrderItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "OrderItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "OrderId1",
                table: "OrderItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PrintingEditionId1",
                table: "OrderItems",
                type: "bigint",
                nullable: true);

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
                name: "IX_OrderItems_OrderId1",
                table: "OrderItems",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PrintingEditionId1",
                table: "OrderItems",
                column: "PrintingEditionId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId1",
                table: "OrderItems",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_PrintingEditions_PrintingEditionId1",
                table: "OrderItems",
                column: "PrintingEditionId1",
                principalTable: "PrintingEditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
