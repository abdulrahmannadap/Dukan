using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dukan.Data.Migrations
{
    /// <inheritdoc />
    public partial class addAlternateMobileNumberInShopDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlternateMobileNumber",
                table: "ShopDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternateMobileNumber",
                table: "ShopDetails");
        }
    }
}
