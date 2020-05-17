using Microsoft.EntityFrameworkCore.Migrations;

namespace IllyriadAssist.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MD_RARE_MINERALS",
                columns: table => new
                {
                    ITEM_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ITEM_NAME = table.Column<string>(maxLength: 100, nullable: false),
                    ILLY_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    ITEM_DESCRIPTION = table.Column<string>(maxLength: 1000000, nullable: false),
                    IMAGE_NAME = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MD_RARE_MINERALS", x => x.ITEM_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MD_RARE_MINERALS");
        }
    }
}
