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
    public partial class FRM_DETAILS : Form
    {
        BL.DETAILS details = new BL.DETAILS();
        int user_id;
        public static int ved_id = 0;
        public static int c_id =0;
        string vedio_name;
        public FRM_DETAILS()
        {
            InitializeComponent();
            user_id = details.getIdUser();
            this.set_COB_course();
            this.set_CMB_subj();
        }

        void set_COB_course()
        {
            DataTable dt = new DataTable();
            dt = details.getCourses();
            this.COB_course.DataSource = dt;
            this.COB_course.DisplayMember = "c_name";
            this.COB_course.ValueMember = "c_id";
        }
        void set_CMB_subj()
        {
            DataTable dt = new DataTable();
            dt = details.getSubject();
            this.CMB_subj.DataSource = dt;
            this.CMB_subj.DisplayMember = "subj_name";
            this.CMB_subj.ValueMember = "subj_id";
        }
        public void durationAndSize(string path)
        {
            WindowsMediaPlayer wsmp = new WindowsMediaPlayerClass();
            IWMPMedia mediaInfo = wsmp.newMedia(path);
            this.txtBox_ved_durtion.Text = String.Format("{0:0.00}", (mediaInfo.duration / 60)) + " دقيقة ";
            FileInfo file = new FileInfo(path);
            this.txtBox_ved_size.Text = String.Format("{0:0.00}", (file.Length / 10485760.0)) + " ميجا ";
        }

        void checkWathed(int ved_id)
        {
            DataTable dt = new DataTable();
            dt = details.checkWatched(ved_id, user_id);
            if (dt.Rows.Count > 0)
            {
                bool watched = (bool)dt.Rows[0]["watched"];
                string watchedTime =  dt.Rows[0]["time_watched"].ToString();
                if (watched)
                {
                    this.checkBox1.Checked = true;
                    this.txtBox_ved_record.Text = watchedTime;
                }
            }
            else
            {
                //MessageBox.Show("هناك خطا");
            }
        }
        void getVedio(int ved_id)
        {
            DataTable dt = new DataTable();
            dt = details.getVedio(ved_id);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    this.txtBox_ved_id.Text = dt.Rows[0]["ved_id"].ToString();
                    this.txtBox_ved_name.Text = dt.Rows[0]["ved_name"].ToString();
                    this.txtBox_ved_path.Text = dt.Rows[0]["ved_path"].ToString();
                    vedio_name = dt.Rows[0]["ved_path"].ToString() + dt.Rows[0]["ved_name"].ToString();
                    string path = dt.Rows[0]["ved_path"].ToString() + dt.Rows[0]["ved_name"].ToString();
                    durationAndSize(path);
                    this.txtBox_ved_accuracy.Text = dt.Rows[0]["ved_accuracy"].ToString();
                    this.COB_course.SelectedValue = dt.Rows[0]["cors_id"];
                    checkWathed((int)dt.Rows[0]["ved_id"]);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("لا يتوفر بيانات");
            }
        }

        void getDetailsCourse(int c_id)
        {
            DataTable dt = new DataTable();
            dt = details.getDetailsCourse(c_id);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    DataRow row = dt.Rows[0];
                    this.txtBox_c_id.Text = row["c_id"].ToString();
                    this.txtBox_c_name.Text = row["c_name"].ToString();
                    this.txtBox_teacher.Text = row["teacher"].ToString();
                    this.txtBox_c_folder.Text = row["folder"].ToString();
                    this.txtBox_v_avg.Text = row["v_avg"].ToString() + " دقيقة ";
                    this.CMB_subj.SelectedValue = row["subj_id"];
                    this.DTP_c_date_create.Value = Convert.ToDateTime(row["date_of_create"].ToString());
                    this.txtBox_num_ved.Text = details.numVedOfCourse((int)row["c_id"]).ToString() + " فيديو ";
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("لا يتوفر بيانات");
            }
        }
        public static void datailsVedio(int id)
        {
            ved_id = id;
            FRM_DETAILS fRM_DETAILS = new FRM_DETAILS();
            fRM_DETAILS.lb_title.Text = "واجهة التفاصيل";
            fRM_DETAILS.LB_typeDetails.Text = "خصائص الفيديو";
            fRM_DETAILS.P_setting.Visible = false;
            fRM_DETAILS.P_details_course.Visible = false;
            fRM_DETAILS.P_details_ved.Visible = true;
            fRM_DETAILS.getVedio(id);
            fRM_DETAILS.Show();
        }
        public static void datailsCourse(int id)
        {
            c_id = id;
            FRM_DETAILS fRM_DETAILS = new FRM_DETAILS();
            fRM_DETAILS.lb_title.Text = "واجهة التفاصيل";
            fRM_DETAILS.LB_typeDetails.Text = "خصائص الكورس";
            fRM_DETAILS.P_setting.Visible = false;
            fRM_DETAILS.P_details_ved.Visible = false;
            fRM_DETAILS.P_details_course.Visible = true;
            fRM_DETAILS.getDetailsCourse(id);
            fRM_DETAILS.Show();
        }

        public static void settingVed(int id)
        {
            ved_id = id;
            FRM_DETAILS fRM_DETAILS = new FRM_DETAILS();
            fRM_DETAILS.lb_title.Text = "واجهة الاعدادات";
            fRM_DETAILS.LB_typeDetails.Text = "تعديل فيديو";
            fRM_DETAILS.P_setting.Visible = true;
            fRM_DETAILS.P_details_ved.Visible = true;
            fRM_DETAILS.P_details_course.Visible = false;
            fRM_DETAILS.txtBox_ved_name.Enabled = true;
            fRM_DETAILS.txtBox_ved_accuracy.Enabled = true;
            fRM_DETAILS.COB_course.Enabled = true;
            fRM_DETAILS.BUT_delete.Enabled = true;
            fRM_DETAILS.getVedio(id);
            fRM_DETAILS.Show();
        }

        public static void settingCourse(int id)
        {
            c_id = id;
            FRM_DETAILS fRM_DETAILS = new FRM_DETAILS();
            fRM_DETAILS.lb_title.Text = "واجهة الاعدادات";
            fRM_DETAILS.LB_typeDetails.Text = "تعديل كورس";
            fRM_DETAILS.P_setting.Visible = true;
            fRM_DETAILS.P_details_ved.Visible = false;
            fRM_DETAILS.P_details_course.Visible = true;
            fRM_DETAILS.txtBox_c_name.Enabled = true;
            fRM_DETAILS.txtBox_teacher.Enabled = true;
            fRM_DETAILS.txtBox_v_avg.Enabled = true;
            fRM_DETAILS.CMB_subj.Enabled = true;
            fRM_DETAILS.DTP_c_date_create.Enabled = true;
            fRM_DETAILS.getDetailsCourse(id);
            fRM_DETAILS.Show();
        }


        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            c_id = 0;
            ved_id = 0;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRM_DETAILS_Load(object sender, EventArgs e)
        {
            //set_COB_course();
        }

        private void BUT_rename_Click(object sender, EventArgs e)
        {
            if(c_id > 0)
            {
                details.rename_Course(c_id, this.txtBox_c_name.Text.Trim());
            }
            else if (ved_id > 0)
            {
                try
                {
                    string newVed_name =txtBox_ved_name.Text.Trim();
                    System.IO.File.Move(vedio_name, txtBox_ved_path.Text + newVed_name);
                    details.rename_ved(ved_id, newVed_name);
                    FRM_MESSAGE.ShowMsg("تم تغيير الاسم بنجاح");

                } catch
                {
                    MessageBox.Show("الاسم موجود مسبقا ", "انتبه ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        
                }
            }
            else
            {
                MessageBox.Show("هناك خطا");
            }
        }

        private void BUT_cancel_Click(object sender, EventArgs e)
        {
            if (c_id > 0)
            {
                getDetailsCourse(c_id);
            }
            else if (ved_id > 0)
            {
                getVedio(ved_id);
            }
            else
            {
                MessageBox.Show("هناك خطا");
            }
        }

        private void BUT_delete_Click(object sender, EventArgs e)
        {
            PL.FRM_MESSAGE.MessgeDelete(ved_id);
            this.Close();
        }

        private void BUT_setting_Click(object sender, EventArgs e)
        {
            if (c_id > 0)
            {
                float v_avg = Convert.ToSingle(txtBox_v_avg.Text);
                int subj_id = Convert.ToInt32(CMB_subj.SelectedValue);
                details.updateCourse(c_id, txtBox_c_name.Text.Trim(), txtBox_teacher.Text.Trim(), DTP_c_date_create.Value, v_avg, subj_id);
                PL.FRM_MESSAGE.MessgeUpdate();
                getDetailsCourse(c_id);
            }
            else if (ved_id > 0)
            {
                int c_id = Convert.ToInt32(COB_course.SelectedValue);
                try
                {
                    details.updateVed(ved_id, txtBox_ved_name.Text.Trim(), txtBox_ved_accuracy.Text.Trim(),c_id);
                    string newVed_name =txtBox_ved_path.Text+ txtBox_ved_name.Text.Trim();
                    System.IO.File.Move(vedio_name, newVed_name);
                    PL.FRM_MESSAGE.MessgeUpdate();
                    getVedio(ved_id);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("هناك خطا");
            }
        }
    }
}
