using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace budget_back.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedFamilyBuildingAccountFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryCreationType",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Travels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BankAccountId",
                table: "Expences",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BankName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    InitialBalance = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Travels_ManagerId",
                table: "Travels",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expences_BankAccountId",
                table: "Expences",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expences_BankAccounts_BankAccountId",
                table: "Expences",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Users_ManagerId",
                table: "Travels",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expences_BankAccounts_BankAccountId",
                table: "Expences");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Users_ManagerId",
                table: "Travels");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Travels_ManagerId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Expences_BankAccountId",
                table: "Expences");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "Expences");

            migrationBuilder.AddColumn<string>(
                name: "CategoryCreationType",
                table: "Categories",
                type: "TEXT",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }
    }
}
