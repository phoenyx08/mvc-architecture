using Microsoft.EntityFrameworkCore.Migrations;

namespace omdbapp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieDetailsModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Rated = table.Column<string>(nullable: true),
                    Released = table.Column<string>(nullable: true),
                    Runtime = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Writer = table.Column<string>(nullable: true),
                    Actors = table.Column<string>(nullable: true),
                    Plot = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Awards = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true),
                    Metascore = table.Column<string>(nullable: true),
                    imdbRating = table.Column<string>(nullable: true),
                    imdbVotes = table.Column<string>(nullable: true),
                    imdbID = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    DVD = table.Column<string>(nullable: true),
                    BoxOffice = table.Column<string>(nullable: true),
                    Production = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDetailsModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaingItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    MovieDetailsModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaingItems_MovieDetailsModels_MovieDetailsModelId",
                        column: x => x.MovieDetailsModelId,
                        principalTable: "MovieDetailsModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaingItems_MovieDetailsModelId",
                table: "RaingItems",
                column: "MovieDetailsModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaingItems");

            migrationBuilder.DropTable(
                name: "MovieDetailsModels");
        }
    }
}
