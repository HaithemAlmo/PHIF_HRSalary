using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class ActivitesFixUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Absences_AbsenceId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AdjectiveEmployees_AdjectiveEmployeeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AdjectiveEmployeeTypes_AdjectiveEmployeeTypeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AdvancePayments_AdvancePaymentId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_BankBranches_BankBranchId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Banks_BankId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Branchs_BranchId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Centers_CenterId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Cities_CityId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Countries_CountryId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_CurrentSituations_CurrentSituationId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Delegations_DelegationId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Departments_DepartmentId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_DevelopmentStates_DevelopmentStateId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_DevelopmentTypeAs_DevelopmentTypeAId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_DevelopmentTypeBs_DevelopmentTypeBId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_DevelopmentTypeCs_DevelopmentTypeCId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_DevelopmentTypeDs_DevelopmentTypeDId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_DevelopmentTypeEs_DevelopmentTypeEId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Divisions_DivisionId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Employees_EmployeeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_EndServiceses_EndServicesId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Evaluations_EvaluationId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ExactSpecialties_ExactSpecialtyId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Extraworks_ExtraworkId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Holidays_HolidayId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Jobs_JobId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Nationalities_NationalityId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Places_PlaceId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Qualifications_QualificationId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_QualificationTypes_QualificationTypeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_RequestedQualifications_RequestedQualificationId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Rewards_RewardId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_RewardTypes_RewardTypeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Sanctions_SanctionId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_SanctionTypes_SanctionTypeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_SelfCourses_SelfCoursesId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_SituationResolveJobs_SituationResolveJobId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Specialties_SpecialtyId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Staffings_StaffingId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_StaffingTypes_StaffingTypeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_SubSpecialties_SubSpecialtyId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_TemporaryPremiums_TemporaryPremiumId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_TrainingCenters_TrainingCenterId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Trainings_TrainingId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Transfers_TransferId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Units_UnitId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_UserGroups_UserGroupId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Vacations_VacationId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_VacationTypes_VacationTypeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_EmployeePremiums_EmployeePremiumPremiumId_EmployeePremiumEmployeeId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_AbsenceId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_AdjectiveEmployeeId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_AdjectiveEmployeeTypeId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_AdvancePaymentId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_BankBranchId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_BankId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_BranchId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CenterId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CityId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CountryId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CurrentSituationId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DelegationId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DepartmentId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DevelopmentStateId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DevelopmentTypeAId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DevelopmentTypeBId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DevelopmentTypeCId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DevelopmentTypeDId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DevelopmentTypeEId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DivisionId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_EmployeeId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_EndServicesId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_EvaluationId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ExactSpecialtyId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ExtraworkId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_HolidayId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_JobId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_NationalityId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_PlaceId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_QualificationId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_QualificationTypeId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_RequestedQualificationId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_RewardId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_RewardTypeId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SanctionId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SanctionTypeId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SelfCoursesId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SituationResolveJobId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SpecialtyId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_StaffingId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_StaffingTypeId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SubSpecialtyId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_TemporaryPremiumId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_TrainingCenterId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_TrainingId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_TransferId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_UnitId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_UserGroupId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_VacationId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_VacationTypeId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_EmployeePremiumPremiumId_EmployeePremiumEmployeeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AbsenceId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AdjectiveEmployeeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AdjectiveEmployeeTypeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AdvancePaymentId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "BankBranchId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CurrentSituationId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DelegationId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DevelopmentStateId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DevelopmentTypeAId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DevelopmentTypeBId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DevelopmentTypeCId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DevelopmentTypeDId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DevelopmentTypeEId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EmployeePremiumEmployeeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EmployeePremiumPremiumId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EndServicesId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EvaluationId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ExactSpecialtyId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ExtraworkId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "HolidayId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "QualificationId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "QualificationTypeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "RequestedQualificationId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "RewardId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "RewardTypeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SanctionId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SanctionTypeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SelfCoursesId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SituationResolveJobId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "StaffingId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "StaffingTypeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SubSpecialtyId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TemporaryPremiumId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TrainingCenterId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "VacationId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "VacationTypeId",
                table: "Activities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AbsenceId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdjectiveEmployeeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdjectiveEmployeeTypeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdvancePaymentId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankBranchId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentSituationId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DelegationId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DevelopmentStateId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DevelopmentTypeAId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DevelopmentTypeBId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DevelopmentTypeCId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DevelopmentTypeDId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DevelopmentTypeEId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeePremiumEmployeeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeePremiumPremiumId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EndServicesId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EvaluationId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExactSpecialtyId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ExtraworkId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HolidayId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QualificationId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QualificationTypeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestedQualificationId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RewardId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RewardTypeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SanctionId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SanctionTypeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelfCoursesId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SituationResolveJobId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffingId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffingTypeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubSpecialtyId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemporaryPremiumId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingCenterId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransferId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserGroupId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VacationId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacationTypeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AbsenceId",
                table: "Activities",
                column: "AbsenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AdjectiveEmployeeId",
                table: "Activities",
                column: "AdjectiveEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AdjectiveEmployeeTypeId",
                table: "Activities",
                column: "AdjectiveEmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AdvancePaymentId",
                table: "Activities",
                column: "AdvancePaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_BankBranchId",
                table: "Activities",
                column: "BankBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_BankId",
                table: "Activities",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_BranchId",
                table: "Activities",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CenterId",
                table: "Activities",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CityId",
                table: "Activities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CountryId",
                table: "Activities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CurrentSituationId",
                table: "Activities",
                column: "CurrentSituationId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DelegationId",
                table: "Activities",
                column: "DelegationId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DepartmentId",
                table: "Activities",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DevelopmentStateId",
                table: "Activities",
                column: "DevelopmentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DevelopmentTypeAId",
                table: "Activities",
                column: "DevelopmentTypeAId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DevelopmentTypeBId",
                table: "Activities",
                column: "DevelopmentTypeBId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DevelopmentTypeCId",
                table: "Activities",
                column: "DevelopmentTypeCId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DevelopmentTypeDId",
                table: "Activities",
                column: "DevelopmentTypeDId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DevelopmentTypeEId",
                table: "Activities",
                column: "DevelopmentTypeEId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DivisionId",
                table: "Activities",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_EmployeeId",
                table: "Activities",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_EndServicesId",
                table: "Activities",
                column: "EndServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_EvaluationId",
                table: "Activities",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ExactSpecialtyId",
                table: "Activities",
                column: "ExactSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ExtraworkId",
                table: "Activities",
                column: "ExtraworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_HolidayId",
                table: "Activities",
                column: "HolidayId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_JobId",
                table: "Activities",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_NationalityId",
                table: "Activities",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_PlaceId",
                table: "Activities",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_QualificationId",
                table: "Activities",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_QualificationTypeId",
                table: "Activities",
                column: "QualificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_RequestedQualificationId",
                table: "Activities",
                column: "RequestedQualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_RewardId",
                table: "Activities",
                column: "RewardId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_RewardTypeId",
                table: "Activities",
                column: "RewardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SanctionId",
                table: "Activities",
                column: "SanctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SanctionTypeId",
                table: "Activities",
                column: "SanctionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SelfCoursesId",
                table: "Activities",
                column: "SelfCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SituationResolveJobId",
                table: "Activities",
                column: "SituationResolveJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SpecialtyId",
                table: "Activities",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_StaffingId",
                table: "Activities",
                column: "StaffingId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_StaffingTypeId",
                table: "Activities",
                column: "StaffingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SubSpecialtyId",
                table: "Activities",
                column: "SubSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TemporaryPremiumId",
                table: "Activities",
                column: "TemporaryPremiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TrainingCenterId",
                table: "Activities",
                column: "TrainingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TrainingId",
                table: "Activities",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TransferId",
                table: "Activities",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UnitId",
                table: "Activities",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserGroupId",
                table: "Activities",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_VacationId",
                table: "Activities",
                column: "VacationId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_VacationTypeId",
                table: "Activities",
                column: "VacationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_EmployeePremiumPremiumId_EmployeePremiumEmployeeId",
                table: "Activities",
                columns: new[] { "EmployeePremiumPremiumId", "EmployeePremiumEmployeeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Absences_AbsenceId",
                table: "Activities",
                column: "AbsenceId",
                principalTable: "Absences",
                principalColumn: "AbsenceId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AdjectiveEmployees_AdjectiveEmployeeId",
                table: "Activities",
                column: "AdjectiveEmployeeId",
                principalTable: "AdjectiveEmployees",
                principalColumn: "AdjectiveEmployeeId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AdjectiveEmployeeTypes_AdjectiveEmployeeTypeId",
                table: "Activities",
                column: "AdjectiveEmployeeTypeId",
                principalTable: "AdjectiveEmployeeTypes",
                principalColumn: "AdjectiveEmployeeTypeId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AdvancePayments_AdvancePaymentId",
                table: "Activities",
                column: "AdvancePaymentId",
                principalTable: "AdvancePayments",
                principalColumn: "AdvancePaymentId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_BankBranches_BankBranchId",
                table: "Activities",
                column: "BankBranchId",
                principalTable: "BankBranches",
                principalColumn: "BankBranchId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Banks_BankId",
                table: "Activities",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "BankId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Branchs_BranchId",
                table: "Activities",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Centers_CenterId",
                table: "Activities",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "CenterId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Cities_CityId",
                table: "Activities",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Countries_CountryId",
                table: "Activities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_CurrentSituations_CurrentSituationId",
                table: "Activities",
                column: "CurrentSituationId",
                principalTable: "CurrentSituations",
                principalColumn: "CurrentSituationId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Delegations_DelegationId",
                table: "Activities",
                column: "DelegationId",
                principalTable: "Delegations",
                principalColumn: "DelegationId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Departments_DepartmentId",
                table: "Activities",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_DevelopmentStates_DevelopmentStateId",
                table: "Activities",
                column: "DevelopmentStateId",
                principalTable: "DevelopmentStates",
                principalColumn: "DevelopmentStateId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_DevelopmentTypeAs_DevelopmentTypeAId",
                table: "Activities",
                column: "DevelopmentTypeAId",
                principalTable: "DevelopmentTypeAs",
                principalColumn: "DevelopmentTypeAId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_DevelopmentTypeBs_DevelopmentTypeBId",
                table: "Activities",
                column: "DevelopmentTypeBId",
                principalTable: "DevelopmentTypeBs",
                principalColumn: "DevelopmentTypeBId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_DevelopmentTypeCs_DevelopmentTypeCId",
                table: "Activities",
                column: "DevelopmentTypeCId",
                principalTable: "DevelopmentTypeCs",
                principalColumn: "DevelopmentTypeCId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_DevelopmentTypeDs_DevelopmentTypeDId",
                table: "Activities",
                column: "DevelopmentTypeDId",
                principalTable: "DevelopmentTypeDs",
                principalColumn: "DevelopmentTypeDId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_DevelopmentTypeEs_DevelopmentTypeEId",
                table: "Activities",
                column: "DevelopmentTypeEId",
                principalTable: "DevelopmentTypeEs",
                principalColumn: "DevelopmentTypeEId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Divisions_DivisionId",
                table: "Activities",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Employees_EmployeeId",
                table: "Activities",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_EndServiceses_EndServicesId",
                table: "Activities",
                column: "EndServicesId",
                principalTable: "EndServiceses",
                principalColumn: "EndServicesId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Evaluations_EvaluationId",
                table: "Activities",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "EvaluationId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ExactSpecialties_ExactSpecialtyId",
                table: "Activities",
                column: "ExactSpecialtyId",
                principalTable: "ExactSpecialties",
                principalColumn: "ExactSpecialtyId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Extraworks_ExtraworkId",
                table: "Activities",
                column: "ExtraworkId",
                principalTable: "Extraworks",
                principalColumn: "ExtraworkId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Holidays_HolidayId",
                table: "Activities",
                column: "HolidayId",
                principalTable: "Holidays",
                principalColumn: "HolidayId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Jobs_JobId",
                table: "Activities",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Nationalities_NationalityId",
                table: "Activities",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Places_PlaceId",
                table: "Activities",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Qualifications_QualificationId",
                table: "Activities",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "QualificationId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_QualificationTypes_QualificationTypeId",
                table: "Activities",
                column: "QualificationTypeId",
                principalTable: "QualificationTypes",
                principalColumn: "QualificationTypeId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_RequestedQualifications_RequestedQualificationId",
                table: "Activities",
                column: "RequestedQualificationId",
                principalTable: "RequestedQualifications",
                principalColumn: "RequestedQualificationId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Rewards_RewardId",
                table: "Activities",
                column: "RewardId",
                principalTable: "Rewards",
                principalColumn: "RewardId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_RewardTypes_RewardTypeId",
                table: "Activities",
                column: "RewardTypeId",
                principalTable: "RewardTypes",
                principalColumn: "RewardTypeId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Sanctions_SanctionId",
                table: "Activities",
                column: "SanctionId",
                principalTable: "Sanctions",
                principalColumn: "SanctionId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_SanctionTypes_SanctionTypeId",
                table: "Activities",
                column: "SanctionTypeId",
                principalTable: "SanctionTypes",
                principalColumn: "SanctionTypeId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_SelfCourses_SelfCoursesId",
                table: "Activities",
                column: "SelfCoursesId",
                principalTable: "SelfCourses",
                principalColumn: "SelfCoursesId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_SituationResolveJobs_SituationResolveJobId",
                table: "Activities",
                column: "SituationResolveJobId",
                principalTable: "SituationResolveJobs",
                principalColumn: "SituationResolveJobId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Specialties_SpecialtyId",
                table: "Activities",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Staffings_StaffingId",
                table: "Activities",
                column: "StaffingId",
                principalTable: "Staffings",
                principalColumn: "StaffingId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_StaffingTypes_StaffingTypeId",
                table: "Activities",
                column: "StaffingTypeId",
                principalTable: "StaffingTypes",
                principalColumn: "StaffingTypeId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_SubSpecialties_SubSpecialtyId",
                table: "Activities",
                column: "SubSpecialtyId",
                principalTable: "SubSpecialties",
                principalColumn: "SubSpecialtyId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_TemporaryPremiums_TemporaryPremiumId",
                table: "Activities",
                column: "TemporaryPremiumId",
                principalTable: "TemporaryPremiums",
                principalColumn: "TemporaryPremiumId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_TrainingCenters_TrainingCenterId",
                table: "Activities",
                column: "TrainingCenterId",
                principalTable: "TrainingCenters",
                principalColumn: "TrainingCenterId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Trainings_TrainingId",
                table: "Activities",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "TrainingId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Transfers_TransferId",
                table: "Activities",
                column: "TransferId",
                principalTable: "Transfers",
                principalColumn: "TransferId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Units_UnitId",
                table: "Activities",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_UserGroups_UserGroupId",
                table: "Activities",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "UserGroupId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Vacations_VacationId",
                table: "Activities",
                column: "VacationId",
                principalTable: "Vacations",
                principalColumn: "VacationId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_VacationTypes_VacationTypeId",
                table: "Activities",
                column: "VacationTypeId",
                principalTable: "VacationTypes",
                principalColumn: "VacationTypeId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_EmployeePremiums_EmployeePremiumPremiumId_EmployeePremiumEmployeeId",
                table: "Activities",
                columns: new[] { "EmployeePremiumPremiumId", "EmployeePremiumEmployeeId" },
                principalTable: "EmployeePremiums",
                principalColumns: new[] { "PremiumId", "EmployeeId" },
                onDelete: ReferentialAction.SetNull);
        }
    }
}
