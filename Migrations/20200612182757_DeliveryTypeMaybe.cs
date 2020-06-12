using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWeb.Migrations
{
    public partial class DeliveryTypeMaybe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryName = table.Column<string>(nullable: true),
                    PriceUnder1000 = table.Column<decimal>(nullable: false),
                    PriceBetween1000And2000 = table.Column<decimal>(nullable: false),
                    PriceOver2000 = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.DeliveryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_DeliveryTypeId",
                table: "DeskQuote",
                column: "DeliveryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_Delivery_DeliveryTypeId",
                table: "DeskQuote",
                column: "DeliveryTypeId",
                principalTable: "Delivery",
                principalColumn: "DeliveryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_Delivery_DeliveryTypeId",
                table: "DeskQuote");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropIndex(
                name: "IX_DeskQuote_DeliveryTypeId",
                table: "DeskQuote");
        }
    }
}
