using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ALzero.BL
{
    class LIBRARY
    {
        DAL.DAL dal = new DAL.DAL();

        public DataTable getSubj()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("select_subj", null);
            return dt;
        }

        public DataTable getCourses(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@subj_id", SqlDbType.Int);
            param[0].Value = id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("c_from_subj", param);

            return dt;
        }

        public DataTable getIDOfSubj(string subj_name)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@subj_name", SqlDbType.NVarChar,50);
            param[0].Value = subj_name;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("idOfSubj", param);

            return dt;
        }
        public DataTable getVed(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@c_id", SqlDbType.Int);
            param[0].Value = id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("ved_from_c", param);

            return dt;
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

        public DataTable getUser()
        {           
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("userLogin", null);

            return dt;
        }
        public DataTable getIdUser()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("idOfUser", null);

            return dt;
        }
        public void insertVedLater(int ved_id,int user_id)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ved_id", SqlDbType.Int);
            param[0].Value = ved_id;
            param[1] = new SqlParameter("@user_id", SqlDbType.Int);
            param[1].Value = user_id;

            dal.open();
            dal.write("insertVedLater", param);
        }

        public int countCourses()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("countOfC", null);

            int cc = dt.Rows.Count;
            return cc;
        }
        public int countVed()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("countOfVed", null);

            int cv = dt.Rows.Count;

            return cv;
        }
        public int countVedoflater()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("countOfVed_later", null);

            int cvl = dt.Rows.Count;
            return cvl;
        }
        public int countVedofrec()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("countOfRec", null);

            int cvr = dt.Rows.Count;
            return cvr;
        }

    }
}
