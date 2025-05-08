using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Infrast.Migrations
{
    /// <inheritdoc />
    public partial class service : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MigrationServiceId",
                table: "ConsultationRequests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MigrationServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MigrationServices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRequests_MigrationServiceId",
                table: "ConsultationRequests",
                column: "MigrationServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultationRequests_MigrationServices_MigrationServiceId",
                table: "ConsultationRequests",
                column: "MigrationServiceId",
                principalTable: "MigrationServices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultationRequests_MigrationServices_MigrationServiceId",
                table: "ConsultationRequests");

            migrationBuilder.DropTable(
                name: "MigrationServices");

            migrationBuilder.DropIndex(
                name: "IX_ConsultationRequests_MigrationServiceId",
                table: "ConsultationRequests");

            migrationBuilder.DropColumn(
                name: "MigrationServiceId",
                table: "ConsultationRequests");
        }
    }
}
