using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class deleteCreatedByIdColumnInMovieTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Vote");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Vote",
                newName: "LastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Movie",
                newName: "LastUpdateDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "Vote",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "Movie",
                newName: "UpdateDate");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Vote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
