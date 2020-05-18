using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataLayer.Migrations
{
    public partial class LogRecordTypeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogRecordTypes",
                columns: table => new
                {
                    LogRecordTypeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogRecordTypes", x => x.LogRecordTypeId);
                });

            migrationBuilder.InsertData(
                table: "LogRecordTypes",
                columns: new[] { "LogRecordTypeId", "Name", "Number" },
                values: new object[,]
                {
                    { 1, "Unknown", 1 },
                    { 2, "Debug", 2 },
                    { 3, "Info", 3 },
                    { 4, "Warning", 4 },
                    { 5, "Error", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogRecordTypes");
        }
    }
}
