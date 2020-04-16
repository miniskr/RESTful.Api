using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RESTful.API.Migrations
{
    public partial class AddEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "Gender", "LastName" },
                values: new object[] { new Guid("8fd60c67-46cb-46cf-bd0f-864a6e93c847"), new Guid("a8dec6cd-a296-460d-a717-41364b282f4b"), new DateTime(1986, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "G003", "Mary", 2, "Kin" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "Gender", "LastName" },
                values: new object[] { new Guid("39b8abd2-d49b-4b8d-8ca4-0bce642893a6"), new Guid("a8dec6cd-a296-460d-a717-41364b282f4b"), new DateTime(1977, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "G093", "Mary", 1, "Kin" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "Gender", "LastName" },
                values: new object[] { new Guid("57695b2d-655e-4cef-9974-163c25721765"), new Guid("d0587ebd-4267-42fd-8a80-da6d058d9c00"), new DateTime(1973, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MSFT231", "Nick", 1, "Carter" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "Gender", "LastName" },
                values: new object[] { new Guid("2b540fa2-708a-4830-941c-b9ff20036946"), new Guid("d0587ebd-4267-42fd-8a80-da6d058d9c00"), new DateTime(1973, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MSFT777", "Vince", 1, "Ted" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("2b540fa2-708a-4830-941c-b9ff20036946"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("39b8abd2-d49b-4b8d-8ca4-0bce642893a6"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("57695b2d-655e-4cef-9974-163c25721765"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("8fd60c67-46cb-46cf-bd0f-864a6e93c847"));
        }
    }
}
