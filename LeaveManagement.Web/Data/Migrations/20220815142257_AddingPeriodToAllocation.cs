using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddingPeriodToAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14b4c776-df2c-427f-9fad-9a5a2666d882",
                column: "ConcurrencyStamp",
                value: "9a41806b-4181-41d5-be18-463641d5d05f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65cf1bb6-b57f-4060-a030-3d28691c4ecc",
                column: "ConcurrencyStamp",
                value: "36689dc9-45e6-4eb1-8b04-2273cfd67ba9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d1872cf-5ecb-4ad7-b30e-4585cdc9841e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19dd3121-b901-4bae-9765-53c0a7546958", "AQAAAAEAACcQAAAAEKHYMoT9mHb85eMVBtqq0bURSN60DAFQA/T1Zd/iM7aAJL7DIdKNAlrjMBjmnqoegw==", "d61b98ab-81a6-44c7-b459-32379c379a18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e87290f1-52ae-4053-be83-fae6d29875e3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbe685ef-a6df-4c5c-8d50-a20f646382df", "AQAAAAEAACcQAAAAEDjNQrVn/rSFUrpY7fjOFwDTscSU+2xzpfiPTlFtbcafgimQnHVxbhQTgVyw/MpA1Q==", "ae32df29-2f65-4ab7-8f4a-766563f74994" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "489e8e72-39ec-4c56-a045-c9757ebf43a1", "AQAAAAEAACcQAAAAED9j+MDQv7s1dJg6D67X07XiagfglJGfuONsNIYH1cUjojx66qumGi/3dH0hlXHPOA==", "ef8ad7e7-4d5b-4cc3-86f3-2c5d9fd918ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e87290f1-52ae-4053-be83-fae6d29875e3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0db1638c-dd47-4b72-9d4f-e576ac2866ca", "AQAAAAEAACcQAAAAEHlm7jhavMq00MpPJ6RQuGuc7zkl5pkSCtaxXCTk5X7yHMoI2UpXbSq6GvKE+bTPuQ==", "5d8e6700-0637-4e92-981a-bd95cbc7c735" });
        }
    }
}
