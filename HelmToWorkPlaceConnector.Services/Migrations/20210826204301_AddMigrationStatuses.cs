using Microsoft.EntityFrameworkCore.Migrations;

namespace HelmToWorkPlaceConnector.Services.Migrations
{
    public partial class AddMigrationStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConnectorStatusId",
                table: "RequisitionLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ConnectorStatuses",
                columns: table => new
                {
                    ConnectorStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectorStatuses", x => x.ConnectorStatusId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectorStatuses");

            migrationBuilder.DropColumn(
                name: "ConnectorStatusId",
                table: "RequisitionLines");
        }
    }
}
