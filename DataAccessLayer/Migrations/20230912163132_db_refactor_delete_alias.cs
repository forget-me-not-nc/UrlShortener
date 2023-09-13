using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class db_refactor_delete_alias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_urls_aliases_AliasId",
                table: "urls");

            migrationBuilder.DropTable(
                name: "aliases");

            migrationBuilder.DropIndex(
                name: "IX_urls_AliasId",
                table: "urls");

            migrationBuilder.DropColumn(
                name: "AliasId",
                table: "urls");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AliasId",
                table: "urls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "aliases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AliasSlug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aliases", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_urls_AliasId",
                table: "urls",
                column: "AliasId");

            migrationBuilder.AddForeignKey(
                name: "FK_urls_aliases_AliasId",
                table: "urls",
                column: "AliasId",
                principalTable: "aliases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
