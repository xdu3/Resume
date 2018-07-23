using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Xin.Data.Migrations
{
    public partial class desDtlToDesFKIDSetUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesDetails_Description_DescriptionId",
                table: "DesDetails");

            migrationBuilder.AlterColumn<int>(
                name: "DescriptionId",
                table: "DesDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DesDetails_Description_DescriptionId",
                table: "DesDetails",
                column: "DescriptionId",
                principalTable: "Description",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesDetails_Description_DescriptionId",
                table: "DesDetails");

            migrationBuilder.AlterColumn<int>(
                name: "DescriptionId",
                table: "DesDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DesDetails_Description_DescriptionId",
                table: "DesDetails",
                column: "DescriptionId",
                principalTable: "Description",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
