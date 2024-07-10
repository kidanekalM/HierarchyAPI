using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HierarchyAPI.Migrations
{
    /// <inheritdoc />
    public partial class configAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_roles_ParentId",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Role_Table");

            migrationBuilder.RenameIndex(
                name: "IX_roles_ParentId",
                table: "Role_Table",
                newName: "IX_Role_Table_ParentId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Table_Role_Table_ParentId",
                table: "Role_Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role_Table",
                table: "Role_Table");

            migrationBuilder.RenameTable(
                name: "Role_Table",
                newName: "roles");

            migrationBuilder.RenameIndex(
                name: "IX_Role_Table_ParentId",
                table: "roles",
                newName: "IX_roles_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_roles_roles_ParentId",
                table: "roles",
                column: "ParentId",
                principalTable: "roles",
                principalColumn: "Id");
        }
    }
}
