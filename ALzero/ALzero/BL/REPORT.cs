using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ALzero.BL
{
    class REPORT
    {
        DAL.DAL dal = new DAL.DAL();
        public DataTable getUser()
        {
            DataTable dt = new DataTable();
            dal.open();
            return dt = dal.read("getAllUsers", null);
        }

        public DataTable getAllCourses()
        {
            DataTable dt = new DataTable();
            dal.open();
            return dt = dal.read("getAllCourses", null);
        }

        public DataTable getVedioCourse(int c_id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@c_id", SqlDbType.Int);
            para[0].Value = c_id;
            DataTable dt = new DataTable();
            dal.open();
            return dt = dal.read("ReportCourse", para);

        }

        public DataTable getWatchedVedio(int user_id, int ved_id)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@user_id", SqlDbType.Int);
            para[0].Value = user_id;
            para[1] = new SqlParameter("@ved_id", SqlDbType.Int);
            para[1].Value = ved_id;
            DataTable dt = new DataTable();
            dal.open();
            return dt = dal.read("ReportVideo", para);

        }
    }
}
