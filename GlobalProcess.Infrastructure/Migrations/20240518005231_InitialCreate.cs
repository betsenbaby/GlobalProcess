using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalProcess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynamicForms",
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
                    table.PrimaryKey("PK_DynamicForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workflows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessProcessId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflows_BusinessProcesses_BusinessProcessId",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DynamicFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Options = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    DynamicFormId = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicFields_DynamicForms_DynamicFormId",
                        column: x => x.DynamicFormId,
                        principalTable: "DynamicForms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkflowId = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_DynamicForms_FormId",
                        column: x => x.FormId,
                        principalTable: "DynamicForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                    onUpdate: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Steps_Workflows_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                    onUpdate: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ActionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    ParentActionItemId = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionItems_ActionItems_ParentActionItemId",
                        column: x => x.ParentActionItemId,
                        principalTable: "ActionItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActionItems_ApplicationUser_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionItems_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessProcessInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkflowId = table.Column<int>(type: "int", nullable: false),
                    CurrentStepId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcessInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProcessInstances_Steps_CurrentStepId",
                        column: x => x.CurrentStepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessProcessInstances_Workflows_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    IsEditable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldPermissions_DynamicFields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "DynamicFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldPermissions_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroupPermissions_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessProcessInstanceId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldValues_BusinessProcessInstances_BusinessProcessInstanceId",
                        column: x => x.BusinessProcessInstanceId,
                        principalTable: "BusinessProcessInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldValues_DynamicFields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "DynamicFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldValues_DynamicForms_FormId",
                        column: x => x.FormId,
                        principalTable: "DynamicForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusinessProcessInstanceId = table.Column<int>(type: "int", nullable: true),
                    StepId = table.Column<int>(type: "int", nullable: true),
                    ActionItemId = table.Column<int>(type: "int", nullable: true),
                    BusinessProcessId = table.Column<int>(type: "int", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    DynamicFieldId = table.Column<int>(type: "int", nullable: true),
                    DynamicFormId = table.Column<int>(type: "int", nullable: true),
                    FieldPermissionsId = table.Column<int>(type: "int", nullable: true),
                    FieldValueId = table.Column<int>(type: "int", nullable: true),
                    UserGroupPermissionId = table.Column<int>(type: "int", nullable: true),
                    WorkflowId = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_ActionItems_ActionItemId",
                        column: x => x.ActionItemId,
                        principalTable: "ActionItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_BusinessProcessInstances_BusinessProcessInstanceId",
                        column: x => x.BusinessProcessInstanceId,
                        principalTable: "BusinessProcessInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_BusinessProcesses_BusinessProcessId",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_DynamicFields_DynamicFieldId",
                        column: x => x.DynamicFieldId,
                        principalTable: "DynamicFields",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_DynamicForms_DynamicFormId",
                        column: x => x.DynamicFormId,
                        principalTable: "DynamicForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_FieldPermissions_FieldPermissionsId",
                        column: x => x.FieldPermissionsId,
                        principalTable: "FieldPermissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_FieldValues_FieldValueId",
                        column: x => x.FieldValueId,
                        principalTable: "FieldValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_UserGroupPermissions_UserGroupPermissionId",
                        column: x => x.UserGroupPermissionId,
                        principalTable: "UserGroupPermissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Workflows_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionItems_AssignedUserId",
                table: "ActionItems",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionItems_ParentActionItemId",
                table: "ActionItems",
                column: "ParentActionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionItems_StepId",
                table: "ActionItems",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessInstances_CurrentStepId",
                table: "BusinessProcessInstances",
                column: "CurrentStepId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessInstances_WorkflowId",
                table: "BusinessProcessInstances",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ActionItemId",
                table: "Comments",
                column: "ActionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BusinessProcessId",
                table: "Comments",
                column: "BusinessProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BusinessProcessInstanceId",
                table: "Comments",
                column: "BusinessProcessInstanceId");

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
                name: "IX_Comments_StepId",
                table: "Comments",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserGroupPermissionId",
                table: "Comments",
                column: "UserGroupPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_WorkflowId",
                table: "Comments",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicFields_DynamicFormId",
                table: "DynamicFields",
                column: "DynamicFormId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldPermissions_FieldId",
                table: "FieldPermissions",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldPermissions_StepId",
                table: "FieldPermissions",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValues_BusinessProcessInstanceId",
                table: "FieldValues",
                column: "BusinessProcessInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValues_FieldId",
                table: "FieldValues",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValues_FormId",
                table: "FieldValues",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_FormId",
                table: "Steps",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_WorkflowId",
                table: "Steps",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupPermissions_StepId",
                table: "UserGroupPermissions",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflows_BusinessProcessId",
                table: "Workflows",
                column: "BusinessProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ActionItems");

            migrationBuilder.DropTable(
                name: "FieldPermissions");

            migrationBuilder.DropTable(
                name: "FieldValues");

            migrationBuilder.DropTable(
                name: "UserGroupPermissions");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "BusinessProcessInstances");

            migrationBuilder.DropTable(
                name: "DynamicFields");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "DynamicForms");

            migrationBuilder.DropTable(
                name: "Workflows");

            migrationBuilder.DropTable(
                name: "BusinessProcesses");
        }
    }
}
