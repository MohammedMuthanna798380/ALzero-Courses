using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ALzero.BL
{
    class MESSAGE
    {
        DAL.DAL dal = new DAL.DAL();
        public void deleteVed(int ved_id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ved_id", SqlDbType.Int);
            param[0].Value = ved_id;

            dal.open();
            dal.write("deleteVed", param);
        }
    }
}
