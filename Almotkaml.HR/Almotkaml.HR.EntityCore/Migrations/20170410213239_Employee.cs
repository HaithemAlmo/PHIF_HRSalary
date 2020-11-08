using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 1000, nullable: true),
                    AdjectiveEmployeeId = table.Column<int>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    BirthPlace = table.Column<string>(maxLength: 128, nullable: true),
                    BloodType = table.Column<int>(nullable: false),
                    ChildernCount = table.Column<int>(nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    EnglishFatherName = table.Column<string>(maxLength: 128, nullable: true),
                    EnglishFirstName = table.Column<string>(maxLength: 128, nullable: true),
                    EnglishGrandfatherName = table.Column<string>(maxLength: 128, nullable: true),
                    EnglishLastName = table.Column<string>(maxLength: 128, nullable: true),
                    FatherName = table.Column<string>(maxLength: 128, nullable: true),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    GrandfatherName = table.Column<string>(maxLength: 128, nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    JobId = table.Column<int>(nullable: true),
                    LastName = table.Column<string>(maxLength: 128, nullable: true),
                    MotherName = table.Column<string>(maxLength: 1000, nullable: true),
                    NationalNumber = table.Column<long>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    Phone = table.Column<string>(maxLength: 128, nullable: true),
                    PlaceId = table.Column<int>(nullable: true),
                    Religion = table.Column<int>(nullable: false),
                    SocialStatus = table.Column<int>(nullable: false),
                    SubSpecialtyId = table.Column<int>(nullable: true),
                    UnitId = table.Column<int>(nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_AdjectiveEmployees_AdjectiveEmployeeId",
                        column: x => x.AdjectiveEmployeeId,
                        principalTable: "AdjectiveEmployees",
                        principalColumn: "AdjectiveEmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_SubSpecialties_SubSpecialtyId",
                        column: x => x.SubSpecialtyId,
                        principalTable: "SubSpecialties",
                        principalColumn: "SubSpecialtyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booklets",
                columns: table => new
                {
                    BookletId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CivilRegistry = table.Column<string>(maxLength: 128, nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    FamilyNumber = table.Column<string>(maxLength: 128, nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    IssuePlace = table.Column<string>(maxLength: 128, nullable: true),
                    Number = table.Column<string>(maxLength: 128, nullable: true),
                    RegistrationNumber = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booklets", x => x.BookletId);
                    table.ForeignKey(
                        name: "FK_Booklets_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationCards",
                columns: table => new
                {
                    IdentificationCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    IssuePlace = table.Column<string>(maxLength: 128, nullable: true),
                    Number = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationCards", x => x.IdentificationCardId);
                    table.ForeignKey(
                        name: "FK_IdentificationCards_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobInfos",
                columns: table => new
                {
                    JobInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdjectiveEmployeeId = table.Column<int>(nullable: true),
                    Bouns = table.Column<int>(nullable: true),
                    CurrentSituationId = table.Column<int>(nullable: true),
                    DateBouns = table.Column<DateTime>(nullable: true),
                    DateDegreeNow = table.Column<DateTime>(nullable: true),
                    DateMeritBouns = table.Column<DateTime>(nullable: true),
                    DateMeritDegreeNow = table.Column<DateTime>(nullable: true),
                    Degree = table.Column<int>(nullable: true),
                    DegreeNow = table.Column<int>(nullable: true),
                    DirectlyDate = table.Column<DateTime>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    JobId = table.Column<int>(nullable: true),
                    JobNumber = table.Column<string>(maxLength: 128, nullable: true),
                    JobNumberApproved = table.Column<int>(nullable: true),
                    JobType = table.Column<int>(nullable: false),
                    NoteId = table.Column<int>(nullable: true),
                    ResolveResolutionDate = table.Column<DateTime>(nullable: true),
                    ResolveResolutionNumber = table.Column<string>(maxLength: 128, nullable: true),
                    SerialNumber = table.Column<int>(nullable: true),
                    SituationResolveJob = table.Column<int>(nullable: false),
                    StaffingId = table.Column<int>(nullable: true),
                    UnitId = table.Column<int>(nullable: true),
                    VacationBalance = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobInfos", x => x.JobInfoId);
                    table.ForeignKey(
                        name: "FK_JobInfos_AdjectiveEmployees_AdjectiveEmployeeId",
                        column: x => x.AdjectiveEmployeeId,
                        principalTable: "AdjectiveEmployees",
                        principalColumn: "AdjectiveEmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobInfos_CurrentSituations_CurrentSituationId",
                        column: x => x.CurrentSituationId,
                        principalTable: "CurrentSituations",
                        principalColumn: "CurrentSituationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobInfos_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobInfos_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobInfos_Staffings_StaffingId",
                        column: x => x.StaffingId,
                        principalTable: "Staffings",
                        principalColumn: "StaffingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobInfos_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryDatas",
                columns: table => new
                {
                    MilitaryDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdjectiveMilitary = table.Column<int>(nullable: false),
                    College = table.Column<string>(maxLength: 128, nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    GranduationDate = table.Column<DateTime>(nullable: true),
                    MilitaryNumber = table.Column<string>(maxLength: 128, nullable: true),
                    MotherUnit = table.Column<string>(maxLength: 128, nullable: true),
                    Rank = table.Column<string>(maxLength: 128, nullable: true),
                    Subunit = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryDatas", x => x.MilitaryDataId);
                    table.ForeignKey(
                        name: "FK_MilitaryDatas_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    PassportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutoNumber = table.Column<string>(maxLength: 128, nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    IssuePlace = table.Column<string>(maxLength: 128, nullable: true),
                    Number = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.PassportId);
                    table.ForeignKey(
                        name: "FK_Passports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentValues",
                columns: table => new
                {
                    EmploymentValuesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BenefitFromServicesDate = table.Column<DateTime>(nullable: true),
                    BenefitFromServicesSide = table.Column<string>(maxLength: 1000, nullable: true),
                    CollaboratorDate = table.Column<DateTime>(nullable: true),
                    CollaboratorSide = table.Column<string>(maxLength: 1000, nullable: true),
                    ContractDateFrom = table.Column<DateTime>(nullable: true),
                    ContractDateTo = table.Column<DateTime>(nullable: true),
                    DelegationDate = table.Column<DateTime>(nullable: true),
                    DelegationSide = table.Column<string>(maxLength: 1000, nullable: true),
                    DesignationIssue = table.Column<string>(maxLength: 128, nullable: true),
                    DesignationResolutionDate = table.Column<DateTime>(nullable: true),
                    DesignationResolutionNumber = table.Column<string>(maxLength: 128, nullable: true),
                    EmptiedDate = table.Column<DateTime>(nullable: true),
                    EmptiedSide = table.Column<string>(maxLength: 1000, nullable: true),
                    JobInfoId = table.Column<int>(nullable: true),
                    LoaningDate = table.Column<DateTime>(nullable: true),
                    LoaningSide = table.Column<string>(maxLength: 1000, nullable: true),
                    TransferDate = table.Column<DateTime>(nullable: true),
                    TransferSide = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentValues", x => x.EmploymentValuesId);
                    table.ForeignKey(
                        name: "FK_EmploymentValues_JobInfos_JobInfoId",
                        column: x => x.JobInfoId,
                        principalTable: "JobInfos",
                        principalColumn: "JobInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinancialDatas",
                columns: table => new
                {
                    FinancialDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankBranchId = table.Column<int>(nullable: true),
                    BondNumber = table.Column<string>(maxLength: 128, nullable: true),
                    FinancialNumber = table.Column<string>(maxLength: 128, nullable: true),
                    JobInfoId = table.Column<int>(nullable: true),
                    Salary = table.Column<decimal>(nullable: true),
                    SecurityNumber = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialDatas", x => x.FinancialDataId);
                    table.ForeignKey(
                        name: "FK_FinancialDatas_BankBranches_BankBranchId",
                        column: x => x.BankBranchId,
                        principalTable: "BankBranches",
                        principalColumn: "BankBranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinancialDatas_JobInfos_JobInfoId",
                        column: x => x.JobInfoId,
                        principalTable: "JobInfos",
                        principalColumn: "JobInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelfCourses_EmployeeId",
                table: "SelfCourses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanctions_EmployeeId",
                table: "Sanctions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_EmployeeId",
                table: "Rewards",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_EmployeeId",
                table: "Qualifications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Extraworks_EmployeeId",
                table: "Extraworks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_EmployeeId",
                table: "Evaluations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EndServiceses_EmployeeId",
                table: "EndServiceses",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_EmployeeId",
                table: "Activities",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Booklets_EmployeeId",
                table: "Booklets",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AdjectiveEmployeeId",
                table: "Employees",
                column: "AdjectiveEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobId",
                table: "Employees",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalityId",
                table: "Employees",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PlaceId",
                table: "Employees",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SubSpecialtyId",
                table: "Employees",
                column: "SubSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UnitId",
                table: "Employees",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentValues_JobInfoId",
                table: "EmploymentValues",
                column: "JobInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinancialDatas_BankBranchId",
                table: "FinancialDatas",
                column: "BankBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialDatas_JobInfoId",
                table: "FinancialDatas",
                column: "JobInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentificationCards_EmployeeId",
                table: "IdentificationCards",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_AdjectiveEmployeeId",
                table: "JobInfos",
                column: "AdjectiveEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_CurrentSituationId",
                table: "JobInfos",
                column: "CurrentSituationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_EmployeeId",
                table: "JobInfos",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_JobId",
                table: "JobInfos",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_StaffingId",
                table: "JobInfos",
                column: "StaffingId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_UnitId",
                table: "JobInfos",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryDatas_EmployeeId",
                table: "MilitaryDatas",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passports_EmployeeId",
                table: "Passports",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Employees_EmployeeId",
                table: "Activities",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_EndServiceses_Employees_EmployeeId",
                table: "EndServiceses",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Employees_EmployeeId",
                table: "Evaluations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Extraworks_Employees_EmployeeId",
                table: "Extraworks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_Employees_EmployeeId",
                table: "Qualifications",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Employees_EmployeeId",
                table: "Rewards",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_Employees_EmployeeId",
                table: "Sanctions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SelfCourses_Employees_EmployeeId",
                table: "SelfCourses",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Employees_EmployeeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_EndServiceses_Employees_EmployeeId",
                table: "EndServiceses");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Employees_EmployeeId",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Extraworks_Employees_EmployeeId",
                table: "Extraworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_Employees_EmployeeId",
                table: "Qualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Employees_EmployeeId",
                table: "Rewards");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_Employees_EmployeeId",
                table: "Sanctions");

            migrationBuilder.DropForeignKey(
                name: "FK_SelfCourses_Employees_EmployeeId",
                table: "SelfCourses");

            migrationBuilder.DropTable(
                name: "Booklets");

            migrationBuilder.DropTable(
                name: "EmploymentValues");

            migrationBuilder.DropTable(
                name: "FinancialDatas");

            migrationBuilder.DropTable(
                name: "IdentificationCards");

            migrationBuilder.DropTable(
                name: "MilitaryDatas");

            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "JobInfos");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_SelfCourses_EmployeeId",
                table: "SelfCourses");

            migrationBuilder.DropIndex(
                name: "IX_Sanctions_EmployeeId",
                table: "Sanctions");

            migrationBuilder.DropIndex(
                name: "IX_Rewards_EmployeeId",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Qualifications_EmployeeId",
                table: "Qualifications");

            migrationBuilder.DropIndex(
                name: "IX_Extraworks_EmployeeId",
                table: "Extraworks");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_EmployeeId",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_EndServiceses_EmployeeId",
                table: "EndServiceses");

            migrationBuilder.DropIndex(
                name: "IX_Activities_EmployeeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Activities");
        }
    }
}
