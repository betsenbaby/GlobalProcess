using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalProcess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustUserGroupPermissionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DynamicFields_DynamicForms_DynamicFormId",
                table: "DynamicFields");

            migrationBuilder.DropIndex(
                name: "IX_DynamicFields_DynamicFormId",
                table: "DynamicFields");

            migrationBuilder.DropColumn(
                name: "DynamicFormId",
                table: "DynamicFields");

            migrationBuilder.AddColumn<bool>(
                name: "CanEdit",
                table: "UserGroupPermissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanView",
                table: "UserGroupPermissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserGroupId",
                table: "UserGroupPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "DynamicFields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserGroupId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupPermissions_UserGroupId",
                table: "UserGroupPermissions",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicFields_FormId",
                table: "DynamicFields",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserGroupId",
                table: "Comments",
                column: "UserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserGroups_UserGroupId",
                table: "Comments",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicFields_DynamicForms_FormId",
                table: "DynamicFields",
                column: "FormId",
                principalTable: "DynamicForms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroupPermissions_UserGroups_UserGroupId",
                table: "UserGroupPermissions",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserGroups_UserGroupId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_DynamicFields_DynamicForms_FormId",
                table: "DynamicFields");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroupPermissions_UserGroups_UserGroupId",
                table: "UserGroupPermissions");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserGroupPermissions_UserGroupId",
                table: "UserGroupPermissions");

            migrationBuilder.DropIndex(
                name: "IX_DynamicFields_FormId",
                table: "DynamicFields");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserGroupId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CanEdit",
                table: "UserGroupPermissions");

            migrationBuilder.DropColumn(
                name: "CanView",
                table: "UserGroupPermissions");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "UserGroupPermissions");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "DynamicFields");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "DynamicFormId",
                table: "DynamicFields",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DynamicFields_DynamicFormId",
                table: "DynamicFields",
                column: "DynamicFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicFields_DynamicForms_DynamicFormId",
                table: "DynamicFields",
                column: "DynamicFormId",
                principalTable: "DynamicForms",
                principalColumn: "Id");
        }
    }
}
