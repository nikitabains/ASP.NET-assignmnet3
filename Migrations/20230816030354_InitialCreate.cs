using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mobileInfo_Assignment03.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mobileInfo",
                columns: table => new
                {
                    mobileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mobileModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobileCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manufacturedYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobileStorage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobileColour = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mobileInfo", x => x.mobileId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mobileInfo");
        }
    }
}
