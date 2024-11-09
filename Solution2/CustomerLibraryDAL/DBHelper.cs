using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CustomerLibraryDAL;

namespace CustomerLibraryDAL
{
    public class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-99C4LBT;Initial Catalog=Car_Configurator;Integrated Security=True;");
            return con;
        }
    }
}
