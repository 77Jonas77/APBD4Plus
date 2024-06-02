using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cw10.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    PkCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.PkCategory);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    PkProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Depth = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.PkProduct);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRole);
                });

            migrationBuilder.CreateTable(
                name: "ProductsCategories",
                columns: table => new
                {
                    FkProduct = table.Column<int>(type: "int", nullable: false),
                    FkCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsCategories", x => new { x.FkProduct, x.FkCategory });
                    table.ForeignKey(
                        name: "FK_ProductsCategories_Categories_FkCategory",
                        column: x => x.FkCategory,
                        principalTable: "Categories",
                        principalColumn: "PkCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsCategories_Products_FkProduct",
                        column: x => x.FkProduct,
                        principalTable: "Products",
                        principalColumn: "PkProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    PkAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkRole = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.PkAccount);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_FkRole",
                        column: x => x.FkRole,
                        principalTable: "Roles",
                        principalColumn: "PkRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    FkAccount = table.Column<int>(type: "int", nullable: false),
                    FkProduct = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => new { x.FkAccount, x.FkProduct });
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Accounts_FkAccount",
                        column: x => x.FkAccount,
                        principalTable: "Accounts",
                        principalColumn: "PkAccount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_FkProduct",
                        column: x => x.FkProduct,
                        principalTable: "Products",
                        principalColumn: "PkProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_FkRole",
                table: "Accounts",
                column: "FkRole");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCategories_FkCategory",
                table: "ProductsCategories",
                column: "FkCategory");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_FkProduct",
                table: "ShoppingCarts",
                column: "FkProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsCategories");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
