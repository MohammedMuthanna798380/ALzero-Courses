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
    public partial class FRM_SEARCH : Form
    {
        BL.SEARCCH search = new BL.SEARCCH();
        DataTable dt = new DataTable();
        string ved_name="";
        int ved_id = 0;
        int user_id = 0;
        public FRM_SEARCH()
        {
            InitializeComponent();
        }

        void set_user_id()
        {
            DataTable dt = new DataTable();
            dt = search.getIdUser();
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
        private void txtBox_search_TextChanged(object sender, EventArgs e)
        {
            bB_clear.Enabled = true;
            bB_search.Enabled = true;
        }

        private void bB_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void searching()
        {
            if (txtBox_search.Text.Trim() != "")
            {
                try
                {
                    dt = search.searchVedio(txtBox_search.Text.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        this.DGV_Vedio.DataSource = dt;
                        DGV_Vedio.Columns["ved_id"].Visible = false;
                    }
                    else
                    {
                        FRM_MESSAGE.ShowMsg("لم يتم العثور على العنصر");
                    }
                }
                catch (Exception ex)
                {
                    FRM_MESSAGE.ShowMsg(ex.Message);
                }
            }
        }
        private void bB_search_Click(object sender, EventArgs e)
        {
            searching();
        }

        private void bB_clear_Click(object sender, EventArgs e)
        {
            this.txtBox_search.Clear();
            this.DGV_Vedio.DataSource = null;
        }

        private void txtBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
                searching();
        }

        private void DGV_Vedio_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PL.FRM_DISPLAY.display(ved_name);
        }

        private void CMS_T_open_Click(object sender, EventArgs e)
        {
            if(ved_name != "")          
                PL.FRM_DISPLAY.display(ved_name);
        }

        private void CMS_T_details_Click(object sender, EventArgs e)
        {
            if (ved_id != 0)
                PL.FRM_DETAILS.datailsVedio(ved_id);
        }

        private void DGV_Vedio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ved_name = this.DGV_Vedio.SelectedRows[0].Cells[1].Value.ToString();
            ved_id = Convert.ToInt32(this.DGV_Vedio.SelectedRows[0].Cells[0].Value);
        }

        private void CMS_T_setting_Click(object sender, EventArgs e)
        {
            if (ved_id != 0)
                PL.FRM_DETAILS.settingVed(ved_id);
        }

        private void CMS_T_delete_Click(object sender, EventArgs e)
        {
            if (ved_id != 0)
                PL.FRM_DETAILS.settingVed(ved_id);
        }

        public void CheckAdmin()
        {
            if (BL.ISADMIN.getAdminStatus(user_id) > 0)
            {
                this.CMS_T_delete.Enabled = true;
                this.CMS_T_setting.Enabled = true;
            }
        }

        private void FRM_SEARCH_Load(object sender, EventArgs e)
        {
            CheckAdmin();
        }
    }
}
