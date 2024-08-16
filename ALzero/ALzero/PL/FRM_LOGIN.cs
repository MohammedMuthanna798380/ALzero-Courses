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
    public partial class FRM_LOGIN : Form
    {
        BL.LOGIN Log = new BL.LOGIN();
        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        void log_data()
        {
            this.errorProvider1.Clear();
            if (this.txtBox_name.Text.Trim() !="" && this.txtBox_pass.Text.Trim() != "")
            {
                DataTable dt = new DataTable();
                dt = Log.log_in(txtBox_name.Text.Trim(), txtBox_pass.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    int user_id = (int)dt.Rows[0]["user_id"];
                    Log.set_log(user_id);
                    FRM_MAIN frmain = new FRM_MAIN(user_id);
                    frmain.Show();
                    this.Hide();
                }
                else
                {
                    FRM_MESSAGE.ShowMsg("اسم المستخدم او كلمة المرور غير صحيحة!!");
                }
            }
            else
            {
                if (this.txtBox_name.Text.Trim() == "")
                {
                    errorProvider1.SetError(txtBox_name, "الرجاء إدخال اسم المستخدم");
                }
                if (this.txtBox_pass.Text.Trim() == "")
                {
                    errorProvider1.SetError(txtBox_pass, "الرجاء إدخال كلمة المرور ");
                }
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            log_data();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void LLB_clear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.txtBox_name.Text = "";
            this.txtBox_pass.Text = "";
        }

        private void txtBox_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
                this.txtBox_pass.Focus();
            if (e.KeyData == Keys.Enter)
                log_data();
        }

        private void txtBox_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
                this.txtBox_name.Focus();
            if (e.KeyData == Keys.Enter)
                log_data();
        }

        private void LLB_create_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PL.FRM_Users.CreateUser(false);
        }
    }
}
