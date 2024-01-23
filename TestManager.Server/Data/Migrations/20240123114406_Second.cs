using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestManager.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
            name: "KickOffTimeStamp",
            table: "Tests",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedTimeStamp",
            table: "Tests",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
