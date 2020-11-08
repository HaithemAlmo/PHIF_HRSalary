
namespace Almotkaml
{
    public abstract class ApplicationUser<TPermission, TUser, TLoginModel, TApplicationUserInterface> : IApplicationUser<TPermission>
    {
        public int Id { get; protected set; }
        public string UserName { get; protected set; }
        public string Title { get; protected set; }
        public TPermission Permissions { get; protected set; }
        public abstract void Set(TUser user, TLoginModel loginModel);
        public abstract TApplicationUserInterface AsInterface();
    }
}