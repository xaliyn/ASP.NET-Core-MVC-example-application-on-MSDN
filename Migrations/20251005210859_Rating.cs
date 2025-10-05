using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class Rating : Migration
    {
        /// <inheritdoc />
        /*
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);
        }
        */
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1) Fix existing data first
            migrationBuilder.Sql("UPDATE Movie SET Rating = 'NR' WHERE Rating IS NULL;");
            migrationBuilder.Sql("UPDATE Movie SET Genre  = 'Unknown' WHERE Genre IS NULL;");
            migrationBuilder.Sql("UPDATE Movie SET Title  = 'Untitled' WHERE Title IS NULL;");

            // 2) Then make the columns non-nullable (if you changed annotations)
            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "Movie",
                type: "nvarchar(5)",
                nullable: false,               // <- non-nullable now
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldNullable: true);
            // Do similar AlterColumn for Genre/Title if you made them [Required]
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movie");
        }
    }
}
