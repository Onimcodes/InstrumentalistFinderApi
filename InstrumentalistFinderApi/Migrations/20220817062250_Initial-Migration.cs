using Microsoft.EntityFrameworkCore.Migrations;

namespace InstrumentalistFinderApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Message" },
                values: new object[,]
                {
                    { 1, "I need a church to play for. No fees " },
                    { 2, "Im a professional drummer looking for a choir to grow with. No fees required" },
                    { 3, "I'm available for programmes. Dm to discuss fees " },
                    { 4, "On my way to a church programme " },
                    { 5, "I need a church to play for. " }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
