using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace budget_back.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersAndManagerToFamilyAndBuilding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Families",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Buildings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BuildingUsers",
                columns: table => new
                {
                    BuildingsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingUsers", x => new { x.BuildingsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_BuildingUsers_Buildings_BuildingsId",
                        column: x => x.BuildingsId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyUsers",
                columns: table => new
                {
                    FamiliesId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyUsers", x => new { x.FamiliesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_FamilyUsers_Families_FamiliesId",
                        column: x => x.FamiliesId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Families_ManagerId",
                table: "Families",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_ManagerId",
                table: "Buildings",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingUsers_UsersId",
                table: "BuildingUsers",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyUsers_UsersId",
                table: "FamilyUsers",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Users_ManagerId",
                table: "Buildings",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Families_Users_ManagerId",
                table: "Families",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Users_ManagerId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Families_Users_ManagerId",
                table: "Families");

            migrationBuilder.DropTable(
                name: "BuildingUsers");

            migrationBuilder.DropTable(
                name: "FamilyUsers");

            migrationBuilder.DropIndex(
                name: "IX_Families_ManagerId",
                table: "Families");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_ManagerId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Buildings");
        }
    }
}
