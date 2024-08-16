using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ALzero.DAL
{
    class DAL
    {
        SqlConnection con;

        public DAL()
        {
            //string ServerName = "DESKTOP-8N1HTEA,1433";
            //string DB_Name = "Corsa";
            //string Authentiction_mode = "auth";

            string UserName = "sa";
            string Password = "md";

            string ServerName = "DESKTOP-8N1HTEA";
            string DB_Name = "MyCourses";
            string Authentiction_mode = "win";

            if (Authentiction_mode == "win")
                con = new SqlConnection(@"server = " + ServerName + "; DataBase = " + DB_Name +
                    "; integrated security = True");
            else
                con = new SqlConnection(@"server = " + ServerName + "; DataBase = " + DB_Name +
                    "; integrated security =false; User Id = " + UserName + "; Password = " + Password);
        }
        public void open()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
        }
        public void close()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public DataTable read(string sp, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;

            if (param != null)
                cmd.Parameters.AddRange(param);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public void write(string sp, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;

            if (param != null)
                cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }
    }
}
