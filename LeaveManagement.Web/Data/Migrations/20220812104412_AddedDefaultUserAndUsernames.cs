using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUserAndUsernames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14b4c776-df2c-427f-9fad-9a5a2666d882",
                column: "ConcurrencyStamp",
                value: "ae77383c-1c39-43e2-a6d1-1f0dd42cc3de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65cf1bb6-b57f-4060-a030-3d28691c4ecc",
                column: "ConcurrencyStamp",
                value: "69632910-7e94-463f-8d5d-2e6b9854269d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d1872cf-5ecb-4ad7-b30e-4585cdc9841e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "489e8e72-39ec-4c56-a045-c9757ebf43a1", true, "EMIN1@TEST.COM", "AQAAAAEAACcQAAAAED9j+MDQv7s1dJg6D67X07XiagfglJGfuONsNIYH1cUjojx66qumGi/3dH0hlXHPOA==", "ef8ad7e7-4d5b-4cc3-86f3-2c5d9fd918ba", "Emin1@test.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e87290f1-52ae-4053-be83-fae6d29875e3",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "0db1638c-dd47-4b72-9d4f-e576ac2866ca", true, "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEHlm7jhavMq00MpPJ6RQuGuc7zkl5pkSCtaxXCTk5X7yHMoI2UpXbSq6GvKE+bTPuQ==", "5d8e6700-0637-4e92-981a-bd95cbc7c735", "Admin@localhost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14b4c776-df2c-427f-9fad-9a5a2666d882",
                column: "ConcurrencyStamp",
                value: "d0ec2095-7e14-40d8-801f-d044187b9c0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65cf1bb6-b57f-4060-a030-3d28691c4ecc",
                column: "ConcurrencyStamp",
                value: "a6cbc86f-9095-4d33-9d87-fd526068a1ca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d1872cf-5ecb-4ad7-b30e-4585cdc9841e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "2360a487-d040-4956-8224-825f1fb2ca5b", false, null, "AQAAAAEAACcQAAAAEFexePdeWVrJaFz7h7aDXoqS+oDGw2hQrgJp/W4mIyjfeKfN2U4yTKIrMhFJkFW1+g==", "c2a250d3-0b05-4b8d-9761-1bccdc34af61", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e87290f1-52ae-4053-be83-fae6d29875e3",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b7bdd1f8-b0a4-48d1-9fb5-47576f3591aa", false, null, "AQAAAAEAACcQAAAAEKWgKkV4lqkRZm2LF7te+SH1QWmNkk39ar/UCZ8hrJK4g4/bXe6v7TmSfiIJ/iFZ6g==", "a1b762a9-6206-4e6c-99dd-9e0d5871ff55", null });
        }
    }
}
