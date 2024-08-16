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

namespace ALzero.PL
{
    public partial class FRM_DISPLAY : Form
    {
        BL.DISPLAY dis = new BL.DISPLAY();
        BL.LOGOUT logout = new BL.LOGOUT();
        int user_id = 0;
        string ved_name = "";
        string[] paths, files;
        bool checkOpen = true;

        public FRM_DISPLAY()
        {
            InitializeComponent();
        }
        public FRM_DISPLAY(int idOfCourse)
        {
            InitializeComponent();
            set_user_id();
            getVedios(idOfCourse);
        }
        public FRM_DISPLAY(int idOfCourse, string nameOfVedio)
        {
            InitializeComponent();
            set_user_id();
            getVedios(idOfCourse);
            getVed(nameOfVedio);
        }
        public static void display(string ved_name)
        {
            FRM_DISPLAY dis = new FRM_DISPLAY();
            dis.Show();
            dis.set_user_id();
            dis.getVed(ved_name);
        }
        public FRM_DISPLAY(string record)
        {
            InitializeComponent();
            set_user_id();

            if (record == "record")
            {
                getViewVedRecord();
            }
            else
            {
                getViewVedLater();
            }
        }
        void set_user_id()
        {
            DataTable dt = new DataTable();
            dt = dis.getIdUser();
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
        void getVedios(int idOfCourse)
        {
            DataTable dt = new DataTable();
            dt = dis.getVed(idOfCourse);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    int i = 0;
                    paths = new string[dt.Rows.Count];
                    files = new string[dt.Rows.Count];
                    foreach (DataRow row in dt.Rows)
                    {
                        this.LB_vedio.Items.Add(row["ved_name"].ToString());
                        paths[i] = row["ved_path"].ToString() + row["ved_name"].ToString();
                        files[i] = row["ved_name"].ToString();
                        i++;
                    }
                }
                catch(Exception ex)
                {
                    FRM_MESSAGE.ShowMsg(ex.Message);
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("لا يتوفر بيانات!!!");
            }
        }

        void getViewVedLater()
        {
            if(user_id != 0)
            {
                DataTable dt = new DataTable();
                dt = dis.ved_id_from_later(user_id);
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        int i = 0;
                        paths = new string[dt.Rows.Count];
                        files = new string[dt.Rows.Count];
                        DataRow row;
                        for (int x = dt.Rows.Count-1; x >= 0; x--)
                        {
                            row = dt.Rows[x];
                            int ved_id = (int)row["ved_id"];
                            DataTable dt2 = new DataTable();
                            dt2 = dis.vedOfViewLater(ved_id);
                            if (dt2.Rows.Count > 0)
                            {
                                foreach (DataRow row2 in dt2.Rows)
                                {
                                    this.LB_vedio.Items.Add(row2["ved_name"].ToString());
                                    paths[i] = row2["ved_path"].ToString() + row2["ved_name"].ToString();
                                    files[i] = row2["ved_name"].ToString();
                                    i++;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        FRM_MESSAGE.ShowMsg(ex.Message);
                    }
                }
                else
                {
                    FRM_MESSAGE.ShowMsg("لا يتوفر بيانات!!!");
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("هناك خطا في المستخدم...!!");
            }
        }
        void getViewVedRecord()
        {
            if (user_id != 0)
            {
                DataTable dt = new DataTable();
                dt = dis.ved_id_from_record(user_id);
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        int i = 0;
                        paths = new string[dt.Rows.Count];
                        files = new string[dt.Rows.Count];
                        DataRow row;
                        for (int x = dt.Rows.Count - 1; x >= 0; x--)
                        {
                            row = dt.Rows[x];
                            int ved_id = (int)row["ved_id"];
                            DataTable dt2 = new DataTable();
                            dt2 = dis.vedOfViewLater(ved_id);
                            if (dt2.Rows.Count > 0)
                            {
                                foreach (DataRow row2 in dt2.Rows)
                                {
                                    this.LB_vedio.Items.Add(row2["ved_name"].ToString());
                                    paths[i] = row2["ved_path"].ToString() + row2["ved_name"].ToString();
                                    files[i] = row2["ved_name"].ToString();
                                    i++;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        FRM_MESSAGE.ShowMsg(ex.Message);
                    }
                }
                else
                {
                    FRM_MESSAGE.ShowMsg("لا يتوفر بيانات!!!");
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("هناك خطا في المستخدم...!!");
            }
        }
        void getVed(string nameOfVedio)
        {
            DataTable dt = new DataTable();
            dt = dis.getPathOfVed(nameOfVedio);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    string pathOfVed = dt.Rows[0]["ved_path"].ToString();
                    if (File.Exists(pathOfVed + nameOfVedio))
                    {
                        this.wmp.URL = pathOfVed + nameOfVedio;
                        this.wmp.Ctlcontrols.play();
                        this.ved_name = nameOfVedio;
                        insertIntoRecord();
                        this.LB_vedio_state.Text = "الفيديو قيد التشغيل....";
                        this.timer1.Start();
                        this.TB_sound.Value = wmp.settings.volume;
                        LB_sound.Text = TB_sound.Value.ToString() + " %";
                    }
                    else
                    {
                        FRM_MESSAGE.ShowMsg("الفيديو غير متوفر!!!");
                    }
                }
                catch(Exception ex)
                {
                    FRM_MESSAGE.ShowMsg(ex.Message);
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("حدث خطا غير متوقع!!!");
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
        void insertIntoRecord()
        {
            if(ved_name != "" && user_id != 0 && checkOpen)
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = dis.getIdOfVed(ved_name);
                    if (dt.Rows.Count > 0)
                    {
                        int ved_id = (int)dt.Rows[0]["ved_id"];
                        dis.check_delete_record(ved_id, user_id);
                        dis.insert_ved_record(ved_id, user_id);
                    }
                    else
                    {
                        FRM_MESSAGE.ShowMsg("الفيديو غير موجود");
                    }
                }
                catch(Exception ex)
                {
                    FRM_MESSAGE.ShowMsg(ex.Message);
                }
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
                P_MB.BackColor = System.Drawing.Color.FromArgb(((int)((byte)(77))), ((int)((byte)(88))), ((int)((byte)(160))));
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

        public void CheckAdmin()
        {
            if (BL.ISADMIN.getAdminStatus(user_id) > 0)
            {
                this.button5.Enabled = true;
                this.button8.Enabled = true;
                this.button9.Enabled = true;
            }
        }

        private void FRM_DISPLAY_Load(object sender, EventArgs e)
        {
            min_MBar();
            set_user_id();
            if ((Application.OpenForms[1].WindowState == FormWindowState.Maximized) || (Application.OpenForms[2].WindowState == FormWindowState.Maximized))
                this.WindowState = FormWindowState.Maximized;
            CheckAdmin();
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
        private void BUT_open_Click(object sender, EventArgs e)
        {
            checkOpen = false;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "All Files|*.mp4;*.wmv;*.avi;*.mov;*.flv;*.3gp;*.vop;*.mkv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.LB_vedio.Items.Clear();
                files = ofd.SafeFileNames;
                paths = ofd.FileNames;
                for(int x = 0; x < files.Length; x++)
                {
                    this.LB_vedio.Items.Add(files[x]);
                }
            }
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            if (this.wmp.currentMedia != null)
            {
                this.wmp.Ctlcontrols.play();
                this.LB_vedio_state.Text = "الفيديو قيد التشغيل....";
                insertIntoRecord();
            }
            else
            {
                FRM_MESSAGE.ShowMsg("قم بتحديد فيديو");
            }
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            this.wmp.Ctlcontrols.pause();
            this.LB_vedio_state.Text = "تم إيقاف الفيديو مؤقتا....";
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            this.wmp.Ctlcontrols.stop();
            this.LB_vedio_state.Text = "تم إيقاف الفيديو ....";
            this.PB_vedio.Value = 0;
        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            this.wmp.Ctlcontrols.stop();
            this.wmp.Ctlcontrols.play();
            this.LB_vedio_state.Text = "الفيديو قيد التشغيل....";
        }
        private void LB_vedio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.wmp.URL = paths[this.LB_vedio.SelectedIndex];
            this.wmp.Ctlcontrols.play();
            ved_name = files[this.LB_vedio.SelectedIndex];
            insertIntoRecord();
            this.LB_vedio_state.Text = "الفيديو قيد التشغيل....";
            this.timer1.Start();
            this.TB_sound.Value = wmp.settings.volume;
            LB_sound.Text = TB_sound.Value.ToString() + " %";
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            if (LB_vedio.SelectedIndex < LB_vedio.Items.Count - 1)
            {
                LB_vedio.SelectedIndex = LB_vedio.SelectedIndex + 1;
                this.LB_vedio_state.Text = "الفيديو قيد التشغيل....";
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            if (LB_vedio.SelectedIndex > 0)
            {
                LB_vedio.SelectedIndex = LB_vedio.SelectedIndex - 1;
                this.LB_vedio_state.Text = "الفيديو قيد التشغيل....";
            }
        }

        private void TB_sound_Scroll(object sender, EventArgs e)
        {
            wmp.settings.volume = TB_sound.Value;
            LB_sound.Text = TB_sound.Value.ToString()+" %";
        }

        private void BUT_goback_Click(object sender, EventArgs e)
        {
            this.wmp.Ctlcontrols.stop();
            this.Close();
        }

        private void goback_Click(object sender, EventArgs e)
        {
            this.wmp.Ctlcontrols.stop();
            this.Close();
        }

        private void wmp_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            logout.logout();
            FRM_LOGIN log = new FRM_LOGIN();
            this.Close();
            log.Show();
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FRM_COURSES frmCourses = new FRM_COURSES();
            frmCourses.ShowDialog();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_DISPLAY frm = new FRM_DISPLAY("record");
            frm.ShowDialog();
        }

        private void bunifuImageButton12_Click(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (wmp.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
            this.PB_vedio.Maximum = (int)wmp.Ctlcontrols.currentItem.duration;
            this.PB_vedio.Value = (int)wmp.Ctlcontrols.currentPosition;
            }
            this.LB_start_ved.Text = wmp.Ctlcontrols.currentPositionString;
            this.LB_end_veb.Text = wmp.Ctlcontrols.currentItem.durationString.ToString();
        }

    }
}
