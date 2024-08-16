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
using WMPLib;

namespace ALzero.PL
{
    public partial class FRM_Add : Form
    {
        BL.ADD add = new BL.ADD();
        OpenFileDialog ofd;
        public FRM_Add()
        {
            InitializeComponent();
        }

        void set_COB_course()
        {
            DataTable dt = new DataTable();
            dt = add.getCourses();
            this.CMB_Coursrs.DataSource = dt;
            this.CMB_Coursrs.DisplayMember = "c_name";
            this.CMB_Coursrs.ValueMember = "c_id";
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BUT_add_MouseHover(object sender, EventArgs e)
        {
            this.BUT_add.ForeColor = Color.White;
        }

        private void BUT_add_MouseLeave(object sender, EventArgs e)
        {
            this.BUT_add.ForeColor = Color.Black;
        }

        private void BUT_add_MouseDown(object sender, MouseEventArgs e)
        {
            this.BUT_add.ForeColor = Color.White;
        }

        private void BUT_save_MouseHover(object sender, EventArgs e)
        {
            this.BUT_save.ForeColor = Color.White;
        }

        private void BUT_save_MouseLeave(object sender, EventArgs e)
        {
            this.BUT_save.ForeColor = Color.Black;
        }

        private void FRM_Add_Load(object sender, EventArgs e)
        {
            string[] accuracy = { "144p", "240p", "360p", "480p", "720p", "1080p" };
            this.CMB_ved_accuracy.Items.AddRange(accuracy);
            set_COB_course();
        }

        private void BUT_add_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "All Files|*.mp4;*.wmv;*.avi;*.mov;*.flv;*.3gp;*.vop;*.mkv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(ofd.FileName);
                this.txtBox_ved_name.Text = file.Name;
                this.txtBox_ved_size.Text = String.Format("{0:0.00}", (file.Length / 10485760.0)) + " ميجا ";
                WindowsMediaPlayer wsmp = new WindowsMediaPlayerClass();
                IWMPMedia mediaInfo = wsmp.newMedia(ofd.FileName);
                this.txtBox_ved_durtion.Text = String.Format("{0:0.00}", (mediaInfo.duration / 60)) + " دقيقة ";
                this.CMB_ved_accuracy.SelectedIndex = 1;
            }
        }

        private void txtBox_ved_name_TextChanged(object sender, EventArgs e)
        {
            if (txtBox_ved_name.Text.Trim() != "" && txtBox_ved_path.Text.Trim() != "")
                this.BUT_save.Enabled = true;
        }

        private void txtBox_ved_path_TextChanged(object sender, EventArgs e)
        {
            if (txtBox_ved_name.Text.Trim() != "" && txtBox_ved_path.Text.Trim() != "")
                this.BUT_save.Enabled = true;
        }
        void getFolderOfCourse(int c_id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = add.getFolderOfCourse(c_id);
                if (dt.Rows.Count > 0)
                    this.txtBox_ved_path.Text = @"Courses\" + dt.Rows[0]["folder"].ToString() + @"\";
                else
                    FRM_MESSAGE.ShowMsg("خطا في المجلد");
            }
            catch(Exception ex)
            {
                FRM_MESSAGE.ShowMsg(ex.Message);
            }
        }
        private void CMB_Coursrs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c_id;
            bool r = Int32.TryParse(CMB_Coursrs.SelectedValue.ToString(), out c_id);
            if (c_id != 0)
                getFolderOfCourse(c_id);
        }

        private void BUT_save_Click(object sender, EventArgs e)
        {
            if (File.Exists(ofd.FileName))
            {
                try
                {
                    if (txtBox_ved_name.Text.Trim() != "" && txtBox_ved_path.Text.Trim() != "")
                    {
                        int c_id = Convert.ToInt32(CMB_Coursrs.SelectedValue);
                        File.Copy(ofd.FileName, this.txtBox_ved_path.Text+Path.GetFileName(ofd.FileName));
                        add.addVedio(txtBox_ved_name.Text.Trim(), txtBox_ved_path.Text.Trim(), CMB_ved_accuracy.Text, c_id);
                        FRM_MESSAGE.ShowMsg("تم إضافة الفيديو بنجاح");
                        this.BUT_save.Enabled = false;
                    }
                }
                catch
                {
                    this.BUT_save.Enabled = false;
                    FRM_MESSAGE.ShowMsg("هذا الفيديو لقد تم إضافته مسبقا");
                }
            }
            else
            {
                FRM_MESSAGE.ShowMsg("حدث خطاء في مسار الفيديو");
            }
        }
    }
}
