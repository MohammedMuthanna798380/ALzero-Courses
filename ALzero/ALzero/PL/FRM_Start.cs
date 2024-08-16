using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALzero.PL
{
    public partial class FRM_Start : Form
    {
        int id = 0;
        public FRM_Start()
        {
            InitializeComponent();
        }

        int startPoint = 0;
        BL.START start = new BL.START();

        void checkUser()
        {
            DataTable dt = new DataTable();
            dt = start.getIdUser();
            if (dt.Rows.Count > 0)
            {
                id = (int)dt.Rows[0]["user_id"];
                this.checkBox1.Checked = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 5;
            MyProgress.Value = startPoint;
            checkUser();
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                timer1.Stop();
                if(id != 0)
                {
                    FRM_MAIN frmain = new FRM_MAIN(id);
                    frmain.Show();
                    this.Hide();
                }
                else
                {
                    FRM_LOGIN frmLogin = new FRM_LOGIN();
                    frmLogin.Show();
                    this.Hide();
                }
            }
        }

        private void FRM_Start_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
