using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Activity
    {
        public static Activity New(int userId, string activityType)
        {
            Check.MoreThanZero(userId, nameof(userId));
            Check.NotEmpty(activityType, nameof(activityType));

            var activtiy = new Activity()
            {
                FiredBy_UserId = userId,
                Type = activityType
            };

            // not completed ...
            return activtiy;
        }

        public static Activity New(User user, string activityType)
        {
            Check.NotNull(user, nameof(user));
            Check.NotEmpty(activityType, nameof(activityType));

            var activtiy = new Activity()
            {
                FiredBy_User = user,
                FiredBy_UserId = user.UserId,
                Type = activityType
            };

            return activtiy;
        }

        private Activity() { }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public long ActivityId { get; private set; }
        public DateTime DateTime { get; private set; } = DateTime.Now;
        public int FiredBy_UserId { get; private set; }
        public User FiredBy_User { get; private set; }
        public string Type { get; private set; }
        public ICollection<Notification> Notifications { get; } = new HashSet<Notification>();
    }
}
