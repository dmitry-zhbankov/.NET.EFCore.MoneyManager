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
                values: new object[] { 379, 3790m, 4, 4, null, new DateTime(2014, 10, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4884), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 511, 5110m, 6, 6, null, new DateTime(2012, 12, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5074), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 513, 5130m, 6, 6, null, new DateTime(2012, 12, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5076), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 515, 5150m, 6, 6, null, new DateTime(2012, 11, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5257), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 566, 5650m, 6, 8, null, new DateTime(2012, 3, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5338), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 568, 5670m, 6, 9, null, new DateTime(2012, 3, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5340), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 570, 5690m, 6, 10, null, new DateTime(2012, 2, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5343), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 571, 5710m, 6, 6, null, new DateTime(2012, 2, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5344), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 573, 5730m, 6, 6, null, new DateTime(2012, 2, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5346), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 575, 5750m, 6, 6, null, new DateTime(2012, 2, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5349), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 32, 310m, 7, 9, null, new DateTime(2019, 7, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4342), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 34, 330m, 7, 10, null, new DateTime(2019, 7, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4346), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 36, 350m, 7, 11, null, new DateTime(2019, 6, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4348), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 37, 370m, 7, 7, null, new DateTime(2019, 6, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4349), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 39, 390m, 7, 7, null, new DateTime(2019, 6, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4352), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 41, 410m, 7, 7, null, new DateTime(2019, 5, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4354), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 92, 910m, 7, 9, null, new DateTime(2018, 9, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4469), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 94, 930m, 7, 10, null, new DateTime(2018, 9, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4471), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 96, 950m, 7, 11, null, new DateTime(2018, 8, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4473), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 97, 970m, 7, 7, null, new DateTime(2018, 8, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4475), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 99, 990m, 7, 7, null, new DateTime(2018, 8, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4477), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 101, 1010m, 7, 7, null, new DateTime(2018, 8, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4479), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 510, 5090m, 6, 10, null, new DateTime(2012, 12, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5073), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 508, 5070m, 6, 9, null, new DateTime(2013, 1, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5071), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 506, 5050m, 6, 8, null, new DateTime(2013, 1, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5068), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 455, 4550m, 6, 6, null, new DateTime(2013, 9, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5008), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 268, 2670m, 6, 9, null, new DateTime(2016, 4, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4754), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 270, 2690m, 6, 10, null, new DateTime(2016, 4, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4756), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 271, 2710m, 6, 6, null, new DateTime(2016, 4, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4757), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 273, 2730m, 6, 6, null, new DateTime(2016, 3, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4760), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 275, 2750m, 6, 6, null, new DateTime(2016, 3, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4762), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 326, 3250m, 6, 8, null, new DateTime(2015, 7, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4822), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 328, 3270m, 6, 9, null, new DateTime(2015, 6, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4824), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 330, 3290m, 6, 10, null, new DateTime(2015, 6, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4826), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 331, 3310m, 6, 6, null, new DateTime(2015, 6, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4827), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 333, 3330m, 6, 6, null, new DateTime(2015, 5, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4830), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 152, 1510m, 7, 9, null, new DateTime(2017, 11, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4541), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 335, 3350m, 6, 6, null, new DateTime(2015, 5, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4832), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 388, 3870m, 6, 9, null, new DateTime(2014, 8, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4894), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 390, 3890m, 6, 10, null, new DateTime(2014, 8, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4897), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 391, 3910m, 6, 6, null, new DateTime(2014, 8, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4898), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 393, 3930m, 6, 6, null, new DateTime(2014, 8, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4900), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 395, 3950m, 6, 6, null, new DateTime(2014, 7, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4903), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 446, 4450m, 6, 8, null, new DateTime(2013, 11, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4997), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 448, 4470m, 6, 9, null, new DateTime(2013, 10, 31, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5000), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 450, 4490m, 6, 10, null, new DateTime(2013, 10, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5002), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 451, 4510m, 6, 6, null, new DateTime(2013, 10, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5003), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 453, 4530m, 6, 6, null, new DateTime(2013, 10, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5006), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 386, 3850m, 6, 8, null, new DateTime(2014, 9, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4892), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 266, 2650m, 6, 8, null, new DateTime(2016, 4, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4751), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 154, 1530m, 7, 10, null, new DateTime(2017, 11, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4543), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 157, 1570m, 7, 7, null, new DateTime(2017, 10, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4547), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 452, 4510m, 7, 9, null, new DateTime(2013, 10, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5004), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 454, 4530m, 7, 10, null, new DateTime(2013, 10, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5007), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 456, 4550m, 7, 11, null, new DateTime(2013, 9, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5009), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 457, 4570m, 7, 7, null, new DateTime(2013, 9, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5010), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 459, 4590m, 7, 7, null, new DateTime(2013, 9, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5013), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 461, 4610m, 7, 7, null, new DateTime(2013, 8, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5015), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 512, 5110m, 7, 9, null, new DateTime(2012, 12, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5075), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 514, 5130m, 7, 10, null, new DateTime(2012, 12, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5255), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 516, 5150m, 7, 11, null, new DateTime(2012, 11, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5258), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 517, 5170m, 7, 7, null, new DateTime(2012, 11, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5259), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 519, 5190m, 7, 7, null, new DateTime(2012, 11, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5261), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 521, 5210m, 7, 7, null, new DateTime(2012, 10, 31, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5264), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 572, 5710m, 7, 9, null, new DateTime(2012, 2, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5345), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 574, 5730m, 7, 10, null, new DateTime(2012, 2, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5348), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 576, 5750m, 7, 11, null, new DateTime(2012, 1, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5350), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 577, 5770m, 7, 7, null, new DateTime(2012, 1, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5351), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 579, 5790m, 7, 7, null, new DateTime(2012, 1, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5354), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 581, 5810m, 7, 7, null, new DateTime(2012, 1, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5356), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 38, 370m, 8, 10, null, new DateTime(2019, 6, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4350), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 40, 390m, 8, 11, null, new DateTime(2019, 6, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4353), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 42, 410m, 8, 12, null, new DateTime(2019, 5, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4355), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 401, 4010m, 7, 7, null, new DateTime(2014, 6, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4944), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 399, 3990m, 7, 7, null, new DateTime(2014, 7, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4942), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 397, 3970m, 7, 7, null, new DateTime(2014, 7, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4940), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 396, 3950m, 7, 11, null, new DateTime(2014, 7, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4939), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 159, 1590m, 7, 7, null, new DateTime(2017, 10, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4549), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 161, 1610m, 7, 7, null, new DateTime(2017, 10, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4551), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 212, 2110m, 7, 9, null, new DateTime(2017, 1, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4646), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 214, 2130m, 7, 10, null, new DateTime(2017, 1, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4648), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 216, 2150m, 7, 11, null, new DateTime(2017, 1, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4651), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 217, 2170m, 7, 7, null, new DateTime(2016, 12, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4652), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 219, 2190m, 7, 7, null, new DateTime(2016, 12, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4654), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 221, 2210m, 7, 7, null, new DateTime(2016, 12, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4657), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 272, 2710m, 7, 9, null, new DateTime(2016, 3, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4759), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 274, 2730m, 7, 10, null, new DateTime(2016, 3, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4761), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 156, 1550m, 7, 11, null, new DateTime(2017, 10, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4545), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 276, 2750m, 7, 11, null, new DateTime(2016, 3, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4763), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 279, 2790m, 7, 7, null, new DateTime(2016, 2, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4767), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 281, 2810m, 7, 7, null, new DateTime(2016, 2, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4769), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 332, 3310m, 7, 9, null, new DateTime(2015, 6, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4829), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 334, 3330m, 7, 10, null, new DateTime(2015, 5, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4831), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 336, 3350m, 7, 11, null, new DateTime(2015, 5, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4833), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 337, 3370m, 7, 7, null, new DateTime(2015, 5, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4835), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 339, 3390m, 7, 7, null, new DateTime(2015, 4, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4837), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 341, 3410m, 7, 7, null, new DateTime(2015, 4, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4839), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 392, 3910m, 7, 9, null, new DateTime(2014, 8, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4899), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 394, 3930m, 7, 10, null, new DateTime(2014, 7, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4902), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 277, 2770m, 7, 7, null, new DateTime(2016, 3, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4764), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 215, 2150m, 6, 6, null, new DateTime(2017, 1, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4650), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 213, 2130m, 6, 6, null, new DateTime(2017, 1, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4647), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 211, 2110m, 6, 6, null, new DateTime(2017, 1, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4645), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 84, 830m, 5, 9, null, new DateTime(2018, 10, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4458), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 85, 850m, 5, 5, null, new DateTime(2018, 10, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4459), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 87, 870m, 5, 5, null, new DateTime(2018, 10, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4462), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 89, 890m, 5, 5, null, new DateTime(2018, 9, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4465), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 140, 1390m, 5, 7, null, new DateTime(2018, 1, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4527), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 142, 1410m, 5, 8, null, new DateTime(2018, 1, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4529), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 144, 1430m, 5, 9, null, new DateTime(2017, 12, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4531), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 145, 1450m, 5, 5, null, new DateTime(2017, 12, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4532), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 147, 1470m, 5, 5, null, new DateTime(2017, 12, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4535), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 149, 1490m, 5, 5, null, new DateTime(2017, 12, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4537), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 200, 1990m, 5, 7, null, new DateTime(2017, 3, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4632), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 202, 2010m, 5, 8, null, new DateTime(2017, 3, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4634), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 204, 2030m, 5, 9, null, new DateTime(2017, 3, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4637), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 205, 2050m, 5, 5, null, new DateTime(2017, 2, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4638), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 207, 2070m, 5, 5, null, new DateTime(2017, 2, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4640), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 209, 2090m, 5, 5, null, new DateTime(2017, 2, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4643), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 260, 2590m, 5, 7, null, new DateTime(2016, 5, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4744), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 262, 2610m, 5, 8, null, new DateTime(2016, 5, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4747), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 264, 2630m, 5, 9, null, new DateTime(2016, 5, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4749), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 265, 2650m, 5, 5, null, new DateTime(2016, 5, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4750), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 267, 2670m, 5, 5, null, new DateTime(2016, 4, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4753), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 82, 810m, 5, 8, null, new DateTime(2018, 11, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4455), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 80, 790m, 5, 7, null, new DateTime(2018, 11, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4453), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 29, 290m, 5, 5, null, new DateTime(2019, 7, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4339), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 27, 270m, 5, 5, null, new DateTime(2019, 8, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4336), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 434, 4330m, 4, 6, null, new DateTime(2014, 1, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4983), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 436, 4350m, 4, 7, null, new DateTime(2013, 12, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4986), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 438, 4370m, 4, 8, null, new DateTime(2013, 12, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4988), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 439, 4390m, 4, 4, null, new DateTime(2013, 12, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4989), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 441, 4410m, 4, 4, null, new DateTime(2013, 12, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4991), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 443, 4430m, 4, 4, null, new DateTime(2013, 11, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4994), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 494, 4930m, 4, 6, null, new DateTime(2013, 3, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5054), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 496, 4950m, 4, 7, null, new DateTime(2013, 3, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5057), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 498, 4970m, 4, 8, null, new DateTime(2013, 2, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5059), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 499, 4990m, 4, 4, null, new DateTime(2013, 2, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5060), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 269, 2690m, 5, 5, null, new DateTime(2016, 4, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4755), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 501, 5010m, 4, 4, null, new DateTime(2013, 2, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5062), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 554, 5530m, 4, 6, null, new DateTime(2012, 5, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5324), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 556, 5550m, 4, 7, null, new DateTime(2012, 5, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5326), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 558, 5570m, 4, 8, null, new DateTime(2012, 4, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5328), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 559, 5590m, 4, 4, null, new DateTime(2012, 4, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5330), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 561, 5610m, 4, 4, null, new DateTime(2012, 4, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5332), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 563, 5630m, 4, 4, null, new DateTime(2012, 4, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5334), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 20, 190m, 5, 7, null, new DateTime(2019, 9, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4328), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 22, 210m, 5, 8, null, new DateTime(2019, 8, 31, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4330), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 24, 230m, 5, 9, null, new DateTime(2019, 8, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4333), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 25, 250m, 5, 5, null, new DateTime(2019, 8, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4334), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 503, 5030m, 4, 4, null, new DateTime(2013, 1, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5065), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 320, 3190m, 5, 7, null, new DateTime(2015, 8, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4815), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 322, 3210m, 5, 8, null, new DateTime(2015, 7, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4817), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 324, 3230m, 5, 9, null, new DateTime(2015, 7, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4819), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 569, 5690m, 5, 5, null, new DateTime(2012, 3, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5341), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 26, 250m, 6, 8, null, new DateTime(2019, 8, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4335), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 28, 270m, 6, 9, null, new DateTime(2019, 8, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4338), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 30, 290m, 6, 10, null, new DateTime(2019, 7, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4340), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 31, 310m, 6, 6, null, new DateTime(2019, 7, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4341), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 33, 330m, 6, 6, null, new DateTime(2019, 7, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4343), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 35, 350m, 6, 6, null, new DateTime(2019, 6, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4347), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 86, 850m, 6, 8, null, new DateTime(2018, 10, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4461), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 88, 870m, 6, 9, null, new DateTime(2018, 10, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4463), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 90, 890m, 6, 10, null, new DateTime(2018, 9, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4466), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 567, 5670m, 5, 5, null, new DateTime(2012, 3, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5339), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 91, 910m, 6, 6, null, new DateTime(2018, 9, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4467), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 95, 950m, 6, 6, null, new DateTime(2018, 8, 31, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4472), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 146, 1450m, 6, 8, null, new DateTime(2017, 12, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4534), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 148, 1470m, 6, 9, null, new DateTime(2017, 12, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4536), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 150, 1490m, 6, 10, null, new DateTime(2017, 11, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4538), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 151, 1510m, 6, 6, null, new DateTime(2017, 11, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4540), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 153, 1530m, 6, 6, null, new DateTime(2017, 11, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4542), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 155, 1550m, 6, 6, null, new DateTime(2017, 11, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4544), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 206, 2050m, 6, 8, null, new DateTime(2017, 2, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4639), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 208, 2070m, 6, 9, null, new DateTime(2017, 2, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4641), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 210, 2090m, 6, 10, null, new DateTime(2017, 2, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4644), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 93, 930m, 6, 6, null, new DateTime(2018, 9, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4470), 6 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 43, 430m, 8, 8, null, new DateTime(2019, 5, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4356), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 565, 5650m, 5, 5, null, new DateTime(2012, 3, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5337), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 562, 5610m, 5, 8, null, new DateTime(2012, 4, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5333), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 325, 3250m, 5, 5, null, new DateTime(2015, 7, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4821), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 327, 3270m, 5, 5, null, new DateTime(2015, 6, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4823), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 329, 3290m, 5, 5, null, new DateTime(2015, 6, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4825), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 380, 3790m, 5, 7, null, new DateTime(2014, 10, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4885), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 382, 3810m, 5, 8, null, new DateTime(2014, 9, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4887), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 384, 3830m, 5, 9, null, new DateTime(2014, 9, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4890), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 385, 3850m, 5, 5, null, new DateTime(2014, 9, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4891), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 387, 3870m, 5, 5, null, new DateTime(2014, 9, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4893), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 389, 3890m, 5, 5, null, new DateTime(2014, 8, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4896), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 440, 4390m, 5, 7, null, new DateTime(2013, 12, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4990), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 564, 5630m, 5, 9, null, new DateTime(2012, 3, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5335), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 442, 4410m, 5, 8, null, new DateTime(2013, 11, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4993), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 445, 4450m, 5, 5, null, new DateTime(2013, 11, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4996), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 447, 4470m, 5, 5, null, new DateTime(2013, 11, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4998), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 449, 4490m, 5, 5, null, new DateTime(2013, 10, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5001), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 500, 4990m, 5, 7, null, new DateTime(2013, 2, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5061), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 502, 5010m, 5, 8, null, new DateTime(2013, 2, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5064), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 504, 5030m, 5, 9, null, new DateTime(2013, 1, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5066), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 505, 5050m, 5, 5, null, new DateTime(2013, 1, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5067), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 507, 5070m, 5, 5, null, new DateTime(2013, 1, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5069), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 509, 5090m, 5, 5, null, new DateTime(2012, 12, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5072), 5 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 560, 5590m, 5, 7, null, new DateTime(2012, 4, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5331), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 444, 4430m, 5, 9, null, new DateTime(2013, 11, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4995), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 383, 3830m, 4, 4, null, new DateTime(2014, 9, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4889), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 45, 450m, 8, 8, null, new DateTime(2019, 5, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4358), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 98, 970m, 8, 10, null, new DateTime(2018, 8, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4476), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 177, 1770m, 10, 10, null, new DateTime(2017, 7, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4570), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 179, 1790m, 10, 10, null, new DateTime(2017, 7, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4607), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 230, 2290m, 10, 12, null, new DateTime(2016, 10, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4667), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 232, 2310m, 10, 13, null, new DateTime(2016, 10, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4670), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 234, 2330m, 10, 14, null, new DateTime(2016, 10, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4672), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 235, 2350m, 10, 10, null, new DateTime(2016, 9, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4673), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 237, 2370m, 10, 10, null, new DateTime(2016, 9, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4676), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 239, 2390m, 10, 10, null, new DateTime(2016, 9, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4678), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 290, 2890m, 10, 12, null, new DateTime(2015, 12, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4780), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 292, 2910m, 10, 13, null, new DateTime(2015, 12, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4782), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 294, 2930m, 10, 14, null, new DateTime(2015, 12, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4784), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 295, 2950m, 10, 10, null, new DateTime(2015, 12, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4785), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 297, 2970m, 10, 10, null, new DateTime(2015, 11, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4788), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 299, 2990m, 10, 10, null, new DateTime(2015, 11, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4790), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 350, 3490m, 10, 12, null, new DateTime(2015, 3, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4850), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 352, 3510m, 10, 13, null, new DateTime(2015, 2, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4852), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 354, 3530m, 10, 14, null, new DateTime(2015, 2, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4854), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 355, 3550m, 10, 10, null, new DateTime(2015, 2, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4856), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 357, 3570m, 10, 10, null, new DateTime(2015, 1, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4858), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 359, 3590m, 10, 10, null, new DateTime(2015, 1, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4860), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 410, 4090m, 10, 12, null, new DateTime(2014, 5, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4955), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 175, 1750m, 10, 10, null, new DateTime(2017, 7, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4567), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 174, 1730m, 10, 14, null, new DateTime(2017, 8, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4566), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 172, 1710m, 10, 13, null, new DateTime(2017, 8, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4564), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 170, 1690m, 10, 12, null, new DateTime(2017, 8, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4562), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 528, 5270m, 9, 13, null, new DateTime(2012, 9, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5272), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 529, 5290m, 9, 9, null, new DateTime(2012, 9, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5274), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 531, 5310m, 9, 9, null, new DateTime(2012, 9, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5276), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 533, 5330m, 9, 9, null, new DateTime(2012, 9, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5278), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 584, 5830m, 9, 11, null, new DateTime(2011, 12, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5359), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 586, 5850m, 9, 12, null, new DateTime(2011, 12, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5362), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 588, 5870m, 9, 13, null, new DateTime(2011, 12, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5364), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 589, 5890m, 9, 9, null, new DateTime(2011, 11, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5365), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 591, 5910m, 9, 9, null, new DateTime(2011, 11, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5368), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 593, 5930m, 9, 9, null, new DateTime(2011, 11, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5370), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 412, 4110m, 10, 13, null, new DateTime(2014, 4, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4957), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 50, 490m, 10, 12, null, new DateTime(2019, 4, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4365), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 54, 530m, 10, 14, null, new DateTime(2019, 3, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4369), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 55, 550m, 10, 10, null, new DateTime(2019, 3, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4370), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 57, 570m, 10, 10, null, new DateTime(2019, 3, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4373), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 59, 590m, 10, 10, null, new DateTime(2019, 2, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4375), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 110, 1090m, 10, 12, null, new DateTime(2018, 6, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4490), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 112, 1110m, 10, 13, null, new DateTime(2018, 6, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4492), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 114, 1130m, 10, 14, null, new DateTime(2018, 5, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4494), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 115, 1150m, 10, 10, null, new DateTime(2018, 5, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4496), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 117, 1170m, 10, 10, null, new DateTime(2018, 5, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4498), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 119, 1190m, 10, 10, null, new DateTime(2018, 5, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4500), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 52, 510m, 10, 13, null, new DateTime(2019, 4, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4367), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 526, 5250m, 9, 12, null, new DateTime(2012, 10, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5270), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 414, 4130m, 10, 14, null, new DateTime(2014, 4, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4960), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 417, 4170m, 10, 10, null, new DateTime(2014, 4, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4963), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 178, 1770m, 11, 14, null, new DateTime(2017, 7, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4606), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 180, 1790m, 11, 15, null, new DateTime(2017, 7, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4609), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 236, 2350m, 11, 13, null, new DateTime(2016, 9, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4674), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 238, 2370m, 11, 14, null, new DateTime(2016, 9, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4677), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 240, 2390m, 11, 15, null, new DateTime(2016, 9, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4679), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 296, 2950m, 11, 13, null, new DateTime(2015, 11, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4787), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 298, 2970m, 11, 14, null, new DateTime(2015, 11, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4789), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 300, 2990m, 11, 15, null, new DateTime(2015, 11, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4791), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 356, 3550m, 11, 13, null, new DateTime(2015, 2, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4857), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 358, 3570m, 11, 14, null, new DateTime(2015, 1, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4859), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 360, 3590m, 11, 15, null, new DateTime(2015, 1, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4861), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 416, 4150m, 11, 13, null, new DateTime(2014, 4, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4962), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 418, 4170m, 11, 14, null, new DateTime(2014, 3, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4964), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 420, 4190m, 11, 15, null, new DateTime(2014, 3, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4967), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 476, 4750m, 11, 13, null, new DateTime(2013, 6, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5033), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 478, 4770m, 11, 14, null, new DateTime(2013, 6, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5035), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 480, 4790m, 11, 15, null, new DateTime(2013, 5, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5038), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 536, 5350m, 11, 13, null, new DateTime(2012, 8, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5282), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 538, 5370m, 11, 14, null, new DateTime(2012, 8, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5284), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 540, 5390m, 11, 15, null, new DateTime(2012, 7, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5287), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 596, 5950m, 11, 13, null, new DateTime(2011, 10, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5374), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 176, 1750m, 11, 13, null, new DateTime(2017, 7, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4569), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 120, 1190m, 11, 15, null, new DateTime(2018, 4, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4501), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 118, 1170m, 11, 14, null, new DateTime(2018, 5, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4499), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 116, 1150m, 11, 13, null, new DateTime(2018, 5, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4497), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 419, 4190m, 10, 10, null, new DateTime(2014, 3, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4966), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 470, 4690m, 10, 12, null, new DateTime(2013, 7, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5026), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 472, 4710m, 10, 13, null, new DateTime(2013, 7, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5028), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 474, 4730m, 10, 14, null, new DateTime(2013, 6, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5031), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 475, 4750m, 10, 10, null, new DateTime(2013, 6, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5032), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 477, 4770m, 10, 10, null, new DateTime(2013, 6, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5034), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 479, 4790m, 10, 10, null, new DateTime(2013, 5, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5037), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 530, 5290m, 10, 12, null, new DateTime(2012, 9, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5275), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 532, 5310m, 10, 13, null, new DateTime(2012, 9, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5277), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 534, 5330m, 10, 14, null, new DateTime(2012, 8, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5280), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 415, 4150m, 10, 10, null, new DateTime(2014, 4, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4961), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 535, 5350m, 10, 10, null, new DateTime(2012, 8, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5281), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 539, 5390m, 10, 10, null, new DateTime(2012, 8, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5286), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 590, 5890m, 10, 12, null, new DateTime(2011, 11, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5367), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 592, 5910m, 10, 13, null, new DateTime(2011, 11, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5369), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 594, 5930m, 10, 14, null, new DateTime(2011, 11, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5371), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 595, 5950m, 10, 10, null, new DateTime(2011, 10, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5372), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 597, 5970m, 10, 10, null, new DateTime(2011, 10, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5375), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 599, 5990m, 10, 10, null, new DateTime(2011, 10, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5377), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 56, 550m, 11, 13, null, new DateTime(2019, 3, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4372), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 58, 570m, 11, 14, null, new DateTime(2019, 3, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4374), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 60, 590m, 11, 15, null, new DateTime(2019, 2, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4376), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 537, 5370m, 10, 10, null, new DateTime(2012, 8, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5283), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 524, 5230m, 9, 11, null, new DateTime(2012, 10, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5268), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 473, 4730m, 9, 9, null, new DateTime(2013, 6, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5030), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 471, 4710m, 9, 9, null, new DateTime(2013, 7, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5027), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 343, 3430m, 8, 8, null, new DateTime(2015, 4, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4842), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 345, 3450m, 8, 8, null, new DateTime(2015, 3, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4844), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 347, 3470m, 8, 8, null, new DateTime(2015, 3, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4846), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 398, 3970m, 8, 10, null, new DateTime(2014, 7, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4941), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 400, 3990m, 8, 11, null, new DateTime(2014, 6, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4943), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 402, 4010m, 8, 12, null, new DateTime(2014, 6, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4946), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 403, 4030m, 8, 8, null, new DateTime(2014, 6, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4947), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 405, 4050m, 8, 8, null, new DateTime(2014, 6, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4949), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 407, 4070m, 8, 8, null, new DateTime(2014, 5, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4951), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 458, 4570m, 8, 10, null, new DateTime(2013, 9, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5012), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 460, 4590m, 8, 11, null, new DateTime(2013, 9, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5014), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 462, 4610m, 8, 12, null, new DateTime(2013, 8, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5016), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 463, 4630m, 8, 8, null, new DateTime(2013, 8, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5018), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 465, 4650m, 8, 8, null, new DateTime(2013, 8, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5020), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 467, 4670m, 8, 8, null, new DateTime(2013, 7, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5022), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 518, 5170m, 8, 10, null, new DateTime(2012, 11, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5260), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 520, 5190m, 8, 11, null, new DateTime(2012, 11, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5263), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 522, 5210m, 8, 12, null, new DateTime(2012, 10, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5265), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 523, 5230m, 8, 8, null, new DateTime(2012, 10, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5266), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 525, 5250m, 8, 8, null, new DateTime(2012, 10, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5269), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 527, 5270m, 8, 8, null, new DateTime(2012, 10, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5271), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 342, 3410m, 8, 12, null, new DateTime(2015, 4, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4840), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 340, 3390m, 8, 11, null, new DateTime(2015, 4, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4838), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 338, 3370m, 8, 10, null, new DateTime(2015, 5, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4836), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 287, 2870m, 8, 8, null, new DateTime(2016, 1, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4776), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 100, 990m, 8, 11, null, new DateTime(2018, 8, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4478), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 102, 1010m, 8, 12, null, new DateTime(2018, 7, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4480), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 103, 1030m, 8, 8, null, new DateTime(2018, 7, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4482), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 105, 1050m, 8, 8, null, new DateTime(2018, 7, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4484), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 107, 1070m, 8, 8, null, new DateTime(2018, 7, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4486), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 158, 1570m, 8, 10, null, new DateTime(2017, 10, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4548), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 160, 1590m, 8, 11, null, new DateTime(2017, 10, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4550), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 162, 1610m, 8, 12, null, new DateTime(2017, 9, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4552), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 163, 1630m, 8, 8, null, new DateTime(2017, 9, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4554), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 165, 1650m, 8, 8, null, new DateTime(2017, 9, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4556), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 578, 5770m, 8, 10, null, new DateTime(2012, 1, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5352), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 167, 1670m, 8, 8, null, new DateTime(2017, 9, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4558), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 220, 2190m, 8, 11, null, new DateTime(2016, 12, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4655), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 222, 2210m, 8, 12, null, new DateTime(2016, 12, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4658), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 223, 2230m, 8, 8, null, new DateTime(2016, 11, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4659), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 225, 2250m, 8, 8, null, new DateTime(2016, 11, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4661), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 227, 2270m, 8, 8, null, new DateTime(2016, 11, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4664), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 278, 2770m, 8, 10, null, new DateTime(2016, 2, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4766), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 280, 2790m, 8, 11, null, new DateTime(2016, 2, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4768), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 282, 2810m, 8, 12, null, new DateTime(2016, 2, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4770), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 283, 2830m, 8, 8, null, new DateTime(2016, 2, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4772), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 285, 2850m, 8, 8, null, new DateTime(2016, 1, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4774), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 218, 2170m, 8, 10, null, new DateTime(2016, 12, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4653), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 580, 5790m, 8, 11, null, new DateTime(2012, 1, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5355), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 582, 5810m, 8, 12, null, new DateTime(2011, 12, 31, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5357), 7 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 583, 5830m, 8, 8, null, new DateTime(2011, 12, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5358), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 284, 2830m, 9, 11, null, new DateTime(2016, 1, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4773), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 286, 2850m, 9, 12, null, new DateTime(2016, 1, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4775), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 288, 2870m, 9, 13, null, new DateTime(2016, 1, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4777), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 289, 2890m, 9, 9, null, new DateTime(2016, 1, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4779), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 291, 2910m, 9, 9, null, new DateTime(2015, 12, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4781), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 293, 2930m, 9, 9, null, new DateTime(2015, 12, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4783), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 344, 3430m, 9, 11, null, new DateTime(2015, 4, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4843), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 346, 3450m, 9, 12, null, new DateTime(2015, 3, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4845), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 348, 3470m, 9, 13, null, new DateTime(2015, 3, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4847), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 349, 3490m, 9, 9, null, new DateTime(2015, 3, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4849), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 233, 2330m, 9, 9, null, new DateTime(2016, 10, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4671), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 351, 3510m, 9, 9, null, new DateTime(2015, 2, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4851), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 404, 4030m, 9, 11, null, new DateTime(2014, 6, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4948), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 406, 4050m, 9, 12, null, new DateTime(2014, 5, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4950), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 408, 4070m, 9, 13, null, new DateTime(2014, 5, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4953), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 409, 4090m, 9, 9, null, new DateTime(2014, 5, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4954), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 411, 4110m, 9, 9, null, new DateTime(2014, 5, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4956), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 413, 4130m, 9, 9, null, new DateTime(2014, 4, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4959), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 464, 4630m, 9, 11, null, new DateTime(2013, 8, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5019), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 466, 4650m, 9, 12, null, new DateTime(2013, 8, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5021), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 468, 4670m, 9, 13, null, new DateTime(2013, 7, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5024), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 469, 4690m, 9, 9, null, new DateTime(2013, 7, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5025), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 353, 3530m, 9, 9, null, new DateTime(2015, 2, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4853), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 47, 470m, 8, 8, null, new DateTime(2019, 4, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4361), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 231, 2310m, 9, 9, null, new DateTime(2016, 10, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4669), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 228, 2270m, 9, 13, null, new DateTime(2016, 11, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4665), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 585, 5850m, 8, 8, null, new DateTime(2011, 12, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5361), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 587, 5870m, 8, 8, null, new DateTime(2011, 12, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5363), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 44, 430m, 9, 11, null, new DateTime(2019, 5, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4357), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 46, 450m, 9, 12, null, new DateTime(2019, 5, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4360), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 48, 470m, 9, 13, null, new DateTime(2019, 4, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4362), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 49, 490m, 9, 9, null, new DateTime(2019, 4, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4363), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 51, 510m, 9, 9, null, new DateTime(2019, 4, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4366), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 53, 530m, 9, 9, null, new DateTime(2019, 3, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4368), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 104, 1030m, 9, 11, null, new DateTime(2018, 7, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4483), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 106, 1050m, 9, 12, null, new DateTime(2018, 7, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4485), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 229, 2290m, 9, 9, null, new DateTime(2016, 10, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4666), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 108, 1070m, 9, 13, null, new DateTime(2018, 6, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4487), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 111, 1110m, 9, 9, null, new DateTime(2018, 6, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4491), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 113, 1130m, 9, 9, null, new DateTime(2018, 6, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4493), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 164, 1630m, 9, 11, null, new DateTime(2017, 9, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4555), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 166, 1650m, 9, 12, null, new DateTime(2017, 9, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4557), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 168, 1670m, 9, 13, null, new DateTime(2017, 8, 31, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4559), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 169, 1690m, 9, 9, null, new DateTime(2017, 8, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4561), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 171, 1710m, 9, 9, null, new DateTime(2017, 8, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4563), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 173, 1730m, 9, 9, null, new DateTime(2017, 8, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4565), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 224, 2230m, 9, 11, null, new DateTime(2016, 11, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4660), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 226, 2250m, 9, 12, null, new DateTime(2016, 11, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4662), 8 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 109, 1090m, 9, 9, null, new DateTime(2018, 6, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4489), 9 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 381, 3810m, 4, 4, null, new DateTime(2014, 10, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4886), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 600, 5990m, 11, 15, null, new DateTime(2011, 10, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5378), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 378, 3770m, 4, 8, null, new DateTime(2014, 10, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4883), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 364, 3630m, 2, 5, null, new DateTime(2014, 12, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4866), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 362, 3610m, 2, 4, null, new DateTime(2015, 1, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4864), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 311, 3110m, 2, 2, null, new DateTime(2015, 9, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4804), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 309, 3090m, 2, 2, null, new DateTime(2015, 9, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4802), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 307, 3070m, 2, 2, null, new DateTime(2015, 10, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4799), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 306, 3050m, 2, 6, null, new DateTime(2015, 10, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4798), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 304, 3030m, 2, 5, null, new DateTime(2015, 10, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4796), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 302, 3010m, 2, 4, null, new DateTime(2015, 10, 31, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4794), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 251, 2510m, 2, 2, null, new DateTime(2016, 7, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4692), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 366, 3650m, 2, 6, null, new DateTime(2014, 12, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4868), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 249, 2490m, 2, 2, null, new DateTime(2016, 7, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4690), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 246, 2450m, 2, 6, null, new DateTime(2016, 8, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4686), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 244, 2430m, 2, 5, null, new DateTime(2016, 8, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4684), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 242, 2410m, 2, 4, null, new DateTime(2016, 8, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4682), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 191, 1910m, 2, 2, null, new DateTime(2017, 5, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4622), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 189, 1890m, 2, 2, null, new DateTime(2017, 5, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4619), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 187, 1870m, 2, 2, null, new DateTime(2017, 5, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4617), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 186, 1850m, 2, 6, null, new DateTime(2017, 6, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4616), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 184, 1830m, 2, 5, null, new DateTime(2017, 6, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4613), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 182, 1810m, 2, 4, null, new DateTime(2017, 6, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4611), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 247, 2470m, 2, 2, null, new DateTime(2016, 8, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4687), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 131, 1310m, 2, 2, null, new DateTime(2018, 3, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4516), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 367, 3670m, 2, 2, null, new DateTime(2014, 12, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4870), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 371, 3710m, 2, 2, null, new DateTime(2014, 11, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4874), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 10, 90m, 3, 6, null, new DateTime(2019, 10, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4314), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 8, 70m, 3, 5, null, new DateTime(2019, 11, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4311), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 551, 5510m, 2, 2, null, new DateTime(2012, 6, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5320), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 549, 5490m, 2, 2, null, new DateTime(2012, 6, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5318), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 547, 5470m, 2, 2, null, new DateTime(2012, 6, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5315), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 546, 5450m, 2, 6, null, new DateTime(2012, 6, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5314), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 544, 5430m, 2, 5, null, new DateTime(2012, 7, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5312), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 542, 5410m, 2, 4, null, new DateTime(2012, 7, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5310), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 491, 4910m, 2, 2, null, new DateTime(2013, 3, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5051), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 369, 3690m, 2, 2, null, new DateTime(2014, 11, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4872), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 489, 4890m, 2, 2, null, new DateTime(2013, 4, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5048), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 486, 4850m, 2, 6, null, new DateTime(2013, 4, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5045), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 484, 4830m, 2, 5, null, new DateTime(2013, 5, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5043), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 482, 4810m, 2, 4, null, new DateTime(2013, 5, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5040), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 431, 4310m, 2, 2, null, new DateTime(2014, 1, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4980), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 429, 4290m, 2, 2, null, new DateTime(2014, 2, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4978), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 427, 4270m, 2, 2, null, new DateTime(2014, 2, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4975), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 426, 4250m, 2, 6, null, new DateTime(2014, 2, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4974), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 424, 4230m, 2, 5, null, new DateTime(2014, 2, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4972), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 422, 4210m, 2, 4, null, new DateTime(2014, 3, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4969), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 487, 4870m, 2, 2, null, new DateTime(2013, 4, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5046), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 12, 110m, 3, 7, null, new DateTime(2019, 10, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4317), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 129, 1290m, 2, 2, null, new DateTime(2018, 3, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4512), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 126, 1250m, 2, 6, null, new DateTime(2018, 3, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4509), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 361, 3610m, 1, 1, null, new DateTime(2015, 1, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4863), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 305, 3050m, 1, 1, null, new DateTime(2015, 10, 16, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4797), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 303, 3030m, 1, 1, null, new DateTime(2015, 10, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4795), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 301, 3010m, 1, 1, null, new DateTime(2015, 11, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4792), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 245, 2450m, 1, 1, null, new DateTime(2016, 8, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4685), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 243, 2430m, 1, 1, null, new DateTime(2016, 8, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4683), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 241, 2410m, 1, 1, null, new DateTime(2016, 8, 31, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4680), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 185, 1850m, 1, 1, null, new DateTime(2017, 6, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4615), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 183, 1830m, 1, 1, null, new DateTime(2017, 6, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4612), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 363, 3630m, 1, 1, null, new DateTime(2014, 12, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4865), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 181, 1810m, 1, 1, null, new DateTime(2017, 6, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4610), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 123, 1230m, 1, 1, null, new DateTime(2018, 4, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4505), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 121, 1210m, 1, 1, null, new DateTime(2018, 4, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4503), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 65, 650m, 1, 1, null, new DateTime(2019, 1, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4382), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 63, 630m, 1, 1, null, new DateTime(2019, 2, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4380), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 61, 610m, 1, 1, null, new DateTime(2019, 2, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4378), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 5, 50m, 1, 1, null, new DateTime(2019, 11, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4303), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 3, 30m, 1, 1, null, new DateTime(2019, 12, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4299), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 1, 10m, 1, 1, null, new DateTime(2019, 12, 14, 15, 48, 37, 654, DateTimeKind.Local).AddTicks(3947), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 598, 5970m, 11, 14, null, new DateTime(2011, 10, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5376), 10 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 125, 1250m, 1, 1, null, new DateTime(2018, 4, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4507), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 127, 1270m, 2, 2, null, new DateTime(2018, 3, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4510), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 365, 3650m, 1, 1, null, new DateTime(2014, 12, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4867), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 423, 4230m, 1, 1, null, new DateTime(2014, 3, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4971), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 124, 1230m, 2, 5, null, new DateTime(2018, 4, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4506), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 122, 1210m, 2, 4, null, new DateTime(2018, 4, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4504), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 71, 710m, 2, 2, null, new DateTime(2018, 12, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4442), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 69, 690m, 2, 2, null, new DateTime(2019, 1, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4440), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 66, 650m, 2, 6, null, new DateTime(2019, 1, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4385), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 64, 630m, 2, 5, null, new DateTime(2019, 2, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4381), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 62, 610m, 2, 4, null, new DateTime(2019, 2, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4379), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 11, 110m, 2, 2, null, new DateTime(2019, 10, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4316), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 9, 90m, 2, 2, null, new DateTime(2019, 11, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4312), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 421, 4210m, 1, 1, null, new DateTime(2014, 3, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4968), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 7, 70m, 2, 2, null, new DateTime(2019, 11, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4310), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 4, 30m, 2, 5, null, new DateTime(2019, 11, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4301), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 2, 10m, 2, 4, null, new DateTime(2019, 12, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4243), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 545, 5450m, 1, 1, null, new DateTime(2012, 7, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5313), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 543, 5430m, 1, 1, null, new DateTime(2012, 7, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5311), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 541, 5410m, 1, 1, null, new DateTime(2012, 7, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5288), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 485, 4850m, 1, 1, null, new DateTime(2013, 4, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5044), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 483, 4830m, 1, 1, null, new DateTime(2013, 5, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5041), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 481, 4810m, 1, 1, null, new DateTime(2013, 5, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5039), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 425, 4250m, 1, 1, null, new DateTime(2014, 2, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4973), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 6, 50m, 2, 6, null, new DateTime(2019, 11, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4308), 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 13, 130m, 3, 3, null, new DateTime(2019, 10, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4318), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 67, 670m, 2, 2, null, new DateTime(2019, 1, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4386), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 17, 170m, 3, 3, null, new DateTime(2019, 9, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4323), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 136, 1350m, 4, 7, null, new DateTime(2018, 2, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4522), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 134, 1330m, 4, 6, null, new DateTime(2018, 2, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4520), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 83, 830m, 4, 4, null, new DateTime(2018, 10, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4456), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 81, 810m, 4, 4, null, new DateTime(2018, 11, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4454), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 79, 790m, 4, 4, null, new DateTime(2018, 11, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4452), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 78, 770m, 4, 8, null, new DateTime(2018, 11, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4450), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 76, 750m, 4, 7, null, new DateTime(2018, 12, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4448), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 74, 730m, 4, 6, null, new DateTime(2018, 12, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4446), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 23, 230m, 4, 4, null, new DateTime(2019, 8, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4331), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 138, 1370m, 4, 8, null, new DateTime(2018, 1, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4524), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 21, 210m, 4, 4, null, new DateTime(2019, 9, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4329), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 18, 170m, 4, 8, null, new DateTime(2019, 9, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4326), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 16, 150m, 4, 7, null, new DateTime(2019, 9, 30, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4322), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 14, 130m, 4, 6, null, new DateTime(2019, 10, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4319), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 557, 5570m, 3, 3, null, new DateTime(2012, 5, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5327), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 555, 5550m, 3, 3, null, new DateTime(2012, 5, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5325), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 553, 5530m, 3, 3, null, new DateTime(2012, 5, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5323), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 552, 5510m, 3, 7, null, new DateTime(2012, 5, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5321), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 550, 5490m, 3, 6, null, new DateTime(2012, 6, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5319), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 548, 5470m, 3, 5, null, new DateTime(2012, 6, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5317), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 19, 190m, 4, 4, null, new DateTime(2019, 9, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4327), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 497, 4970m, 3, 3, null, new DateTime(2013, 2, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5058), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 139, 1390m, 4, 4, null, new DateTime(2018, 1, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4525), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 194, 1930m, 4, 6, null, new DateTime(2017, 4, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4625), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 376, 3750m, 4, 7, null, new DateTime(2014, 10, 26, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4880), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 15, 150m, 3, 3, null, new DateTime(2019, 10, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4321), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 374, 3730m, 4, 6, null, new DateTime(2014, 11, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4878), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 323, 3230m, 4, 4, null, new DateTime(2015, 7, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4818), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 321, 3210m, 4, 4, null, new DateTime(2015, 7, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4816), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 319, 3190m, 4, 4, null, new DateTime(2015, 8, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4813), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 318, 3170m, 4, 8, null, new DateTime(2015, 8, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4812), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 316, 3150m, 4, 7, null, new DateTime(2015, 8, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4810), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 314, 3130m, 4, 6, null, new DateTime(2015, 9, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4808), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 141, 1410m, 4, 4, null, new DateTime(2018, 1, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4528), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 263, 2630m, 4, 4, null, new DateTime(2016, 5, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4748), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 259, 2590m, 4, 4, null, new DateTime(2016, 6, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4743), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 258, 2570m, 4, 8, null, new DateTime(2016, 6, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4742), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 256, 2550m, 4, 7, null, new DateTime(2016, 6, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4698), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 254, 2530m, 4, 6, null, new DateTime(2016, 6, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4695), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 203, 2030m, 4, 4, null, new DateTime(2017, 3, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4636), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 201, 2010m, 4, 4, null, new DateTime(2017, 3, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4633), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 199, 1990m, 4, 4, null, new DateTime(2017, 3, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4631), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 198, 1970m, 4, 8, null, new DateTime(2017, 4, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4630), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 196, 1950m, 4, 7, null, new DateTime(2017, 4, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4627), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 261, 2610m, 4, 4, null, new DateTime(2016, 5, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4746), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 495, 4950m, 3, 3, null, new DateTime(2013, 3, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5055), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 143, 1430m, 4, 4, null, new DateTime(2018, 1, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4530), 4 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 492, 4910m, 3, 7, null, new DateTime(2013, 3, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5052), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 250, 2490m, 3, 6, null, new DateTime(2016, 7, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4691), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 248, 2470m, 3, 5, null, new DateTime(2016, 7, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4688), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 197, 1970m, 3, 3, null, new DateTime(2017, 4, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4629), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 195, 1950m, 3, 3, null, new DateTime(2017, 4, 18, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4626), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 193, 1930m, 3, 3, null, new DateTime(2017, 4, 28, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4624), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 192, 1910m, 3, 7, null, new DateTime(2017, 5, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4623), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 190, 1890m, 3, 6, null, new DateTime(2017, 5, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4620), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 188, 1870m, 3, 5, null, new DateTime(2017, 5, 23, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4618), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 135, 1350m, 3, 3, null, new DateTime(2018, 2, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4521), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 252, 2510m, 3, 7, null, new DateTime(2016, 7, 7, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4693), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 133, 1330m, 3, 3, null, new DateTime(2018, 2, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4519), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 130, 1290m, 3, 6, null, new DateTime(2018, 3, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4515), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 128, 1270m, 3, 5, null, new DateTime(2018, 3, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4511), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 77, 770m, 3, 3, null, new DateTime(2018, 11, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4449), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 75, 750m, 3, 3, null, new DateTime(2018, 12, 9, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4447), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 73, 730m, 3, 3, null, new DateTime(2018, 12, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4445), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 72, 710m, 3, 7, null, new DateTime(2018, 12, 24, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4443), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 493, 4930m, 3, 3, null, new DateTime(2013, 3, 20, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5053), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 70, 690m, 3, 6, null, new DateTime(2019, 1, 3, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4441), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 68, 670m, 3, 5, null, new DateTime(2019, 1, 13, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4387), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 132, 1310m, 3, 7, null, new DateTime(2018, 2, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4517), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 253, 2530m, 3, 3, null, new DateTime(2016, 7, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4694), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 137, 1370m, 3, 3, null, new DateTime(2018, 2, 2, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4523), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 257, 2570m, 3, 3, null, new DateTime(2016, 6, 12, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4699), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 488, 4870m, 3, 5, null, new DateTime(2013, 4, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5047), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 490, 4890m, 3, 6, null, new DateTime(2013, 4, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(5050), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 437, 4370m, 3, 3, null, new DateTime(2013, 12, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4987), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 255, 2550m, 3, 3, null, new DateTime(2016, 6, 22, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4697), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 435, 4350m, 3, 3, null, new DateTime(2014, 1, 4, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4984), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 433, 4330m, 3, 3, null, new DateTime(2014, 1, 14, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4982), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 432, 4310m, 3, 7, null, new DateTime(2014, 1, 19, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4981), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 428, 4270m, 3, 5, null, new DateTime(2014, 2, 8, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4976), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 377, 3770m, 3, 3, null, new DateTime(2014, 10, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4882), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 375, 3750m, 3, 3, null, new DateTime(2014, 10, 31, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4879), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 373, 3730m, 3, 3, null, new DateTime(2014, 11, 10, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4877), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 430, 4290m, 3, 6, null, new DateTime(2014, 1, 29, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4979), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 372, 3710m, 3, 7, null, new DateTime(2014, 11, 15, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4876), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 370, 3690m, 3, 6, null, new DateTime(2014, 11, 25, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4873), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 368, 3670m, 3, 5, null, new DateTime(2014, 12, 5, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4871), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 317, 3170m, 3, 3, null, new DateTime(2015, 8, 17, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4811), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 315, 3150m, 3, 3, null, new DateTime(2015, 8, 27, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4809), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 313, 3130m, 3, 3, null, new DateTime(2015, 9, 6, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4806), 3 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 308, 3070m, 3, 5, null, new DateTime(2015, 10, 1, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4801), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 312, 3110m, 3, 7, null, new DateTime(2015, 9, 11, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4805), 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "AssetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[] { 310, 3090m, 3, 6, null, new DateTime(2015, 9, 21, 15, 48, 37, 655, DateTimeKind.Local).AddTicks(4803), 2 });

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
