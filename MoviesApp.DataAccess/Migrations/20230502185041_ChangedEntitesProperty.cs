using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEntitesProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoteAverage",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Average",
                table: "Votes",
                newName: "Point");

            migrationBuilder.RenameColumn(
                name: "VoteCount",
                table: "Movies",
                newName: "CreatedById");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Votes");

            migrationBuilder.RenameColumn(
                name: "Point",
                table: "Votes",
                newName: "Average");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Movies",
                newName: "VoteCount");

            migrationBuilder.AddColumn<double>(
                name: "VoteAverage",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
