using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;

namespace BMDevice_New
{
    public partial class frmStoreRecords : Form
    {
        public frmStoreRecords()
        {
            InitializeComponent();
        }

        string dataSourcePath = "";
        bool emp;
        bool date;

        private void frmStoreRecords_Load(object sender, EventArgs e)
        {
            dtpDate.MaxDate = DateTime.Now;
            emp = false;
            date = false;
            lbError.Visible = false;
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
                    }
                    c.Close();
                }
            }
            catch { }
            cmbDeviceIp.Items.Clear();
            cmbDeviceIp.Items.Add("--Device IP--");
            cmbDeviceIp.SelectedIndex = 0;
            foreach (DataRow dr in t.Rows)
            {
                cmbDeviceIp.Items.Add(dr[0].ToString());
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            lbError.Visible = false;
            if (chkDate.Checked == true)
            {
                grpDate.Enabled = true;
                date = true;
            }
            else
            {
                grpDate.Enabled = false;
                date = false;
            }
        }

        private void chkEmpId_CheckedChanged(object sender, EventArgs e)
        {
            lbError.Visible = false;
            if (chkEmpId.Checked == true)
            {
                grpEmp.Enabled = true;
                emp = true;
            }
            else
            {
                grpEmp.Enabled = false;
                emp = false;
            }
        }

        private void btnGetRecords_Click(object sender, EventArgs e)
        {
            string DeviceIp = "";
            string EmpId = "";
            string dateRec = "";
            lbError.Visible = false;
            if (cmbDeviceIp.SelectedIndex != 0)
            {
                DeviceIp = cmbDeviceIp.SelectedItem.ToString();
                if (emp == true)
                {
                    EmpId = txtEmp.Text.Trim();
                    if (EmpId == "")
                    {
                        lbError.Visible = true;
                        lbError.Text = "Enter Emp ID";
                        txtEmp.Focus();
                        return;
                    }
                }
                if (date == true)
                {
                    dateRec = dtpDate.Text;
                }
                Application.DoEvents();
                fnGetRecords(DeviceIp, EmpId, dateRec);
            }
            else
            {
                lbError.Visible = true;
                lbError.Text = "Select Device Ip";
                cmbDeviceIp.Focus();
                return;
            }
        }

        private void fnGetRecords(string DeviceIp, string EmpId, string dateRec)
        {
            lbError.ForeColor = Color.Red;
            string data = "";
            int dev_port = 0;
            int dev_no = 0;
            int run = 0;
            dataSourcePath = "Data Source = " + Application.StartupPath + @"\DeviceData.sdf";
            SqlCeConnection sqlConnection1 = new SqlCeConnection();
            sqlConnection1.ConnectionString = dataSourcePath;
            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            SqlCeDataReader SQLRD;
            cmd.CommandText = "SELECT * FROM DeviceData WHERE DEVICE_IP='" + DeviceIp + "'";
            SQLRD = cmd.ExecuteReader();
            int v = 0;
            while (SQLRD.Read())
            {
                dev_no = Convert.ToInt32(SQLRD[0]);
                dev_port = Convert.ToInt32(SQLRD[2]);
                v++;
            }
            SQLRD.Close();
            Application.DoEvents();
            if (v != 0)
            {
                lbError.Visible = true;
                lbError.ForeColor = Color.Black;
                lbError.Text = "Connecting Device....";
                lbError.Update();
                Application.DoEvents();
                bool rec = false;
                if (axCZKEM1.Connect_Net(DeviceIp, dev_port))
                {
                    rec = true;
                    Application.DoEvents();
                    lbError.Text = "Loading Device data....";
                    lbError.Update();
                    Application.DoEvents();
                    if (axCZKEM1.ReadGeneralLogData(dev_no))
                    {
                        Application.DoEvents();
                        int dwEnrollNumber = 0;
                        int dwVerifyMode = 0;
                        int dwInOutMode = 0;
                        string timeStr = "";

                        string query = "";
                        int inserte = 0;
                        int read = 0;
                        lbError.Text = "Reading Device data....";
                        lbError.Update();
                        Application.DoEvents();
                        while (axCZKEM1.GetGeneralLogDataStr(dev_no, ref dwEnrollNumber, ref dwVerifyMode, ref dwInOutMode, ref timeStr))
                        {
                            Application.DoEvents();
                            string emp_id = dwEnrollNumber.ToString();
                            string LogDate = timeStr.Substring(0, 10);
                            string LogTime = timeStr.Substring(11, 8);
                            if (emp == true && date == true)
                            {
                                if (emp_id == EmpId && dateRec == LogDate)
                                {
                                    data += dev_no + " " + emp_id + " " + LogDate + " " + LogTime + "\r\n";
                                    run++;
                                }
                            }
                            else if (emp == true)
                            {
                                if (emp_id == EmpId)
                                {
                                    data += dev_no + " " + emp_id + " " + LogDate + " " + LogTime + "\r\n";
                                    run++;
                                }
                            }
                            else if (date == true)
                            {
                                if (dateRec == LogDate)
                                {
                                    data += dev_no + " " + emp_id + " " + LogDate + " " + LogTime + "\r\n";
                                    run++;
                                }
                            }
                            else
                            {
                                data += dev_no + " " + emp_id + " " + LogDate + " " + LogTime + "\r\n";
                                run++;
                            }
                            Application.DoEvents();
                            lbError.Text = "Found records : " + run;
                            lbError.Update();
                            Application.DoEvents();
                        }
                        FileStream fs = new FileStream("./"+DeviceIp+"_"+DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".txt", FileMode.Append, FileAccess.Write);
                        //File.WriteAllLines(File.Open(fst, stringArray));
                        StreamWriter sw = new StreamWriter(fs);
                        //foreach (String line in stringArray)
                        //{
                            sw.WriteLine(data);
                        //}
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                    }
                }
                axCZKEM1.Disconnect();
            }
            sqlConnection1.Dispose();
            sqlConnection1.Close();
        }
    }
}
