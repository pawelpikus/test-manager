using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestManager.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FwVersion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RackName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    KickOffTimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedTimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.ID);
                });
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
