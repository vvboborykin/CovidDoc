using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidDoc.Model.Migrations
{
    public partial class Security : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SmsoConnection_Database",
                schema: "dbo",
                table: "Organization",
                type: "TEXT",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmsoConnection_Host",
                schema: "dbo",
                table: "Organization",
                type: "TEXT",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmsoConnection_Password",
                schema: "dbo",
                table: "Organization",
                type: "TEXT",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmsoConnection_Port",
                schema: "dbo",
                table: "Organization",
                type: "TEXT",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmsoConnection_UserName",
                schema: "dbo",
                table: "Organization",
                type: "TEXT",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppRole",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Fio = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    SmsoPersonId = table.Column<int>(type: "INTEGER", nullable: true),
                    Disabled = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    OrganizationId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUser_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "dbo",
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppRole_Users_x_AppUser_Roles",
                schema: "dbo",
                columns: table => new
                {
                    RolesId = table.Column<long>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRole_Users_x_AppUser_Roles", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AppRole_Users_x_AppUser_Roles_AppRole_RolesId",
                        column: x => x.RolesId,
                        principalSchema: "dbo",
                        principalTable: "AppRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRole_Users_x_AppUser_Roles_AppUser_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "dbo",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_Name",
                schema: "dbo",
                table: "AppRole",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_Users_x_AppUser_Roles_UsersId",
                schema: "dbo",
                table: "AppRole_Users_x_AppUser_Roles",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_OrganizationId",
                schema: "dbo",
                table: "AppUser",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_UserName",
                schema: "dbo",
                table: "AppUser",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRole_Users_x_AppUser_Roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppUser",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "SmsoConnection_Database",
                schema: "dbo",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "SmsoConnection_Host",
                schema: "dbo",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "SmsoConnection_Password",
                schema: "dbo",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "SmsoConnection_Port",
                schema: "dbo",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "SmsoConnection_UserName",
                schema: "dbo",
                table: "Organization");
        }
    }
}
