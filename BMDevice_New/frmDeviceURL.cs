using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace BMDevice_New
{
    public partial class frmDeviceURL : Form
    {
        public frmDeviceURL()
        {
            InitializeComponent();
        }
        string dataSourcePath;
        string StrEdit = "";

        private void frmDeviceURL_Load(object sender, EventArgs e)
        {
            Global.selUrlIp = "";
            Global.selURL = "";
            cmbDeviceIp.Enabled = false;
            txtDeviceURL.Enabled = false;
            StrEdit = "";
            dataSourcePath = "Data Source = " + Application.StartupPath + @"\DeviceData.sdf";
            DataTable t = new DataTable();
            try
            {
                using (SqlCeConnection c = new SqlCeConnection(dataSourcePath))
                {
                    c.Open();
                    using (SqlCeDataAdapter a = new SqlCeDataAdapter("SELECT DEVICE_IP FROM DeviceData", c))
                    {
                        a.Fill(t);
                        //cmbDeviceIp.DataSource = t;
                        //dgvDeviceIps.DataSource = t;
                        //fnDeselectRow();
                    }
                    c.Close();
                }
            }
            catch { }
            cmbDeviceIp.Items.Clear();
            cmbDeviceIp.Items.Add("--Device IP--");
            txtDeviceURL.Text = "";
            cmbDeviceIp.SelectedIndex = 0;
            foreach (DataRow dr in t.Rows)
            {
                cmbDeviceIp.Items.Add(dr[0].ToString());
            }
            DataTable t1 = new DataTable();
            try
            {
                using (SqlCeConnection c1 = new SqlCeConnection(dataSourcePath))
                {
                    c1.Open();
                    using (SqlCeDataAdapter a1 = new SqlCeDataAdapter("SELECT DEV_IP as Device_IP,DEV_URL as Device_URL FROM DeviceURL", c1))
                    {
                        a1.Fill(t1);
                        //cmbDeviceIp.DataSource = t;
                        dgvDeviceURL.DataSource = t1;
                        //fnDeselectRow();
                    }
                    c1.Close();
                }
            }
            catch { }

            DataGridViewColumn column1 = dgvDeviceURL.Columns[0];
            column1.Width = 90;
            DataGridViewColumn column2 = dgvDeviceURL.Columns[1];
            if (dgvDeviceURL.Rows.Count > 6)
                column2.Width = 247;
            else
                column2.Width = 263;
            cmbDeviceIp.SelectedIndex = 0;
            txtDeviceURL.Focus();
            Application.DoEvents();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            fnDeselectRow();
        }

        private void fnDeselectRow()
        {
            int rowCount = dgvDeviceURL.Rows.Count;
            if (rowCount >= 1)
                dgvDeviceURL.Rows[0].Selected = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmDeviceURL_Load(null, null);
            txtDeviceURL.Text = "";
            btnSave.Enabled = true;
            cmbDeviceIp.Enabled = true;
            txtDeviceURL.Enabled = true;

            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lbError.Visible = false;
            Application.DoEvents();
            dataSourcePath = "Data Source = " + Application.StartupPath + @"\DeviceData.sdf";
            SqlCeConnection sqlConnection1 = new SqlCeConnection();
            sqlConnection1.ConnectionString = dataSourcePath;
            if (cmbDeviceIp.SelectedIndex != 0 && txtDeviceURL.Text != "")
            {
                frmBMDeviceMain frm = new frmBMDeviceMain();
                if (frm.fnGetDBValues(txtDeviceURL.Text.Trim()))
                {
                    SqlCeCommand cmd = new SqlCeCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    string url = @txtDeviceURL.Text;
                    SqlCeDataReader SQLRD;
                    cmd.CommandText = "SELECT * FROM DeviceURL WHERE DEV_IP='" + cmbDeviceIp.SelectedItem.ToString() + "' AND DEV_URL='" + url + "'";
                    SQLRD = cmd.ExecuteReader();
                    int v = 0;
                    while (SQLRD.Read())
                    {
                        v++;
                    }
                    SQLRD.Close();
                    if (v == 0)
                    {
                        if (StrEdit != "edit")
                        {
                            try
                            {
                                cmd.CommandText = "INSERT INTO DeviceURL (DEV_IP, DEV_URL) VALUES('" + cmbDeviceIp.SelectedItem.ToString() + "', '" + url + "')";
                                cmd.ExecuteNonQuery();
                                lbError.Visible = true;
                                lbError.Text = "Device IP and URL Maped Successfully";
                                btnSave.Enabled = false;
                            }
                            catch
                            { }
                        }
                        else if (StrEdit == "edit")
                        {
                            try
                            {
                                cmd.CommandText = "UPDATE DeviceURL SET DEV_IP='" + cmbDeviceIp.SelectedItem.ToString() + "',DEV_URL='" + url + "'";
                                cmd.ExecuteNonQuery();
                                lbError.Visible = true;
                                lbError.Text = "Device IP and URL Maping Updated Successfully";
                                btnSave.Enabled = false;
                            }
                            catch
                            { }
                        }
                    }
                    else
                    {
                        lbError.Visible = true;
                        lbError.Text = "Already exists this details";
                    }
                    frmDeviceURL_Load(null, null);
                }
                else
                {
                    lbError.Visible = true;
                    lbError.Text = "Enter Correct SPP Web URL";
                    txtDeviceURL.SelectAll();
                    txtDeviceURL.Focus();
                }
            }
            else
            {
                cmbDeviceIp.Enabled = true;
                txtDeviceURL.Enabled = true;
                if (cmbDeviceIp.SelectedIndex == 0)
                {
                    lbError.Visible = true;
                    lbError.Text = "Select Device IP";
                    cmbDeviceIp.Focus();
                }
                else if (txtDeviceURL.Text == "")
                {
                    lbError.Visible = true;
                    lbError.Text = "Enter Web URL";
                    txtDeviceURL.Focus();
                }

            }
            sqlConnection1.Dispose();
            sqlConnection1.Close();
        }

        private void dgvDeviceURL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Global.selUrlIp = "";
            Global.selURL = "";
            lbError.Visible = false;
            int rowindex = e.RowIndex;
            if (rowindex != -1)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                Global.selUrlIp = dgvDeviceURL.Rows[rowindex].Cells[0].Value.ToString();
                Global.selURL = dgvDeviceURL.Rows[rowindex].Cells[1].Value.ToString();
                int ind = -1;
                int i = 0;
                txtDeviceURL.Text = Global.selURL;
                foreach (string lc in cmbDeviceIp.Items)
                {
                    if ((lc).Equals(Global.selUrlIp))
                    {                                 
                        ind = i;
                        cmbDeviceIp.SelectedIndex = ind;
                        btnSave.Enabled = true;
                        if (StrEdit == "no")
                        {
                            cmbDeviceIp.Enabled = true;
                            txtDeviceURL.Enabled = true;
                            StrEdit = "edit";
                        }
                        else
                        {
                            btnDelete.Enabled = true;
                            btnEdit.Enabled = true;
                            btnSave.Enabled = false;
                        }
                        return;
                    }
                    i++;
                }
                //grbDeviceIP.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dataSourcePath = "Data Source = " + Application.StartupPath + @"\DeviceData.sdf";
            if (Global.selUrlIp != "" && Global.selURL != "")
            {
                SqlCeConnection sqlConnection1 = new SqlCeConnection();
                sqlConnection1.ConnectionString = dataSourcePath;
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();

                cmd.CommandText = "DELETE FROM DeviceURL WHERE DEV_IP='" + Global.selUrlIp + "' AND DEV_URL='" + Global.selURL + "'";
                cmd.ExecuteNonQuery();

                sqlConnection1.Dispose();
                sqlConnection1.Close();
                frmDeviceURL_Load(null, null);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cmbDeviceIp.SelectedIndex != 0 && txtDeviceURL.Text != "")
            {
                cmbDeviceIp.Enabled = true;
                txtDeviceURL.Enabled = true;
                StrEdit = "edit";
            }
            else
            {
                lbError.Visible = true;
                lbError.Text = "To Edit, first select Device IP and URL details form table";
                StrEdit = "no";
            }
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
        }
    }
}
