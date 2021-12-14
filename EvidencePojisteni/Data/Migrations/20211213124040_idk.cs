using Microsoft.EntityFrameworkCore.Migrations;

namespace EvidencePojisteni.Data.Migrations
{
    public partial class idk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailViewModelId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetailViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DetailViewModelId",
                table: "Products",
                column: "DetailViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_DetailViewModel_DetailViewModelId",
                table: "Products",
                column: "DetailViewModelId",
                principalTable: "DetailViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_DetailViewModel_DetailViewModelId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "DetailViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Products_DetailViewModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DetailViewModelId",
                table: "Products");
        }
    }
}
