using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Database.Migrations
{
    public partial class insertDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0903ed29-3ffa-499d-abc0-5a407f041cee", "b312bf7f-ecae-45a1-a246-3ac5f7bee5bf", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3cdb533-ceac-44c5-b1f4-2d676921925a", "ed9da848-1c5f-4210-b0e8-98a49bae1db2", "Seller", "Seller" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0903ed29-3ffa-499d-abc0-5a407f041cee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3cdb533-ceac-44c5-b1f4-2d676921925a");
        }
    }
}
