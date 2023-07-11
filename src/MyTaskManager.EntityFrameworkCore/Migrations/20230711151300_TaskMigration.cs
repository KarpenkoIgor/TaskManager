using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTaskManager.Migrations
{
    /// <inheritdoc />
    public partial class TaskMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppComments_AppTasks_TaskId",
                table: "AppComments");

            migrationBuilder.DropTable(
                name: "AppTasks");

            migrationBuilder.DropIndex(
                name: "IX_AppComments_TaskId",
                table: "AppComments");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectTaskId",
                table: "AppComments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppProjectTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ProjectUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProjectTasks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppComments_ProjectTaskId",
                table: "AppComments",
                column: "ProjectTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppComments_AppProjectTasks_ProjectTaskId",
                table: "AppComments",
                column: "ProjectTaskId",
                principalTable: "AppProjectTasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppComments_AppProjectTasks_ProjectTaskId",
                table: "AppComments");

            migrationBuilder.DropTable(
                name: "AppProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_AppComments_ProjectTaskId",
                table: "AppComments");

            migrationBuilder.DropColumn(
                name: "ProjectTaskId",
                table: "AppComments");

            migrationBuilder.CreateTable(
                name: "AppTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeadLine = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ProjectUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTasks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppComments_TaskId",
                table: "AppComments",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppComments_AppTasks_TaskId",
                table: "AppComments",
                column: "TaskId",
                principalTable: "AppTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
