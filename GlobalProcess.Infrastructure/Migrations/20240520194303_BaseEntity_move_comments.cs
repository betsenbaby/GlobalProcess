using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalProcess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BaseEntity_move_comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_DynamicFields_DynamicFieldId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_DynamicForms_DynamicFormId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_FieldPermissions_FieldPermissionsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_FieldValues_FieldValueId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserGroupPermissions_UserGroupPermissionId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserGroups_UserGroupId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_DynamicFieldId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_DynamicFormId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_FieldPermissionsId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_FieldValueId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserGroupId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserGroupPermissionId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DynamicFieldId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DynamicFormId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "FieldPermissionsId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "FieldValueId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserGroupPermissionId",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DynamicFieldId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DynamicFormId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FieldPermissionsId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FieldValueId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserGroupId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserGroupPermissionId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DynamicFieldId",
                table: "Comments",
                column: "DynamicFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DynamicFormId",
                table: "Comments",
                column: "DynamicFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FieldPermissionsId",
                table: "Comments",
                column: "FieldPermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FieldValueId",
                table: "Comments",
                column: "FieldValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserGroupId",
                table: "Comments",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserGroupPermissionId",
                table: "Comments",
                column: "UserGroupPermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_DynamicFields_DynamicFieldId",
                table: "Comments",
                column: "DynamicFieldId",
                principalTable: "DynamicFields",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_DynamicForms_DynamicFormId",
                table: "Comments",
                column: "DynamicFormId",
                principalTable: "DynamicForms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_FieldPermissions_FieldPermissionsId",
                table: "Comments",
                column: "FieldPermissionsId",
                principalTable: "FieldPermissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_FieldValues_FieldValueId",
                table: "Comments",
                column: "FieldValueId",
                principalTable: "FieldValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserGroupPermissions_UserGroupPermissionId",
                table: "Comments",
                column: "UserGroupPermissionId",
                principalTable: "UserGroupPermissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserGroups_UserGroupId",
                table: "Comments",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");
        }
    }
}
