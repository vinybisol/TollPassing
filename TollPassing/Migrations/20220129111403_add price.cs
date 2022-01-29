using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TollPassing.Migrations
{
    public partial class addprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "pas_price",
                schema: "public",
                table: "passing",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pas_price",
                schema: "public",
                table: "passing");
        }
    }
}
