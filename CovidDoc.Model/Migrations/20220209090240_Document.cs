using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidDoc.Model.Migrations
{
    public partial class Document : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Organization_Orgn",
                schema: "dbo",
                table: "Organization");

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

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Organization",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                schema: "dbo",
                table: "Organization",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "dbo",
                table: "AppUser",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "DocumentModifiedByUserId",
                schema: "dbo",
                table: "AppUser",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StatusTransitionGrantedForRolesId",
                schema: "dbo",
                table: "AppRole",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentStatus",
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
                    table.PrimaryKey("PK_DocumentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityDocumentType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    SerialPattern = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    NumberPattern = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityDocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabService",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mis",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    SmsoConnection_Host = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    SmsoConnection_Port = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    SmsoConnection_Database = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    SmsoConnection_UserName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    SmsoConnection_Password = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearchResult",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearchType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsoEventType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsoEventType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestReason",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestSystem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccineType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifyDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrganizationId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreateByUserId = table.Column<long>(type: "INTEGER", nullable: false),
                    DocumentStatusId = table.Column<long>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    LaboratoryId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_AppUser_CreateByUserId",
                        column: x => x.CreateByUserId,
                        principalSchema: "dbo",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document_DocumentStatus_DocumentStatusId",
                        column: x => x.DocumentStatusId,
                        principalSchema: "dbo",
                        principalTable: "DocumentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document_Organization_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalSchema: "dbo",
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "dbo",
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusTransition",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EnablePredicate = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: true),
                    AutoRunPredicate = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: true),
                    InitialStatusId = table.Column<long>(type: "INTEGER", nullable: true),
                    TargetStatusId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTransition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusTransition_DocumentStatus_InitialStatusId",
                        column: x => x.InitialStatusId,
                        principalSchema: "dbo",
                        principalTable: "DocumentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatusTransition_DocumentStatus_TargetStatusId",
                        column: x => x.TargetStatusId,
                        principalSchema: "dbo",
                        principalTable: "DocumentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Signature",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SignDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SignData = table.Column<byte>(type: "INTEGER", nullable: false),
                    SignatoryUserId = table.Column<long>(type: "INTEGER", nullable: false),
                    DocumentId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Signature_AppUser_SignatoryUserId",
                        column: x => x.SignatoryUserId,
                        principalSchema: "dbo",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Signature_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatrName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Sex = table.Column<byte>(type: "INTEGER", nullable: false, defaultValue: (byte)2),
                    Snils = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false, defaultValue: "Номер телефона"),
                    Policy = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false, defaultValue: "Номер полиса ОМС единого образца"),
                    ParentFio = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    FactAddressId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Region = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    District = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Town = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Street = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    House = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Building = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Appartment = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    PatientRegAddressId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Patient_PatientRegAddressId",
                        column: x => x.PatientRegAddressId,
                        principalSchema: "dbo",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityDocument",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Serial = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Number = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientId = table.Column<long>(type: "INTEGER", nullable: false),
                    IdentityDocumentTypeId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityDocument_IdentityDocumentType_IdentityDocumentTypeId",
                        column: x => x.IdentityDocumentTypeId,
                        principalSchema: "dbo",
                        principalTable: "IdentityDocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityDocument_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferralItem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProbeDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastVisitDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MKB = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    DiseaseDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CureDays = table.Column<byte>(type: "INTEGER", nullable: true),
                    IsLeaveCountry = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    Patalogy = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ct = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CreatedByUserId = table.Column<long>(type: "INTEGER", nullable: false),
                    PatientId = table.Column<long>(type: "INTEGER", nullable: false),
                    ReferralPackId = table.Column<long>(type: "INTEGER", nullable: false),
                    TestReasonId = table.Column<long>(type: "INTEGER", nullable: false),
                    DoctorId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferralItem_AppUser_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "dbo",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferralItem_AppUser_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "dbo",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferralItem_Document_ReferralPackId",
                        column: x => x.ReferralPackId,
                        principalSchema: "dbo",
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferralItem_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferralItem_TestReason_TestReasonId",
                        column: x => x.TestReasonId,
                        principalSchema: "dbo",
                        principalTable: "TestReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Work_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalization",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeginDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HospitalName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ReferralItemHospitalizationId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitalization_ReferralItem_ReferralItemHospitalizationId",
                        column: x => x.ReferralItemHospitalizationId,
                        principalSchema: "dbo",
                        principalTable: "ReferralItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabOrder",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SendDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TestSystemId = table.Column<long>(type: "INTEGER", nullable: false),
                    LabServiceId = table.Column<long>(type: "INTEGER", nullable: false),
                    ReferralItemLabOrderId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabOrder_LabService_LabServiceId",
                        column: x => x.LabServiceId,
                        principalSchema: "dbo",
                        principalTable: "LabService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabOrder_ReferralItem_ReferralItemLabOrderId",
                        column: x => x.ReferralItemLabOrderId,
                        principalSchema: "dbo",
                        principalTable: "ReferralItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabOrder_TestSystem_TestSystemId",
                        column: x => x.TestSystemId,
                        principalSchema: "dbo",
                        principalTable: "TestSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabResult",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResultDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ResultCode = table.Column<byte>(type: "INTEGER", nullable: false),
                    ResearchTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    ResearchResultId = table.Column<long>(type: "INTEGER", nullable: false),
                    ReferralItemLabResultId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabResult_ReferralItem_ReferralItemLabResultId",
                        column: x => x.ReferralItemLabResultId,
                        principalSchema: "dbo",
                        principalTable: "ReferralItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabResult_ResearchResult_ResearchResultId",
                        column: x => x.ResearchResultId,
                        principalSchema: "dbo",
                        principalTable: "ResearchResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabResult_ResearchType_ResearchTypeId",
                        column: x => x.ResearchTypeId,
                        principalSchema: "dbo",
                        principalTable: "ResearchType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecurrenceDisease",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeginDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MKB = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    UNRZ = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ReferralItemRecurrenceDiseaseId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurrenceDisease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurrenceDisease_ReferralItem_ReferralItemRecurrenceDiseaseId",
                        column: x => x.ReferralItemRecurrenceDiseaseId,
                        principalSchema: "dbo",
                        principalTable: "ReferralItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vaccination",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastVaccinationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VaccineTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    ReferralItemVaccinationId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccination_ReferralItem_ReferralItemVaccinationId",
                        column: x => x.ReferralItemVaccinationId,
                        principalSchema: "dbo",
                        principalTable: "ReferralItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vaccination_VaccineType_VaccineTypeId",
                        column: x => x.VaccineTypeId,
                        principalSchema: "dbo",
                        principalTable: "VaccineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Email",
                schema: "dbo",
                table: "Organization",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Orgn",
                schema: "dbo",
                table: "Organization",
                column: "Orgn");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_ParentId",
                schema: "dbo",
                table: "Organization",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_DocumentModifiedByUserId",
                schema: "dbo",
                table: "AppUser",
                column: "DocumentModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_StatusTransitionGrantedForRolesId",
                schema: "dbo",
                table: "AppRole",
                column: "StatusTransitionGrantedForRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Appartment",
                schema: "dbo",
                table: "Address",
                column: "Appartment",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_Building",
                schema: "dbo",
                table: "Address",
                column: "Building",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_District",
                schema: "dbo",
                table: "Address",
                column: "District",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_House",
                schema: "dbo",
                table: "Address",
                column: "House",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_PatientRegAddressId",
                schema: "dbo",
                table: "Address",
                column: "PatientRegAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_Region",
                schema: "dbo",
                table: "Address",
                column: "Region",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_Street",
                schema: "dbo",
                table: "Address",
                column: "Street",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_Town",
                schema: "dbo",
                table: "Address",
                column: "Town",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Document_CreateByUserId",
                schema: "dbo",
                table: "Document",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocumentStatusId",
                schema: "dbo",
                table: "Document",
                column: "DocumentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_LaboratoryId",
                schema: "dbo",
                table: "Document",
                column: "LaboratoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Document_OrganizationId",
                schema: "dbo",
                table: "Document",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentStatus_Name",
                schema: "dbo",
                table: "DocumentStatus",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalization_HospitalName",
                schema: "dbo",
                table: "Hospitalization",
                column: "HospitalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalization_ReferralItemHospitalizationId",
                schema: "dbo",
                table: "Hospitalization",
                column: "ReferralItemHospitalizationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocument_IdentityDocumentTypeId",
                schema: "dbo",
                table: "IdentityDocument",
                column: "IdentityDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocument_Number",
                schema: "dbo",
                table: "IdentityDocument",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocument_PatientId",
                schema: "dbo",
                table: "IdentityDocument",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocument_Serial",
                schema: "dbo",
                table: "IdentityDocument",
                column: "Serial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocumentType_Code",
                schema: "dbo",
                table: "IdentityDocumentType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocumentType_Name",
                schema: "dbo",
                table: "IdentityDocumentType",
                column: "Name",
                unique: true);

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
                name: "IX_LabOrder_LabServiceId",
                schema: "dbo",
                table: "LabOrder",
                column: "LabServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_LabOrder_ReferralItemLabOrderId",
                schema: "dbo",
                table: "LabOrder",
                column: "ReferralItemLabOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabOrder_TestSystemId",
                schema: "dbo",
                table: "LabOrder",
                column: "TestSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_LabResult_ReferralItemLabResultId",
                schema: "dbo",
                table: "LabResult",
                column: "ReferralItemLabResultId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabResult_ResearchResultId",
                schema: "dbo",
                table: "LabResult",
                column: "ResearchResultId");

            migrationBuilder.CreateIndex(
                name: "IX_LabResult_ResearchTypeId",
                schema: "dbo",
                table: "LabResult",
                column: "ResearchTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LabService_Code",
                schema: "dbo",
                table: "LabService",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabService_Name",
                schema: "dbo",
                table: "LabService",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_FactAddressId",
                schema: "dbo",
                table: "Patient",
                column: "FactAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_FirstName",
                schema: "dbo",
                table: "Patient",
                column: "FirstName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_LastName",
                schema: "dbo",
                table: "Patient",
                column: "LastName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ParentFio",
                schema: "dbo",
                table: "Patient",
                column: "ParentFio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PatrName",
                schema: "dbo",
                table: "Patient",
                column: "PatrName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Phone",
                schema: "dbo",
                table: "Patient",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Policy",
                schema: "dbo",
                table: "Patient",
                column: "Policy",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Snils",
                schema: "dbo",
                table: "Patient",
                column: "Snils",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecurrenceDisease_MKB",
                schema: "dbo",
                table: "RecurrenceDisease",
                column: "MKB",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecurrenceDisease_ReferralItemRecurrenceDiseaseId",
                schema: "dbo",
                table: "RecurrenceDisease",
                column: "ReferralItemRecurrenceDiseaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecurrenceDisease_UNRZ",
                schema: "dbo",
                table: "RecurrenceDisease",
                column: "UNRZ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReferralItem_CreatedByUserId",
                schema: "dbo",
                table: "ReferralItem",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferralItem_DoctorId",
                schema: "dbo",
                table: "ReferralItem",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferralItem_MKB",
                schema: "dbo",
                table: "ReferralItem",
                column: "MKB",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReferralItem_Patalogy",
                schema: "dbo",
                table: "ReferralItem",
                column: "Patalogy",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReferralItem_PatientId",
                schema: "dbo",
                table: "ReferralItem",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferralItem_ReferralPackId",
                schema: "dbo",
                table: "ReferralItem",
                column: "ReferralPackId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferralItem_TestReasonId",
                schema: "dbo",
                table: "ReferralItem",
                column: "TestReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchResult_Code",
                schema: "dbo",
                table: "ResearchResult",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResearchResult_Name",
                schema: "dbo",
                table: "ResearchResult",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResearchType_Code",
                schema: "dbo",
                table: "ResearchType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResearchType_Name",
                schema: "dbo",
                table: "ResearchType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Signature_DocumentId",
                schema: "dbo",
                table: "Signature",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Signature_SignatoryUserId",
                schema: "dbo",
                table: "Signature",
                column: "SignatoryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTransition_InitialStatusId",
                schema: "dbo",
                table: "StatusTransition",
                column: "InitialStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTransition_Name",
                schema: "dbo",
                table: "StatusTransition",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusTransition_TargetStatusId",
                schema: "dbo",
                table: "StatusTransition",
                column: "TargetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TestReason_Code",
                schema: "dbo",
                table: "TestReason",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestReason_Name",
                schema: "dbo",
                table: "TestReason",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestSystem_Code",
                schema: "dbo",
                table: "TestSystem",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestSystem_Name",
                schema: "dbo",
                table: "TestSystem",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccination_ReferralItemVaccinationId",
                schema: "dbo",
                table: "Vaccination",
                column: "ReferralItemVaccinationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccination_VaccineTypeId",
                schema: "dbo",
                table: "Vaccination",
                column: "VaccineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineType_Code",
                schema: "dbo",
                table: "VaccineType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaccineType_Name",
                schema: "dbo",
                table: "VaccineType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Work_Address",
                schema: "dbo",
                table: "Work",
                column: "Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Work_Name",
                schema: "dbo",
                table: "Work",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Work_PatientId",
                schema: "dbo",
                table: "Work",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRole_StatusTransition_StatusTransitionGrantedForRolesId",
                schema: "dbo",
                table: "AppRole",
                column: "StatusTransitionGrantedForRolesId",
                principalSchema: "dbo",
                principalTable: "StatusTransition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Document_DocumentModifiedByUserId",
                schema: "dbo",
                table: "AppUser",
                column: "DocumentModifiedByUserId",
                principalSchema: "dbo",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Organization_ParentId",
                schema: "dbo",
                table: "Organization",
                column: "ParentId",
                principalSchema: "dbo",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Address_FactAddressId",
                schema: "dbo",
                table: "Patient",
                column: "FactAddressId",
                principalSchema: "dbo",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRole_StatusTransition_StatusTransitionGrantedForRolesId",
                schema: "dbo",
                table: "AppRole");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Document_DocumentModifiedByUserId",
                schema: "dbo",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Organization_ParentId",
                schema: "dbo",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Patient_PatientRegAddressId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropTable(
                name: "Hospitalization",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "IdentityDocument",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LabOrder",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LabResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Mis",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RecurrenceDisease",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Signature",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SmsoEventType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StatusTransition",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Vaccination",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Work",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "IdentityDocumentType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LabService",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TestSystem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ResearchResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ResearchType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ReferralItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VaccineType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Document",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TestReason",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DocumentStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Patient",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Organization_Email",
                schema: "dbo",
                table: "Organization");

            migrationBuilder.DropIndex(
                name: "IX_Organization_Orgn",
                schema: "dbo",
                table: "Organization");

            migrationBuilder.DropIndex(
                name: "IX_Organization_ParentId",
                schema: "dbo",
                table: "Organization");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_DocumentModifiedByUserId",
                schema: "dbo",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppRole_StatusTransitionGrantedForRolesId",
                schema: "dbo",
                table: "AppRole");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "dbo",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "dbo",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "DocumentModifiedByUserId",
                schema: "dbo",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "StatusTransitionGrantedForRolesId",
                schema: "dbo",
                table: "AppRole");

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

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Orgn",
                schema: "dbo",
                table: "Organization",
                column: "Orgn",
                unique: true);
        }
    }
}
