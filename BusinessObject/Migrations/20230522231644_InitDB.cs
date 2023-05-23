using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObject.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fullname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    birthday = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    male = table.Column<bool>(type: "bit", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "id", "birthday", "email", "fullname", "male", "phone_number", "points" },
                values: new object[] { "1", "02/04/2001", "kaizph@gmail.com", "Kaiz Nguyen", true, "0396384095", 8 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "id", "birthday", "email", "fullname", "male", "phone_number", "points" },
                values: new object[] { "2", "02/08/1997", "chaunt@gmail.com", "Chau NT", false, "0793786216", 9 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
