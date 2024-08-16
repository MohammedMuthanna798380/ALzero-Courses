using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace ALzero.PL
{   
    public partial class FRM_COURSES : Form
    {
        static FRM_COURSES frm_course;
        BL.COURSES corsa = new BL.COURSES();
        BL.LOGOUT logout = new BL.LOGOUT();

        int idOfSelectCourse = 0;
        string name_course = "";
        string ved_selcted = "";
        int user_id = 0;
        int ved_id;

        public FRM_COURSES()
        {
            InitializeComponent();
            if (frm_course == null)
                frm_course = this;
        }

        public static FRM_COURSES FRM_COURSES_gettr
        {
            get
            {
                if (frm_course == null)
                    frm_course = new FRM_COURSES();
                return frm_course;
            }
        }

        void set_user_id()
        {
            DataTable dt = new DataTable();
            dt = corsa.getIdUser();
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void min_MBar()
        {
            P_MB.Width = 47;
            P_MB.BackColor = Color.White;
            P_MB.Location = new Point(P_MB.Location.X + 120, P_MB.Location.Y);
            P_Container.Width = P_Container.Width + 100;
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
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (P_MB.Width == 180)
            {
                min_MBar();
            }
            else
            {
                P_MB.Width = 180;
                P_MB.BackColor = System.Drawing.Color.FromArgb(((int)((byte)(77))), ((int)((byte)(88))), ((int)((byte)(160))));
                P_MB.Location = new Point(P_MB.Location.X - 120, P_MB.Location.Y);
                P_Container.Width = P_Container.Width - 100;
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
        void getCourses()
        {
            DataTable dt = new DataTable();
            dt = corsa.getNamesOfCourses();
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    this.LV_C.Items.Add(row["c_name"].ToString(),0);
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("..... للاسف لم يتم العثور على اي كورس .....");
            }
        }
        public Double duration(string file)
        {
            WindowsMediaPlayer wsmp = new WindowsMediaPlayerClass();
            IWMPMedia mediaInfo = wsmp.newMedia(file);
            return mediaInfo.duration;
        }
        void getVedio(string setPath)
        {
            DataTable dt = new DataTable();
            dt = corsa.getIDOfCourse(setPath);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    int c_id = (int)dt.Rows[0]["c_id"];
                    idOfSelectCourse = (int)dt.Rows[0]["c_id"];
                    DataTable dt2 = new DataTable();
                    dt2 = corsa.getVed(c_id);
                    if (dt2.Rows.Count > 0)
                    {
                        ListViewItem lvi;
                        foreach (DataRow row in dt2.Rows)
                        {
                            lvi=this.LV_V.Items.Add(row["ved_name"].ToString(), 0);
                            lvi.SubItems.Add(row["ved_accuracy"].ToString());
                            string path = row["ved_path"].ToString() + row["ved_name"].ToString();
                            lvi.SubItems.Add(String.Format("{0:0.00}", (duration(path) / 60)));
                            FileInfo file = new FileInfo(path);
                            lvi.SubItems.Add(String.Format("{0:0.00}", (file.Length / 10485760.0)));
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

        public void CheckAdmin()
        {
            if (BL.ISADMIN.getAdminStatus(user_id) > 0)
            {
                this.button5.Enabled = true;
                this.button8.Enabled = true;
                this.button9.Enabled = true;
                this.BUT_delete.Enabled = true;
            }
        }

        private void FRM_COURSES_Load(object sender, EventArgs e)
        {
            min_MBar();
            getCourses();
            set_user_id();
            if ((Application.OpenForms[1].WindowState == FormWindowState.Maximized) || (Application.OpenForms[2].WindowState == FormWindowState.Maximized))
                this.WindowState = FormWindowState.Maximized;
            CheckAdmin();
        }

        private void BUT_goback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void goback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LV_C_DoubleClick(object sender, EventArgs e)
        {
            name_course = LV_C.FocusedItem.Text;
            ved_selcted = "";
            LV_V.Items.Clear();
            getVedio(name_course);
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            logout.logout();
            FRM_LOGIN log = new FRM_LOGIN();
            this.Close();
            log.Show();
        }

        private void BUT_openFile_Click(object sender, EventArgs e)
        {
            try
            {
                name_course = LV_C.FocusedItem.Text;
                ved_selcted = "";
                LV_V.Items.Clear();
                getVedio(name_course);
            }
            catch
            {
                FRM_MESSAGE.ShowMsg("حدد مجلد...");
            }
        }

        void insertIntoVedLater(string name)
        {
            if (user_id != 0)
            {
                try
                {
                    DataTable dt2 = new DataTable();
                    dt2 = corsa.getIdOfVed(name);
                    if (dt2.Rows.Count > 0)
                    {
                        ved_id = (int)dt2.Rows[0]["ved_id"];
                        corsa.insertVedLater(ved_id, user_id);
                        FRM_MESSAGE.ShowMsg("تم إضافة الفيديو الى قائمة المشاهده لاحقا .....");
                    }
                }
                catch (Exception ex)
                {
                    FRM_MESSAGE.ShowMsg(ex.Message);
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("هناك خطا في المستخدم...!!");
            }
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
                    FRM_DISPLAY FD = new FRM_DISPLAY(idOfSelectCourse, ved_selcted);
                    FD.ShowDialog();
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("قم بتحديد الكورس اولا...");
            }
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

        private void LV_V_SelectedIndexChanged(object sender, EventArgs e)
        {
            ved_selcted = this.LV_V.FocusedItem.Text;
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

        private void BUT_detalies_Click(object sender, EventArgs e)
        {
            if (idOfSelectCourse > 0)
            {
                if (ved_selcted != "")
                {
                    DataTable dt = new DataTable();
                    dt = corsa.getIdOfVed(ved_selcted);
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
                FRM_MESSAGE.ShowMsg("قم بتحديد الكورس اولا ثم حدد الفيديو...");
            }
        }

        private void BUT_delete_Click(object sender, EventArgs e)
        {
            if (idOfSelectCourse > 0)
            {
                if (ved_selcted != "")
                {
                    DataTable dt = new DataTable();
                    dt = corsa.getIdOfVed(ved_selcted);
                    if (dt.Rows.Count > 0)
                    {
                        PL.FRM_DETAILS.settingVed((int)dt.Rows[0]["ved_id"]);
                        this.LV_V.Items.Clear();
                        getVedio(name_course);
                    }
                    else
                    {
                        FRM_MESSAGE.ShowMsg("الفيديو غير متوفر");
                    }
                }
                else
                {
                    PL.FRM_DETAILS.settingCourse(idOfSelectCourse);
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
            fRM_Add.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FRM_SETTING fRM_SETTING = new FRM_SETTING();
            fRM_SETTING.ShowDialog();
            //this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FRM_Users.UserInfo();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FRM_REPORT rep = new FRM_REPORT();
            rep.ShowDialog();
        }
    }
}
