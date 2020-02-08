using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PcRepaire.Migrations
{
    public partial class AddEquipmentUsing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Statistic_StatisticId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Employees_EquipUserId",
                table: "Equipments");

            migrationBuilder.DropTable(
                name: "RepairLists");

            migrationBuilder.DropTable(
                name: "StatRepaires");

            migrationBuilder.DropTable(
                name: "Statistic");

            migrationBuilder.DropIndex(
                name: "IX_Employees_StatisticId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CountHard",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CountRepaires",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CountSoft",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "StatisticId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Manufacture",
                table: "Equipments",
                newName: "ManufactureId");

            migrationBuilder.AlterColumn<int>(
                name: "EquipUserId",
                table: "Equipments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Tablet_EquipUserId",
                table: "Equipments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Manufactures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufactures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepaireLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false),
                    RepaireManId = table.Column<int>(nullable: false),
                    DateRepaire = table.Column<DateTime>(nullable: false),
                    SoftWare = table.Column<bool>(nullable: false),
                    HardWare = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaireLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepaireLists_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepaireLists_Employees_RepaireManId",
                        column: x => x.RepaireManId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ManufactureId",
                table: "Equipments",
                column: "ManufactureId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_Tablet_EquipUserId",
                table: "Equipments",
                column: "Tablet_EquipUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RepaireLists_EquipmentId",
                table: "RepaireLists",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RepaireLists_RepaireManId",
                table: "RepaireLists",
                column: "RepaireManId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Manufactures_ManufactureId",
                table: "Equipments",
                column: "ManufactureId",
                principalTable: "Manufactures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Employees_EquipUserId",
                table: "Equipments",
                column: "EquipUserId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Employees_Tablet_EquipUserId",
                table: "Equipments",
                column: "Tablet_EquipUserId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Manufactures_ManufactureId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Employees_EquipUserId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Employees_Tablet_EquipUserId",
                table: "Equipments");

            migrationBuilder.DropTable(
                name: "Manufactures");

            migrationBuilder.DropTable(
                name: "RepaireLists");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_ManufactureId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_Tablet_EquipUserId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Tablet_EquipUserId",
                table: "Equipments");

            migrationBuilder.RenameColumn(
                name: "ManufactureId",
                table: "Equipments",
                newName: "Manufacture");

            migrationBuilder.AlterColumn<int>(
                name: "EquipUserId",
                table: "Equipments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountHard",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountRepaires",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountSoft",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatisticId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RepairLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    HardWareId = table.Column<int>(nullable: true),
                    HardWareRapaired = table.Column<bool>(nullable: false),
                    PcId = table.Column<int>(nullable: false),
                    RepaireManId = table.Column<int>(nullable: true),
                    SoftWareId = table.Column<int>(nullable: true),
                    SoftWareRapaired = table.Column<bool>(nullable: false),
                    WorkerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairLists_HardWares_HardWareId",
                        column: x => x.HardWareId,
                        principalTable: "HardWares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepairLists_Equipments_PcId",
                        column: x => x.PcId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairLists_Employees_RepaireManId",
                        column: x => x.RepaireManId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepairLists_SoftWares_SoftWareId",
                        column: x => x.SoftWareId,
                        principalTable: "SoftWares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatRepaires",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    StatisticId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatRepaires", x => x.Date);
                    table.ForeignKey(
                        name: "FK_StatRepaires_Statistic_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StatisticId",
                table: "Employees",
                column: "StatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairLists_HardWareId",
                table: "RepairLists",
                column: "HardWareId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairLists_PcId",
                table: "RepairLists",
                column: "PcId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairLists_RepaireManId",
                table: "RepairLists",
                column: "RepaireManId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairLists_SoftWareId",
                table: "RepairLists",
                column: "SoftWareId");

            migrationBuilder.CreateIndex(
                name: "IX_StatRepaires_StatisticId",
                table: "StatRepaires",
                column: "StatisticId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Statistic_StatisticId",
                table: "Employees",
                column: "StatisticId",
                principalTable: "Statistic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Employees_EquipUserId",
                table: "Equipments",
                column: "EquipUserId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
