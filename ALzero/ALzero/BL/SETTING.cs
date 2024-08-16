using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ALzero.BL
{
    class SETTING
    {
        DAL.DAL dal = new DAL.DAL();
        public DataTable getAllUsers()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("getAllUsers", null);

            return dt;
        }
        public DataTable getAllSubj()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("getAllSubj", null);

            return dt;
        }
        public DataTable getAllCourses()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("getAllCourses", null);

            return dt;
        }
        public DataTable getAllVedios()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("getAllVedios", null);

            return dt;
        }
        public DataTable searchVedio(string ved_name)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ved_name", SqlDbType.NVarChar, 1000);
            param[0].Value = ved_name;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("searchVedio", param);

            return dt;
        }
        public DataTable getIdUser()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("idOfUser", null);

            return dt;
        }
    }
}
