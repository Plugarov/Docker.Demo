using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleManagementAPI.Migrations
{
    public partial class fixModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Vehicle");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Vehicle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Vehicle",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VIN",
                table: "Vehicle",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VIN",
                table: "Vehicle");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
