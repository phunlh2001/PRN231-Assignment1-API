using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObject.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeCustomers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCustomers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TypeCustomers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "VIP" },
                    { "2", "Gold" },
                    { "3", "Diamond" },
                    { "4", "Newbie" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: "1",
                column: "TypeId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: "2",
                column: "TypeId",
                value: "2");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TypeId",
                table: "Customers",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_TypeCustomers_TypeId",
                table: "Customers",
                column: "TypeId",
                principalTable: "TypeCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_TypeCustomers_TypeId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "TypeCustomers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Customers");
        }
    }
}
