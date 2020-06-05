using Microsoft.EntityFrameworkCore.Migrations;

namespace IllyriadAssist.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MD_API_SETTINGS",
                columns: table => new
                {
                    API_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    API_TYPE = table.Column<string>(maxLength: 15, nullable: false),
                    API_KEY = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MD_API_SETTINGS", x => x.API_ID);
                });

            migrationBuilder.CreateTable(
                name: "MD_ILLY_REGIONS",
                columns: table => new
                {
                    REGION_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ILLY_REGION_ID = table.Column<int>(maxLength: 3, nullable: false),
                    REGION_NAME = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MD_ILLY_REGIONS", x => x.REGION_ID);
                });

            migrationBuilder.CreateTable(
                name: "MD_RARE_HERBS",
                columns: table => new
                {
                    ITEM_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ITEM_NAME = table.Column<string>(maxLength: 100, nullable: false),
                    ILLY_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    ITEM_DESCRIPTION = table.Column<string>(maxLength: 1000000, nullable: true),
                    IMAGE_NAME = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MD_RARE_HERBS", x => x.ITEM_ID);
                });

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

            migrationBuilder.CreateTable(
                name: "USER_ILLY_DATA",
                columns: table => new
                {
                    RECORD_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NOTIFY_ID = table.Column<int>(maxLength: 40, nullable: false),
                    NOTIFY_TYPE_ID = table.Column<int>(maxLength: 4, nullable: false),
                    NOTIFY_CAT_ID = table.Column<int>(maxLength: 2, nullable: false),
                    NOTIFY_CATEGORY = table.Column<string>(maxLength: 20, nullable: false),
                    NOTIFY_TYPE = table.Column<string>(maxLength: 4, nullable: false),
                    CITY_NAME = table.Column<string>(maxLength: 100, nullable: false),
                    CITY_X_GRID = table.Column<string>(maxLength: 5, nullable: false),
                    CITY_Y_GRID = table.Column<string>(maxLength: 5, nullable: false),
                    ILLY_ITEM_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    ITEM_CATEGORY = table.Column<string>(maxLength: 4, nullable: false),
                    ITEM_X_GRID = table.Column<string>(maxLength: 5, nullable: false),
                    ITEM_Y_GRID = table.Column<string>(maxLength: 5, nullable: false),
                    GRID_QUANTITY = table.Column<string>(maxLength: 10, nullable: false),
                    ILLY_REGION_ID = table.Column<int>(maxLength: 3, nullable: false),
                    NOTIFICATION_DATE = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ILLY_DATA", x => x.RECORD_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MD_API_SETTINGS");

            migrationBuilder.DropTable(
                name: "MD_ILLY_REGIONS");

            migrationBuilder.DropTable(
                name: "MD_RARE_HERBS");

            migrationBuilder.DropTable(
                name: "MD_RARE_MINERALS");

            migrationBuilder.DropTable(
                name: "USER_ILLY_DATA");
        }
    }
}
