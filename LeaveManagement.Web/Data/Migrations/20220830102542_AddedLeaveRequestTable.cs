using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14b4c776-df2c-427f-9fad-9a5a2666d882",
                column: "ConcurrencyStamp",
                value: "a677de9e-6e0e-46b1-a628-dc3b9e7a8d17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65cf1bb6-b57f-4060-a030-3d28691c4ecc",
                column: "ConcurrencyStamp",
                value: "22714c99-8248-4ca5-a509-207929ee7a6b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d1872cf-5ecb-4ad7-b30e-4585cdc9841e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f8af665-88a8-43d7-b7b4-b3b6a648c9f9", "AQAAAAEAACcQAAAAEPHogkM2G1TS30isP/AZNmuWlFYOsjcVc5ZUNSiNpKOKEEESdoX83Vhy5U53WYJgBw==", "27144a6b-6779-4b74-8d5b-6349ce83d59b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e87290f1-52ae-4053-be83-fae6d29875e3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "193e9e13-ccf8-42e4-bf5d-24f0eb8a2ba0", "AQAAAAEAACcQAAAAEHRIRmK0ErOVlziUMNI1FjaAD7CzZe3lamK0YFdSxEmVF5GVDiidnhtkJZwhaBOREg==", "488343a4-91b4-41fa-b167-473da0e99d21" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}
