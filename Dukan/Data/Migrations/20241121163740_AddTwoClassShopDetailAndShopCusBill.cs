using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dukan.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTwoClassShopDetailAndShopCusBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopDetails",
                columns: table => new
                {
                    SpDetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopGSTNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopDetails", x => x.SpDetId);
                });

            migrationBuilder.CreateTable(
                name: "ShopCusBills",
                columns: table => new
                {
                    SopCusBId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpDetId = table.Column<int>(type: "int", nullable: false),
                    SCusId = table.Column<int>(type: "int", nullable: false),
                    ProId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCusBills", x => x.SopCusBId);
                    table.ForeignKey(
                        name: "FK_ShopCusBills_Products_ProId",
                        column: x => x.ProId,
                        principalTable: "Products",
                        principalColumn: "ProId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopCusBills_ShopCustomers_SCusId",
                        column: x => x.SCusId,
                        principalTable: "ShopCustomers",
                        principalColumn: "SCusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopCusBills_ShopDetails_SpDetId",
                        column: x => x.SpDetId,
                        principalTable: "ShopDetails",
                        principalColumn: "SpDetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopCusBills_ProId",
                table: "ShopCusBills",
                column: "ProId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCusBills_SCusId",
                table: "ShopCusBills",
                column: "SCusId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCusBills_SpDetId",
                table: "ShopCusBills",
                column: "SpDetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopCusBills");

            migrationBuilder.DropTable(
                name: "ShopDetails");
        }
    }
}
