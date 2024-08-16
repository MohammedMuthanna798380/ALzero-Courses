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
    public partial class FRM_BOOKS : Form
    {
        public FRM_BOOKS()
        {
            InitializeComponent();
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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
    }
}
