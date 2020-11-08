using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class TrainingExtensions
    {
        public static IEnumerable<TrainingGridRow> ToGrid(this IEnumerable<Training> trainings)
            => trainings.Select(d => new TrainingGridRow()
            {
                TrainingPlace = d.TrainingPlace,
                DevelopmentTypeDName = d.DevelopmentTypeD?.Name,
                TrainingId = d.TrainingId,
                RequestedQualificationName = d.RequestedQualification?.Name,
                CorporationName = d.Corporation?.Name,
                TrainingType = d.TrainingType
            });
        public static IEnumerable<TrainingDetailGridRow> ToGrid(this IEnumerable<TrainingDetail> trainingDetails)
            => trainingDetails.Select(d => new TrainingDetailGridRow()
            {
                TrainingDetailId = d.TrainingDetailId,
                EmployeeName = d.Employee?.GetFullName(),
                EmployeeId = d.EmployeeId
            });
    }
}