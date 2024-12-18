using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dukan.Data.Migrations
{
    /// <inheritdoc />
    public partial class REMOVEREQUIREDALTERNATEMOBILENUMBER : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AlternateMobileNumber",
                table: "ShopDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AlternateMobileNumber",
                table: "ShopDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
