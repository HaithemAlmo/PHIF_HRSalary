namespace Almotkaml.HR.Domain.UserFactory
{
    public interface IIdHolder
    {
        INameHolder WithUserId(int userId);
    }
    public interface INameHolder
    {
        IPasswordHolder WithUserName(string userName);
    }
    public interface IPasswordHolder
    {
        ICheckPermHolder WithPassword(string password);
    }
    public interface ICheckPermHolder
    {
        IGroupHolder WithCheckPerm(int CheckPerm);
    }
    public interface IGroupHolder
    {
        ITitleHolder BelongsToGroupId(int userGroupId);
        ITitleHolder BelongsToGroup(UserGroup userGroup);
    }

    public interface ITitleHolder
    {
        INotifyHolder WithTitle(string title);
    }

    public interface INotifyHolder
    {
        IBuild NotifyOn(Notify notify);
    }
    public interface IBuild
    {
        User Biuld();
    }
}