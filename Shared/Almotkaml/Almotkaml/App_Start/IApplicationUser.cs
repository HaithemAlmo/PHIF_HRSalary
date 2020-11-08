
namespace Almotkaml
{
    public interface IApplicationUser<out TPermission>
    {
        int Id { get; }
        string UserName { get; }
        string Title { get; }
        TPermission Permissions { get; }
    }
}