using Microsoft.EntityFrameworkCore.Migrations;

namespace HelmToWorkPlaceConnector.Services.Migrations
{
    public partial class ConnectorStatusDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionLines_ConnectorStatuses_ConnectorStatusId",
                table: "RequisitionLines");

            migrationBuilder.DropIndex(
                name: "IX_RequisitionLines_ConnectorStatusId",
                table: "RequisitionLines");

            migrationBuilder.AddColumn<int>(
                name: "ConnectorStatusId1",
                table: "RequisitionLines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionLines_ConnectorStatusId1",
                table: "RequisitionLines",
                column: "ConnectorStatusId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionLines_ConnectorStatuses_ConnectorStatusId1",
                table: "RequisitionLines",
                column: "ConnectorStatusId1",
                principalTable: "ConnectorStatuses",
                principalColumn: "ConnectorStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionLines_ConnectorStatuses_ConnectorStatusId1",
                table: "RequisitionLines");

            migrationBuilder.DropIndex(
                name: "IX_RequisitionLines_ConnectorStatusId1",
                table: "RequisitionLines");

            migrationBuilder.DropColumn(
                name: "ConnectorStatusId1",
                table: "RequisitionLines");

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
    }
}
