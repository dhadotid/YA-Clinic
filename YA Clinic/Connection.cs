using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace YA_Clinic
{
    public class Connection
    {
        public SqlConnection openConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-MEO5I55\\DHADOTID; Initial Catalog=YR; User Id=sa; Password=qwerty");
            return con;
        }
    }
}