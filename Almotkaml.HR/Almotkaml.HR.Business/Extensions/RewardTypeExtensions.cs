using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.Extensions
{
    public static class RewardTypeExtensions
    {
        public static IEnumerable<RewardTypeListItem> ToList(this IEnumerable<RewardType> rewardTypes)
            => rewardTypes.Select(d => new RewardTypeListItem()
            {
                Name = d.Name,
                RewardTypeId = d.RewardTypeId
            });
    }
}