using Microsoft.EntityFrameworkCore.Migrations;

namespace HelmToWorkPlaceConnector.Services.Migrations
{
    public partial class referenceKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idfRQHeaderKey",
                table: "Requisitions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "idfRQNumber",
                table: "Requisitions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idfRQDetailKey",
                table: "RequisitionLines",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idfRQHeaderKey",
                table: "Requisitions");

            migrationBuilder.DropColumn(
                name: "idfRQNumber",
                table: "Requisitions");

            migrationBuilder.DropColumn(
                name: "idfRQDetailKey",
                table: "RequisitionLines");
        }
    }
}
