using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class RewardExtensions
    {

        public static IEnumerable<RewardGridRow> ToGrid(this IEnumerable<Reward> rewards)
          => rewards.Select(r => new RewardGridRow()
          {
              RewardId = r.RewardId,
              Date = r.Date.FormatToString(),
              EmployeeId = r.EmployeeId,
              EmployeeName = r.Employee?.GetFullName(),
              EfficiencyEstimate = r.EfficiencyEstimate,
              Note = r.Note,
              RewardTypeId = r.RewardTypeId,
              RewardTypeName = r.RewardType?.Name,
              Value = r.Value
          });
    }
}
