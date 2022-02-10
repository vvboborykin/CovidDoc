using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidDoc.Model.Migrations
{
    public partial class ErrUniqDocType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IdentityDocumentType_NumberPattern",
                schema: "dbo",
                table: "IdentityDocumentType");

            migrationBuilder.DropIndex(
                name: "IX_IdentityDocumentType_SerialPattern",
                schema: "dbo",
                table: "IdentityDocumentType");

            migrationBuilder.DropIndex(
                name: "IX_IdentityDocument_Number",
                schema: "dbo",
                table: "IdentityDocument");

            migrationBuilder.DropIndex(
                name: "IX_IdentityDocument_Serial",
                schema: "dbo",
                table: "IdentityDocument");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocumentType_NumberPattern",
                schema: "dbo",
                table: "IdentityDocumentType",
                column: "NumberPattern");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocumentType_SerialPattern",
                schema: "dbo",
                table: "IdentityDocumentType",
                column: "SerialPattern");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocument_Number",
                schema: "dbo",
                table: "IdentityDocument",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocument_Serial",
                schema: "dbo",
                table: "IdentityDocument",
                column: "Serial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IdentityDocumentType_NumberPattern",
                schema: "dbo",
                table: "IdentityDocumentType");

            migrationBuilder.DropIndex(
                name: "IX_IdentityDocumentType_SerialPattern",
                schema: "dbo",
                table: "IdentityDocumentType");

            migrationBuilder.DropIndex(
                name: "IX_IdentityDocument_Number",
                schema: "dbo",
                table: "IdentityDocument");

            migrationBuilder.DropIndex(
                name: "IX_IdentityDocument_Serial",
                schema: "dbo",
                table: "IdentityDocument");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocumentType_NumberPattern",
                schema: "dbo",
                table: "IdentityDocumentType",
                column: "NumberPattern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocumentType_SerialPattern",
                schema: "dbo",
                table: "IdentityDocumentType",
                column: "SerialPattern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocument_Number",
                schema: "dbo",
                table: "IdentityDocument",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocument_Serial",
                schema: "dbo",
                table: "IdentityDocument",
                column: "Serial",
                unique: true);
        }
    }
}
