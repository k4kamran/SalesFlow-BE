using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDesignationWithPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Designations",
                newName: "Des_Grade");

            migrationBuilder.RenameColumn(
                name: "DesignationId",
                table: "Designations",
                newName: "Des_Code");

            migrationBuilder.AddColumn<string>(
                name: "Des_Description",
                table: "Designations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Des_Fuel_Limit",
                table: "Designations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Des_Max_Sal",
                table: "Designations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Des_Start_Sal",
                table: "Designations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Des_Vba",
                table: "Designations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Des_Description",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "Des_Fuel_Limit",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "Des_Max_Sal",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "Des_Start_Sal",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "Des_Vba",
                table: "Designations");

            migrationBuilder.RenameColumn(
                name: "Des_Grade",
                table: "Designations",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Des_Code",
                table: "Designations",
                newName: "DesignationId");
        }
    }
}
