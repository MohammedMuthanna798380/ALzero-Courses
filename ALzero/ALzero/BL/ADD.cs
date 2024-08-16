using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ALzero.BL
{
    class ADD
    {
        DAL.DAL dal = new DAL.DAL();

        public DataTable getCourses()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("getCourses", null);
            return dt;
        }
        public DataTable getFolderOfCourse(int c_id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@c_id", SqlDbType.Int);
            param[0].Value = c_id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("getFolderOfCourse", param);
            return dt;
        }
        public void addVedio(string ved_name,string ved_path,string ved_accuracy,int cors_id)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ved_name", SqlDbType.NVarChar, 1000);
            param[0].Value = ved_name;
            param[1] = new SqlParameter("@ved_path", SqlDbType.NVarChar, 500);
            param[1].Value = ved_path;
            param[2] = new SqlParameter("@ved_accuracy", SqlDbType.NVarChar, 50);
            param[2].Value = ved_accuracy;
            param[3] = new SqlParameter("@cors_id", SqlDbType.Int);
            param[3].Value = cors_id;

            dal.open();
            dal.write("addVedio", param);

        }
    }
}
