using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ALzero.BL
{
    class DISPLAY
    {
        DAL.DAL dal = new DAL.DAL();
        public DataTable getVed(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@c_id", SqlDbType.Int);
            param[0].Value = id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("nameAndPathVed", param);

            return dt;
        }
        public DataTable getPathOfVed(string ved_name)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ved_name", SqlDbType.NVarChar, 1000);
            param[0].Value = ved_name;
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("pathOfVed", param);
            return dt;
        }
        public DataTable getIdUser()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("idOfUser", null);

            return dt;
        }

        //public DataTable selectVedLater(int user_id)
        //{
        //    SqlParameter[] param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@user_id", SqlDbType.Int);
        //    param[0].Value = user_id;

        //    DataTable dt = new DataTable();
        //    dal.open();
        //    dt = dal.read("select_ved_later", param);
        //    return dt;
        //}

        public DataTable ved_id_from_later(int user_id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = user_id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("ved_id_from_later", param);
            return dt;
        }

        public DataTable vedOfViewLater(int ved_id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ved_id", SqlDbType.Int);
            param[0].Value = ved_id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("vedOfViewLater", param);
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
        public void insert_ved_record(int ved_id, int user_id)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ved_id", SqlDbType.Int);
            param[0].Value = ved_id;
            param[1] = new SqlParameter("@user_id", SqlDbType.Int);
            param[1].Value = user_id;
            param[2] = new SqlParameter("@time_watched", SqlDbType.DateTime);
            param[2].Value = DateTime.Now;

            dal.open();
            dal.write("insert_ved_record", param);
        }
        public void check_delete_record(int ved_id, int user_id)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ved_id", SqlDbType.Int);
            param[0].Value = ved_id;
            param[1] = new SqlParameter("@user_id", SqlDbType.Int);
            param[1].Value = user_id;

            dal.open();
            dal.write("check_delete_record", param);
        }
        public DataTable ved_id_from_record(int user_id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = user_id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("ved_id_from_record", param);
            return dt;
        }
    }
}
