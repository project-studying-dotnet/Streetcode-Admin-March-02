using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Streetcode.DAL.Persistence.Migrations
{
    public partial class AddColumnOrderNumberInFactsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_facts_StreetcodeId",
                schema: "streetcode",
                table: "facts");

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                schema: "streetcode",
                table: "facts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_facts_StreetcodeId_OrderNumber",
                schema: "streetcode",
                table: "facts",
                columns: new[] { "StreetcodeId", "OrderNumber" },
                unique: true,
                filter: "[OrderNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_facts_StreetcodeId_OrderNumber",
                schema: "streetcode",
                table: "facts");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                schema: "streetcode",
                table: "facts");

            migrationBuilder.CreateIndex(
                name: "IX_facts_StreetcodeId",
                schema: "streetcode",
                table: "facts",
                column: "StreetcodeId");
        }
    }
}
