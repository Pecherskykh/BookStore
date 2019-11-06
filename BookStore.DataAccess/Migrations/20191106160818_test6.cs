using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DataAccess.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PrintingEditions");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "PrintingEditions",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "PrintingEditions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PrintingEditions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
