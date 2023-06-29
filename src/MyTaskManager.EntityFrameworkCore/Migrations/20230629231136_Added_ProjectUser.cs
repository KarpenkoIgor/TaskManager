using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTaskManager.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTasks_AbpUsers_AssingnedUserId",
                table: "AppTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_AppTasks_AppProjects_ProjectId",
                table: "AppTasks");

            migrationBuilder.DropIndex(
                name: "IX_AppTasks_AssingnedUserId",
                table: "AppTasks");

            migrationBuilder.DropIndex(
                name: "IX_AppTasks_ProjectId",
                table: "AppTasks");

            migrationBuilder.DropColumn(
                name: "AssingnedUserId",
                table: "AppTasks");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "AppTasks",
                newName: "ProjectUserId");

            migrationBuilder.CreateTable(
                name: "AppProjectUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    ExtraProperties = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProjectUsers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppProjectUsers");

            migrationBuilder.RenameColumn(
                name: "ProjectUserId",
                table: "AppTasks",
                newName: "ProjectId");

            migrationBuilder.AddColumn<Guid>(
                name: "AssingnedUserId",
                table: "AppTasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppTasks_AssingnedUserId",
                table: "AppTasks",
                column: "AssingnedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTasks_ProjectId",
                table: "AppTasks",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTasks_AbpUsers_AssingnedUserId",
                table: "AppTasks",
                column: "AssingnedUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppTasks_AppProjects_ProjectId",
                table: "AppTasks",
                column: "ProjectId",
                principalTable: "AppProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
