using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "Position" },
                values: new object[,]
                {
                    { 1, "test1@gmail.com", "Mahmoud", "Images/EmployeePersonalImage/test1.jpg", "Abd Elaziz", "Software Engineer" },
                    { 2, "test2@gmail.com", "Malak", "Images/EmployeePersonalImage/test2.jpg", "Gamal", "Network Engineer" },
                    { 3, "test3@gmail.com", "Yassen", "Images/EmployeePersonalImage/test3.jpg", "Walid", "Sales Manager" },
                    { 4, "test4@gmail.com", "Mahmoud", "Images/EmployeePersonalImage/test4.jpg", "Wael", "Markting" },
                    { 5, "test5@gmail.com", "Mansour", "Images/EmployeePersonalImage/test5.jpg", "Mohamed", "Technical Support" },
                    { 6, "test6@gmail.com", "Ahmed", "Images/EmployeePersonalImage/test6.jpg", "Gmal", "HR Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
