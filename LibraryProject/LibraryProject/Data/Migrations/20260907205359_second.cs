using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryProject.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthyear = table.Column<int>(type: "int", nullable: false),
                    Deathyear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GId);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    PId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.PId);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pagecount = table.Column<int>(type: "int", nullable: false),
                    Edition = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    PublishYear = table.Column<int>(type: "int", nullable: false),
                    AId = table.Column<int>(type: "int", nullable: false),
                    PId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BId);
                    table.ForeignKey(
                        name: "FK_Book_Author_AId",
                        column: x => x.AId,
                        principalTable: "Author",
                        principalColumn: "AId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PId",
                        column: x => x.PId,
                        principalTable: "Publisher",
                        principalColumn: "PId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BooksBId = table.Column<int>(type: "int", nullable: false),
                    GenresGId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BooksBId, x.GenresGId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Book_BooksBId",
                        column: x => x.BooksBId,
                        principalTable: "Book",
                        principalColumn: "BId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genre_GenresGId",
                        column: x => x.GenresGId,
                        principalTable: "Genre",
                        principalColumn: "GId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "AId", "Birthyear", "Deathyear", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 1898, 1963, "C.S.", "Lewis" },
                    { 2, 1892, 1973, "J.R.R.", "Tolkien" },
                    { 3, 1973, 0, "Guy", "Haley" },
                    { 4, 1989, 0, "John", "French" },
                    { 5, 1990, 0, "Robert", "Rath" },
                    { 6, 1965, 0, "Dan", "Abnett" },
                    { 7, 1920, 1986, "Frank", "Herbert" },
                    { 8, 1971, 0, "Justin D.", "Hill" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GId", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Science Fiction" },
                    { 3, "Horror" },
                    { 4, "Romance" },
                    { 5, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "PId", "Name" },
                values: new object[,]
                {
                    { 1, "Black Library" },
                    { 2, "Geoffrey Bles" },
                    { 3, "George Allen & Unwin" },
                    { 4, "Hodder & Stoughton Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BId", "AId", "Edition", "PId", "Pagecount", "PublishYear", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, 208, 1950, 2, "The Lion, the Witch and the Wardrobe" },
                    { 2, 2, 1, 3, 300, 1937, 2, "The Hobbit" },
                    { 3, 3, 2, 1, 432, 2021, 1, "Dark Imperium" },
                    { 4, 3, 2, 1, 401, 2022, 1, "Dark Imperium: Plague War" },
                    { 5, 3, 2, 1, 431, 2022, 1, "Dark Imperium: Godblight" },
                    { 6, 7, 4, 4, 577, 2015, 1, "Dune" },
                    { 7, 7, 4, 4, 293, 2017, 2, "Dune Messiah" },
                    { 8, 7, 4, 4, 423, 2021, 2, "Children of Dune" },
                    { 9, 7, 3, 4, 420, 2020, 2, "God Emperor of Dune" },
                    { 10, 5, 1, 1, 656, 2023, 1, "The Fall of Cadia" },
                    { 11, 5, 1, 1, 464, 2022, 1, "Assassinorum: Kingmaker" },
                    { 12, 4, 1, 1, 192, 2024, 1, "Cypher: Lord of the Fallen" },
                    { 13, 4, 2, 1, 880, 2024, 1, "Ahriman: The Omnibus" },
                    { 14, 6, 2, 1, 880, 2022, 2, "The Founding" },
                    { 15, 8, 1, 1, 1079, 2023, 1, "Minka Lesk: The Last Whiteshield" },
                    { 16, 2, 1, 3, 423, 1937, 3, "The Fellowship of the Ring" },
                    { 17, 2, 1, 3, 352, 1937, 3, "The Two Towers" },
                    { 18, 2, 1, 3, 416, 1937, 3, "The Return of the King" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AId",
                table: "Book",
                column: "AId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PId",
                table: "Book",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresGId",
                table: "BookGenre",
                column: "GenresGId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
