using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Xin.Data.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_AspNetUsers_UserId",
                table: "WorkExperience");

            migrationBuilder.DropTable(
                name: "WorkExperienceDetail");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WorkExperience",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_AspNetUsers_UserId",
                table: "WorkExperience",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_AspNetUsers_UserId",
                table: "WorkExperience");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WorkExperience",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "WorkExperienceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    WEDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperienceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperienceDetail_WorkExperience_Id",
                        column: x => x.Id,
                        principalTable: "WorkExperience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_AspNetUsers_UserId",
                table: "WorkExperience",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
