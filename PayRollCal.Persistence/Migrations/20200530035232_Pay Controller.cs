using Microsoft.EntityFrameworkCore.Migrations;

namespace PayRollCal.Persistence.Migrations
{
    public partial class PayController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "PaymentRecords",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "PaymentRecords");
        }
    }
}
