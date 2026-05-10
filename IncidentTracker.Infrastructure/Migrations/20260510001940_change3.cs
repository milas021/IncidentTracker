using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncidentTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Severity",
                table: "Incidents",
                newName: "Priority");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "IncidentTimelines",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "IncidentTimelines");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Incidents",
                newName: "Severity");
        }
    }
}
