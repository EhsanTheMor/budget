using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace budget_back.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Users_UserId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_ExpenseScopes_ExpenseScopeId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Users_ManagerId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingUsers_Buildings_BuildingsId",
                table: "BuildingUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingUsers_Users_UsersId",
                table: "BuildingUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ExpenseScopes_ExpenseScopeId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Expences_BankAccounts_BankAccountId",
                table: "Expences");

            migrationBuilder.DropForeignKey(
                name: "FK_Expences_ExpenseScopes_ExpenseScopeId",
                table: "Expences");

            migrationBuilder.DropForeignKey(
                name: "FK_Families_ExpenseScopes_ExpenseScopeId",
                table: "Families");

            migrationBuilder.DropForeignKey(
                name: "FK_Families_Users_ManagerId",
                table: "Families");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyUsers_Families_FamiliesId",
                table: "FamilyUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyUsers_Users_UsersId",
                table: "FamilyUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_ExpenseScopes_ExpenseScopeId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Users_ManagerId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelUsers_Travels_TravelsId",
                table: "TravelUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelUsers_Users_UsersId",
                table: "TravelUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelUsers",
                table: "TravelUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Travels",
                table: "Travels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyUsers",
                table: "FamilyUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Families",
                table: "Families");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseScopes",
                table: "ExpenseScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expences",
                table: "Expences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingUsers",
                table: "BuildingUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccounts",
                table: "BankAccounts");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "TravelUsers",
                newName: "TravelUser");

            migrationBuilder.RenameTable(
                name: "Travels",
                newName: "Travel");

            migrationBuilder.RenameTable(
                name: "FamilyUsers",
                newName: "FamilyUser");

            migrationBuilder.RenameTable(
                name: "Families",
                newName: "Family");

            migrationBuilder.RenameTable(
                name: "ExpenseScopes",
                newName: "ExpenseScope");

            migrationBuilder.RenameTable(
                name: "Expences",
                newName: "Expence");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "BuildingUsers",
                newName: "BuildingUser");

            migrationBuilder.RenameTable(
                name: "Buildings",
                newName: "Building");

            migrationBuilder.RenameTable(
                name: "BankAccounts",
                newName: "BankAccount");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Username",
                table: "User",
                newName: "IX_User_Username");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "User",
                newName: "IX_User_Email");

            migrationBuilder.RenameIndex(
                name: "IX_TravelUsers_UsersId",
                table: "TravelUser",
                newName: "IX_TravelUser_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Travels_ManagerId",
                table: "Travel",
                newName: "IX_Travel_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Travels_ExpenseScopeId",
                table: "Travel",
                newName: "IX_Travel_ExpenseScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyUsers_UsersId",
                table: "FamilyUser",
                newName: "IX_FamilyUser_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Families_ManagerId",
                table: "Family",
                newName: "IX_Family_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Families_ExpenseScopeId",
                table: "Family",
                newName: "IX_Family_ExpenseScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_Expences_ExpenseScopeId",
                table: "Expence",
                newName: "IX_Expence_ExpenseScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_Expences_BankAccountId",
                table: "Expence",
                newName: "IX_Expence_BankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ExpenseScopeId",
                table: "Category",
                newName: "IX_Category_ExpenseScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingUsers_UsersId",
                table: "BuildingUser",
                newName: "IX_BuildingUser_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_ManagerId",
                table: "Building",
                newName: "IX_Building_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_ExpenseScopeId",
                table: "Building",
                newName: "IX_Building_ExpenseScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccount",
                newName: "IX_BankAccount_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelUser",
                table: "TravelUser",
                columns: new[] { "TravelsId", "UsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Travel",
                table: "Travel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyUser",
                table: "FamilyUser",
                columns: new[] { "FamiliesId", "UsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Family",
                table: "Family",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseScope",
                table: "ExpenseScope",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expence",
                table: "Expence",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingUser",
                table: "BuildingUser",
                columns: new[] { "BuildingsId", "UsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Building",
                table: "Building",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccount",
                table: "BankAccount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_User_UserId",
                table: "BankAccount",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Building_ExpenseScope_ExpenseScopeId",
                table: "Building",
                column: "ExpenseScopeId",
                principalTable: "ExpenseScope",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Building_User_ManagerId",
                table: "Building",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingUser_Building_BuildingsId",
                table: "BuildingUser",
                column: "BuildingsId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingUser_User_UsersId",
                table: "BuildingUser",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_ExpenseScope_ExpenseScopeId",
                table: "Category",
                column: "ExpenseScopeId",
                principalTable: "ExpenseScope",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expence_BankAccount_BankAccountId",
                table: "Expence",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Expence_ExpenseScope_ExpenseScopeId",
                table: "Expence",
                column: "ExpenseScopeId",
                principalTable: "ExpenseScope",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Family_ExpenseScope_ExpenseScopeId",
                table: "Family",
                column: "ExpenseScopeId",
                principalTable: "ExpenseScope",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Family_User_ManagerId",
                table: "Family",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyUser_Family_FamiliesId",
                table: "FamilyUser",
                column: "FamiliesId",
                principalTable: "Family",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyUser_User_UsersId",
                table: "FamilyUser",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Travel_ExpenseScope_ExpenseScopeId",
                table: "Travel",
                column: "ExpenseScopeId",
                principalTable: "ExpenseScope",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Travel_User_ManagerId",
                table: "Travel",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUser_Travel_TravelsId",
                table: "TravelUser",
                column: "TravelsId",
                principalTable: "Travel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUser_User_UsersId",
                table: "TravelUser",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_User_UserId",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Building_ExpenseScope_ExpenseScopeId",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_Building_User_ManagerId",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingUser_Building_BuildingsId",
                table: "BuildingUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingUser_User_UsersId",
                table: "BuildingUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_ExpenseScope_ExpenseScopeId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Expence_BankAccount_BankAccountId",
                table: "Expence");

            migrationBuilder.DropForeignKey(
                name: "FK_Expence_ExpenseScope_ExpenseScopeId",
                table: "Expence");

            migrationBuilder.DropForeignKey(
                name: "FK_Family_ExpenseScope_ExpenseScopeId",
                table: "Family");

            migrationBuilder.DropForeignKey(
                name: "FK_Family_User_ManagerId",
                table: "Family");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyUser_Family_FamiliesId",
                table: "FamilyUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyUser_User_UsersId",
                table: "FamilyUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Travel_ExpenseScope_ExpenseScopeId",
                table: "Travel");

            migrationBuilder.DropForeignKey(
                name: "FK_Travel_User_ManagerId",
                table: "Travel");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelUser_Travel_TravelsId",
                table: "TravelUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelUser_User_UsersId",
                table: "TravelUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelUser",
                table: "TravelUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Travel",
                table: "Travel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyUser",
                table: "FamilyUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Family",
                table: "Family");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseScope",
                table: "ExpenseScope");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expence",
                table: "Expence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingUser",
                table: "BuildingUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Building",
                table: "Building");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccount",
                table: "BankAccount");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TravelUser",
                newName: "TravelUsers");

            migrationBuilder.RenameTable(
                name: "Travel",
                newName: "Travels");

            migrationBuilder.RenameTable(
                name: "FamilyUser",
                newName: "FamilyUsers");

            migrationBuilder.RenameTable(
                name: "Family",
                newName: "Families");

            migrationBuilder.RenameTable(
                name: "ExpenseScope",
                newName: "ExpenseScopes");

            migrationBuilder.RenameTable(
                name: "Expence",
                newName: "Expences");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "BuildingUser",
                newName: "BuildingUsers");

            migrationBuilder.RenameTable(
                name: "Building",
                newName: "Buildings");

            migrationBuilder.RenameTable(
                name: "BankAccount",
                newName: "BankAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_User_Username",
                table: "Users",
                newName: "IX_Users_Username");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_TravelUser_UsersId",
                table: "TravelUsers",
                newName: "IX_TravelUsers_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Travel_ManagerId",
                table: "Travels",
                newName: "IX_Travels_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Travel_ExpenseScopeId",
                table: "Travels",
                newName: "IX_Travels_ExpenseScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyUser_UsersId",
                table: "FamilyUsers",
                newName: "IX_FamilyUsers_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Family_ManagerId",
                table: "Families",
                newName: "IX_Families_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Family_ExpenseScopeId",
                table: "Families",
                newName: "IX_Families_ExpenseScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_Expence_ExpenseScopeId",
                table: "Expences",
                newName: "IX_Expences_ExpenseScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_Expence_BankAccountId",
                table: "Expences",
                newName: "IX_Expences_BankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ExpenseScopeId",
                table: "Categories",
                newName: "IX_Categories_ExpenseScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingUser_UsersId",
                table: "BuildingUsers",
                newName: "IX_BuildingUsers_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Building_ManagerId",
                table: "Buildings",
                newName: "IX_Buildings_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Building_ExpenseScopeId",
                table: "Buildings",
                newName: "IX_Buildings_ExpenseScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccount_UserId",
                table: "BankAccounts",
                newName: "IX_BankAccounts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelUsers",
                table: "TravelUsers",
                columns: new[] { "TravelsId", "UsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Travels",
                table: "Travels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyUsers",
                table: "FamilyUsers",
                columns: new[] { "FamiliesId", "UsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Families",
                table: "Families",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseScopes",
                table: "ExpenseScopes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expences",
                table: "Expences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingUsers",
                table: "BuildingUsers",
                columns: new[] { "BuildingsId", "UsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccounts",
                table: "BankAccounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Users_UserId",
                table: "BankAccounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_ExpenseScopes_ExpenseScopeId",
                table: "Buildings",
                column: "ExpenseScopeId",
                principalTable: "ExpenseScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Users_ManagerId",
                table: "Buildings",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingUsers_Buildings_BuildingsId",
                table: "BuildingUsers",
                column: "BuildingsId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingUsers_Users_UsersId",
                table: "BuildingUsers",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ExpenseScopes_ExpenseScopeId",
                table: "Categories",
                column: "ExpenseScopeId",
                principalTable: "ExpenseScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expences_BankAccounts_BankAccountId",
                table: "Expences",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Expences_ExpenseScopes_ExpenseScopeId",
                table: "Expences",
                column: "ExpenseScopeId",
                principalTable: "ExpenseScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Families_ExpenseScopes_ExpenseScopeId",
                table: "Families",
                column: "ExpenseScopeId",
                principalTable: "ExpenseScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Families_Users_ManagerId",
                table: "Families",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyUsers_Families_FamiliesId",
                table: "FamilyUsers",
                column: "FamiliesId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyUsers_Users_UsersId",
                table: "FamilyUsers",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_ExpenseScopes_ExpenseScopeId",
                table: "Travels",
                column: "ExpenseScopeId",
                principalTable: "ExpenseScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Users_ManagerId",
                table: "Travels",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUsers_Travels_TravelsId",
                table: "TravelUsers",
                column: "TravelsId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUsers_Users_UsersId",
                table: "TravelUsers",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
