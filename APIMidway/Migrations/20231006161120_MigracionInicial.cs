using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMidway.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Empleados");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Empleados",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Empleados",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
