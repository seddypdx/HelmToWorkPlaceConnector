using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelmToWorkPlaceConnector.Services.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequisitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Space = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PartIt = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitionLines_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Space = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineItemCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Divisionid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Assset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LinkedItemType = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LinkedItemid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisitions_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionLines_CreatedById",
                table: "RequisitionLines",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_CreatedById",
                table: "Requisitions",
                column: "CreatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequisitionLines");

            migrationBuilder.DropTable(
                name: "Requisitions");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
