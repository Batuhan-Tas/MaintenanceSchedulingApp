using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MaintenanceSchedulingApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    LastMaintenanceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MaintenanceFrequency = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetsId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceTask",
                columns: table => new
                {
                    MaintenanceTaskId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssetId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AssetsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceTask", x => x.MaintenanceTaskId);
                    table.ForeignKey(
                        name: "FK_MaintenanceTask_Assets_AssetsId",
                        column: x => x.AssetsId,
                        principalTable: "Assets",
                        principalColumn: "AssetsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceHistory",
                columns: table => new
                {
                    MaintenanceHistoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TechnicianName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceHistory", x => x.MaintenanceHistoryId);
                    table.ForeignKey(
                        name: "FK_MaintenanceHistory_MaintenanceTask_TaskId",
                        column: x => x.TaskId,
                        principalTable: "MaintenanceTask",
                        principalColumn: "MaintenanceTaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceHistory_TaskId",
                table: "MaintenanceHistory",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceTask_AssetsId",
                table: "MaintenanceTask",
                column: "AssetsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceHistory");

            migrationBuilder.DropTable(
                name: "MaintenanceTask");

            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
