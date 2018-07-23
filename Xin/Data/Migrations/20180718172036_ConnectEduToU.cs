using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Xin.Data.Migrations
{
    public partial class ConnectEduToU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eduction_AspNetUsers_UserId",
                table: "Eduction");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Eduction",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Eduction_AspNetUsers_UserId",
                table: "Eduction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eduction_AspNetUsers_UserId",
                table: "Eduction");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Eduction",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Eduction_AspNetUsers_UserId",
                table: "Eduction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
