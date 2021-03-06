using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientTracking.DataAccess.Migrations
{
    public partial class CreatedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)"),
                    CountryCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonType = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "space(0)"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "space(0)"),
                    Gsm = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false, defaultValueSql: "space(0)"),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Convert(Date,GetDate())"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)"),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "space(0)"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)"),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "space(0)"),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false, defaultValueSql: "space(0)"),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitals_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Deparments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deparments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deparments_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeparmentId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diseases_Deparments_DeparmentId",
                        column: x => x.DeparmentId,
                        principalTable: "Deparments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeparmentId = table.Column<int>(type: "int", nullable: false),
                    DegreeId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "space(0)"),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctors_Deparments_DeparmentId",
                        column: x => x.DeparmentId,
                        principalTable: "Deparments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctors_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientDiseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DiseaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDiseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientDiseases_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientDiseases_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Email",
                table: "Admins",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_PersonId",
                table: "Admins",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryCode",
                table: "Countries",
                column: "CountryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deparments_HospitalId",
                table: "Deparments",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_DeparmentId",
                table: "Diseases",
                column: "DeparmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DegreeId",
                table: "Doctors",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DeparmentId",
                table: "Doctors",
                column: "DeparmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                table: "Doctors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PersonId",
                table: "Doctors",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_DistrictId",
                table: "Hospitals",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiseases_DiseaseId",
                table: "PatientDiseases",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiseases_PatientId_DiseaseId",
                table: "PatientDiseases",
                columns: new[] { "PatientId", "DiseaseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IdentityNumber",
                table: "Patients",
                column: "IdentityNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PersonId",
                table: "Patients",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Gsm",
                table: "Persons",
                column: "Gsm",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "PatientDiseases");

            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Deparments");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
