using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IShop.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationTypeChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "ApplicationTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "ApplicationTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
