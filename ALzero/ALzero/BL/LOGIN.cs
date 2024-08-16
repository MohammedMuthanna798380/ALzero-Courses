using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ALzero.BL
{
    class LOGIN
    {
        DAL.DAL dal = new DAL.DAL();
        public DataTable log_in(string username, string pass)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar, 150);
            param[0].Value = username;
            param[1] = new SqlParameter("@pass", SqlDbType.NVarChar, 50);
            param[1].Value = pass;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("login_sp", param);

            return dt;
        }
        public void set_log(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = id;

            dal.open();
            dal.write("set_login", param);
        }
    }
}
