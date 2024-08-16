using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ALzero.BL
{
    class START
    {
        DAL.DAL dal = new DAL.DAL();
        public DataTable getIdUser()
        {
            DataTable dt = new DataTable();
            dal.open();
            dt = dal.read("idOfUser", null);

            return dt;
        }
    }
}
