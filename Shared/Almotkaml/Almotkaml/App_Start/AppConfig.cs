using Almotkaml.Extensions;
using System;

namespace Almotkaml
{
    public class AppConfig
    {
        private string _dbName;
        public string ConnectionString { get; set; }
        public Type RepositoryType { get; set; }
        public bool IsDemo { get; set; }

        public string DbName
        {
            get
            {
                if (_dbName != null)
                    return _dbName;

                _dbName = ConnectionString.Between("Database=", ';');
                return _dbName;
            }
        }
    }
}
