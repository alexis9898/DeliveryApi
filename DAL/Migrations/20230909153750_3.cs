using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_DeliveryPersonsId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_DeliveryPersonsId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "DeliveryPersonsId",
                table: "Deliveries");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryPersonId",
                table: "Deliveries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DeliveryPersonId",
                table: "Deliveries",
                column: "DeliveryPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_DeliveryPersonId",
                table: "Deliveries",
                column: "DeliveryPersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_DeliveryPersonId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_DeliveryPersonId",
                table: "Deliveries");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryPersonId",
                table: "Deliveries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryPersonsId",
                table: "Deliveries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DeliveryPersonsId",
                table: "Deliveries",
                column: "DeliveryPersonsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_DeliveryPersonsId",
                table: "Deliveries",
                column: "DeliveryPersonsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
