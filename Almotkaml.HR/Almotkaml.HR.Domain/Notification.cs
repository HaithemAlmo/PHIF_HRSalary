namespace Almotkaml.HR.Domain
{
    public class Notification
    {
        public static Notification New(Activity activity, int receiverUserId)
        {
            Check.NotNull(activity, nameof(activity));
            Check.MoreThanZero(receiverUserId, nameof(receiverUserId));

            return new Notification()
            {
                Activity = activity,
                ActivityId = activity.ActivityId,
                Receiver_UserId = receiverUserId
            };
        }
        public static Notification New(Activity activity, User receiverUser)
        {
            Check.NotNull(activity, nameof(activity));
            Check.NotNull(receiverUser, nameof(receiverUser));

            return new Notification()
            {
                Activity = activity,
                ActivityId = activity.ActivityId,
                Receiver_User = receiverUser,
                Receiver_UserId = receiverUser.UserId
            };
        }
        private Notification()
        {
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public long NotificationId { get; private set; }
        public long ActivityId { get; private set; }
        public Activity Activity { get; private set; }
        public int Receiver_UserId { get; private set; }
        public User Receiver_User { get; private set; }
        public bool IsRead { get; private set; }
        public void Read() => IsRead = true;

        public void UnRead() => IsRead = false;
    }
}
