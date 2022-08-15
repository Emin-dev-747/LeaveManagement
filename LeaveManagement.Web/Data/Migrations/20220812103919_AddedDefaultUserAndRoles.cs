using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUserAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14b4c776-df2c-427f-9fad-9a5a2666d882", "d0ec2095-7e14-40d8-801f-d044187b9c0a", "Administrator", "ADMINISTRATOR" },
                    { "65cf1bb6-b57f-4060-a030-3d28691c4ecc", "a6cbc86f-9095-4d33-9d87-fd526068a1ca", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d1872cf-5ecb-4ad7-b30e-4585cdc9841e", 0, "2360a487-d040-4956-8224-825f1fb2ca5b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emin1@test.com", false, "Me", "Myself", false, null, "EMIN1@TEST.COM", null, "AQAAAAEAACcQAAAAEFexePdeWVrJaFz7h7aDXoqS+oDGw2hQrgJp/W4mIyjfeKfN2U4yTKIrMhFJkFW1+g==", null, false, "c2a250d3-0b05-4b8d-9761-1bccdc34af61", null, false, null },
                    { "e87290f1-52ae-4053-be83-fae6d29875e3", 0, "b7bdd1f8-b0a4-48d1-9fb5-47576f3591aa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEKWgKkV4lqkRZm2LF7te+SH1QWmNkk39ar/UCZ8hrJK4g4/bXe6v7TmSfiIJ/iFZ6g==", null, false, "a1b762a9-6206-4e6c-99dd-9e0d5871ff55", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "65cf1bb6-b57f-4060-a030-3d28691c4ecc", "0d1872cf-5ecb-4ad7-b30e-4585cdc9841e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "14b4c776-df2c-427f-9fad-9a5a2666d882", "e87290f1-52ae-4053-be83-fae6d29875e3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65cf1bb6-b57f-4060-a030-3d28691c4ecc", "0d1872cf-5ecb-4ad7-b30e-4585cdc9841e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "14b4c776-df2c-427f-9fad-9a5a2666d882", "e87290f1-52ae-4053-be83-fae6d29875e3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14b4c776-df2c-427f-9fad-9a5a2666d882");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65cf1bb6-b57f-4060-a030-3d28691c4ecc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d1872cf-5ecb-4ad7-b30e-4585cdc9841e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e87290f1-52ae-4053-be83-fae6d29875e3");
        }
    }
}
