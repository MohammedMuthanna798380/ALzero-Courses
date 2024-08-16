using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ALzero.BL
{
    class ISADMIN
    {

        public static int getAdminStatus(int user_id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = user_id;
            DAL.DAL dal = new DAL.DAL();   
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("IsSetAdmin", param);
            return dt.Rows.Count;
        }
    }
}
