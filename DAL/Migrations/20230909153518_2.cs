using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_ManagerId1",
                table: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "ManagerId1",
                table: "Deliveries",
                newName: "DeliveryPersonsId");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_ManagerId1",
                table: "Deliveries",
                newName: "IX_Deliveries_DeliveryPersonsId");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "Deliveries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryPersonId",
                table: "Deliveries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_ManagerId",
                table: "Deliveries",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_DeliveryPersonsId",
                table: "Deliveries",
                column: "DeliveryPersonsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_ManagerId",
                table: "Deliveries",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_DeliveryPersonsId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_ManagerId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_ManagerId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "DeliveryPersonId",
                table: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "DeliveryPersonsId",
                table: "Deliveries",
                newName: "ManagerId1");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_DeliveryPersonsId",
                table: "Deliveries",
                newName: "IX_Deliveries_ManagerId1");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Deliveries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_ManagerId1",
                table: "Deliveries",
                column: "ManagerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
