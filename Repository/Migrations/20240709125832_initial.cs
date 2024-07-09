using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.CheckConstraint("FirstName", "LEN(FirstName) >= 3");
                    table.CheckConstraint("LastName", "LEN(LastName) >= 3");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersFavoritesProducts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFavoritesProducts", x => new { x.UserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_UsersFavoritesProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersFavoritesProducts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(1193), "Electronics", null },
                    { 2, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(1205), "Home Appliances", null },
                    { 3, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(1206), "Books", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "RoleName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(1505), "Admin", null },
                    { 2, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(1506), "User", null },
                    { 3, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(1506), "Guest", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "Email", "FirstName", "LastName", "Password", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(2119), "ege.erbilen@example.com", "Ege", "Erbilen", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", null },
                    { 2, null, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(2139), "ece.erbilen@example.com", "Ece", "Erbilen", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", null },
                    { 3, null, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(2153), "ahmet.yilmaz@example.com", "Ahmet", "Yılmaz", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "ImageData", "Name", "Price", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(1408), "Description 1", null, "Product 1", 100.0m, null, 1 },
                    { 2, 1, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(1410), "Description 1", null, "Product 2", 200.0m, null, 1 },
                    { 3, 2, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(1411), null, null, "Product 3", 150.0m, null, 2 },
                    { 4, 2, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(1412), "Description 1", null, "Product 4", 250.0m, null, 2 },
                    { 5, 3, new DateTime(2024, 7, 9, 15, 58, 32, 244, DateTimeKind.Local).AddTicks(1413), "Description 1", null, "Product 5", 300.0m, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "UsersFavoritesProducts",
                columns: new[] { "ProductId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFavoritesProducts_ProductId",
                table: "UsersFavoritesProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RoleId",
                table: "UsersRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersFavoritesProducts");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
