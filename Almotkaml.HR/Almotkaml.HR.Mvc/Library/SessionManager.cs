using Almotkaml.HR.Models;
using System.Web;

namespace Almotkaml.HR.Mvc.Library
{
    public static class SessionManager
    {
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static int Year { get; set; }
        public static void Load()
        {
            try
            {
                UserName = (string)HttpContext.Current.Session["UserName"];
                Password = (string)HttpContext.Current.Session["Password"];
                //Year = (int)HttpContext.Current.Session["Year"];
            }
            catch
            {
                // ignored
            }
        }

        public static void Set(LoginModel model)
        {
            HttpContext.Current.Session["UserName"] = UserName = model.UserName;
            HttpContext.Current.Session["Password"] = Password = model.Password;
            //HttpContext.Current.Session["Year"] = Year = model.Year;
        }
    }
}