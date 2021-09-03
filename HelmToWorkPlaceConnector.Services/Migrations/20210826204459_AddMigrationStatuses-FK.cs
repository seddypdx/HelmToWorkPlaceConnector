using Microsoft.EntityFrameworkCore.Migrations;

namespace HelmToWorkPlaceConnector.Services.Migrations
{
    public partial class AddMigrationStatusesFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RequisitionLines_ConnectorStatusId",
                table: "RequisitionLines",
                column: "ConnectorStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionLines_ConnectorStatuses_ConnectorStatusId",
                table: "RequisitionLines",
                column: "ConnectorStatusId",
                principalTable: "ConnectorStatuses",
                principalColumn: "ConnectorStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionLines_ConnectorStatuses_ConnectorStatusId",
                table: "RequisitionLines");

            migrationBuilder.DropIndex(
                name: "IX_RequisitionLines_ConnectorStatusId",
                table: "RequisitionLines");
        }
    }
}
