using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ALzero.PL
{
    public partial class FRM_REPORT : Form
    {
        BL.REPORT rep = new BL.REPORT();
        int user_id = 0;
        int c_id = 0;
        string username;
        string coursename;
        bool checkCoursClick = false;
        
        public FRM_REPORT()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV_userORc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(user_id == 0 && !checkCoursClick)
            {
                user_id = (int) DGV_userORc.SelectedRows[0].Cells[0].Value;
                username = DGV_userORc.SelectedRows[0].Cells[6].Value.ToString();
                BTN_cors.Enabled = true;

            }
            else if(checkCoursClick)
            {
                c_id = (int)DGV_userORc.SelectedRows[0].Cells[0].Value;
                coursename= DGV_userORc.SelectedRows[0].Cells[1].Value.ToString();
                BTN_report.Enabled = true;
            }
        }

        private void BTN_user_Click(object sender, EventArgs e)
        {
            user_id = 0;
            BTN_cors.Enabled = false;
            BTN_report.Enabled = false;
            checkCoursClick = false;
            DataTable dt = new DataTable();
            dt = rep.getUser();
            DGV_userORc.DataSource = dt;
            this.DGV_userORc.Columns["user_id"].Visible = false;

        }

        private void BTN_cors_Click(object sender, EventArgs e)
        {
            checkCoursClick = true;
            DataTable dt = new DataTable();
            dt = rep.getAllCourses();
            DGV_userORc.DataSource = dt;
            this.DGV_userORc.Columns["c_id"].Visible = false;
        }

        public Double duration(string file)
        {
            WindowsMediaPlayer wsmp = new WindowsMediaPlayerClass();
            IWMPMedia mediaInfo = wsmp.newMedia(file);
            return mediaInfo.duration;
        }

        public void setDataReport()
        {
            double durations = 0;
            int vidNumbers = 0;


            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            if (c_id != 0)
            {
                dt1 = rep.getVedioCourse(c_id);
                if(dt1.Rows.Count > 0)
                {
                    foreach(DataRow row in dt1.Rows)
                    {
                        int ved_id = (int)row["ved_id"];
                        dt2 = rep.getWatchedVedio(user_id, ved_id);
                        if(dt2.Rows.Count > 0)
                        {
                            durations += duration(row["ved_path"].ToString() + row["ved_name"].ToString());
                            vidNumbers++;
                        }
                    }
                }

                RPOT.FRM_REPORTER rpot = new RPOT.FRM_REPORTER();
                RPOT.CertificateRPOT cr = new RPOT.CertificateRPOT();
                TextObject Name = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["Name"];
                TextObject Hour = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["Hours"];
                TextObject Course = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["Course"];
                TextObject Videos = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["Videos"];

                Name.Text = username;
                Hour.Text = (durations / 3600.0).ToString();
                Course.Text = coursename;
                Videos.Text = vidNumbers.ToString();

                rpot.crystalReportViewer1.ReportSource = cr;
                rpot.Show();

            }
        }

        private void BTN_report_Click(object sender, EventArgs e)
        {
            setDataReport();
            DGV_userORc.DataSource = null;
            user_id = 0;
            username = "";
            coursename = "";
            BTN_cors.Enabled = false;
            BTN_report.Enabled = false;
        }
    }
}
