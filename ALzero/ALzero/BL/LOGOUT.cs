using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ALzero.BL
{
    class LOGOUT
    {
        DAL.DAL dal = new DAL.DAL();
        public void logout()
        {
            dal.open();
            dal.write("logout", null);
        }
    }
}
