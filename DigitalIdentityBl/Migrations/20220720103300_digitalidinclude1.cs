using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalIdentity.Data.Migrations
{
    public partial class digitalidinclude1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Vouchees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Vouchees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VoucherId",
                table: "Vouchees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VoucherRefId",
                table: "Vouchees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "gender",
                table: "Vouchees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vouchees_VoucherId",
                table: "Vouchees",
                column: "VoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchees_Vouchers_VoucherId",
                table: "Vouchees",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vouchees_Vouchers_VoucherId",
                table: "Vouchees");

            migrationBuilder.DropIndex(
                name: "IX_Vouchees_VoucherId",
                table: "Vouchees");

            migrationBuilder.DropColumn(
                name: "VoucherId",
                table: "Vouchees");

            migrationBuilder.DropColumn(
                name: "VoucherRefId",
                table: "Vouchees");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "Vouchees");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Vouchees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Vouchees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
