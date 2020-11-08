using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.Hosting;

namespace Almotkaml.HR.Mvc
{
    public static class HumanResourceConfig
    {
        public static AppConfig LoadConfig() => new AppConfig()
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"],
            IsDemo = ConfigurationManager.AppSettings["Setting"] != "almo",
            RepositoryType = Type.GetType(ConfigurationManager.AppSettings["UnitOfWorkType"], true)
        };

        public static string ApplicationFolderFullPath { get; set; }

        private static string _applicationFolderVirtualPath;

        public static string ApplicationFolderVirtualPath
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_applicationFolderVirtualPath))
                    return _applicationFolderVirtualPath;

                _applicationFolderVirtualPath = ApplicationFolderFullPath.ToVirtualPath();
                return _applicationFolderVirtualPath;
            }
        }

        private static string ToVirtualPath(this string path)
        {
            var currentDir = HostingEnvironment.ApplicationPhysicalPath;
            var directory = new DirectoryInfo(currentDir);
            string[] absDirs = directory.FullName.Split('\\');
            string[] relDirs = path.Split('\\');
            // Get the shortest of the two paths 
            int len = absDirs.Length < relDirs.Length ? absDirs.Length : relDirs.Length;
            // Use to determine where in the loop we exited 
            int lastCommonRoot = -1; int index;
            // Find common root 
            for (index = 0; index < len; index++)
            {
                if (string.Equals(absDirs[index], relDirs[index], StringComparison.CurrentCultureIgnoreCase))
                    lastCommonRoot = index;
                else break;
            }
            // If we didn't find a common prefix then throw 
            if (lastCommonRoot == -1)
            {
                throw new ArgumentException("Paths do not have a common base , first path : " + path
                    + " , second : " + currentDir);
            }
            // Build up the relative path 
            StringBuilder relativePath = new StringBuilder();
            // Add on the .. 
            for (index = lastCommonRoot + 1; index < absDirs.Length; index++)
            {
                if (absDirs[index].Length > 0) relativePath.Append("..\\");
            }
            // Add on the folders 
            for (index = lastCommonRoot + 1; index < relDirs.Length - 1; index++)
            {
                relativePath.Append(relDirs[index] + "\\");
            }
            relativePath.Append(relDirs[relDirs.Length - 1]);
            return relativePath.ToString().Replace('\\', '/');
        }
        public static string ToPhysicalPath(this string path) => path.Replace('/', '\\');
    }
}