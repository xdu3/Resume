using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Xin.Data.Migrations
{
    public partial class ConnectPTU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                table: "Profile");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Profile",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                table: "Profile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                table: "Profile");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Profile",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                table: "Profile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
