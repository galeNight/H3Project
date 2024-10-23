using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xxx.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Steven Spielberg" },
                    { 2, "Christopher Nolan" },
                    { 3, "Martin Scorsese" },
                    { 4, "Ridley Scott" },
                    { 5, "Peter Jackson" },
                    { 6, "Lana Wachowski" },
                    { 7, "Justin Lin" },
                    { 8, "Quentin Tarantino" },
                    { 9, "James Cameron" },
                    { 10, "Alex Kurtzman" },
                    { 11, "Shawn Levy" },
                    { 12, "Michael Bay" },
                    { 13, "Roland Emmerich" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "adventure" },
                    { 3, "comedy" },
                    { 4, "Drama" },
                    { 5, "fantasy" },
                    { 6, "horror" },
                    { 7, "musicals" },
                    { 8, "mystery" },
                    { 9, "romance" },
                    { 10, "sci-fi" },
                    { 11, "sports" },
                    { 12, "thriller" },
                    { 13, "Western" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorId", "DurationMinutes", "GenreId", "Title" },
                values: new object[,]
                {
                    { 1, 1, 127, 12, "Jurassic Park" },
                    { 2, 2, 169, 10, "Interstellar" },
                    { 3, 3, 126, 8, "Hugo" },
                    { 4, 4, 144, 4, "The Martian" },
                    { 5, 5, 201, 5, "The Lord of the Rings: The Return of the King" },
                    { 6, 6, 136, 10, "The Matrix" },
                    { 7, 7, 107, 12, "Fast & Furious" },
                    { 8, 8, 111, 1, "Kill Bill: Vol. 1" },
                    { 9, 9, 162, 5, "Avatar" },
                    { 10, 10, 111, 6, "The Mummy" },
                    { 11, 11, 108, 3, "Night at the Museum" },
                    { 12, 12, 144, 1, "Transformers " },
                    { 13, 13, 131, 12, "White House Down" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "MovieId", "Rating" },
                values: new object[,]
                {
                    { 1, "Greate Movie", 1, 5 },
                    { 2, "Not bad.", 2, 3 },
                    { 3, "not gona watch again", 3, 1 },
                    { 4, "awesome movie love the aactor that is left on mars", 4, 9 },
                    { 5, "could be better", 5, 2 },
                    { 6, "good movie", 6, 6 },
                    { 7, "i am gona watch this with my familie next time", 7, 8 },
                    { 8, "Love lovie this movie", 8, 7 },
                    { 9, "awesome", 9, 6 },
                    { 10, "good movie love it ", 10, 8 },
                    { 11, "i am gona recommend to all i know", 11, 9 },
                    { 12, "act better or i am gonna not gona watch you movies again", 12, 2 },
                    { 13, "this is the worst movie ever", 13, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
