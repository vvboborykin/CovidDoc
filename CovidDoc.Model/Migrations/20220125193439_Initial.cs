using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidDoc.Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Organization",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Orgn = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    IsLab = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    IsHospital = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Name",
                schema: "dbo",
                table: "Organization",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Orgn",
                schema: "dbo",
                table: "Organization",
                column: "Orgn",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organization",
                schema: "dbo");
        }
    }
}
