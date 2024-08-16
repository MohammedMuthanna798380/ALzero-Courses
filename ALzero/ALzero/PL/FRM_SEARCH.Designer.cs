namespace ALzero.PL
{
    partial class FRM_SEARCH
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bB_clear = new Bunifu.Framework.UI.BunifuImageButton();
            this.txtBox_search = new System.Windows.Forms.TextBox();
            this.bB_search = new Bunifu.Framework.UI.BunifuImageButton();
            this.bB_close = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGV_Vedio = new Guna.UI2.WinForms.Guna2DataGridView();
            this.CMS_search = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMS_T_open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CMS_T_details = new System.Windows.Forms.ToolStripMenuItem();
            this.CMS_T_setting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CMS_T_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bB_clear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bB_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bB_close)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Vedio)).BeginInit();
            this.CMS_search.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bB_clear);
            this.panel1.Controls.Add(this.txtBox_search);
            this.panel1.Controls.Add(this.bB_search);
            this.panel1.Controls.Add(this.bB_close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 49);
            this.panel1.TabIndex = 0;
            // 
            // bB_clear
            // 
            this.bB_clear.BackColor = System.Drawing.Color.Transparent;
            this.bB_clear.Enabled = false;
            this.bB_clear.Image = global::ALzero.Properties.Resources.x40px;
            this.bB_clear.ImageActive = null;
            this.bB_clear.Location = new System.Drawing.Point(52, 8);
            this.bB_clear.Name = "bB_clear";
            this.bB_clear.Size = new System.Drawing.Size(37, 31);
            this.bB_clear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bB_clear.TabIndex = 5;
            this.bB_clear.TabStop = false;
            this.bB_clear.Zoom = 10;
            this.bB_clear.Click += new System.EventHandler(this.bB_clear_Click);
            // 
            // txtBox_search
            // 
            this.txtBox_search.Location = new System.Drawing.Point(48, 5);
            this.txtBox_search.Name = "txtBox_search";
            this.txtBox_search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBox_search.Size = new System.Drawing.Size(504, 38);
            this.txtBox_search.TabIndex = 4;
            this.txtBox_search.TextChanged += new System.EventHandler(this.txtBox_search_TextChanged);
            this.txtBox_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_search_KeyDown);
            // 
            // bB_search
            // 
            this.bB_search.BackColor = System.Drawing.Color.Transparent;
            this.bB_search.Enabled = false;
            this.bB_search.Image = global::ALzero.Properties.Resources.search56px;
            this.bB_search.ImageActive = null;
            this.bB_search.Location = new System.Drawing.Point(556, 3);
            this.bB_search.Name = "bB_search";
            this.bB_search.Size = new System.Drawing.Size(39, 40);
            this.bB_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bB_search.TabIndex = 3;
            this.bB_search.TabStop = false;
            this.bB_search.Zoom = 10;
            this.bB_search.Click += new System.EventHandler(this.bB_search_Click);
            // 
            // bB_close
            // 
            this.bB_close.BackColor = System.Drawing.Color.Transparent;
            this.bB_close.Image = global::ALzero.Properties.Resources.exitt60px;
            this.bB_close.ImageActive = null;
            this.bB_close.Location = new System.Drawing.Point(0, 0);
            this.bB_close.Name = "bB_close";
            this.bB_close.Size = new System.Drawing.Size(42, 46);
            this.bB_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bB_close.TabIndex = 2;
            this.bB_close.TabStop = false;
            this.bB_close.Zoom = 10;
            this.bB_close.Click += new System.EventHandler(this.bB_close_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DGV_Vedio);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 651);
            this.panel2.TabIndex = 1;
            // 
            // DGV_Vedio
            // 
            this.DGV_Vedio.AllowUserToAddRows = false;
            this.DGV_Vedio.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGV_Vedio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Vedio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Vedio.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Vedio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV_Vedio.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGV_Vedio.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Kufi Arabic", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Vedio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Vedio.ColumnHeadersHeight = 33;
            this.DGV_Vedio.ContextMenuStrip = this.CMS_search;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Kufi Arabic", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Vedio.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Vedio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Vedio.EnableHeadersVisualStyles = false;
            this.DGV_Vedio.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV_Vedio.Location = new System.Drawing.Point(0, 0);
            this.DGV_Vedio.Name = "DGV_Vedio";
            this.DGV_Vedio.ReadOnly = true;
            this.DGV_Vedio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV_Vedio.RowHeadersVisible = false;
            this.DGV_Vedio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Vedio.Size = new System.Drawing.Size(600, 651);
            this.DGV_Vedio.TabIndex = 0;
            this.DGV_Vedio.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGV_Vedio.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGV_Vedio.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGV_Vedio.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGV_Vedio.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGV_Vedio.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGV_Vedio.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV_Vedio.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGV_Vedio.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_Vedio.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Noto Kufi Arabic", 12F);
            this.DGV_Vedio.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGV_Vedio.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGV_Vedio.ThemeStyle.HeaderStyle.Height = 33;
            this.DGV_Vedio.ThemeStyle.ReadOnly = true;
            this.DGV_Vedio.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGV_Vedio.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGV_Vedio.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Noto Kufi Arabic", 12F);
            this.DGV_Vedio.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGV_Vedio.ThemeStyle.RowsStyle.Height = 22;
            this.DGV_Vedio.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV_Vedio.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGV_Vedio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Vedio_CellContentClick);
            this.DGV_Vedio.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Vedio_CellContentDoubleClick);
            // 
            // CMS_search
            // 
            this.CMS_search.BackColor = System.Drawing.Color.White;
            this.CMS_search.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMS_search.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMS_T_open,
            this.toolStripSeparator1,
            this.CMS_T_details,
            this.CMS_T_setting,
            this.toolStripSeparator2,
            this.CMS_T_delete,
            this.toolStripSeparator3});
            this.CMS_search.Name = "CMS_search";
            this.CMS_search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CMS_search.Size = new System.Drawing.Size(126, 118);
            // 
            // CMS_T_open
            // 
            this.CMS_T_open.Name = "CMS_T_open";
            this.CMS_T_open.Size = new System.Drawing.Size(125, 24);
            this.CMS_T_open.Text = "فتح";
            this.CMS_T_open.Click += new System.EventHandler(this.CMS_T_open_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(122, 6);
            // 
            // CMS_T_details
            // 
            this.CMS_T_details.Name = "CMS_T_details";
            this.CMS_T_details.Size = new System.Drawing.Size(125, 24);
            this.CMS_T_details.Text = "تفاصيل";
            this.CMS_T_details.Click += new System.EventHandler(this.CMS_T_details_Click);
            // 
            // CMS_T_setting
            // 
            this.CMS_T_setting.Enabled = false;
            this.CMS_T_setting.Name = "CMS_T_setting";
            this.CMS_T_setting.Size = new System.Drawing.Size(125, 24);
            this.CMS_T_setting.Text = "تعديل";
            this.CMS_T_setting.Click += new System.EventHandler(this.CMS_T_setting_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(122, 6);
            // 
            // CMS_T_delete
            // 
            this.CMS_T_delete.Enabled = false;
            this.CMS_T_delete.Name = "CMS_T_delete";
            this.CMS_T_delete.Size = new System.Drawing.Size(125, 24);
            this.CMS_T_delete.Text = "حذف";
            this.CMS_T_delete.Click += new System.EventHandler(this.CMS_T_delete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(122, 6);
            // 
            // FRM_SEARCH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Noto Kufi Arabic", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "FRM_SEARCH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRM_SEARCH_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bB_clear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bB_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bB_close)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Vedio)).EndInit();
            this.CMS_search.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2DataGridView DGV_Vedio;
        private Bunifu.Framework.UI.BunifuImageButton bB_clear;
        private System.Windows.Forms.TextBox txtBox_search;
        private Bunifu.Framework.UI.BunifuImageButton bB_search;
        private Bunifu.Framework.UI.BunifuImageButton bB_close;
        private System.Windows.Forms.ContextMenuStrip CMS_search;
        private System.Windows.Forms.ToolStripMenuItem CMS_T_open;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CMS_T_details;
        private System.Windows.Forms.ToolStripMenuItem CMS_T_setting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CMS_T_delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}