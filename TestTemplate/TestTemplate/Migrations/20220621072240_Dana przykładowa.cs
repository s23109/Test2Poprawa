using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTemplate.Migrations
{
    public partial class Danaprzykładowa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organisation",
                columns: new[] { "OrganisationID", "OrganisationDomain", "OrganisationName" },
                values: new object[] { 1, "Mogus", "Sus" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organisation",
                keyColumn: "OrganisationID",
                keyValue: 1);
        }
    }
}
