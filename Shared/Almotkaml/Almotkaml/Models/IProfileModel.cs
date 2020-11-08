namespace Almotkaml.Models
{
    public interface IProfileModel
    {
        string UserName { get; set; }
        string OldPassword { get; set; }
        string NewPassword { get; set; }
        string ConfirmPassword { get; set; }
        bool ChangePassword { get; set; }
    }
}