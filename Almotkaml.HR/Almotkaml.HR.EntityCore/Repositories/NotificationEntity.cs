using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        internal NotificationRepository(HrDbContext context)
            : base(context)
        {
        }
    }
}
