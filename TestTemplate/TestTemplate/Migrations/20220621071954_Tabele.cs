using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTemplate.Migrations
{
    public partial class Tabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organisation",
                columns: table => new
                {
                    OrganisationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrganisationDomain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation", x => x.OrganisationID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationID = table.Column<int>(type: "int", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MemberNickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Member_Organisation_OrganisationID",
                        column: x => x.OrganisationID,
                        principalTable: "Organisation",
                        principalColumn: "OrganisationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationID = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Team_Organisation_OrganisationID",
                        column: x => x.OrganisationID,
                        principalTable: "Organisation",
                        principalColumn: "OrganisationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    FileID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileExtention = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_File_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: true),
                    MembershipDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Membership_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Membership_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_OrganisationID",
                table: "Member",
                column: "OrganisationID");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_MemberID",
                table: "Membership",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_OrganisationID",
                table: "Team",
                column: "OrganisationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Organisation");
        }
    }
}
