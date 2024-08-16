using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace ALzero.BL
{
    class USERS
    {
        DAL.DAL dal = new DAL.DAL();

        public void updateUser(int user_id,string user_name,string user_password,string fill_name )
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = user_id;
            param[1] = new SqlParameter("@user_name", SqlDbType.NVarChar, 150);
            param[1].Value = user_name;
            param[2] = new SqlParameter("@password", SqlDbType.NVarChar, 50);
            param[2].Value = user_password;
            param[3] = new SqlParameter("@full_name", SqlDbType.NVarChar, 150);
            param[3].Value = fill_name;

            dal.open();
            dal.write("updateUser", param);
        }
        public void updateUserNU(int user_id, string user_name, string fill_name)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = user_id;
            param[1] = new SqlParameter("@user_name", SqlDbType.NVarChar, 150);
            param[1].Value = user_name;
            param[2] = new SqlParameter("@full_name", SqlDbType.NVarChar, 150);
            param[2].Value = fill_name;

            dal.open();
            dal.write("updateUserNU", param);
        }

       // public DataTable createUser(String username, String pass, byte[] image,bool setadmin,String name)
       //{  String check;

        //    SqlParameter[] param = new SqlParameter[5];

        //param[0] = new SqlParameter("@username", SqlDbType.NVarChar, 150);
        //           param[0].Value = username;
        //         param[1] = new SqlParameter("@password", SqlDbType.NVarChar, 50);
        //       param[1].Value = pass;
        //     param[2] = new SqlParameter("@image", SqlDbType.Image);
        //   param[2].Value = image;
        // param[3] = new SqlParameter("@setadmin", SqlDbType.Bit);
        //  param[3].Value = setadmin;
        //  param[4] = new SqlParameter("@fullname", SqlDbType.NVarChar, 150);
        // param[4].Value = name;


        //DataTable dt = new DataTable();
        // dal.open();
        //dt = dal.read("login_sp", param);

        //return dt;
        // }

        public void insertUser(string user_name,string password,bool set_admin,string full_name)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar, 150);
            param[0].Value = user_name;
            param[1] = new SqlParameter("@password", SqlDbType.NVarChar,50);
            param[1].Value = password;
            param[2] = new SqlParameter("@set_admain", SqlDbType.Bit);
            param[2].Value = set_admin;
            param[3] = new SqlParameter("@full_name", SqlDbType.NVarChar, 150);
            param[3].Value = full_name;

            dal.open();
            dal.write("insertUser", param);
        }
        public DataTable getIdUser()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("idOfUser", null);

            return dt;
        }
        public DataTable displayUser(int user_id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = user_id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("displayUser", param);

            return dt;
        }
        public DataTable checkPassword(int user_id , string password)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = user_id;
            param[1] = new SqlParameter("@password", SqlDbType.NVarChar, 50);
            param[1].Value = password;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("checkPassword", param);

            return dt;

        }

        public DataTable secur(String pass)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@password", SqlDbType.NVarChar,50);
            param[0].Value = pass;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("secur", param);

            return dt;
        }
        public DataTable selectImageUser(int user_id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = user_id;

            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("selectImageUser", param);
            return dt;
        }
        public void updateImageUser(int user_id , Image image)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = user_id;
            param[1] = new SqlParameter("@image", SqlDbType.Image);
            param[1].Value = image;

            dal.open();
            dal.write("updateImageUser", param);
        }
    }
}
