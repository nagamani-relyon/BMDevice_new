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
    public partial class frmNewDevice : Form
    {
        public frmNewDevice()
        {
            InitializeComponent();
        }

        string dataSourcePath;
        string newOld = "";
        int selectedMech;

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            grbDeviceIP.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            txtDevPort.Text = "";
            txtDevNo.Text = "";
            txtDevIp.Text = "";
            newOld = "";
            fnDeselectRow();
        }

        private void frmNewDevice_Load(object sender, EventArgs e)
        {
            fnGetIpsFronTable();
        }

        private void fnGetIpsFronTable()
        {
            dataSourcePath = "Data Source = " + Application.StartupPath + @"\DeviceData.sdf";
            //MessageBox.Show(dataSourcePath);
            //DataTable t = new DataTable();
            //try
            //{
            //    using (SqlCeConnection c = new SqlCeConnection(dataSourcePath))
            //    {
            //        c.Open();
            //        using (SqlCeDataAdapter a = new SqlCeDataAdapter("SELECT * FROM DeviceData", c))
            //        {
            //            a.Fill(t);
            //            if (t.Rows.Count > 0)
            //            {
            //                dgvDeviceIps.DataSource = t;
            //                //dgvDeviceIps.Update();
            //            }
            //            //fnDeselectRow();
            //        }
            //        c.Close();
            //    }
            //}
            //catch { }
            DataTable t1 = new DataTable();
            try
            {
                using (SqlCeConnection c1 = new SqlCeConnection(dataSourcePath))
                {
                    c1.Open();
                    using (SqlCeDataAdapter a1 = new SqlCeDataAdapter("SELECT DEVICE_NUM as Device_Number,DEVICE_IP as Device_IP,DEVICE_PORT as Device_Port FROM DeviceData", c1))
                    {
                        a1.Fill(t1);
                        //cmbDeviceIp.DataSource = t;
                        dgvDeviceIps.DataSource = t1;
                        //fnDeselectRow();
                    }
                    c1.Close();
                }
            }
            catch { }

            if (dgvDeviceIps.Rows.Count < 8 && dgvDeviceIps.Rows.Count > 0)
            {
                DataGridViewColumn column1 = dgvDeviceIps.Columns[1];
                column1.Width = 152;
            }
            else if (dgvDeviceIps.Rows.Count >= 8)
            {
                DataGridViewColumn column1 = dgvDeviceIps.Columns[1];
                column1.Width = 137;
            }
            Global.Indexrow = -1;
            Application.DoEvents();
            fnDeselectRow();
        }

        private void fnDeselectRow()
        {
            int rowCount = dgvDeviceIps.Rows.Count;
            if (rowCount >= 1)
                dgvDeviceIps.Rows[0].Selected = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnSave.Enabled = false;
            lbError.Visible = false;
            dataSourcePath = "Data Source = " + Application.StartupPath + @"\DeviceData.sdf";
            SqlCeConnection sqlConnection1 = new SqlCeConnection();
            sqlConnection1.ConnectionString = dataSourcePath;
            if (txtDevIp.Text != "" && txtDevNo.Text != "" && txtDevPort.Text != "")
            {
                lbError.Visible = true;
                lbError.Text = "Please wait, Testing device Connection before saving";
                Application.DoEvents();
                if (axCZKEM1.Connect_Net(txtDevIp.Text.Trim(), Convert.ToInt32(txtDevPort.Text.Trim())))
                {
                    //if (axCZKEM1.ReadGeneralLogData(Convert.ToInt32(txtDevNo.Text)))
                    //{
                        lbError.Visible = false;
                        lbError.Text = "";
                        Application.DoEvents();
                        SqlCeCommand cmd = new SqlCeCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = sqlConnection1;
                        sqlConnection1.Open();
                        if (newOld != "edit")
                        {
                            SqlCeDataReader SQLRD;
                            cmd.CommandText = "SELECT * FROM DeviceData WHERE DEVICE_NUM=" + txtDevNo.Text.Trim() + " OR DEVICE_IP='" + txtDevIp.Text.Trim() + "'";
                            SQLRD = cmd.ExecuteReader();
                            int v = 0;
                            while (SQLRD.Read())
                            {
                                v++;
                            }
                            SQLRD.Close();
                            if (v == 0)
                            {
                                try
                                {
                                    cmd.CommandText = "INSERT INTO DeviceData VALUES(" + txtDevNo.Text.Trim() + ",'" + txtDevIp.Text.Trim() + "','" + txtDevPort.Text.Trim() + "')";
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                { }
                            }
                            else
                            {
                                lbError.Visible = true;
                                lbError.Text = "Already entered the details for this Device IP or Mechine number";
                            }
                        }
                        else
                        {
                            string mech = Global.selMech.ToString();
                            if (mech != txtDevNo.Text || Global.selMechIp != txtDevIp.Text || Global.selMechPort != txtDevPort.Text)
                            {
                                SqlCeDataReader SQLRD1;
                                cmd.CommandText = "SELECT * FROM DeviceData WHERE DEVICE_NUM=" + txtDevNo.Text.Trim() + " AND DEVICE_IP='" + txtDevIp.Text.Trim() + "' AND DEVICE_PORT='" + txtDevPort.Text.Trim() + "'";
                                SQLRD1 = cmd.ExecuteReader();
                                int v = 0;
                                while (SQLRD1.Read())
                                {
                                    v++;
                                }
                                SQLRD1.Close();
                                if (v == 0)
                                {
                                    try
                                    {
                                        cmd.CommandText = "UPDATE DeviceData  SET DEVICE_NUM=" + txtDevNo.Text.Trim() + ", DEVICE_IP='" + txtDevIp.Text.Trim() + "', DEVICE_PORT='" + txtDevPort.Text.Trim() + "' WHERE DEVICE_NUM=" + selectedMech;
                                        cmd.ExecuteNonQuery();
                                        lbError.Visible = true;
                                        lbError.Text = "Details of Device IP : " + txtDevIp.Text + " Saved";
                                    }
                                    catch
                                    { }
                                }
                                else
                                {
                                    lbError.Visible = true;
                                    lbError.Text = "Already exist same details for this Device IP : " + txtDevIp.Text;
                                }
                            }
                            else
                            {
                                lbError.Visible = true;
                                lbError.Text = "Data not Changed ";
                            }
                            btnEdit.Enabled = false;
                        }
                        btnSave.Enabled = false;
                    //}
                    //else
                    //{
                    //    lbError.Visible = true;
                    //    lbError.Text = "Enter Correct Device Number";
                    //    txtDevNo.SelectAll();
                    //    txtDevNo.Focus();
                    //}
                }
                else
                {
                    lbError.Visible = true;
                    //lbError.Text = "Enter Correct Device Ip and Port";
                    lbError.Text = "Unable to connect device, enter correct device IP";
                    txtDevIp.SelectAll();
                    return;
                }
                axCZKEM1.Disconnect();
            }
            else
            {
                if (newOld != "edit")
                {
                    if (txtDevNo.Text == "")
                    {
                        lbError.Visible = true;
                        lbError.Text = "Enter Device Number";
                        txtDevNo.Focus();
                    }
                    else if (txtDevPort.Text == "")
                    {
                        lbError.Visible = true;
                        lbError.Text = "Enter Device Port Number";
                        txtDevPort.Focus();
                    }
                    else if (txtDevIp.Text == "")
                    {
                        lbError.Visible = true;
                        lbError.Text = "Enter Device IP";
                        txtDevIp.Focus();
                    }
                }
                else
                {
                    lbError.Visible = true;
                    lbError.Text = "To Edit, First select details from the table";
                    btnSave.Enabled = false;
                }
            }
            sqlConnection1.Dispose();
            sqlConnection1.Close();

            btnNew.Enabled = true;
            btnSave.Enabled = true;
            fnGetIpsFronTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDeviceIps_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbError.Visible = false;
            int rowindex = e.RowIndex;
            if (rowindex != -1)
            {
                Global.Indexrow = rowindex;
                selectedMech = Convert.ToInt32(dgvDeviceIps.Rows[rowindex].Cells[0].Value);

                Global.selMech = Convert.ToInt32(dgvDeviceIps.Rows[rowindex].Cells[0].Value);
                Global.selMechIp = dgvDeviceIps.Rows[rowindex].Cells[1].Value.ToString();
                Global.selMechPort = dgvDeviceIps.Rows[rowindex].Cells[2].Value.ToString();

                txtDevNo.Text = dgvDeviceIps.Rows[rowindex].Cells[0].Value.ToString();
                txtDevIp.Text = dgvDeviceIps.Rows[rowindex].Cells[1].Value.ToString();
                txtDevPort.Text = dgvDeviceIps.Rows[rowindex].Cells[2].Value.ToString();
                if (newOld == "edit")
                {
                    grbDeviceIP.Enabled = true;
                    btnSave.Enabled = true;
                }
                else
                {
                    grbDeviceIP.Enabled = false;
                    btnSave.Enabled = false;
                }
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                btnTestConn.Enabled = true;
            }
            else
            {
                Global.Indexrow = -1;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Global.Indexrow != -1)
            {
                string cellVal = dgvDeviceIps.Rows[Global.Indexrow].Cells[0].Value.ToString();
                if (cellVal.Equals(txtDevNo.Text))
                {
                    grbDeviceIP.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
            else
            {
                lbError.Visible = true;
                lbError.Text = "To Edit, First select details from the table";
            }
            btnDelete.Enabled = false;
            newOld = "edit";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            grbDeviceIP.Enabled = false;

            dataSourcePath = "Data Source = " + Application.StartupPath + @"\DeviceData.sdf";
            SqlCeConnection sqlConnection1 = new SqlCeConnection();
            sqlConnection1.ConnectionString = dataSourcePath;
            SqlCeCommand cmd = new SqlCeCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            try
            {
                cmd.CommandText = "DELETE FROM DeviceData WHERE DEVICE_IP='" + Global.selMechIp + "'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM DeviceURL WHERE DEV_IP='" + Global.selMechIp + "'";
                cmd.ExecuteNonQuery();
            }
            catch { }
            sqlConnection1.Dispose();
            sqlConnection1.Close();
            fnGetIpsFronTable();
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;

            txtDevIp.Text = "";
            txtDevNo.Text = "";
            txtDevPort.Text = "";
            Application.DoEvents();
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            if (Global.Indexrow != -1)
            {
                lbError.Visible = true;
                lbError.ForeColor = Color.Black;
                lbError.Text = "Testing Connection of Mechine[" + Global.selMech + "] with Ip : " + Global.selMechIp;
                lbError.Update();
                Application.DoEvents();
                if (axCZKEM1.Connect_Net(Global.selMechIp, Convert.ToInt32(Global.selMechPort)))
                {
                    lbError.Text = "Mechine[" + Global.selMech + "] with Ip : " + Global.selMechIp+" Connected";
                    btnTestConn.Enabled = false;
                }
            }
            else
            {
                lbError.Visible = true;
                lbError.Text = "To Test Connection, First select details from the table";
            }
        }

    }
}
