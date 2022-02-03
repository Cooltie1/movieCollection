using Microsoft.EntityFrameworkCore.Migrations;

namespace movieCollection.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    movieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: false),
                    categoryID = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_movies_categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "categories",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 1, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[] { 3, "Drama" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "movieID", "categoryID", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 1, 1, "Tim Burton", false, "", "", "PG-13", "Batman", 1989 });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "movieID", "categoryID", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 2, 1, "Joel Schumacher", false, "", "", "PG-13", "Batman & Robin", 1997 });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "movieID", "categoryID", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 3, 1, "Christopher Nolan", false, "", "", "PG-13", "Batman Begins", 2005 });

            migrationBuilder.CreateIndex(
                name: "IX_movies_categoryID",
                table: "movies",
                column: "categoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
