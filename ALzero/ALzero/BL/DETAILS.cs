using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ALzero.BL
{
    class DETAILS
    {
        DAL.DAL dal = new DAL.DAL();

        public int getIdUser()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("idOfUser", null);
            if (dt.Rows.Count > 0)
            {
                return (int)dt.Rows[0]["user_id"];
            }
            else
            {
                return 0;
            }
        }
        public DataTable getCourses()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("getCourses", null);
            return dt;
        }
        public DataTable getSubject()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("getSubject", null);
            return dt;
        }
        public DataTable getVedio(int ved_id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ved_id", SqlDbType.Int);
            param[0].Value = ved_id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("getVedio", param);
            return dt;
        }
        public DataTable checkWatched(int ved_id , int user_id)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ved_id", SqlDbType.Int);
            param[0].Value = ved_id;
            param[1] = new SqlParameter("@user_id", SqlDbType.Int);
            param[1].Value = user_id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("checkWatched", param);
            return dt;

        }
        public int numVedOfCourse(int c_id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@c_id", SqlDbType.Int);
            param[0].Value = c_id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("numVedOfCourse", param);

            return dt.Rows.Count;
        }
        public DataTable getDetailsCourse(int c_id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@c_id", SqlDbType.Int);
            param[0].Value = c_id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("getDetailsCourse", param);

            return dt;
        }
        public void rename_Course(int c_id,string c_name)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@c_id", SqlDbType.Int);
            param[0].Value = c_id;
            param[1] = new SqlParameter("@c_name", SqlDbType.NVarChar,50);
            param[1].Value = c_name;

            dal.open();
            dal.write("renameCourse", param);
        }
        public void rename_ved(int ved_id,string ved_name)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ved_id", SqlDbType.Int);
            param[0].Value = ved_id;
            param[1] = new SqlParameter("@ved_name", SqlDbType.NVarChar, 1000);
            param[1].Value = ved_name;

            dal.open();
            dal.write("renameVed", param);
        }
        public void updateVed(int ved_id,string ved_name,string ved_accuracy, int c_id)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ved_id", SqlDbType.Int);
            param[0].Value = ved_id;
            param[1] = new SqlParameter("@ved_name", SqlDbType.NVarChar, 1000);
            param[1].Value = ved_name;
            param[2] = new SqlParameter("@ved_accuracy", SqlDbType.NVarChar, 50);
            param[2].Value = ved_accuracy;
            param[3] = new SqlParameter("@c_id", SqlDbType.Int);
            param[3].Value = c_id;

            dal.open();
            dal.write("updateVed", param);
        }
        public void updateCourse(int c_id , string c_name , string teacher ,DateTime date_of_create,float v_avg, int subj_id)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@c_id", SqlDbType.Int);
            param[0].Value = c_id;
            param[1] = new SqlParameter("@c_name", SqlDbType.NVarChar, 50);
            param[1].Value = c_name;
            param[2] = new SqlParameter("@teacher", SqlDbType.NVarChar, 100);
            param[2].Value = teacher;
            param[3] = new SqlParameter("@date_of_create", SqlDbType.Date);
            param[3].Value = date_of_create;
            param[4] = new SqlParameter("@v_avg", SqlDbType.Float);
            param[4].Value = v_avg;
            param[5] = new SqlParameter("@subj_id", SqlDbType.Int);
            param[5].Value = subj_id;


            dal.open();
            dal.write("updateCourse",param);
        }
    }
}
