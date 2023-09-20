using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_DeliveryPersonId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_ManagerId",
                table: "Deliveries");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_DeliveryPersonId",
                table: "Deliveries",
                column: "DeliveryPersonId",
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
                name: "FK_Deliveries_AspNetUsers_DeliveryPersonId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_ManagerId",
                table: "Deliveries");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_DeliveryPersonId",
                table: "Deliveries",
                column: "DeliveryPersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_ManagerId",
                table: "Deliveries",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
