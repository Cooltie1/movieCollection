using Microsoft.EntityFrameworkCore.Migrations;

namespace movieCollection.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    movieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: false),
                    category = table.Column<string>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    director = table.Column<string>(nullable: false),
                    rating = table.Column<string>(nullable: false),
                    edited = table.Column<bool>(nullable: false),
                    lentTo = table.Column<string>(nullable: true),
                    notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.movieID);
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "movieID", "category", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 1, "Action/Adventure", "Tim Burton", false, "", "", "PG-13", "Batman", 1989 });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "movieID", "category", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 2, "Action/Adventure", "Joel Schumacher", false, "", "", "PG-13", "Batman & Robin", 1997 });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "movieID", "category", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 3, "Action/Adventure", "Christopher Nolan", false, "", "", "PG-13", "Batman Begins", 2005 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
