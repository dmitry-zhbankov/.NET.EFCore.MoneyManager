using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    ParentCategoryId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Assets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCategory",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategory", x => new { x.UserId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_UserCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCategory_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    AssetId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 1, "Category1Income", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 58, "Category10Expense", null, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 55, "Category10Income", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 52, "Category9Expense", null, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 49, "Category9Income", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 46, "Category8Expense", null, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 40, "Category7Expense", null, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 37, "Category7Income", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 34, "Category6Expense", null, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 31, "Category6Income", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 43, "Category8Income", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 25, "Category5Income", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 22, "Category4Expense", null, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 19, "Category4Income", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 16, "Category3Expense", null, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 13, "Category3Income", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 10, "Category2Expense", null, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 7, "Category2Income", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 4, "Category1Expense", null, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 28, "Category5Expense", null, 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[] { 8, "email8", "User8" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[] { 7, "email7", "User7" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[] { 6, "email6", "User6" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[] { 5, "email5", "User5" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[] { 1, "email1", "User1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[] { 3, "email3", "User3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[] { 2, "email2", "User2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[] { 9, "email9", "User9" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[] { 4, "email4", "User4" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[] { 10, "email10", "User10" });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 16, 0m, "User8Asset2", 8 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 1, 0m, "User1Asset1", 1 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 2, 0m, "User1Asset2", 1 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 3, 0m, "User2Asset1", 2 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 4, 0m, "User2Asset2", 2 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 5, 0m, "User3Asset1", 3 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 15, 0m, "User8Asset1", 8 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 7, 0m, "User4Asset1", 4 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 8, 0m, "User4Asset2", 4 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 20, 0m, "User10Asset2", 10 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 6, 0m, "User3Asset2", 3 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 9, 0m, "User5Asset1", 5 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 10, 0m, "User5Asset2", 5 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 11, 0m, "User6Asset1", 6 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 12, 0m, "User6Asset2", 6 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 18, 0m, "User9Asset2", 9 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 17, 0m, "User9Asset1", 9 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 13, 0m, "User7Asset1", 7 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 14, 0m, "User7Asset2", 7 });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Balance", "Name", "UserId" },
                values: new object[] { 19, 0m, "User10Asset1", 10 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 50, "Category91Income", 49, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 51, "Category92Income", 49, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 53, "Category91Expense", 52, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 54, "Category92Expense", 52, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 60, "Category102Expense", 58, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 57, "Category102Income", 55, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 59, "Category101Expense", 58, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 48, "Category82Expense", 46, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 56, "Category101Income", 55, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 47, "Category81Expense", 46, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 2, "Category11Income", 1, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 44, "Category81Income", 43, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 5, "Category11Expense", 4, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 3, "Category12Income", 1, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 14, "Category31Income", 13, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 12, "Category22Expense", 10, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 18, "Category32Expense", 16, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 20, "Category41Income", 19, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 45, "Category82Income", 43, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 9, "Category22Income", 7, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 21, "Category42Income", 19, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 6, "Category12Expense", 4, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 8, "Category21Income", 7, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 23, "Category41Expense", 22, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 24, "Category42Expense", 22, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 15, "Category32Income", 13, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 17, "Category31Expense", 16, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 32, "Category61Income", 31, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 26, "Category51Income", 25, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 42, "Category72Expense", 40, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 27, "Category52Income", 25, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 41, "Category71Expense", 40, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 39, "Category72Income", 37, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 11, "Category21Expense", 10, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 29, "Category51Expense", 28, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 30, "Category52Expense", 28, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 38, "Category71Income", 37, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 33, "Category62Income", 31, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 35, "Category61Expense", 34, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ParentCategoryId", "Type" },
                values: new object[] { 36, "Category62Expense", 34, 0 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 10 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 13 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 1 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 16 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 4 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 46 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 7 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 28 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 40 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 37 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 34 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 31 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 25 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 22 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 19 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 16 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 13 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 10 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 7 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 4 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 1 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 43 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 19 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 49 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 25 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 52 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 49 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 46 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 43 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 40 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 37 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 34 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 31 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 28 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 22 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 19 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 16 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 13 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 10 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 7 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 4 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 1 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 52 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 46 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 43 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 40 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 37 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 34 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 31 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 28 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 22 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 25 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 7 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 37 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 13 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 10 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 7 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 22 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 19 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 16 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 13 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 10 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 7 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 16 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 13 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 10 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 7 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 4 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 2, 10 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 2, 7 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 2, 4 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 16 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 40 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 19 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 25 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 34 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 31 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 28 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 25 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 22 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 19 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 16 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 13 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 10 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 7 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 34 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 31 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 28 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 25 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 22 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 19 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 16 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 13 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 10 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 55 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 28 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 22 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 58 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 379, 3790m, 4, 4, null, new DateTime(2014, 10, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5669), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 511, 5110m, 6, 6, null, new DateTime(2012, 12, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5856), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 513, 5130m, 6, 6, null, new DateTime(2012, 12, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5858), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 515, 5150m, 6, 6, null, new DateTime(2012, 11, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5941), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 566, 5650m, 6, 8, null, new DateTime(2012, 3, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6000), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 568, 5670m, 6, 9, null, new DateTime(2012, 3, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6002), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 570, 5690m, 6, 10, null, new DateTime(2012, 2, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6005), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 571, 5710m, 6, 6, null, new DateTime(2012, 2, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6006), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 573, 5730m, 6, 6, null, new DateTime(2012, 2, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6008), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 575, 5750m, 6, 6, null, new DateTime(2012, 2, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6010), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 32, 310m, 7, 9, null, new DateTime(2019, 7, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5112), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 34, 330m, 7, 10, null, new DateTime(2019, 7, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5115), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 36, 350m, 7, 11, null, new DateTime(2019, 6, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5117), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 37, 370m, 7, 7, null, new DateTime(2019, 6, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5118), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 39, 390m, 7, 7, null, new DateTime(2019, 6, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5121), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 41, 410m, 7, 7, null, new DateTime(2019, 5, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5123), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 92, 910m, 7, 9, null, new DateTime(2018, 9, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5183), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 94, 930m, 7, 10, null, new DateTime(2018, 9, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5186), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 96, 950m, 7, 11, null, new DateTime(2018, 8, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5188), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 97, 970m, 7, 7, null, new DateTime(2018, 8, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5189), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 99, 990m, 7, 7, null, new DateTime(2018, 8, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5191), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 101, 1010m, 7, 7, null, new DateTime(2018, 7, 31, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5194), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 510, 5090m, 6, 10, null, new DateTime(2012, 12, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5855), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 508, 5070m, 6, 9, null, new DateTime(2013, 1, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5852), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 506, 5050m, 6, 8, null, new DateTime(2013, 1, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5850), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 455, 4550m, 6, 6, null, new DateTime(2013, 9, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5790), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 268, 2670m, 6, 9, null, new DateTime(2016, 4, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5490), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 270, 2690m, 6, 10, null, new DateTime(2016, 4, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5492), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 271, 2710m, 6, 6, null, new DateTime(2016, 4, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5493), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 273, 2730m, 6, 6, null, new DateTime(2016, 3, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5496), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 275, 2750m, 6, 6, null, new DateTime(2016, 3, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5498), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 326, 3250m, 6, 8, null, new DateTime(2015, 7, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5608), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 328, 3270m, 6, 9, null, new DateTime(2015, 6, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5610), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 330, 3290m, 6, 10, null, new DateTime(2015, 6, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5612), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 331, 3310m, 6, 6, null, new DateTime(2015, 6, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5613), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 333, 3330m, 6, 6, null, new DateTime(2015, 5, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5616), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 152, 1510m, 7, 9, null, new DateTime(2017, 11, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5296), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 335, 3350m, 6, 6, null, new DateTime(2015, 5, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5618), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 388, 3870m, 6, 9, null, new DateTime(2014, 8, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5679), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 390, 3890m, 6, 10, null, new DateTime(2014, 8, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5681), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 391, 3910m, 6, 6, null, new DateTime(2014, 8, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5682), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 393, 3930m, 6, 6, null, new DateTime(2014, 8, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5685), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 395, 3950m, 6, 6, null, new DateTime(2014, 7, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5687), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 446, 4450m, 6, 8, null, new DateTime(2013, 11, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5780), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 448, 4470m, 6, 9, null, new DateTime(2013, 10, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5782), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 450, 4490m, 6, 10, null, new DateTime(2013, 10, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5784), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 451, 4510m, 6, 6, null, new DateTime(2013, 10, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5786), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 453, 4530m, 6, 6, null, new DateTime(2013, 10, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5788), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 386, 3850m, 6, 8, null, new DateTime(2014, 9, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5677), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 266, 2650m, 6, 8, null, new DateTime(2016, 4, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5488), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 154, 1530m, 7, 10, null, new DateTime(2017, 11, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5298), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 157, 1570m, 7, 7, null, new DateTime(2017, 10, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5302), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 452, 4510m, 7, 9, null, new DateTime(2013, 10, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5787), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 454, 4530m, 7, 10, null, new DateTime(2013, 9, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5789), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 456, 4550m, 7, 11, null, new DateTime(2013, 9, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5791), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 457, 4570m, 7, 7, null, new DateTime(2013, 9, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5792), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 459, 4590m, 7, 7, null, new DateTime(2013, 9, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5795), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 461, 4610m, 7, 7, null, new DateTime(2013, 8, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5797), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 512, 5110m, 7, 9, null, new DateTime(2012, 12, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5857), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 514, 5130m, 7, 10, null, new DateTime(2012, 12, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5939), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 516, 5150m, 7, 11, null, new DateTime(2012, 11, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5942), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 517, 5170m, 7, 7, null, new DateTime(2012, 11, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5943), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 519, 5190m, 7, 7, null, new DateTime(2012, 11, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5946), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 521, 5210m, 7, 7, null, new DateTime(2012, 10, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5948), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 572, 5710m, 7, 9, null, new DateTime(2012, 2, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6007), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 574, 5730m, 7, 10, null, new DateTime(2012, 2, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6009), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 576, 5750m, 7, 11, null, new DateTime(2012, 1, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6011), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 577, 5770m, 7, 7, null, new DateTime(2012, 1, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6013), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 579, 5790m, 7, 7, null, new DateTime(2012, 1, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6015), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 581, 5810m, 7, 7, null, new DateTime(2012, 1, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6053), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 38, 370m, 8, 10, null, new DateTime(2019, 6, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5120), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 40, 390m, 8, 11, null, new DateTime(2019, 6, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5122), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 42, 410m, 8, 12, null, new DateTime(2019, 5, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5124), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 401, 4010m, 7, 7, null, new DateTime(2014, 6, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5694), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 399, 3990m, 7, 7, null, new DateTime(2014, 7, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5692), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 397, 3970m, 7, 7, null, new DateTime(2014, 7, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5689), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 396, 3950m, 7, 11, null, new DateTime(2014, 7, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5688), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 159, 1590m, 7, 7, null, new DateTime(2017, 10, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5304), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 161, 1610m, 7, 7, null, new DateTime(2017, 10, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5306), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 212, 2110m, 7, 9, null, new DateTime(2017, 1, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5365), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 214, 2130m, 7, 10, null, new DateTime(2017, 1, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5367), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 216, 2150m, 7, 11, null, new DateTime(2017, 1, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5428), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 217, 2170m, 7, 7, null, new DateTime(2016, 12, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5430), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 219, 2190m, 7, 7, null, new DateTime(2016, 12, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5432), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 221, 2210m, 7, 7, null, new DateTime(2016, 12, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5435), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 272, 2710m, 7, 9, null, new DateTime(2016, 3, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5495), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 274, 2730m, 7, 10, null, new DateTime(2016, 3, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5497), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 156, 1550m, 7, 11, null, new DateTime(2017, 10, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5301), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 276, 2750m, 7, 11, null, new DateTime(2016, 3, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5499), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 279, 2790m, 7, 7, null, new DateTime(2016, 2, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5503), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 281, 2810m, 7, 7, null, new DateTime(2016, 2, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5505), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 332, 3310m, 7, 9, null, new DateTime(2015, 6, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5615), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 334, 3330m, 7, 10, null, new DateTime(2015, 5, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5617), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 336, 3350m, 7, 11, null, new DateTime(2015, 5, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5619), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 337, 3370m, 7, 7, null, new DateTime(2015, 5, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5620), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 339, 3390m, 7, 7, null, new DateTime(2015, 4, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5623), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 341, 3410m, 7, 7, null, new DateTime(2015, 4, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5625), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 392, 3910m, 7, 9, null, new DateTime(2014, 8, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5684), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 394, 3930m, 7, 10, null, new DateTime(2014, 7, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5686), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 277, 2770m, 7, 7, null, new DateTime(2016, 3, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5500), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 215, 2150m, 6, 6, null, new DateTime(2017, 1, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5368), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 213, 2130m, 6, 6, null, new DateTime(2017, 1, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5366), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 211, 2110m, 6, 6, null, new DateTime(2017, 1, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5364), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 84, 830m, 5, 9, null, new DateTime(2018, 10, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5174), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 85, 850m, 5, 5, null, new DateTime(2018, 10, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5175), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 87, 870m, 5, 5, null, new DateTime(2018, 10, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5178), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 89, 890m, 5, 5, null, new DateTime(2018, 9, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5180), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 140, 1390m, 5, 7, null, new DateTime(2018, 1, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5282), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 142, 1410m, 5, 8, null, new DateTime(2018, 1, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5284), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 144, 1430m, 5, 9, null, new DateTime(2017, 12, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5287), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 145, 1450m, 5, 5, null, new DateTime(2017, 12, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5288), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 147, 1470m, 5, 5, null, new DateTime(2017, 12, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5290), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 149, 1490m, 5, 5, null, new DateTime(2017, 12, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5292), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 200, 1990m, 5, 7, null, new DateTime(2017, 3, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5351), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 202, 2010m, 5, 8, null, new DateTime(2017, 3, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5353), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 204, 2030m, 5, 9, null, new DateTime(2017, 3, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5355), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 205, 2050m, 5, 5, null, new DateTime(2017, 2, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5357), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 207, 2070m, 5, 5, null, new DateTime(2017, 2, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5359), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 209, 2090m, 5, 5, null, new DateTime(2017, 2, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5361), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 260, 2590m, 5, 7, null, new DateTime(2016, 5, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5481), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 262, 2610m, 5, 8, null, new DateTime(2016, 5, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5483), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 264, 2630m, 5, 9, null, new DateTime(2016, 5, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5485), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 265, 2650m, 5, 5, null, new DateTime(2016, 5, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5487), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 267, 2670m, 5, 5, null, new DateTime(2016, 4, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5489), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 82, 810m, 5, 8, null, new DateTime(2018, 11, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5172), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 80, 790m, 5, 7, null, new DateTime(2018, 11, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5170), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 29, 290m, 5, 5, null, new DateTime(2019, 7, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5108), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 27, 270m, 5, 5, null, new DateTime(2019, 8, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5106), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 434, 4330m, 4, 6, null, new DateTime(2014, 1, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5765), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 436, 4350m, 4, 7, null, new DateTime(2013, 12, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5768), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 438, 4370m, 4, 8, null, new DateTime(2013, 12, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5770), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 439, 4390m, 4, 4, null, new DateTime(2013, 12, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5771), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 441, 4410m, 4, 4, null, new DateTime(2013, 12, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5774), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 443, 4430m, 4, 4, null, new DateTime(2013, 11, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5776), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 494, 4930m, 4, 6, null, new DateTime(2013, 3, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5836), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 496, 4950m, 4, 7, null, new DateTime(2013, 3, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5838), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 498, 4970m, 4, 8, null, new DateTime(2013, 2, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5840), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 499, 4990m, 4, 4, null, new DateTime(2013, 2, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5842), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 269, 2690m, 5, 5, null, new DateTime(2016, 4, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5491), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 501, 5010m, 4, 4, null, new DateTime(2013, 2, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5844), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 554, 5530m, 4, 6, null, new DateTime(2012, 5, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5986), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 556, 5550m, 4, 7, null, new DateTime(2012, 5, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5988), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 558, 5570m, 4, 8, null, new DateTime(2012, 4, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5991), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 559, 5590m, 4, 4, null, new DateTime(2012, 4, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5992), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 561, 5610m, 4, 4, null, new DateTime(2012, 4, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5994), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 563, 5630m, 4, 4, null, new DateTime(2012, 4, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5996), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 20, 190m, 5, 7, null, new DateTime(2019, 9, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5098), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 22, 210m, 5, 8, null, new DateTime(2019, 8, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5100), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 24, 230m, 5, 9, null, new DateTime(2019, 8, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5102), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 25, 250m, 5, 5, null, new DateTime(2019, 8, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5104), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 503, 5030m, 4, 4, null, new DateTime(2013, 1, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5846), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 320, 3190m, 5, 7, null, new DateTime(2015, 8, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5601), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 322, 3210m, 5, 8, null, new DateTime(2015, 7, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5603), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 324, 3230m, 5, 9, null, new DateTime(2015, 7, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5605), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 569, 5690m, 5, 5, null, new DateTime(2012, 3, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6003), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 26, 250m, 6, 8, null, new DateTime(2019, 8, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5105), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 28, 270m, 6, 9, null, new DateTime(2019, 7, 31, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5107), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 30, 290m, 6, 10, null, new DateTime(2019, 7, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5109), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 31, 310m, 6, 6, null, new DateTime(2019, 7, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5110), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 33, 330m, 6, 6, null, new DateTime(2019, 7, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5113), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 35, 350m, 6, 6, null, new DateTime(2019, 6, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5116), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 86, 850m, 6, 8, null, new DateTime(2018, 10, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5176), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 88, 870m, 6, 9, null, new DateTime(2018, 10, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5179), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 90, 890m, 6, 10, null, new DateTime(2018, 9, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5181), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 567, 5670m, 5, 5, null, new DateTime(2012, 3, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6001), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 91, 910m, 6, 6, null, new DateTime(2018, 9, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5182), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 95, 950m, 6, 6, null, new DateTime(2018, 8, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5187), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 146, 1450m, 6, 8, null, new DateTime(2017, 12, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5289), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 148, 1470m, 6, 9, null, new DateTime(2017, 12, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5291), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 150, 1490m, 6, 10, null, new DateTime(2017, 11, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5293), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 151, 1510m, 6, 6, null, new DateTime(2017, 11, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5295), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 153, 1530m, 6, 6, null, new DateTime(2017, 11, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5297), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 155, 1550m, 6, 6, null, new DateTime(2017, 11, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5299), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 206, 2050m, 6, 8, null, new DateTime(2017, 2, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5358), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 208, 2070m, 6, 9, null, new DateTime(2017, 2, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5360), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 210, 2090m, 6, 10, null, new DateTime(2017, 2, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5363), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 93, 930m, 6, 6, null, new DateTime(2018, 9, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5184), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 43, 430m, 8, 8, null, new DateTime(2019, 5, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5125), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 565, 5650m, 5, 5, null, new DateTime(2012, 3, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5999), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 562, 5610m, 5, 8, null, new DateTime(2012, 4, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5995), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 325, 3250m, 5, 5, null, new DateTime(2015, 7, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5607), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 327, 3270m, 5, 5, null, new DateTime(2015, 6, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5609), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 329, 3290m, 5, 5, null, new DateTime(2015, 6, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5611), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 380, 3790m, 5, 7, null, new DateTime(2014, 10, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5670), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 382, 3810m, 5, 8, null, new DateTime(2014, 9, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5672), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 384, 3830m, 5, 9, null, new DateTime(2014, 9, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5674), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 385, 3850m, 5, 5, null, new DateTime(2014, 9, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5676), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 387, 3870m, 5, 5, null, new DateTime(2014, 8, 31, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5678), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 389, 3890m, 5, 5, null, new DateTime(2014, 8, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5680), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 440, 4390m, 5, 7, null, new DateTime(2013, 12, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5773), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 564, 5630m, 5, 9, null, new DateTime(2012, 3, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5997), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 442, 4410m, 5, 8, null, new DateTime(2013, 11, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5775), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 445, 4450m, 5, 5, null, new DateTime(2013, 11, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5779), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 447, 4470m, 5, 5, null, new DateTime(2013, 11, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5781), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 449, 4490m, 5, 5, null, new DateTime(2013, 10, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5783), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 500, 4990m, 5, 7, null, new DateTime(2013, 2, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5843), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 502, 5010m, 5, 8, null, new DateTime(2013, 2, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5845), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 504, 5030m, 5, 9, null, new DateTime(2013, 1, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5848), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 505, 5050m, 5, 5, null, new DateTime(2013, 1, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5849), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 507, 5070m, 5, 5, null, new DateTime(2013, 1, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5851), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 509, 5090m, 5, 5, null, new DateTime(2012, 12, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5854), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 560, 5590m, 5, 7, null, new DateTime(2012, 4, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5993), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 444, 4430m, 5, 9, null, new DateTime(2013, 11, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5777), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 383, 3830m, 4, 4, null, new DateTime(2014, 9, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5673), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 45, 450m, 8, 8, null, new DateTime(2019, 5, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5128), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 98, 970m, 8, 10, null, new DateTime(2018, 8, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5190), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 177, 1770m, 10, 10, null, new DateTime(2017, 7, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5324), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 179, 1790m, 10, 10, null, new DateTime(2017, 7, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5327), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 230, 2290m, 10, 12, null, new DateTime(2016, 10, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5445), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 232, 2310m, 10, 13, null, new DateTime(2016, 10, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5447), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 234, 2330m, 10, 14, null, new DateTime(2016, 10, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5449), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 235, 2350m, 10, 10, null, new DateTime(2016, 9, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5451), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 237, 2370m, 10, 10, null, new DateTime(2016, 9, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5453), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 239, 2390m, 10, 10, null, new DateTime(2016, 9, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5455), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 290, 2890m, 10, 12, null, new DateTime(2015, 12, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5566), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 292, 2910m, 10, 13, null, new DateTime(2015, 12, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5568), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 294, 2930m, 10, 14, null, new DateTime(2015, 12, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5571), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 295, 2950m, 10, 10, null, new DateTime(2015, 12, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5572), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 297, 2970m, 10, 10, null, new DateTime(2015, 11, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5574), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 299, 2990m, 10, 10, null, new DateTime(2015, 11, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5576), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 350, 3490m, 10, 12, null, new DateTime(2015, 3, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5635), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 352, 3510m, 10, 13, null, new DateTime(2015, 2, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5638), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 354, 3530m, 10, 14, null, new DateTime(2015, 2, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5640), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 355, 3550m, 10, 10, null, new DateTime(2015, 2, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5641), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 357, 3570m, 10, 10, null, new DateTime(2015, 1, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5643), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 359, 3590m, 10, 10, null, new DateTime(2015, 1, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5646), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 410, 4090m, 10, 12, null, new DateTime(2014, 5, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5704), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 175, 1750m, 10, 10, null, new DateTime(2017, 7, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5322), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 174, 1730m, 10, 14, null, new DateTime(2017, 7, 31, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5321), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 172, 1710m, 10, 13, null, new DateTime(2017, 8, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5319), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 170, 1690m, 10, 12, null, new DateTime(2017, 8, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5317), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 528, 5270m, 9, 13, null, new DateTime(2012, 9, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5956), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 529, 5290m, 9, 9, null, new DateTime(2012, 9, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5957), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 531, 5310m, 9, 9, null, new DateTime(2012, 9, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5959), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 533, 5330m, 9, 9, null, new DateTime(2012, 8, 31, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5962), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 584, 5830m, 9, 11, null, new DateTime(2011, 12, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6056), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 586, 5850m, 9, 12, null, new DateTime(2011, 12, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6059), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 588, 5870m, 9, 13, null, new DateTime(2011, 11, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6061), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 589, 5890m, 9, 9, null, new DateTime(2011, 11, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6062), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 591, 5910m, 9, 9, null, new DateTime(2011, 11, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6064), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 593, 5930m, 9, 9, null, new DateTime(2011, 11, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6067), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 412, 4110m, 10, 13, null, new DateTime(2014, 4, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5706), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 50, 490m, 10, 12, null, new DateTime(2019, 4, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5134), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 54, 530m, 10, 14, null, new DateTime(2019, 3, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5138), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 55, 550m, 10, 10, null, new DateTime(2019, 3, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5139), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 57, 570m, 10, 10, null, new DateTime(2019, 3, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5142), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 59, 590m, 10, 10, null, new DateTime(2019, 2, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5144), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 110, 1090m, 10, 12, null, new DateTime(2018, 6, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5246), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 112, 1110m, 10, 13, null, new DateTime(2018, 6, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5248), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 114, 1130m, 10, 14, null, new DateTime(2018, 5, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5251), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 115, 1150m, 10, 10, null, new DateTime(2018, 5, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5252), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 117, 1170m, 10, 10, null, new DateTime(2018, 5, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5254), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 119, 1190m, 10, 10, null, new DateTime(2018, 5, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5256), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 52, 510m, 10, 13, null, new DateTime(2019, 4, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5136), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 526, 5250m, 9, 12, null, new DateTime(2012, 10, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5954), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 414, 4130m, 10, 14, null, new DateTime(2014, 4, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5709), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 417, 4170m, 10, 10, null, new DateTime(2014, 4, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5712), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 178, 1770m, 11, 14, null, new DateTime(2017, 7, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5326), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 180, 1790m, 11, 15, null, new DateTime(2017, 7, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5328), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 236, 2350m, 11, 13, null, new DateTime(2016, 9, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5452), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 238, 2370m, 11, 14, null, new DateTime(2016, 9, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5454), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 240, 2390m, 11, 15, null, new DateTime(2016, 9, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5456), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 296, 2950m, 11, 13, null, new DateTime(2015, 11, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5573), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 298, 2970m, 11, 14, null, new DateTime(2015, 11, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5575), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 300, 2990m, 11, 15, null, new DateTime(2015, 11, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5578), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 356, 3550m, 11, 13, null, new DateTime(2015, 2, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5642), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 358, 3570m, 11, 14, null, new DateTime(2015, 1, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5645), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 360, 3590m, 11, 15, null, new DateTime(2015, 1, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5647), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 416, 4150m, 11, 13, null, new DateTime(2014, 4, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5711), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 418, 4170m, 11, 14, null, new DateTime(2014, 3, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5713), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 420, 4190m, 11, 15, null, new DateTime(2014, 3, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5715), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 476, 4750m, 11, 13, null, new DateTime(2013, 6, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5815), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 478, 4770m, 11, 14, null, new DateTime(2013, 6, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5817), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 480, 4790m, 11, 15, null, new DateTime(2013, 5, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5819), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 536, 5350m, 11, 13, null, new DateTime(2012, 8, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5965), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 538, 5370m, 11, 14, null, new DateTime(2012, 8, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5968), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 540, 5390m, 11, 15, null, new DateTime(2012, 7, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5970), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 596, 5950m, 11, 13, null, new DateTime(2011, 10, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6070), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 176, 1750m, 11, 13, null, new DateTime(2017, 7, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5323), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 120, 1190m, 11, 15, null, new DateTime(2018, 4, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5258), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 118, 1170m, 11, 14, null, new DateTime(2018, 5, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5255), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 116, 1150m, 11, 13, null, new DateTime(2018, 5, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5253), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 419, 4190m, 10, 10, null, new DateTime(2014, 3, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5714), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 470, 4690m, 10, 12, null, new DateTime(2013, 7, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5807), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 472, 4710m, 10, 13, null, new DateTime(2013, 7, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5810), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 474, 4730m, 10, 14, null, new DateTime(2013, 6, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5812), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 475, 4750m, 10, 10, null, new DateTime(2013, 6, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5814), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 477, 4770m, 10, 10, null, new DateTime(2013, 6, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5816), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 479, 4790m, 10, 10, null, new DateTime(2013, 5, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5818), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 530, 5290m, 10, 12, null, new DateTime(2012, 9, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5958), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 532, 5310m, 10, 13, null, new DateTime(2012, 9, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5960), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 534, 5330m, 10, 14, null, new DateTime(2012, 8, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5963), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 415, 4150m, 10, 10, null, new DateTime(2014, 4, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5710), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 535, 5350m, 10, 10, null, new DateTime(2012, 8, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5964), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 539, 5390m, 10, 10, null, new DateTime(2012, 8, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5969), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 590, 5890m, 10, 12, null, new DateTime(2011, 11, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6063), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 592, 5910m, 10, 13, null, new DateTime(2011, 11, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6065), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 594, 5930m, 10, 14, null, new DateTime(2011, 10, 31, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6068), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 595, 5950m, 10, 10, null, new DateTime(2011, 10, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6069), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 597, 5970m, 10, 10, null, new DateTime(2011, 10, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6071), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 599, 5990m, 10, 10, null, new DateTime(2011, 10, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6073), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 56, 550m, 11, 13, null, new DateTime(2019, 3, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5140), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 58, 570m, 11, 14, null, new DateTime(2019, 3, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5143), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 60, 590m, 11, 15, null, new DateTime(2019, 2, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5145), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 537, 5370m, 10, 10, null, new DateTime(2012, 8, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5966), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 524, 5230m, 9, 11, null, new DateTime(2012, 10, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5951), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 473, 4730m, 9, 9, null, new DateTime(2013, 6, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5811), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 471, 4710m, 9, 9, null, new DateTime(2013, 7, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5809), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 343, 3430m, 8, 8, null, new DateTime(2015, 4, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5627), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 345, 3450m, 8, 8, null, new DateTime(2015, 3, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5629), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 347, 3470m, 8, 8, null, new DateTime(2015, 3, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5632), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 398, 3970m, 8, 10, null, new DateTime(2014, 7, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5690), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 400, 3990m, 8, 11, null, new DateTime(2014, 6, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5693), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 402, 4010m, 8, 12, null, new DateTime(2014, 6, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5695), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 403, 4030m, 8, 8, null, new DateTime(2014, 6, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5696), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 405, 4050m, 8, 8, null, new DateTime(2014, 6, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5698), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 407, 4070m, 8, 8, null, new DateTime(2014, 5, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5701), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 458, 4570m, 8, 10, null, new DateTime(2013, 9, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5794), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 460, 4590m, 8, 11, null, new DateTime(2013, 8, 31, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5796), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 462, 4610m, 8, 12, null, new DateTime(2013, 8, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5798), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 463, 4630m, 8, 8, null, new DateTime(2013, 8, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5799), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 465, 4650m, 8, 8, null, new DateTime(2013, 8, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5802), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 467, 4670m, 8, 8, null, new DateTime(2013, 7, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5804), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 518, 5170m, 8, 10, null, new DateTime(2012, 11, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5945), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 520, 5190m, 8, 11, null, new DateTime(2012, 11, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5947), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 522, 5210m, 8, 12, null, new DateTime(2012, 10, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5949), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 523, 5230m, 8, 8, null, new DateTime(2012, 10, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5950), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 525, 5250m, 8, 8, null, new DateTime(2012, 10, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5953), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 527, 5270m, 8, 8, null, new DateTime(2012, 9, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5955), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 342, 3410m, 8, 12, null, new DateTime(2015, 4, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5626), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 340, 3390m, 8, 11, null, new DateTime(2015, 4, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5624), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 338, 3370m, 8, 10, null, new DateTime(2015, 5, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5621), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 287, 2870m, 8, 8, null, new DateTime(2016, 1, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5512), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 100, 990m, 8, 11, null, new DateTime(2018, 8, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5192), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 102, 1010m, 8, 12, null, new DateTime(2018, 7, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5195), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 103, 1030m, 8, 8, null, new DateTime(2018, 7, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5196), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 105, 1050m, 8, 8, null, new DateTime(2018, 7, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5198), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 107, 1070m, 8, 8, null, new DateTime(2018, 7, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5242), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 158, 1570m, 8, 10, null, new DateTime(2017, 10, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5303), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 160, 1590m, 8, 11, null, new DateTime(2017, 10, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5305), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 162, 1610m, 8, 12, null, new DateTime(2017, 9, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5307), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 163, 1630m, 8, 8, null, new DateTime(2017, 9, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5309), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 165, 1650m, 8, 8, null, new DateTime(2017, 9, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5311), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 578, 5770m, 8, 10, null, new DateTime(2012, 1, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6014), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 167, 1670m, 8, 8, null, new DateTime(2017, 9, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5313), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 220, 2190m, 8, 11, null, new DateTime(2016, 12, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5433), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 222, 2210m, 8, 12, null, new DateTime(2016, 12, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5436), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 223, 2230m, 8, 8, null, new DateTime(2016, 11, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5437), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 225, 2250m, 8, 8, null, new DateTime(2016, 11, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5439), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 227, 2270m, 8, 8, null, new DateTime(2016, 11, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5441), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 278, 2770m, 8, 10, null, new DateTime(2016, 2, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5501), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 280, 2790m, 8, 11, null, new DateTime(2016, 2, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5504), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 282, 2810m, 8, 12, null, new DateTime(2016, 2, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5506), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 283, 2830m, 8, 8, null, new DateTime(2016, 2, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5507), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 285, 2850m, 8, 8, null, new DateTime(2016, 1, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5509), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 218, 2170m, 8, 10, null, new DateTime(2016, 12, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5431), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 580, 5790m, 8, 11, null, new DateTime(2012, 1, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6052), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 582, 5810m, 8, 12, null, new DateTime(2011, 12, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6054), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 583, 5830m, 8, 8, null, new DateTime(2011, 12, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6055), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 284, 2830m, 9, 11, null, new DateTime(2016, 1, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5508), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 286, 2850m, 9, 12, null, new DateTime(2016, 1, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5510), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 288, 2870m, 9, 13, null, new DateTime(2016, 1, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5563), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 289, 2890m, 9, 9, null, new DateTime(2016, 1, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5565), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 291, 2910m, 9, 9, null, new DateTime(2015, 12, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5567), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 293, 2930m, 9, 9, null, new DateTime(2015, 12, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5569), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 344, 3430m, 9, 11, null, new DateTime(2015, 4, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5628), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 346, 3450m, 9, 12, null, new DateTime(2015, 3, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5630), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 348, 3470m, 9, 13, null, new DateTime(2015, 3, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5633), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 349, 3490m, 9, 9, null, new DateTime(2015, 3, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5634), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 233, 2330m, 9, 9, null, new DateTime(2016, 10, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5448), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 351, 3510m, 9, 9, null, new DateTime(2015, 2, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5636), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 404, 4030m, 9, 11, null, new DateTime(2014, 6, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5697), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 406, 4050m, 9, 12, null, new DateTime(2014, 5, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5700), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 408, 4070m, 9, 13, null, new DateTime(2014, 5, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5702), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 409, 4090m, 9, 9, null, new DateTime(2014, 5, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5703), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 411, 4110m, 9, 9, null, new DateTime(2014, 5, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5705), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 413, 4130m, 9, 9, null, new DateTime(2014, 4, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5708), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 464, 4630m, 9, 11, null, new DateTime(2013, 8, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5801), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 466, 4650m, 9, 12, null, new DateTime(2013, 8, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5803), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 468, 4670m, 9, 13, null, new DateTime(2013, 7, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5805), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 469, 4690m, 9, 9, null, new DateTime(2013, 7, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5806), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 353, 3530m, 9, 9, null, new DateTime(2015, 2, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5639), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 47, 470m, 8, 8, null, new DateTime(2019, 4, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5130), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 231, 2310m, 9, 9, null, new DateTime(2016, 10, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5446), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 228, 2270m, 9, 13, null, new DateTime(2016, 11, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5443), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 585, 5850m, 8, 8, null, new DateTime(2011, 12, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6057), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 587, 5870m, 8, 8, null, new DateTime(2011, 12, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6060), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 44, 430m, 9, 11, null, new DateTime(2019, 5, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5127), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 46, 450m, 9, 12, null, new DateTime(2019, 5, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5129), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 48, 470m, 9, 13, null, new DateTime(2019, 4, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5131), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 49, 490m, 9, 9, null, new DateTime(2019, 4, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5132), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 51, 510m, 9, 9, null, new DateTime(2019, 4, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5135), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 53, 530m, 9, 9, null, new DateTime(2019, 3, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5137), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 104, 1030m, 9, 11, null, new DateTime(2018, 7, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5197), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 106, 1050m, 9, 12, null, new DateTime(2018, 7, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5199), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 229, 2290m, 9, 9, null, new DateTime(2016, 10, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5444), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 108, 1070m, 9, 13, null, new DateTime(2018, 6, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5244), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 111, 1110m, 9, 9, null, new DateTime(2018, 6, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5247), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 113, 1130m, 9, 9, null, new DateTime(2018, 6, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5250), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 164, 1630m, 9, 11, null, new DateTime(2017, 9, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5310), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 166, 1650m, 9, 12, null, new DateTime(2017, 9, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5312), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 168, 1670m, 9, 13, null, new DateTime(2017, 8, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5314), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 169, 1690m, 9, 9, null, new DateTime(2017, 8, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5315), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 171, 1710m, 9, 9, null, new DateTime(2017, 8, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5318), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 173, 1730m, 9, 9, null, new DateTime(2017, 8, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5320), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 224, 2230m, 9, 11, null, new DateTime(2016, 11, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5438), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 226, 2250m, 9, 12, null, new DateTime(2016, 11, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5440), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 109, 1090m, 9, 9, null, new DateTime(2018, 6, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5245), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 381, 3810m, 4, 4, null, new DateTime(2014, 9, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5671), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 600, 5990m, 11, 15, null, new DateTime(2011, 10, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6075), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 378, 3770m, 4, 8, null, new DateTime(2014, 10, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5667), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 364, 3630m, 2, 5, null, new DateTime(2014, 12, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5652), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 362, 3610m, 2, 4, null, new DateTime(2015, 1, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5649), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 311, 3110m, 2, 2, null, new DateTime(2015, 9, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5590), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 309, 3090m, 2, 2, null, new DateTime(2015, 9, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5588), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 307, 3070m, 2, 2, null, new DateTime(2015, 10, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5586), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 306, 3050m, 2, 6, null, new DateTime(2015, 10, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5585), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 304, 3030m, 2, 5, null, new DateTime(2015, 10, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5582), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 302, 3010m, 2, 4, null, new DateTime(2015, 10, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5580), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 251, 2510m, 2, 2, null, new DateTime(2016, 7, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5469), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 366, 3650m, 2, 6, null, new DateTime(2014, 12, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5654), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 249, 2490m, 2, 2, null, new DateTime(2016, 7, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5467), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 246, 2450m, 2, 6, null, new DateTime(2016, 8, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5463), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 244, 2430m, 2, 5, null, new DateTime(2016, 8, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5461), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 242, 2410m, 2, 4, null, new DateTime(2016, 8, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5459), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 191, 1910m, 2, 2, null, new DateTime(2017, 5, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5341), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 189, 1890m, 2, 2, null, new DateTime(2017, 5, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5338), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 187, 1870m, 2, 2, null, new DateTime(2017, 5, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5336), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 186, 1850m, 2, 6, null, new DateTime(2017, 6, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5335), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 184, 1830m, 2, 5, null, new DateTime(2017, 6, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5333), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 182, 1810m, 2, 4, null, new DateTime(2017, 6, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5330), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 247, 2470m, 2, 2, null, new DateTime(2016, 7, 31, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5464), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 131, 1310m, 2, 2, null, new DateTime(2018, 3, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5272), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 367, 3670m, 2, 2, null, new DateTime(2014, 12, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5655), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 371, 3710m, 2, 2, null, new DateTime(2014, 11, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5660), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 10, 90m, 3, 6, null, new DateTime(2019, 10, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5084), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 8, 70m, 3, 5, null, new DateTime(2019, 11, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5081), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 551, 5510m, 2, 2, null, new DateTime(2012, 6, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5983), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 549, 5490m, 2, 2, null, new DateTime(2012, 6, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5980), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 547, 5470m, 2, 2, null, new DateTime(2012, 6, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5978), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 546, 5450m, 2, 6, null, new DateTime(2012, 6, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5977), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 544, 5430m, 2, 5, null, new DateTime(2012, 7, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5975), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 542, 5410m, 2, 4, null, new DateTime(2012, 7, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5972), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 491, 4910m, 2, 2, null, new DateTime(2013, 3, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5832), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 369, 3690m, 2, 2, null, new DateTime(2014, 11, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5657), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 489, 4890m, 2, 2, null, new DateTime(2013, 4, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5830), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 486, 4850m, 2, 6, null, new DateTime(2013, 4, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5826), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 484, 4830m, 2, 5, null, new DateTime(2013, 5, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5824), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 482, 4810m, 2, 4, null, new DateTime(2013, 5, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5822), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 431, 4310m, 2, 2, null, new DateTime(2014, 1, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5728), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 429, 4290m, 2, 2, null, new DateTime(2014, 2, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5726), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 427, 4270m, 2, 2, null, new DateTime(2014, 2, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5724), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 426, 4250m, 2, 6, null, new DateTime(2014, 2, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5723), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 424, 4230m, 2, 5, null, new DateTime(2014, 2, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5720), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 422, 4210m, 2, 4, null, new DateTime(2014, 3, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5718), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 487, 4870m, 2, 2, null, new DateTime(2013, 4, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5828), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 12, 110m, 3, 7, null, new DateTime(2019, 10, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5087), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 129, 1290m, 2, 2, null, new DateTime(2018, 3, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5268), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 126, 1250m, 2, 6, null, new DateTime(2018, 3, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5265), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 361, 3610m, 1, 1, null, new DateTime(2015, 1, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5648), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 305, 3050m, 1, 1, null, new DateTime(2015, 10, 15, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5583), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 303, 3030m, 1, 1, null, new DateTime(2015, 10, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5581), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 301, 3010m, 1, 1, null, new DateTime(2015, 11, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5579), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 245, 2450m, 1, 1, null, new DateTime(2016, 8, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5462), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 243, 2430m, 1, 1, null, new DateTime(2016, 8, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5460), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 241, 2410m, 1, 1, null, new DateTime(2016, 8, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5458), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 185, 1850m, 1, 1, null, new DateTime(2017, 6, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5334), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 183, 1830m, 1, 1, null, new DateTime(2017, 6, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5331), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 363, 3630m, 1, 1, null, new DateTime(2014, 12, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5650), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 181, 1810m, 1, 1, null, new DateTime(2017, 6, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5329), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 123, 1230m, 1, 1, null, new DateTime(2018, 4, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5261), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 121, 1210m, 1, 1, null, new DateTime(2018, 4, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5259), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 65, 650m, 1, 1, null, new DateTime(2019, 1, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5151), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 63, 630m, 1, 1, null, new DateTime(2019, 2, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5149), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 61, 610m, 1, 1, null, new DateTime(2019, 2, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5146), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 5, 50m, 1, 1, null, new DateTime(2019, 11, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5071), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 3, 30m, 1, 1, null, new DateTime(2019, 12, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5067), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 1, 10m, 1, 1, null, new DateTime(2019, 12, 13, 15, 56, 25, 747, DateTimeKind.Local).AddTicks(4541), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 598, 5970m, 11, 14, null, new DateTime(2011, 10, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(6072), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 125, 1250m, 1, 1, null, new DateTime(2018, 4, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5263), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 127, 1270m, 2, 2, null, new DateTime(2018, 3, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5266), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 365, 3650m, 1, 1, null, new DateTime(2014, 12, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5653), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 423, 4230m, 1, 1, null, new DateTime(2014, 3, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5719), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 124, 1230m, 2, 5, null, new DateTime(2018, 4, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5262), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 122, 1210m, 2, 4, null, new DateTime(2018, 4, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5260), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 71, 710m, 2, 2, null, new DateTime(2018, 12, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5159), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 69, 690m, 2, 2, null, new DateTime(2019, 1, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5157), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 66, 650m, 2, 6, null, new DateTime(2019, 1, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5153), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 64, 630m, 2, 5, null, new DateTime(2019, 2, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5150), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 62, 610m, 2, 4, null, new DateTime(2019, 2, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5148), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 11, 110m, 2, 2, null, new DateTime(2019, 10, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5086), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 9, 90m, 2, 2, null, new DateTime(2019, 11, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5082), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 421, 4210m, 1, 1, null, new DateTime(2014, 3, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5717), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 7, 70m, 2, 2, null, new DateTime(2019, 11, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5079), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 4, 30m, 2, 5, null, new DateTime(2019, 11, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5069), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 2, 10m, 2, 4, null, new DateTime(2019, 12, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5016), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 545, 5450m, 1, 1, null, new DateTime(2012, 7, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5976), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 543, 5430m, 1, 1, null, new DateTime(2012, 7, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5974), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 541, 5410m, 1, 1, null, new DateTime(2012, 7, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5971), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 485, 4850m, 1, 1, null, new DateTime(2013, 4, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5825), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 483, 4830m, 1, 1, null, new DateTime(2013, 5, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5823), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 481, 4810m, 1, 1, null, new DateTime(2013, 5, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5821), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 425, 4250m, 1, 1, null, new DateTime(2014, 2, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5722), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 6, 50m, 2, 6, null, new DateTime(2019, 11, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5078), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 13, 130m, 3, 3, null, new DateTime(2019, 10, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5089), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 67, 670m, 2, 2, null, new DateTime(2019, 1, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5154), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 17, 170m, 3, 3, null, new DateTime(2019, 9, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5093), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 136, 1350m, 4, 7, null, new DateTime(2018, 2, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5278), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 134, 1330m, 4, 6, null, new DateTime(2018, 2, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5275), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 83, 830m, 4, 4, null, new DateTime(2018, 10, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5173), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 81, 810m, 4, 4, null, new DateTime(2018, 11, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5171), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 79, 790m, 4, 4, null, new DateTime(2018, 11, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5168), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 78, 770m, 4, 8, null, new DateTime(2018, 11, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5167), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 76, 750m, 4, 7, null, new DateTime(2018, 12, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5165), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 74, 730m, 4, 6, null, new DateTime(2018, 12, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5163), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 23, 230m, 4, 4, null, new DateTime(2019, 8, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5101), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 138, 1370m, 4, 8, null, new DateTime(2018, 1, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5280), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 21, 210m, 4, 4, null, new DateTime(2019, 9, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5099), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 18, 170m, 4, 8, null, new DateTime(2019, 9, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5095), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 16, 150m, 4, 7, null, new DateTime(2019, 9, 29, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5092), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 14, 130m, 4, 6, null, new DateTime(2019, 10, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5090), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 557, 5570m, 3, 3, null, new DateTime(2012, 5, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5990), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 555, 5550m, 3, 3, null, new DateTime(2012, 5, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5987), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 553, 5530m, 3, 3, null, new DateTime(2012, 5, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5985), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 552, 5510m, 3, 7, null, new DateTime(2012, 5, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5984), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 550, 5490m, 3, 6, null, new DateTime(2012, 6, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5982), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 548, 5470m, 3, 5, null, new DateTime(2012, 6, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5979), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 19, 190m, 4, 4, null, new DateTime(2019, 9, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5097), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 497, 4970m, 3, 3, null, new DateTime(2013, 2, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5839), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 139, 1390m, 4, 4, null, new DateTime(2018, 1, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5281), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 194, 1930m, 4, 6, null, new DateTime(2017, 4, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5344), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 376, 3750m, 4, 7, null, new DateTime(2014, 10, 25, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5665), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 15, 150m, 3, 3, null, new DateTime(2019, 10, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5091), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 374, 3730m, 4, 6, null, new DateTime(2014, 11, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5663), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 323, 3230m, 4, 4, null, new DateTime(2015, 7, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5604), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 321, 3210m, 4, 4, null, new DateTime(2015, 7, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5602), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 319, 3190m, 4, 4, null, new DateTime(2015, 8, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5599), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 318, 3170m, 4, 8, null, new DateTime(2015, 8, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5598), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 316, 3150m, 4, 7, null, new DateTime(2015, 8, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5596), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 314, 3130m, 4, 6, null, new DateTime(2015, 8, 31, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5594), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 141, 1410m, 4, 4, null, new DateTime(2018, 1, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5283), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 263, 2630m, 4, 4, null, new DateTime(2016, 5, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5484), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 259, 2590m, 4, 4, null, new DateTime(2016, 6, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5480), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 258, 2570m, 4, 8, null, new DateTime(2016, 6, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5478), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 256, 2550m, 4, 7, null, new DateTime(2016, 6, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5475), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 254, 2530m, 4, 6, null, new DateTime(2016, 6, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5472), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 203, 2030m, 4, 4, null, new DateTime(2017, 3, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5354), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 201, 2010m, 4, 4, null, new DateTime(2017, 3, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5352), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 199, 1990m, 4, 4, null, new DateTime(2017, 3, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5350), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 198, 1970m, 4, 8, null, new DateTime(2017, 4, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5349), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 196, 1950m, 4, 7, null, new DateTime(2017, 4, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5346), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 261, 2610m, 4, 4, null, new DateTime(2016, 5, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5482), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 495, 4950m, 3, 3, null, new DateTime(2013, 3, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5837), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 143, 1430m, 4, 4, null, new DateTime(2018, 1, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5286), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 492, 4910m, 3, 7, null, new DateTime(2013, 3, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5833), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 250, 2490m, 3, 6, null, new DateTime(2016, 7, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5468), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 248, 2470m, 3, 5, null, new DateTime(2016, 7, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5466), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 197, 1970m, 3, 3, null, new DateTime(2017, 4, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5348), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 195, 1950m, 3, 3, null, new DateTime(2017, 4, 17, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5345), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 193, 1930m, 3, 3, null, new DateTime(2017, 4, 27, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5343), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 192, 1910m, 3, 7, null, new DateTime(2017, 5, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5342), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 190, 1890m, 3, 6, null, new DateTime(2017, 5, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5340), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 188, 1870m, 3, 5, null, new DateTime(2017, 5, 22, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5337), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 135, 1350m, 3, 3, null, new DateTime(2018, 2, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5276), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 252, 2510m, 3, 7, null, new DateTime(2016, 7, 6, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5470), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 133, 1330m, 3, 3, null, new DateTime(2018, 2, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5274), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 130, 1290m, 3, 6, null, new DateTime(2018, 3, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5271), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 128, 1270m, 3, 5, null, new DateTime(2018, 3, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5267), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 77, 770m, 3, 3, null, new DateTime(2018, 11, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5166), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 75, 750m, 3, 3, null, new DateTime(2018, 12, 8, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5164), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 73, 730m, 3, 3, null, new DateTime(2018, 12, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5161), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 72, 710m, 3, 7, null, new DateTime(2018, 12, 23, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5160), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 493, 4930m, 3, 3, null, new DateTime(2013, 3, 19, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5835), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 70, 690m, 3, 6, null, new DateTime(2019, 1, 2, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5158), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 68, 670m, 3, 5, null, new DateTime(2019, 1, 12, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5156), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 132, 1310m, 3, 7, null, new DateTime(2018, 2, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5273), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 253, 2530m, 3, 3, null, new DateTime(2016, 7, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5471), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 137, 1370m, 3, 3, null, new DateTime(2018, 2, 1, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5279), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 257, 2570m, 3, 3, null, new DateTime(2016, 6, 11, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5476), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 488, 4870m, 3, 5, null, new DateTime(2013, 4, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5829), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 490, 4890m, 3, 6, null, new DateTime(2013, 4, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5831), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 437, 4370m, 3, 3, null, new DateTime(2013, 12, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5769), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 255, 2550m, 3, 3, null, new DateTime(2016, 6, 21, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5474), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 435, 4350m, 3, 3, null, new DateTime(2014, 1, 3, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5767), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 433, 4330m, 3, 3, null, new DateTime(2014, 1, 13, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5731), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 432, 4310m, 3, 7, null, new DateTime(2014, 1, 18, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5729), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 428, 4270m, 3, 5, null, new DateTime(2014, 2, 7, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5725), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 377, 3770m, 3, 3, null, new DateTime(2014, 10, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5666), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 375, 3750m, 3, 3, null, new DateTime(2014, 10, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5664), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 373, 3730m, 3, 3, null, new DateTime(2014, 11, 9, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5662), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 430, 4290m, 3, 6, null, new DateTime(2014, 1, 28, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5727), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 372, 3710m, 3, 7, null, new DateTime(2014, 11, 14, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5661), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 370, 3690m, 3, 6, null, new DateTime(2014, 11, 24, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5658), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 368, 3670m, 3, 5, null, new DateTime(2014, 12, 4, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5656), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 317, 3170m, 3, 3, null, new DateTime(2015, 8, 16, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5597), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 315, 3150m, 3, 3, null, new DateTime(2015, 8, 26, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5595), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 313, 3130m, 3, 3, null, new DateTime(2015, 9, 5, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5593), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 308, 3070m, 3, 5, null, new DateTime(2015, 9, 30, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5587), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 312, 3110m, 3, 7, null, new DateTime(2015, 9, 10, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5591), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 310, 3090m, 3, 6, null, new DateTime(2015, 9, 20, 15, 56, 25, 748, DateTimeKind.Local).AddTicks(5589), 2 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 12 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 14 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 12 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 12 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 12 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 14 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 14 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 14 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 12 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 12 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 12 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 11 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 2, 12 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 11 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 11 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 11 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 11 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 11 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 11 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 11 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 9 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 14 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 2, 11 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 12 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 14 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 18 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 14 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 18 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 9 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 18 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 18 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 18 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 18 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 18 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 18 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 17 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 17 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 17 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 14 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 17 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 17 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 17 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 17 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 15 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 15 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 15 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 15 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 15 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 15 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 15 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 15 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 17 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 9 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 2 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 9 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 5 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 3 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 3 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 3 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 3 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 3 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 5 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 3 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 2 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 2 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 2 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 20 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 9 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 5 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 5 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 9 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 9 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 9 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 2, 9 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 8 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 8 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 8 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 8 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 8 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 8 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 8 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 5 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 8 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 6 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 6 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 6 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 6 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 6 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 6 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 6 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 3, 6 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 2, 6 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 1, 6 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 5 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 2, 8 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 20 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 47 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 20 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 41 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 41 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 41 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 39 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 39 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 39 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 39 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 38 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 38 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 38 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 38 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 36 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 36 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 36 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 36 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 36 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 35 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 35 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 35 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 35 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 35 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 33 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 33 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 41 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 42 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 42 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 42 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 60 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 59 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 57 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 56 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 54 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 54 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 53 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 53 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 51 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 51 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 50 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 33 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 50 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 48 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 48 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 47 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 47 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 45 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 45 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 45 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 44 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 44 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 44 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 42 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 48 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 33 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 33 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 32 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 24 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 24 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 24 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 24 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 24 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 24 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 24 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 23 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 23 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 23 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 23 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 26 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 23 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 23 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 21 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 21 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 21 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 21 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 21 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 21 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 4, 21 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 20 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 20 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 20 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 23 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 20 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 26 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 26 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 32 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 32 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 32 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 32 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 30 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 30 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 30 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 30 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 30 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 30 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 29 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 26 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 29 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 29 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 29 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 29 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 27 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 27 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 27 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 7, 27 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 6, 27 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 5, 27 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 10, 26 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 9, 26 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 8, 29 });

            migrationBuilder.InsertData(
                table: "UserCategory",
                columns: new[] { "UserId", "CategoryId" },
                values: new object[] { 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserId",
                table: "Assets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AssetId",
                table: "Transactions",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategory_CategoryId",
                table: "UserCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserCategory");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
