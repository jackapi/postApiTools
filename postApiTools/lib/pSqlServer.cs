using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// SqlServer
/// by:chenran
/// </summary>
namespace postApiTools.lib
{
    using System.Data.SqlClient;
    public class pSqlServer
    {
        public SqlConnection conn;

        public pSqlServer()
        {
            string constr = "server=.;database=myschool;integrated security=SSPI";
            //string constr = "server=.;database=myschool;uid=sa;pwd=sa";
            //string constr = "data source=.;initial catalog=myschool;user id=sa;pwd=sa";
            conn = new SqlConnection(constr);
        }
    }
}
