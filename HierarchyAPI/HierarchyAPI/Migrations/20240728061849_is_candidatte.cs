using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HierarchyAPI.Migrations
{
    /// <inheritdoc />
    public partial class iscandidatte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Table_Role_Table_ParentId",
                table: "Role_Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role_Table",
                table: "Role_Table");

            migrationBuilder.RenameTable(
                name: "Role_Table",
                newName: "role_table");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "role_table",
                newName: "parent_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "role_table",
                newName: "role_name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "role_table",
                newName: "role_description");

            migrationBuilder.RenameIndex(
                name: "IX_Role_Table_ParentId",
                table: "role_table",
                newName: "IX_role_table_parent_id");

            migrationBuilder.AlterColumn<string>(
                name: "role_name",
                table: "role_table",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "role_description",
                table: "role_table",
                type: "text",
                nullable: true,
                defaultValue: "Description is not set... ",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_candidate",
                table: "role_table",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_role_table",
                table: "role_table",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_role_table_role_table_parent_id",
                table: "role_table",
                column: "parent_id",
                principalTable: "role_table",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_role_table_role_table_parent_id",
                table: "role_table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_role_table",
                table: "role_table");

            migrationBuilder.DropColumn(
                name: "is_candidate",
                table: "role_table");

            migrationBuilder.RenameTable(
                name: "role_table",
                newName: "Role_Table");

            migrationBuilder.RenameColumn(
                name: "role_name",
                table: "Role_Table",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "role_description",
                table: "Role_Table",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "parent_id",
                table: "Role_Table",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_role_table_parent_id",
                table: "Role_Table",
                newName: "IX_Role_Table_ParentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Role_Table",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Role_Table",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "Description is not set... ");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role_Table",
                table: "Role_Table",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Table_Role_Table_ParentId",
                table: "Role_Table",
                column: "ParentId",
                principalTable: "Role_Table",
                principalColumn: "Id");
        }
    }
}
