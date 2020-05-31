using Microsoft.EntityFrameworkCore.Migrations;

namespace PayRollCal.Persistence.Migrations
{
    public partial class PayController2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRecords_EmployeeDetails_EmployeeDetailsId",
                table: "PaymentRecords");

            migrationBuilder.DropIndex(
                name: "IX_PaymentRecords_EmployeeDetailsId",
                table: "PaymentRecords");

            migrationBuilder.DropColumn(
                name: "EmployeeDetailsId",
                table: "PaymentRecords");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecords_EmployeeId",
                table: "PaymentRecords",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRecords_EmployeeDetails_EmployeeId",
                table: "PaymentRecords",
                column: "EmployeeId",
                principalTable: "EmployeeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRecords_EmployeeDetails_EmployeeId",
                table: "PaymentRecords");

            migrationBuilder.DropIndex(
                name: "IX_PaymentRecords_EmployeeId",
                table: "PaymentRecords");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeDetailsId",
                table: "PaymentRecords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecords_EmployeeDetailsId",
                table: "PaymentRecords",
                column: "EmployeeDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRecords_EmployeeDetails_EmployeeDetailsId",
                table: "PaymentRecords",
                column: "EmployeeDetailsId",
                principalTable: "EmployeeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
