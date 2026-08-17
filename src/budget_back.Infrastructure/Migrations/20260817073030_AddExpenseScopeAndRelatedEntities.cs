using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace budget_back.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExpenseScopeAndRelatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryCreationType",
                table: "Categories",
                type: "TEXT",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseScopeId",
                table: "Categories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExpenseScopes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true),
                    ExpenseScopeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_ExpenseScopes_ExpenseScopeId",
                        column: x => x.ExpenseScopeId,
                        principalTable: "ExpenseScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExpenseScopeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expences_ExpenseScopes_ExpenseScopeId",
                        column: x => x.ExpenseScopeId,
                        principalTable: "ExpenseScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    ExpenseScopeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Families_ExpenseScopes_ExpenseScopeId",
                        column: x => x.ExpenseScopeId,
                        principalTable: "ExpenseScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExpenseScopeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_ExpenseScopes_ExpenseScopeId",
                        column: x => x.ExpenseScopeId,
                        principalTable: "ExpenseScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelUsers",
                columns: table => new
                {
                    TravelsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelUsers", x => new { x.TravelsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TravelUsers_Travels_TravelsId",
                        column: x => x.TravelsId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ExpenseScopeId",
                table: "Categories",
                column: "ExpenseScopeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_ExpenseScopeId",
                table: "Buildings",
                column: "ExpenseScopeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expences_ExpenseScopeId",
                table: "Expences",
                column: "ExpenseScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_Families_ExpenseScopeId",
                table: "Families",
                column: "ExpenseScopeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Travels_ExpenseScopeId",
                table: "Travels",
                column: "ExpenseScopeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TravelUsers_UsersId",
                table: "TravelUsers",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ExpenseScopes_ExpenseScopeId",
                table: "Categories",
                column: "ExpenseScopeId",
                principalTable: "ExpenseScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ExpenseScopes_ExpenseScopeId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Expences");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "TravelUsers");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ExpenseScopes");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ExpenseScopeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryCreationType",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ExpenseScopeId",
                table: "Categories");
        }
    }
}
