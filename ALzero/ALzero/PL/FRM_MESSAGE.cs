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
    public partial class FRM_MESSAGE : Form
    {
        BL.MESSAGE message = new BL.MESSAGE();
        public static int ved_id = 0;
        public FRM_MESSAGE()
        {
            InitializeComponent();
        }
        void deleteVed(int ved)
        {
            message.deleteVed(ved);
            TXTBOX_Messge.Text = "تم حذف الفيديو";
            this.bunifuThinButton22.Visible = false;
            this.bunifuThinButton23.Location = new Point(bunifuThinButton23.Location.X-80, bunifuThinButton23.Location.Y);
            ved_id = 0;
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (ved_id > 0)
            {
                deleteVed(ved_id);
            }
            else
            {
                this.Close();
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void MessgeDelete(int ved_id1)
        {
            ved_id = ved_id1;
            string msgdelete = "لن تستطيع استرجاع هذا الفيديو بعد الحذف... هل تريد بالتاكيد حذف هذا الفيديو ؟؟";
            FRM_MESSAGE frm_msg = new FRM_MESSAGE();
            frm_msg.TXTBOX_Messge.Text = msgdelete;
            frm_msg.Show();
        }
        public static void MessgeUpdate()
        {
            FRM_MESSAGE frm_msg = new FRM_MESSAGE();
            frm_msg.TXTBOX_Messge.Text = "لقد تم تحديث بياناتك بنجاح...";
            frm_msg.bunifuThinButton22.Visible = false;
            ved_id = 0;
            frm_msg.bunifuThinButton23.Location = new Point(frm_msg.bunifuThinButton23.Location.X - 80, frm_msg.bunifuThinButton23.Location.Y);
            frm_msg.Show();
        }

        public static void ShowMsg(String msg)
        {
            FRM_MESSAGE frm_msg = new FRM_MESSAGE();
            frm_msg.TXTBOX_Messge.Text = msg;
            frm_msg.bunifuThinButton22.Visible = false;
            frm_msg.bunifuThinButton23.Location = new Point(frm_msg.bunifuThinButton23.Location.X - 80, frm_msg.bunifuThinButton23.Location.Y);
            ved_id = 0;
            frm_msg.ShowDialog();
        }

        private void FRM_MESSAGE_Load(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("sound wrong.wav");
            player.Play();
        }
    }
}
