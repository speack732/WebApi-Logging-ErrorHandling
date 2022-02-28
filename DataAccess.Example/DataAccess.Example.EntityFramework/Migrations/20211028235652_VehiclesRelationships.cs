using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Example.EntityFramework.Migrations
{
    public partial class VehiclesRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makes_Makes_MakeId",
                table: "Makes");

            migrationBuilder.DropForeignKey(
                name: "FK_Makes_Models_ModelId",
                table: "Makes");

            migrationBuilder.DropIndex(
                name: "IX_Makes_MakeId",
                table: "Makes");

            migrationBuilder.DropIndex(
                name: "IX_Makes_ModelId",
                table: "Makes");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "Makes");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Makes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "Makes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Makes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Makes_MakeId",
                table: "Makes",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Makes_ModelId",
                table: "Makes",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Makes_Makes_MakeId",
                table: "Makes",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Makes_Models_ModelId",
                table: "Makes",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
