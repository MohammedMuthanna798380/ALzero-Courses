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
    public partial class FRM_MAIN : Form
    {

        BL.LIBRARY lib = new BL.LIBRARY();
        BL.LOGOUT logout = new BL.LOGOUT();

        int count_subj;
        string ved_selcted = "";
        int idOfSelectCourse = 0;
        int user_id = 0;
        int ved_id;
        string strPath = "";

        public FRM_MAIN()
        {
            InitializeComponent();
            getP_HOME();
        }
        public FRM_MAIN(int user_id)
        {
            InitializeComponent();
            getP_MAIN();
        }
        void getP_MAIN()
        {
            this.P_HOME.Visible = false;
            this.P_MAIN.Visible = true;
            this.lb_title.Text = "الرئيسية";
        }
        void getP_HOME()
        {
            this.P_MAIN.Visible = false;
            this.P_HOME.Visible = true;
            this.lb_title.Text = "المكتبة";
        }
        void set_user_id()
        {
            DataTable dt = new DataTable();
            dt = lib.getIdUser();
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
            P_MB.Location = new Point(P_MB.Location.X + 120, P_MB.Location.Y);
            P_Continare.Width = P_Continare.Width + 100;
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
        void getUser()
        {
            DataTable dt = new DataTable();
            dt = lib.getUser();
            if (dt.Rows.Count > 0)
            {
                try
                {
                    this.lb_user.Text = dt.Rows[0]["full_name"].ToString();
                }
                catch (Exception ex)
                {
                    FRM_MESSAGE.ShowMsg(ex.Message);
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("ليس هناك مستخدم حاليا");
            }
        }
        void subjects()
        {
            DataTable dt = new DataTable();
            dt = lib.getSubj();
            count_subj = dt.Rows.Count;  /*نخزن عدد المواد ليتم عرض العدد في الواجهه الرئيسي*/
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    string subj = row["subj_name"].ToString();
                    this.LV_subj.Items.Add(subj,0);
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("لا يوجد بيانات!!");
            }
        }
        void getCourses(string setPath)
        {
            DataTable dt = new DataTable();
            dt = lib.getIDOfSubj(setPath);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    int subj_id = (int)dt.Rows[0]["subj_id"];
                    DataTable dt2 = new DataTable();
                    dt2 = lib.getCourses(subj_id);
                    if (dt2.Rows.Count > 0)
                    {
                        foreach(DataRow row in dt2.Rows)
                        {
                            this.TV_C.Nodes.Add("", row["c_name"].ToString(),0,0);
                        }
                    }
                    else
                    {
                        FRM_MESSAGE.ShowMsg("لا يوجد بيانات!!");
                    }
                }
                catch(Exception ex)
                {
                    FRM_MESSAGE.ShowMsg(ex.Message);
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("لا يوجد بيانات!!");
            }

        }
        void getVedio(string setPath)
        {
            DataTable dt = new DataTable();
            dt = lib.getIDOfCourse(setPath);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    int c_id = (int)dt.Rows[0]["c_id"];
                    idOfSelectCourse = (int)dt.Rows[0]["c_id"];
                    DataTable dt2 = new DataTable();
                    dt2 = lib.getVed(c_id);
                    if (dt2.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt2.Rows)
                        {
                            this.LV_V.Items.Add(row["ved_name"].ToString(), 0);
                        }
                    }
                    else
                    {
                        FRM_MESSAGE.ShowMsg("لا يوجد بيانات!!");
                    }
                }
                catch (Exception ex)
                {
                    FRM_MESSAGE.ShowMsg(ex.Message);
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("لا يوجد بيانات!!");
            }

        }        

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (P_MB.Width == 180)
            {
                min_MBar();
            }
            else
            {
                P_MB.Width = 180;
                P_MB.Location = new Point(P_MB.Location.X - 120, P_MB.Location.Y);
                P_Continare.Width = P_Continare.Width - 100;
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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

        public void CheckAdmin()
        {
            if (BL.ISADMIN.getAdminStatus(user_id) > 0)
            {
                this.button5.Enabled = true;
                this.button8.Enabled = true;
                this.button9.Enabled = true;
            }
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            subjects();
            if ((Application.OpenForms[1].WindowState == FormWindowState.Maximized))
                this.WindowState = FormWindowState.Maximized;
            this.lb_num_subj.Text = count_subj.ToString();
            this.lb_num_cors.Text = lib.countCourses().ToString();
            this.lb_num_vedio.Text = lib.countVed().ToString();
            this.lb_num_rec.Text = lib.countVedofrec().ToString();
            this.lb_num_vl.Text = lib.countVedoflater().ToString();
            getUser();
            set_user_id();
            min_MBar();
            CheckAdmin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getP_MAIN();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            getP_HOME();
        }

        void open_subj(string setPath)
        {
            this.TV_C.Nodes.Clear();
            this.LV_V.Items.Clear();
            ved_selcted = "";
            idOfSelectCourse = 0;
            getCourses(setPath);
        }
        private void LV_subj_DoubleClick(object sender, EventArgs e)
        {
            string setPath = this.LV_subj.FocusedItem.Text;
            open_subj(setPath);
        }

        private void TV_C_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strPath = e.Node.FullPath;
            ved_selcted = "";
            this.LV_V.Items.Clear();
            getVedio(strPath);

        }

        private void LV_V_SelectedIndexChanged(object sender, EventArgs e)
        {
            ved_selcted = LV_V.FocusedItem.Text;
        }

        private void BUT_display_Click(object sender, EventArgs e)
        {
            if (idOfSelectCourse > 0)
            {
                if (ved_selcted == "")
                {
                    FRM_DISPLAY FD = new FRM_DISPLAY(idOfSelectCourse);
                    FD.ShowDialog();
                }
                else
                {
                    FRM_DISPLAY FD = new FRM_DISPLAY(idOfSelectCourse,ved_selcted);
                    FD.ShowDialog();
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("قم بتحديد الكورس اولا...");
            }
        }

        private void BUT_openFile_Click(object sender, EventArgs e)
        {
            try
            {
                string setPath = this.LV_subj.FocusedItem.Text;
                open_subj(setPath);
            }
            catch
            {
                FRM_MESSAGE.ShowMsg("حدد مجلد...");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FRM_COURSES corsa = new FRM_COURSES();
            corsa.ShowDialog();
            //this.Hide();
            //FRM_COURSES corsa = FRM_COURSES.FRM_COURSES_gettr;
            //corsa.ShowDialog();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            logout.logout();
            FRM_LOGIN log = new FRM_LOGIN();
            this.Close();
            log.Show();
        }
        void insertIntoVedLater(string name)
        {
            if (user_id != 0)
            {
                try
                {
                    DataTable dt2 = new DataTable();
                    dt2 = lib.getIdOfVed(name);
                    if (dt2.Rows.Count > 0)
                    {
                        ved_id = (int)dt2.Rows[0]["ved_id"];
                        lib.insertVedLater(ved_id, user_id);
                        FRM_MESSAGE.ShowMsg("تم إضافة الفيديو الى قائمة المشاهده لاحقا .....");
                    }
                }
                catch(Exception ex)
                {
                    FRM_MESSAGE.ShowMsg(ex.Message);
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("هناك خطا في المستخدم...!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRM_DISPLAY frm_display = new FRM_DISPLAY("view");
            frm_display.ShowDialog();
        }

        private void BUT_view_Click(object sender, EventArgs e)
        {
            if (idOfSelectCourse > 0)
            {
                if (ved_selcted != "")
                {
                    insertIntoVedLater(ved_selcted);
                }
                else
                {
                    FRM_MESSAGE.ShowMsg("قم بتحديد الفيديو...");                   
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("قم بتحديد الكورس اولا ثم حدد الفيديو...");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_DISPLAY frm = new FRM_DISPLAY("record");
            frm.ShowDialog();
        }

        private void BUT_detalies_Click(object sender, EventArgs e)
        {

            if (idOfSelectCourse > 0)
            {
                if (ved_selcted != "")
                {
                    DataTable dt = new DataTable();
                    dt = lib.getIdOfVed(ved_selcted);
                    if (dt.Rows.Count > 0)
                    {
                        PL.FRM_DETAILS.datailsVedio((int)dt.Rows[0]["ved_id"]);
                    }
                    else
                    {
                        FRM_MESSAGE.ShowMsg("الفيديو غير متوفر");
                    }
                }
                else
                {
                    PL.FRM_DETAILS.datailsCourse(idOfSelectCourse);
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("قم بتحديد كورس أو فيديو...");
            }
        }

        private void BUT_delete_Click(object sender, EventArgs e)
        {
            if (idOfSelectCourse > 0)
            {
                if (ved_selcted != "")
                {
                    DataTable dt = new DataTable();
                    dt = lib.getIdOfVed(ved_selcted);
                    if (dt.Rows.Count > 0)
                    {
                        PL.FRM_DETAILS.settingVed((int)dt.Rows[0]["ved_id"]);
                        this.LV_V.Items.Clear();
                        getVedio(strPath);
                    }
                    else
                    {
                        FRM_MESSAGE.ShowMsg("الفيديو غير متوفر");
                    }
                }
                else
                {
                    FRM_DETAILS.settingCourse(idOfSelectCourse);
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("قم بتحديد كورس او فيديو...");
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            FRM_SEARCH frm_search = new FRM_SEARCH();
            frm_search.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FRM_Add fRM_Add = new FRM_Add();
            fRM_Add.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FRM_SETTING fRM_SETTING = new FRM_SETTING();
            fRM_SETTING.ShowDialog();
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
