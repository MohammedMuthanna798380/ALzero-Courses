namespace ALzero.PL
{
    partial class FRM_Start
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Start));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MyProgress = new Bunifu.Framework.UI.BunifuProgressBar();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.P_Hi = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.lb_hi = new System.Windows.Forms.Label();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.P_Hi.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MyProgress
            // 
            this.MyProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.MyProgress.BorderRadius = 5;
            this.MyProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MyProgress.Location = new System.Drawing.Point(0, 293);
            this.MyProgress.MaximumValue = 100;
            this.MyProgress.Name = "MyProgress";
            this.MyProgress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(88)))), ((int)(((byte)(160)))));
            this.MyProgress.Size = new System.Drawing.Size(555, 10);
            this.MyProgress.TabIndex = 3;
            this.MyProgress.Value = 0;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 25;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ALzero.Properties.Resources.background;
            this.pictureBox1.Location = new System.Drawing.Point(112, 99);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // P_Hi
            // 
            this.P_Hi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.P_Hi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.P_Hi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("P_Hi.BackgroundImage")));
            this.P_Hi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P_Hi.Controls.Add(this.lb_hi);
            this.P_Hi.GradientBottomLeft = System.Drawing.Color.Transparent;
            this.P_Hi.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(88)))), ((int)(((byte)(160)))));
            this.P_Hi.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(88)))), ((int)(((byte)(160)))));
            this.P_Hi.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(88)))), ((int)(((byte)(160)))));
            this.P_Hi.Location = new System.Drawing.Point(67, 13);
            this.P_Hi.Name = "P_Hi";
            this.P_Hi.Quality = 10;
            this.P_Hi.Size = new System.Drawing.Size(420, 66);
            this.P_Hi.TabIndex = 12;
            // 
            // lb_hi
            // 
            this.lb_hi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_hi.AutoSize = true;
            this.lb_hi.BackColor = System.Drawing.Color.Transparent;
            this.lb_hi.Font = new System.Drawing.Font("Noto Kufi Arabic", 15.75F, System.Drawing.FontStyle.Bold);
            this.lb_hi.ForeColor = System.Drawing.Color.White;
            this.lb_hi.Location = new System.Drawing.Point(5, 13);
            this.lb_hi.Name = "lb_hi";
            this.lb_hi.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lb_hi.Size = new System.Drawing.Size(411, 40);
            this.lb_hi.TabIndex = 6;
            this.lb_hi.Text = "مرحبا بك في تطبيق الكورسات البرمجية";
            this.lb_hi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 25;
            this.bunifuElipse2.TargetControl = this.P_Hi;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(528, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FRM_Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(555, 303);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.P_Hi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MyProgress);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_Start";
            this.Load += new System.EventHandler(this.FRM_Start_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.P_Hi.ResumeLayout(false);
            this.P_Hi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Bunifu.Framework.UI.BunifuProgressBar MyProgress;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel P_Hi;
        private System.Windows.Forms.Label lb_hi;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}