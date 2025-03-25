using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlowSpace.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupsTabs");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TabId",
                table: "Tasks",
                column: "TabId");

            migrationBuilder.CreateIndex(
                name: "IX_Tabs_GroupId",
                table: "Tabs",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabs_Groups_GroupId",
                table: "Tabs",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tabs_TabId",
                table: "Tasks",
                column: "TabId",
                principalTable: "Tabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabs_Groups_GroupId",
                table: "Tabs");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tabs_TabId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TabId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tabs_GroupId",
                table: "Tabs");

            migrationBuilder.CreateTable(
                name: "GroupsTabs",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    TabsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsTabs", x => new { x.GroupsId, x.TabsId });
                    table.ForeignKey(
                        name: "FK_GroupsTabs_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsTabs_Tabs_TabsId",
                        column: x => x.TabsId,
                        principalTable: "Tabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupsTabs_TabsId",
                table: "GroupsTabs",
                column: "TabsId");
        }
    }
}
