using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogManagement_Core.Migrations
{
    /// <inheritdoc />
    public partial class removePass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 5, 22, 50, 919, DateTimeKind.Local).AddTicks(8235),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 21, 5, 18, 21, 501, DateTimeKind.Local).AddTicks(4266));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 5, 22, 50, 922, DateTimeKind.Local).AddTicks(4183),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 21, 5, 18, 21, 502, DateTimeKind.Local).AddTicks(7305));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 5, 18, 21, 501, DateTimeKind.Local).AddTicks(4266),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 21, 5, 22, 50, 919, DateTimeKind.Local).AddTicks(8235));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 5, 18, 21, 502, DateTimeKind.Local).AddTicks(7305),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 21, 5, 22, 50, 922, DateTimeKind.Local).AddTicks(4183));
        }
    }
}
