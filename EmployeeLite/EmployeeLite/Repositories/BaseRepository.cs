using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EmployeeLite.Repositories
{
    public class BaseRepository : IDisposable
    {
        public SQLiteConnection connection;

        public BaseRepository()
        {
            connection = new SQLiteConnection(
                    ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString
                );
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
