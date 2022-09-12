using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdateUserClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationClaims_UserOperationClaims_UserOperationClaimId",
                table: "OperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_OperationClaims_UserOperationClaimId",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "UserOperationClaimId",
                table: "OperationClaims");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId",
                principalTable: "OperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims");

            migrationBuilder.AddColumn<int>(
                name: "UserOperationClaimId",
                table: "OperationClaims",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationClaims_UserOperationClaimId",
                table: "OperationClaims",
                column: "UserOperationClaimId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationClaims_UserOperationClaims_UserOperationClaimId",
                table: "OperationClaims",
                column: "UserOperationClaimId",
                principalTable: "UserOperationClaims",
                principalColumn: "Id");
        }
    }
}
