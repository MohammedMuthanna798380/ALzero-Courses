using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ALzero.BL
{
    class COURSES
    {
        DAL.DAL dal = new DAL.DAL();
        public DataTable getNamesOfCourses()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("namesOfCourses", null);

            return dt;
        }
        public DataTable getIDOfCourse(string subj_name)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@c_name", SqlDbType.NVarChar, 50);
            param[0].Value = subj_name;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("getIDOfCourse", param);

            return dt;
        }
        public DataTable getVed(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@c_id", SqlDbType.Int);
            param[0].Value = id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("select_vedios", param);

            return dt;
        }
        public DataTable getIdUser()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("idOfUser", null);

            return dt;
        }
        public void insertVedLater(int ved_id, int user_id)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ved_id", SqlDbType.Int);
            param[0].Value = ved_id;
            param[1] = new SqlParameter("@user_id", SqlDbType.Int);
            param[1].Value = user_id;

            dal.open();
            dal.write("insertVedLater", param);
        }
        public DataTable getIdOfVed(string ved_name)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ved_name", SqlDbType.NVarChar, 1000);
            param[0].Value = ved_name;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("getIdOfVed", param);
            return dt;
        }
    }
}
