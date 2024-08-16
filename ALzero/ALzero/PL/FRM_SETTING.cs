using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace ALzero.PL
{
    public partial class FRM_SETTING : Form
    {
        BL.SETTING setting = new BL.SETTING();
        BL.LOGOUT logout = new BL.LOGOUT();
        int user_id = 0;
        int uscv = 0;
        DataTable dt = new DataTable();
        public FRM_SETTING()
        {
            InitializeComponent();
        }

        void set_user_id()
        {
            DataTable dt = new DataTable();
            dt = setting.getIdUser();
            if (dt.Rows.Count > 0)
            {
                try
                {
                    user_id = (int)dt.Rows[0]["user_id"];
                }
                catch (Exception ex)
                {
                    FRM_MESSAGE.ShowMsg(ex.Message);
                }
            }
        }
        private void min_MBar()
        {
            P_MB.Width = 47;
            P_MB.BackColor = Color.White;
            P_MB.Location = new Point(P_MB.Location.X + 120, P_MB.Location.Y);
            P_display.Width = P_display.Width + 100;
            this.button1.RightToLeft = RightToLeft.Yes;
            this.button1.RightToLeft = RightToLeft.Yes;
            this.button2.RightToLeft = RightToLeft.Yes;
            this.button3.RightToLeft = RightToLeft.Yes;
            this.button4.RightToLeft = RightToLeft.Yes;
            this.button5.RightToLeft = RightToLeft.Yes;
            this.button6.RightToLeft = RightToLeft.Yes;
            this.button7.RightToLeft = RightToLeft.Yes;
            this.button8.RightToLeft = RightToLeft.Yes;
            this.button9.RightToLeft = RightToLeft.Yes;
            this.pictureBox1.Visible = false;
        }
        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            if (P_MB.Width == 180)
            {
                min_MBar();
            }
            else
            {
                P_MB.Width = 180;
                P_MB.BackColor = Color.Teal;
                P_MB.Location = new Point(P_MB.Location.X - 120, P_MB.Location.Y);
                P_display.Width = P_display.Width - 100;
                this.button1.RightToLeft = RightToLeft.No;
                this.button2.RightToLeft = RightToLeft.No;
                this.button3.RightToLeft = RightToLeft.No;
                this.button4.RightToLeft = RightToLeft.No;
                this.button5.RightToLeft = RightToLeft.No;
                this.button6.RightToLeft = RightToLeft.No;
                this.button7.RightToLeft = RightToLeft.No;
                this.button8.RightToLeft = RightToLeft.No;
                this.button9.RightToLeft = RightToLeft.No;
                this.pictureBox1.Visible = true;
            }
        }

        private void FRM_SETTING_Load(object sender, EventArgs e)
        {
            min_MBar();
            set_user_id();
            if ((Application.OpenForms[1].WindowState == FormWindowState.Maximized) || (Application.OpenForms[2].WindowState == FormWindowState.Maximized))
                this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void BTN_user_Click(object sender, EventArgs e)
        {
            uscv = 1;
            this.txtBox_search.Enabled = true;
            this.BUT_set.Enabled = false;
            this.BTN_add.Enabled = true;
            dt = setting.getAllUsers();
            this.DGV_search.DataSource = dt;
            this.DGV_search.Columns["user_id"].Visible = false;
        }

        private void BTN_subj_Click(object sender, EventArgs e)
        {
            uscv = 2;
            this.txtBox_search.Enabled = true;
            this.BUT_set.Enabled = false;
            this.BTN_add.Enabled = false;
            dt = setting.getAllSubj();
            this.DGV_search.DataSource = dt;
            this.DGV_search.Columns["subj_id"].Visible = false;
            this.DGV_search.RightToLeft = RightToLeft.Yes;
        }

        private void BTN_course_Click(object sender, EventArgs e)
        {
            uscv = 3;
            this.txtBox_search.Enabled = true;
            this.BUT_set.Enabled = false;
            this.BTN_add.Enabled = false;
            dt = setting.getAllCourses();
            this.DGV_search.DataSource = dt;
            this.DGV_search.Columns["c_id"].Visible = false;
        }

        private void BTN_vedio_Click(object sender, EventArgs e)
        {
            uscv = 4;
            this.txtBox_search.Enabled = true;
            this.BUT_set.Enabled = false;
            this.BTN_add.Enabled = true;
            dt = setting.getAllVedios();
            this.DGV_search.DataSource = dt;
            this.DGV_search.Columns["ved_id"].Visible = false;
            this.DGV_search.RightToLeft = RightToLeft.No;
        }

        private void txtBox_search_TextChanged(object sender, EventArgs e)
        {
            this.bB_clear.Enabled = true;
            this.bB_search.Enabled = true;
            this.BUT_set.Enabled = false;
        }

        private void BTN_add_Click(object sender, EventArgs e)
        {
            this.BUT_set.Enabled = false;
            switch (uscv)
            {
                case 1:
                    PL.FRM_Users.CreateUser(true);
                    break;
                case 4:
                    FRM_Add fRM_Add = new FRM_Add();
                    fRM_Add.BackColor = Color.Teal;
                    fRM_Add.ShowDialog();
                    break;
                default:
                    FRM_MESSAGE.ShowMsg("لا يتوفر حاليا");
                    break;

            }
        }
        void searching()
        {
            dt = setting.searchVedio(txtBox_search.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                this.DGV_search.DataSource = dt;
                DGV_search.Columns["ved_id"].Visible = false;
            }
            else
            {
                FRM_MESSAGE.ShowMsg("NotFound");
            }
        }
        private void bB_search_Click_1(object sender, EventArgs e)
        {
            searching();
            this.BUT_set.Enabled = false;
        }

        private void txtBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                searching();
        }

        private void DGV_search_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.BUT_set.Enabled = true;
        }

        private void BUT_set_Click(object sender, EventArgs e)
        {
            switch (uscv)
            {
                case 1:
                    FRM_Users.UserInfo();
                    break;
                case 3:
                    int c_id = Convert.ToInt32(this.DGV_search.SelectedRows[0].Cells[0].Value);
                    PL.FRM_DETAILS.settingCourse(c_id);
                    break;
                case 4:
                    int ved_id = Convert.ToInt32(this.DGV_search.SelectedRows[0].Cells[0].Value);
                    PL.FRM_DETAILS.settingVed(ved_id);
                    break;
                default:
                    FRM_MESSAGE.ShowMsg("نعتذر لا تتوفر هذه العملية حاليا..");
                    break;
            }
        }

        private void bB_clear_Click(object sender, EventArgs e)
        {
            this.txtBox_search.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_MAIN frmin = new FRM_MAIN(user_id);
            frmin.ShowDialog();
            //this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FRM_MAIN frmin = new FRM_MAIN();
            frmin.ShowDialog();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRM_DISPLAY frm_display = new FRM_DISPLAY("view");
            frm_display.ShowDialog();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_DISPLAY frm = new FRM_DISPLAY("record");
            frm.ShowDialog();
            //this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FRM_Add fRM_Add = new FRM_Add();
            fRM_Add.BackColor = Color.Teal;
            fRM_Add.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FRM_COURSES corsa = new FRM_COURSES();
            corsa.ShowDialog();
            //this.Hide();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            FRM_SEARCH frm_search = new FRM_SEARCH();
            frm_search.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            logout.logout();
            FRM_LOGIN log = new FRM_LOGIN();
            this.Close();
            log.Show();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void BUT_goback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void goback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FRM_REPORT rep = new FRM_REPORT();
            rep.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FRM_Users.UserInfo();
        }
    }
}
