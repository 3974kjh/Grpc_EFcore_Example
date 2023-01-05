using Microsoft.EntityFrameworkCore.Migrations;

namespace GrpcService.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hello",
                table: "PatientInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "hello",
                table: "PatientInfo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
