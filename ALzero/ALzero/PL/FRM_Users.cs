using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALzero.PL
{
    public partial class FRM_Users : Form
    {
        BL.USERS user = new BL.USERS();
        int user_id = 0;
        bool checkPass = false;
        static int Create_OR_Display = 0;
        public FRM_Users()
        {
            InitializeComponent();
        }
        void initializeToCreate()
        {
            this.securetypanel.Visible = false;
            this.txtBox_name.Text = "";
            this.txtBox_name.Enabled = true;
            this.txtBox_username.Text = "";
            this.txtBox_username.Enabled = true;
            this.txtBox_pass.Text = "";
            this.txtBox_pass.Visible = true;
            this.txtBox_repeatpass.Text = "";
            this.txtBox_repeatpass.Visible = true;
            this.lab_pass.Visible = true;
            this.lab_repeatpass.Visible = true;
            this.btn_edite_panel.Visible = false;
            this.craetpanel.Visible = true;
            this.itemspanel.Visible = true;
            this.btn_pass.Visible = false;
            this.label1.Visible = true;
        }
        public static void CreateUser(bool isAdmin)
        {
            FRM_Users userfrm = new FRM_Users();
            if (isAdmin)
                userfrm.checkBox_admin.Visible = true;
            Create_OR_Display = 1;
            userfrm.ShowDialog();
            userfrm.initializeToCreate();
        }
        public static void UserInfo()
        {
            FRM_Users userfrm = new FRM_Users();
            Create_OR_Display = 2;
            userfrm.ShowDialog();
        }

        void set_user_id()
        {
            DataTable dt = new DataTable();
            dt = user.getIdUser();
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
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (
                 txtBox_name.Text.Trim() !="" &&
                 txtBox_username.Text.Trim() != "" &&
                 txtBox_pass.Text.Trim() != "" &&
                 txtBox_repeatpass.Text.Trim() != "" )
            {
                if (txtBox_pass.Text.Trim() == txtBox_repeatpass.Text.Trim())
                {
                    try
                    {
                        bool isadmin = this.checkBox_admin.Checked ? true : false;
                        user.insertUser(txtBox_username.Text.Trim(), txtBox_pass.Text.Trim(), isadmin, txtBox_name.Text.Trim());
                        PL.FRM_MESSAGE.ShowMsg("تم إنشاء الحساب بنجاح يمكنك الان تسجيل الدخول.... نتمنى لك مشاهدة ممتعة ");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        PL.FRM_MESSAGE.ShowMsg(ex.Message);
                    }
                }
                else
                {
                    PL.FRM_MESSAGE.ShowMsg("كلمة المرور غير متطابقة");
                }

                //    DAL.DAL dal = new DAL.DAL();
                //MemoryStream ms = new MemoryStream();
                //PBOX_User.Image.Save(ms, PBOX_User.Image.RawFormat);

                //byte[] bytimage = ms.ToArray();
                //SqlParameter[] param = new SqlParameter[5];
                //param[0] = new SqlParameter("@username", SqlDbType.NVarChar, 150);
                //param[0].Value = txtBox_username.Text;
                //param[1] = new SqlParameter("@password", SqlDbType.NVarChar, 50);
                //param[1].Value = txtBox_pass.Text;
                //param[2] = new SqlParameter("@image", SqlDbType.Image);
                //param[2].Value = bytimage;
                //param[3] = new SqlParameter("@setadmin", SqlDbType.Bit);
                //param[3].Value = checkBox_admin.Checked;
                //param[4] = new SqlParameter("@fullname", SqlDbType.NVarChar, 150);
                //param[4].Value = txtBox_name.Text;


                //DataTable dt = new DataTable();
                //dal.open();
                // dal.write("create_new_user", param);

            }
        }

        private void PBOX_User_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images|*.jpg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    PBOX_User.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                FRM_MESSAGE.ShowMsg(ex.Message);
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.itemspanel.Visible = false;
            this.securetypanel.Visible = true;
        }

        void displayUser()
        {
            if (user_id != 0)
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = user.displayUser(user_id);

                    txtBox_username.Text = dt.Rows[0]["user_name"].ToString();
                    txtBox_name.Text = dt.Rows[0]["full_name"].ToString();
                    //  byte[] image = (byte[]) dt.Rows[0]["image"];

                    //   MemoryStream ms = new MemoryStream();
                    //   FRM_Users fimg = new FRM_Users();
                    //  fimg.PBOX_User.Image = Image.FromStream(ms);
                    //  fimg.Dialog();

                    DataTable dtImage = new DataTable();
                    try
                    {
                        dtImage = user.selectImageUser(user_id);
                        if (dtImage.Rows.Count > 0)
                        {
                            this.PBOX_User.Image = (Image)dtImage.Rows[0]["image"];
                        }
                        else
                        {
                            PL.FRM_MESSAGE.ShowMsg("لا توجد صورة شخصية ");
                        }

                    }catch
                    {
                        //PL.FRM_MESSAGE.ShowMsg("لا توجد صورة شخصية ");
                        //PL.FRM_MESSAGE.ShowMsg(ex.Message);
                    }

                }  catch(Exception ex)
                  {
                    FRM_MESSAGE.ShowMsg(ex.Message);
                  }

            }
            else
            {
                FRM_MESSAGE.ShowMsg("user_id");
            }
        }
        private void btn_SAVE_Click(object sender, EventArgs e)
        {
            if (user_id != 0)
            {
                if(checkPass && (txtBox_pass.Text.Trim()!=""|| txtBox_repeatpass.Text.Trim() != ""))
                {
                    if (txtBox_pass.Text.Trim() == txtBox_repeatpass.Text.Trim())
                    {
                        user.updateUser(user_id, txtBox_username.Text, txtBox_pass.Text, txtBox_name.Text);
                        PL.FRM_MESSAGE.ShowMsg("تم تغيير الاسم الكامل واسم المستخدم وكلمة المرور بنجاح");
                    }
                    else
                        PL.FRM_MESSAGE.ShowMsg("كلمة المرور غير متطابقة");
                }
                else
                {
                    user.updateUserNU(user_id, txtBox_username.Text, txtBox_name.Text);
                    PL.FRM_MESSAGE.ShowMsg("تم تغيير الاسم الكامل واسم المستخدم بنجاح");
                }
            }
            else
                PL.FRM_MESSAGE.ShowMsg("حصل خطا ما.....");
        }

        private void FRM_Users_Load(object sender, EventArgs e)
        {
            set_user_id();
            if (Create_OR_Display == 2)
                displayUser();
            else
                initializeToCreate();
            this.btn_SAVE.Enabled = false;
        }

        private void btnclose_secur_Click(object sender, EventArgs e)
        {
            this.securetypanel.Visible=false;
            this.itemspanel.Visible = true;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_securok_Click(object sender, EventArgs e)
        {
            if (user_id != 0)
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = user.checkPassword(user_id,txtbox_secur.Text);
                    if (dt.Rows.Count > 0)
                    {
                        this.securetypanel.Visible = false;
                        this.itemspanel.Visible = true;
                        this.txtBox_name.Enabled = true;
                        this.txtBox_username.Enabled = true;
                        this.btn_pass.Visible = true;
                        this.btn_SAVE.Enabled = true;
                        this.btn_SAVE.Visible = true;
                        this.PBOX_User.Enabled = true;
                    }
                    else
                    {
                        PL.FRM_MESSAGE.ShowMsg("خطأ في كلمة المرور ");
                    }
                }
                catch (Exception ex){
                    FRM_MESSAGE.ShowMsg(ex.Message);
                }
            }
        }

        private void itemspanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_pass_Click(object sender, EventArgs e)
        {
            this.txtBox_pass.Visible = true;
            this.txtBox_repeatpass.Visible = true;
            this.lab_pass.Visible = true;
            this.lab_repeatpass.Visible = true;
            checkPass = true;
        }
    }
}
