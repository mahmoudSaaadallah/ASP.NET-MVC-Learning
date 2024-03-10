using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace learning.Migrations
{
    /// <inheritdoc />
    public partial class addingSomeRecordsToDepartmentAndEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "IsDated", "ManagerName", "Name" },
                values: new object[,]
                {
                    { 1, false, "Ahmed", "SD" },
                    { 2, false, "Emad", "Web" },
                    { 3, false, "Omar", "Fluter" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Dep_Id", "Image", "IsDeleted", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "Aga", 1, "IMG20191207234622.jpg", false, "Saad", 17000.0 },
                    { 2, "Cairo", 2, "IMG20191207235431.jpg", false, "Ahmed", 13000.0 },
                    { 3, "Giza", 3, "IMG20200316005620", false, "Ibrahim", 16400.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
