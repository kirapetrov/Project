using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ForeignKeyFromDeviceLogToLogReordsType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LogRecordTypeId",
                table: "DeviceLogs",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceLogs_LogRecordTypeId",
                table: "DeviceLogs",
                column: "LogRecordTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceLogs_LogRecordTypes_LogRecordTypeId",
                table: "DeviceLogs",
                column: "LogRecordTypeId",
                principalTable: "LogRecordTypes",
                principalColumn: "LogRecordTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceLogs_LogRecordTypes_LogRecordTypeId",
                table: "DeviceLogs");

            migrationBuilder.DropIndex(
                name: "IX_DeviceLogs_LogRecordTypeId",
                table: "DeviceLogs");

            migrationBuilder.DropColumn(
                name: "LogRecordTypeId",
                table: "DeviceLogs");
        }
    }
}
