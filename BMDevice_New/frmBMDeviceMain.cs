using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.SqlServerCe;
using System.Net;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;

namespace BMDevice_New
{
    public partial class frmBMDeviceMain : Form
    {
        public frmBMDeviceMain()
        {
            InitializeComponent();
        }

        int TimeToWait = 0;
        int timer;
        DateTime now;
        DateTime current;
        string txtFileName;

        string EmpRefCard = "";

        string dataSourcePath;

        string strHost;
        string strUsr;
        string strPWD;
        string strDB;
        string strWebAddress;

        bool closeVal = false;

        int read = 0;
        int inserte = 0;

        private void btnAddNewDevice_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            frmNewDevice frm = new frmNewDevice();
            frm.ShowDialog();
            fnCheckVal();
        }

        private void fnCheckVal()
        {
            dataSourcePath = "Data Source = " + Application.StartupPath + @"\DeviceData.sdf";
            string query = "SELECT * FROM DeviceData";
            if (fnCheckIpsUrls(query))
            {
                query = "SELECT * FROM DeviceURL";
                if (fnCheckIpsUrls(query))
                {
                    btnStart.Enabled = true;
                    fnGetTimer();
                    if (txtTimer.Text != "")
                    {
                        try
                        {
                            timer = Convert.ToInt32(txtTimer.Text.Trim());
                            TimeToWait = timer - 1;
                            now = DateTime.Now;
                            timer1.Enabled = true;
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        lbTimer.Text = "Timer not Set";
                        lbRunStatus.Text += "\nNot entered Time interval";
                        fnLabelNewline();
                        return;
                    }
                }
                else
                {
                    lbTimer.Text = "Timer stopped";
                    lbRunStatus.Text += "\nNot mapped SPP Web URL's to Device";
                    fnLabelNewline();
                    btnStart.Enabled = false;
                    btnMapUrl.Focus();
                    return;
                }
            }
            else
            {
                lbTimer.Text = "Timer stopped";
                lbRunStatus.Text += "\nNo device details found. Add devices";
                fnLabelNewline();
                btnStart.Enabled = false;
                btnAddNewDevice.Focus();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMapUrl_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            frmDeviceURL frm = new frmDeviceURL();
            frm.ShowDialog();

            dataSourcePath = "Data Source = " + Application.StartupPath + @"\DeviceData.sdf";
            string query = "SELECT * FROM DeviceURL";
            if (fnCheckIpsUrls(query))
            {
                btnStart.Enabled = true;
                fnGetTimer();
                if (txtTimer.Text != "")
                {
                    try
                    {
                        timer = Convert.ToInt32(txtTimer.Text.Trim());
                        TimeToWait = timer - 1;
                        now = DateTime.Now;
                        timer1.Enabled = true;
                    }
                    catch
                    {
                    }
                }
                else
                {
                    lbTimer.Text = "Timer not Set";
                    lbRunStatus.Text += "\nNot entered Time interval";
                    fnLabelNewline();
                }
            }
            else
            {
                lbTimer.Text = "Timer stopped";
                lbRunStatus.Text += "\nNot mapped SPP Web URL's to Device";
                fnLabelNewline();
                btnStart.Enabled = false;
                btnMapUrl.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string emp = "";
            int TimerText = 0;
            if (rdbnEmpId.Checked == true)
                emp = "emp";
            else if (rdbnRefNo.Checked == true)
                emp = "ref";
            else if (rdbnCardId.Checked == true)
                emp = "card";

            if (txtTimer.Text != "")
            {
                lbError.Text = "";
                try
                {
                    TimerText = Convert.ToInt32(txtTimer.Text);
                    if (TimerText > 0 && TimerText <= 120)
                    {
                        RegistryKey regEmp = Registry.CurrentUser.CreateSubKey(@"Software\Relyon Softech Ltd\BMDevice");
                        regEmp.SetValue("BMDeviceEMP", emp);
                        String value = regEmp.GetValue("BMDeviceEMP").ToString();


                        RegistryKey regTimer = Registry.CurrentUser.CreateSubKey(@"Software\Relyon Softech Ltd\BMDevice");
                        regTimer.SetValue("BMDeviceTimer", TimerText.ToString());
                        value = regTimer.GetValue("BMDeviceTimer").ToString();
                        pnlrdbn.Enabled = false;
                        txtTimer.Enabled = false;
                        btnSave.Enabled = false;

                        /////////////////////////

                        dataSourcePath = "Data Source = " + Application.StartupPath + @"\DeviceData.sdf";
                        //MessageBox.Show(dataSourcePath);
                        string query = "SELECT * FROM DeviceData";
                        if (fnCheckIpsUrls(query))
                        {
                            query = "SELECT * FROM DeviceURL";
                            if (fnCheckIpsUrls(query))
                            {
                                timer = Convert.ToInt32(txtTimer.Text);
                                TimeToWait = timer;
                                TimeToWait--;
                                now = DateTime.Now;
                                btnStart.Enabled = true;
                                timer1.Enabled = true;
                            }
                            else
                            {
                                lbTimer.Text = "Timer stopped";
                                lbRunStatus.Text += "\nNot mapped SPP Web URL's to Device";
                                fnLabelNewline();
                                //pnlStatus
                                btnStart.Enabled = false;
                                btnMapUrl.Focus();
                            }
                        }
                        else
                        {
                            lbTimer.Text = "Timer stopped";
                            lbRunStatus.Text += "\nNo device details found. Add devices";
                            fnLabelNewline();
                            btnStart.Enabled = false;
                            btnAddNewDevice.Focus();
                        }
                        /////////////////////////
                        //fnGetEmpRefCard();
                        //fnGetTimer();
                        //timer = Convert.ToInt32(txtTimer.Text);
                        //TimeToWait = timer - 1;
                        //now = DateTime.Now;
                        //btnStart.Enabled = true;
                        //timer1.Enabled = true;
                    }
                    else
                    {
                        lbError.Text = "(between 1 to 120)";
                        txtTimer.SelectAll();
                        txtTimer.Focus();
                    }
                }
                catch (FormatException fex)
                {
                    lbError.Text = "Enter Number";
                    txtTimer.SelectAll();
                    txtTimer.Focus();
                }
            }
            else
            {
                lbError.Text = "Enter Number";
                txtTimer.Focus();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            pnlrdbn.Enabled = true;
            txtTimer.Enabled = true;
            btnSave.Enabled = true;
        }

        private bool fnCheckIpsUrls(string query)
        {
            bool valid=false;
            DataTable t = new DataTable();
            try
            {
                using (SqlCeConnection c = new SqlCeConnection(dataSourcePath))
                {
                    c.Open();
                    using (SqlCeDataAdapter a = new SqlCeDataAdapter(query, c))
                    {
                        a.Fill(t);
                    }
                    c.Close();
                }
            }
            catch { }
            int rowCount = t.Rows.Count;
            if (rowCount > 0)
                valid = true;
            return valid;
        }

        private void fnRunStartup()
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("Relyon BM Device", Application.ExecutablePath.ToString());
        }

        private void frmBMDeviceMain_Load(object sender, EventArgs e)
        {
            //string filename = Application.StartupPath + "\\Logs\\192.168.3.101\\192.168.3.101_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".txt";
            //string data = "Nagamani";
            //FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fs);
            //sw.WriteLine(data);
            //sw.Flush();
            //sw.Close();
            //fs.Close();
            if (!fnChkSyncExe())
            {
                fnRunStartup();
                notifyIcon1.ShowBalloonTip(10, "Relyon BM Device Reader", "BM Device Reader", ToolTipIcon.Info);
                fnGetEmpRefCard();
                fnGetTimer();
                if (txtTimer.Text != "")
                {
                    dataSourcePath = "Data Source = " + Application.StartupPath + @"\DeviceData.sdf";
                    //MessageBox.Show(dataSourcePath);
                    string query = "SELECT * FROM DeviceData";
                    if (fnCheckIpsUrls(query))
                    {
                        query = "SELECT * FROM DeviceURL";
                        if (fnCheckIpsUrls(query))
                        {
                            timer = Convert.ToInt32(txtTimer.Text);
                            TimeToWait = timer;
                            TimeToWait--;
                            now = DateTime.Now;
                            timer1.Enabled = true;
                        }
                        else
                        {
                            lbTimer.Text = "Timer stopped";
                            lbRunStatus.Text += "\nNot mapped SPP Web URL's to Device";
                            fnLabelNewline();
                            //pnlStatus
                            btnStart.Enabled = false;
                            btnMapUrl.Focus();
                        }
                    }
                    else
                    {
                        lbTimer.Text = "Timer stopped";
                        lbRunStatus.Text += "\nNo device details found. Add devices";
                        fnLabelNewline();
                        btnStart.Enabled = false;
                        btnAddNewDevice.Focus();
                    }
                }

            }
        }

        private void fnLabelNewline()
        {
            //lbAppliStatus.Text += Environment.NewLine;
            lbRunStatus.Update();

            System.Drawing.Point CurrentPoint;
            CurrentPoint = pnlStatus.AutoScrollPosition;
            pnlStatus.AutoScrollPosition = new Point(Math.Abs(pnlStatus.AutoScrollPosition.X), Math.Abs(lbRunStatus.Height));
            pnlStatus.Update();
        }

        private bool fnChkSyncExe()
        {
            bool isRunning = false;
            Process[] localexeByName = Process.GetProcessesByName("BMDevice_New");

            if (localexeByName.Length > 1)
            {
                isRunning = true;
            }
            return isRunning;
        }

        private void fnGetEmpRefCard()
        {
            try
            {
                RegistryKey regGetRPP = Registry.CurrentUser.OpenSubKey(@"Software\Relyon Softech Ltd\BMDevice");
                object value = regGetRPP.GetValue("BMDeviceEMP").ToString();
                if (value != null)
                {
                    string str = value.ToString();

                    EmpRefCard = str;

                    if (str == "emp")
                        rdbnEmpId.Checked = true;
                    else if (str == "ref")
                        rdbnRefNo.Checked = true;
                    else if (str == "card")
                        rdbnCardId.Checked = true;
                    else
                    {
                        lbRunStatus.Text += "\nSeetings not done";
                        fnLabelNewline();
                        pnlrdbn.Enabled = true;
                        txtTimer.Enabled = true;
                        btnSave.Enabled = true;
                    }
                }
                else
                {
                    lbRunStatus.Text += "\nSeetings not done";
                    fnLabelNewline();
                    pnlrdbn.Enabled = true;
                    txtTimer.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
            catch
            {
                RegistryKey regRPP = Registry.CurrentUser.CreateSubKey(@"Software\Relyon Softech Ltd\BMDevice");
                regRPP.SetValue("BMDeviceEMP", "");
            }
        }

        private void fnGetTimer()
        {
            try
            {
                RegistryKey regGetRPP = Registry.CurrentUser.OpenSubKey(@"Software\Relyon Softech Ltd\BMDevice");
                object value = regGetRPP.GetValue("BMDeviceTimer").ToString();
                if (value != null)
                {
                    txtTimer.Text = value.ToString();
                }
            }
            catch
            {
                RegistryKey regRPP = Registry.CurrentUser.CreateSubKey(@"Software\Relyon Softech Ltd\BMDevice");
                regRPP.SetValue("BMDeviceTimer", "");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            current = DateTime.Now;
            TimeSpan elapsed = current - now;

            if ((TimeToWait + 1) == elapsed.Minutes)
            {
                timer1.Enabled = false;
                lbTimer.Text = "Timer Stopped";
                pnlSettings.Enabled = false;
                pnlButtons.Enabled = false;
                button2.Enabled = false;
                Application.DoEvents();
                notifyIcon1.ShowBalloonTip(10, "Relyon BM Device Reader", "Started reading device records", ToolTipIcon.Info);
                fnReadData1();
                notifyIcon1.ShowBalloonTip(10, "Relyon BM Device Reader", "Read and saved Successfully", ToolTipIcon.Info);
                Application.DoEvents();
                TimeToWait = timer - 1;
                now = DateTime.Now;
                pnlSettings.Enabled = true;
                pnlButtons.Enabled = true;
                button2.Enabled = true;
                timer1.Enabled = true;
            }
            else
            {
                lbTimer.Text = "Reads BM Devices data in " + ((TimeToWait) - elapsed.Minutes) + " : " + (59 - (elapsed.Seconds)) + " minutes";
            }
        }

        private void fnReadData1()
        {
            lbRunStatus.Text += "\n\nReading BM Device IPs---->Time : "+DateTime.Now.ToString();
            fnLabelNewline();
            int dev_no = -1;
            string dev_ip = "";
            int dev_port = -1;
            dataSourcePath = "Data Source = " + Application.StartupPath + @"\DeviceData.sdf";
            DataTable t = new DataTable();
            try
            {
                using (SqlCeConnection c = new SqlCeConnection(dataSourcePath))
                {
                    c.Open();
                    using (SqlCeDataAdapter a = new SqlCeDataAdapter("SELECT * FROM DeviceData", c))
                    {
                        a.Fill(t);
                    }
                    c.Close();
                }
            }
            catch { }
            int rowCount = t.Rows.Count;
            //string[] allIPs = new string[rowCount];
            int i = 0;
            fnGetEmpRefCard();
            Application.DoEvents();
            if (EmpRefCard != "")
            {
                /////////////////////////////////////////////////////////////////////////
                //                    FOR EACH IP                                      //
                /////////////////////////////////////////////////////////////////////////
                txtFileName = "";
                foreach (DataRow dr in t.Rows)
                {
                    txtFileName = "";
                    Application.DoEvents();
                    dev_no = Convert.ToInt32(dr[0]);
                    dev_ip = dr[1].ToString();
                    dev_port = Convert.ToInt32(dr[2]);
                    lbRunStatus.Text += "\nConnecting to Mechine[" + dev_no + "] with Ip : " + dev_ip + " and Port : " + dev_port;

                    fnLabelNewline();
                    Application.DoEvents();
                    ////////////////////////////////////
                    //        new code                //
                    ////////////////////////////////////
                    lbRunStatus.Text += "\nReading Mechine[" + dev_no + "] records";
                    fnLabelNewline();
                    fnGetRecords(dev_ip, dev_port, dev_no);
                    string line = "";
                    string query = "";
                    //txtFileName = "./log.txt";
                    if (txtFileName != "")
                    {
                        FileInfo fi = new FileInfo(txtFileName);
                        if (fi.Exists)
                        {
                            StreamReader file = new StreamReader(txtFileName);
                            while ((line = file.ReadLine()) != null)
                            {
                                lbRead.Text = "Read  records : " + read;
                                if (line != "")
                                {
                                    string[] readLine = line.Split(' ');
                                    string emp_id = readLine[1];
                                    string LogDate = readLine[2];
                                    string LogTime = readLine[3];

                                    SqlCeConnection sqlConnection1 = new SqlCeConnection();
                                    sqlConnection1.ConnectionString = dataSourcePath;
                                    SqlCeCommand cmd = new SqlCeCommand();
                                    cmd.CommandType = System.Data.CommandType.Text;
                                    cmd.Connection = sqlConnection1;
                                    sqlConnection1.Open();
                                    SqlCeDataReader SQLRD;
                                    cmd.CommandText = "SELECT * FROM DeviceURL WHERE DEV_IP='" + dev_ip + "'";
                                    SQLRD = cmd.ExecuteReader();
                                    int v = 0;
                                    string URLPath = "";
                                    int urlId = 0;
                                    while (SQLRD.Read())
                                    {
                                        Application.DoEvents();
                                        URLPath = SQLRD[1].ToString();
                                        urlId = Convert.ToInt32(SQLRD[2]);
                                        cmd.CommandText = "SELECT COUNT(*) FROM DEVICE_RECORDS WHERE DEV_IP='" + dev_ip + "' AND DEV_URL='" + URLPath + "' AND EMP_ID='" + emp_id + "' AND LOGDATE='" + LogDate + "' AND LOGTIME='" + LogTime + "' AND DEV_ID=" + dev_no;
                                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                                        if (count == 0)
                                        {
                                            cmd.CommandText = "INSERT INTO DEVICE_RECORDS (DEV_IP, DEV_URL, EMP_ID, LOGDATE, LOGTIME, DEV_ID, INSERTYN) VALUES('" + dev_ip + "','" + URLPath + "','" + emp_id + "','" + LogDate + "','" + LogTime + "'," + dev_no + ",0)";
                                            cmd.ExecuteNonQuery();
                                        }
                                        /////////////////////////////////////////////////////////////////////////////////////////////////////
                                        ////////////////////////////////     Insertion Code    //////////////////////////////////////////////
                                        /////////////////////////////////////////////////////////////////////////////////////////////////////

                                        #region
                                        /*
                                        if (fnGetDBValues(URLPath))
                                        {
                                            Application.DoEvents();
                                            string strConn = "server=" + strHost + ";database=" + strDB + ";uid=" + strUsr + ";pwd=" + strPWD;
                                            //string strConn = "server=176.9.19.244;database=" + strDB + ";uid=" + strUsr + ";pwd=" + strPWD;

                                            MySqlConnection myConn = new MySqlConnection(strConn);
                                            MySqlCommand myCommand = myConn.CreateCommand();
                                            myConn.Open();
                                            bool exists = false;
                                            //check for existence, if exists get emp_id and save record
                                            myCommand.CommandText = query;
                                            MySqlDataReader SQLRD1;
                                            SQLRD1 = myCommand.ExecuteReader();
                                            int co = 0;
                                            while (SQLRD1.Read())
                                            {
                                                emp_id = SQLRD1["EMPID"].ToString();
                                                exists = true;
                                            }
                                            SQLRD1.Close();

                                            if (exists == true)
                                            {
                                                Application.DoEvents();
                                                bool val = false;
                                                try
                                                {
                                                    myCommand.CommandText = "SELECT * FROM `kal_logdetails` WHERE EMPID='" + emp_id + "' AND LOGDATE='" + LogDate + "' AND LOGTIME='" + LogTime + "'";
                                                    MySqlDataReader SQLRD2;
                                                    SQLRD2 = myCommand.ExecuteReader();
                                                    int va = 0;
                                                    while (SQLRD2.Read())
                                                    {
                                                        va++;
                                                    }
                                                    if (va == 0)
                                                    {
                                                        val = true;
                                                    }
                                                    SQLRD2.Dispose();
                                                    SQLRD2.Close();
                                                    Application.DoEvents();
                                                }
                                                catch { }
                                                if (val)
                                                {
                                                    Application.DoEvents();
                                                    try
                                                    {
                                                        myCommand.CommandText = "insert into `kal_logdetails` (EMPID, LOGDATE, LOGTIME, DEVICE_ID) values('" +
                                                                    emp_id + "', '" +
                                                                    LogDate + "', '" +
                                                                    LogTime + "', " +
                                                                    dev_no + ")";
                                                        myCommand.ExecuteNonQuery();
                                                        inserte++;
                                                        lbinserted.Text = "Inseted records : " + inserte;
                                                        lbRunStatus.Update();
                                                        Application.DoEvents();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                    }
                                                }
                                            }
                                        }
                                        */
                                        #endregion

                                        /////////////////////////////////////////////////////////////////////////////////////////////////////
                                    }
                                    Application.DoEvents();
                                    SQLRD.Close();
                                    sqlConnection1.Dispose();
                                    sqlConnection1.Close();
                                    read++;
                                }
                            }
                        }
                    }
                    else
                    {
                        lbRunStatus.Text += "\nNot found any new records";
                        fnLabelNewline();
                    }

                    ////////////////////////////////////
                    //        new code ends           //
                    ////////////////////////////////////

                    #region //old_code
                    /*
                    if (axCZKEM1.Connect_Net(dev_ip,dev_port))
                    {
                        axCZKEM1.RefreshData(dev_no);
                        Application.DoEvents();
                        notifyIcon1.ShowBalloonTip(10, "Relyon BM Device Reader", "Connected and reading Mechine [" + dev_no + "] attendance records", ToolTipIcon.Info);
                        lbRunStatus.Text += "\nConnected to Mechine[" + dev_no + "]";
                        lbRunStatus.Text += "\nLoading Mechine[" + dev_no + "] attendance records";
                        fnLabelNewline();
                        Application.DoEvents();
                        if (axCZKEM1.ReadGeneralLogData(dev_no))
                        {
                            lbRunStatus.Text += "\nReading and Saving Mechine[" + dev_no + "] attendance records";
                            Application.DoEvents();
                            fnLabelNewline();
                            int dwEnrollNumber = 0;
                            int dwVerifyMode = 0;
                            int dwInOutMode = 0;
                            string timeStr = "";

                            string query = "";
                            int inserte = 0;
                            int read = 0;
                            Application.DoEvents();
                            while (axCZKEM1.GetGeneralLogDataStr(dev_no, ref dwEnrollNumber, ref dwVerifyMode, ref dwInOutMode, ref timeStr))
                            {
                                Application.DoEvents();
                                lbRead.Text = "Read  records : " + read;
                                lbRunStatus.Update();
                                string emp_id = dwEnrollNumber.ToString();
                                string LogDate = timeStr.Substring(0, 10);
                                string LogTime = timeStr.Substring(11, 8);

                                if (EmpRefCard == "ref")
                                {
                                    query = "SELECT EMPID FROM mas_employee WHERE REFNO= '" + emp_id + "'";
                                }
                                else if (EmpRefCard == "card")
                                {
                                    query = "SELECT EMPID FROM mas_users WHERE CARDID= '" + emp_id + "'";
                                }
                                else if (EmpRefCard == "emp")
                                {
                                    query = "SELECT EMPID FROM mas_users WHERE EMPID= '" + emp_id + "'";
                                }

                                /////////////////////////////////////////////////////////////////////////
                                //                    FOR EACH URL OF THIS IP                          //
                                /////////////////////////////////////////////////////////////////////////
                                Application.DoEvents();

                                SqlCeConnection sqlConnection1 = new SqlCeConnection();
                                sqlConnection1.ConnectionString = dataSourcePath;
                                SqlCeCommand cmd = new SqlCeCommand();
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Connection = sqlConnection1;
                                sqlConnection1.Open();
                                SqlCeDataReader SQLRD;
                                cmd.CommandText = "SELECT * FROM DeviceURL WHERE DEV_IP='" + dev_ip + "'";
                                SQLRD = cmd.ExecuteReader();
                                int v = 0;
                                string URLPath = "";
                                while (SQLRD.Read())
                                {
                                    Application.DoEvents();
                                    URLPath = SQLRD[1].ToString();
                                    if (fnGetDBValues(URLPath))
                                    {
                                        Application.DoEvents();
                                        string strConn = "server=" + strHost + ";database=" + strDB + ";uid=" + strUsr + ";pwd=" + strPWD;
                                        MySqlConnection myConn = new MySqlConnection(strConn);
                                        MySqlCommand myCommand = myConn.CreateCommand();
                                        myConn.Open();
                                        bool exists = false;
                                        //check for existence, if exists get emp_id and save record
                                        myCommand.CommandText = query;
                                        MySqlDataReader SQLRD1;
                                        SQLRD1 = myCommand.ExecuteReader();
                                        int co = 0;
                                        while (SQLRD1.Read())
                                        {
                                            emp_id = SQLRD1["EMPID"].ToString();
                                            exists = true;
                                        }
                                        SQLRD1.Close();

                                        if (exists == true)
                                        {
                                            Application.DoEvents();
                                            bool val = false;
                                            Application.DoEvents();
                                            try
                                            {
                                                myCommand.CommandText = "SELECT * FROM `kal_logdetails` WHERE EMPID='" + emp_id + "' AND LOGDATE='" + LogDate + "' AND LOGTIME='" + LogTime + "' AND DEVICE_ID=" + dev_no;
                                                MySqlDataReader SQLRD2;
                                                SQLRD2 = myCommand.ExecuteReader();
                                                int va = 0;
                                                while (SQLRD2.Read())
                                                {
                                                    va++;
                                                }
                                                if (va == 0)
                                                {
                                                    val = true;
                                                }
                                                SQLRD2.Dispose();
                                                SQLRD2.Close();
                                                Application.DoEvents();
                                            }
                                            catch { }
                                            if (val)
                                            {
                                                Application.DoEvents();
                                                try
                                                {
                                                    myCommand.CommandText = "insert into `kal_logdetails` (EMPID, LOGDATE, LOGTIME, DEVICE_ID) values('" +
                                                                emp_id + "', '" +
                                                                LogDate + "', '" +
                                                                LogTime + "', " +
                                                                dev_no + ")";
                                                    myCommand.ExecuteNonQuery();
                                                    inserte++;
                                                    lbinserted.Text = "Inseted records : " + inserte;
                                                    lbRunStatus.Update();
                                                    Application.DoEvents();
                                                }
                                                catch (Exception ex)
                                                {
                                                }
                                            }
                                        }
                                    }
                                }
                                Application.DoEvents();
                                SQLRD.Close();
                                sqlConnection1.Dispose();
                                sqlConnection1.Close();
                                read++;
                                Application.DoEvents();
                            }
                            lbRunStatus.Text += "\nRead " + read.ToString() + " records from Mechine[" + dev_no + "]";
                            lbRunStatus.Text += "\nInserted " + inserte.ToString() + " records of Mechine[" + dev_no + "]";
                            fnLabelNewline();
                        }
                        else
                        {
                            lbRunStatus.Text += "\nMechine[" + dev_no + "] has no records";
                            fnLabelNewline();
                        }
                        Application.DoEvents();
                        //axCZKEM1.ClearGLog(dev_no);
                        axCZKEM1.Disconnect();
                        Application.DoEvents();
                    }
                    else
                    {
                        lbRunStatus.Text += "\nMechine[" + dev_no + "] not connected";
                        fnLabelNewline();
                    }
                     */
                    #endregion
                }
                Application.DoEvents();
                //if (txtFileName != "")
                //{
                    lbRunStatus.Text += "\nStarted saving records";
                    fnLabelNewline();
                    fnInsertIntoDbs();
                //}
            }
            Application.DoEvents();
        }

        private void fnInsertIntoDbs()
        {
            dataSourcePath = "Data Source = " + Application.StartupPath + @"\DeviceData.sdf";
            DataTable t = new DataTable();
            try
            {
                using (SqlCeConnection c = new SqlCeConnection(dataSourcePath))
                {
                    c.Open();
                    using (SqlCeDataAdapter a = new SqlCeDataAdapter("SELECT * FROM DeviceURL", c))
                    {
                        a.Fill(t);
                    }
                    c.Close();
                }
            }
            catch { }
            int rowCount = t.Rows.Count;
            string urlP = "";

            SqlCeConnection sqlConnection1 = new SqlCeConnection();
            sqlConnection1.ConnectionString = dataSourcePath;
            SqlCeCommand cmd = new SqlCeCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            foreach (DataRow dr in t.Rows)
            {
                urlP = dr[1].ToString();
                lbRunStatus.Text += "\nSaving records in '" + urlP+"'";
                fnLabelNewline();
                //MessageBox.Show("Brfore Connecting");
                fnGetDBValues(urlP);
                //MessageBox.Show("After Connecting");
                string strConn = "server=" + strHost + ";database=" + strDB + ";uid=" + strUsr + ";pwd=" + strPWD;
                //MessageBox.Show(strConn);
                MySqlConnection myConn = new MySqlConnection(strConn);
                MySqlCommand myCommand = myConn.CreateCommand();
                try
                {
                    //MessageBox.Show("Brfore Connecting");
                    myConn.Open();
                    //MessageBox.Show("After Connecting");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                    return;
                }
                bool exists = false;
                Application.DoEvents();
                SqlCeDataReader SQLRD;
                cmd.CommandText = "SELECT * FROM DEVICE_RECORDS WHERE INSERTYN=0 AND DEV_URL='" + urlP + "'";
                    //MessageBox.Show("SELECT * FROM DEVICE_RECORDS WHERE INSERTYN=0 AND DEV_URL='" + urlP + "'");
                SQLRD = cmd.ExecuteReader();
                while (SQLRD.Read())
                {
                    //MessageBox.Show(SQLRD[3].ToString());
                    string query = "";
                    if (EmpRefCard == "ref")
                    {
                        query = "SELECT EMPID FROM mas_employee WHERE REFNO= '" + SQLRD[3].ToString() + "'";
                    }
                    else if (EmpRefCard == "card")
                    {
                        query = "SELECT EMPID FROM mas_users WHERE CARDID= '" + SQLRD[3].ToString() + "'";
                    }
                    else if (EmpRefCard == "emp")
                    {
                        query = "SELECT EMPID FROM mas_users WHERE EMPID= '" + SQLRD[3].ToString() + "'";
                    }
                    myCommand.CommandText = query;
                    MySqlDataReader SQLRD1;
                    SQLRD1 = myCommand.ExecuteReader();
                    string emp_id = "";
                    exists = false;
                    while (SQLRD1.Read())
                    {
                        emp_id = SQLRD1["EMPID"].ToString();
                        exists = true;
                    }
                    SQLRD1.Close();

                    if (exists == true)
                    {
                        Application.DoEvents();
                        bool val = false;
                        try
                        {
                            myCommand.CommandText = "SELECT COUNT(*) FROM `kal_logdetails` WHERE EMPID='" + emp_id + "' AND LOGDATE='" + SQLRD[4].ToString() + "' AND LOGTIME='" + SQLRD[5].ToString() + "'";
                            int con = Convert.ToInt32(myCommand.ExecuteScalar());
                            if (con == 0)
                            {
                                val = true;
                            }
                            Application.DoEvents();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        if (val)
                        {
                            Application.DoEvents();
                            try
                            {
                                myCommand.CommandText = "insert into `kal_logdetails` (EMPID, LOGDATE, LOGTIME, DEVICE_ID) values('" +
                                            emp_id + "', '" +
                                            SQLRD[4].ToString() + "', '" +
                                            SQLRD[5].ToString() + "', " +
                                            Convert.ToInt32(SQLRD[6]) + ")";
                                myCommand.ExecuteNonQuery();
                                lbRunStatus.Update();
                                Application.DoEvents();
                                cmd.CommandText = "UPDATE DEVICE_RECORDS SET INSERTYN=1 WHERE DEV_URL='" + urlP + "' AND EMP_ID='" + SQLRD[3].ToString() + "' AND LOGDATE='" + SQLRD[4].ToString() + "' AND LOGTIME='" + SQLRD[3].ToString() + "' AND DEV_ID=" + Convert.ToInt32(SQLRD[6]);
                                cmd.ExecuteNonQuery();
                                inserte++;
                                lbinserted.Text = "Inseted records : " + inserte;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return;
                            }
                        }
                        else
                        {
                            try
                            {
                                cmd.CommandText = "UPDATE DEVICE_RECORDS SET INSERTYN=1 WHERE DEV_URL='" + urlP + "' AND EMP_ID='" + SQLRD[3].ToString() + "' AND LOGDATE='" + SQLRD[4].ToString() + "' AND LOGTIME='" + SQLRD[5].ToString() + "' AND DEV_ID=" + Convert.ToInt32(SQLRD[6]);
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return;
                            }
                        }
                    }
                }
                SQLRD.Close();
                lbRunStatus.Text += "\nSaved Successfully";
                fnLabelNewline();
            }

            cmd.CommandText = "DELETE FROM DEVICE_RECORDS WHERE INSERTYN=1";
            cmd.ExecuteNonQuery();

            //MessageBox.Show("End of function");

            sqlConnection1.Dispose();
            sqlConnection1.Close();
        }

        private void fnGetRecords(string DeviceIp,int port,int no)
        {
            txtFileName = "";
            lbError.ForeColor = Color.Red;
            string data = "";
            Application.DoEvents();
                Application.DoEvents();
                if (axCZKEM1.Connect_Net(DeviceIp, port))
                {
                    Application.DoEvents();
                    if (axCZKEM1.Connect_Net(DeviceIp, port))
                    {
                        Application.DoEvents();
                        int dwEnrollNumber = 0;
                        int dwVerifyMode = 0;
                        int dwInOutMode = 0;
                        string timeStr = "";
                        while (axCZKEM1.GetGeneralLogDataStr(no, ref dwEnrollNumber, ref dwVerifyMode, ref dwInOutMode, ref timeStr))
                        {
                            Application.DoEvents();
                            string emp_id = dwEnrollNumber.ToString();
                            string LogDate = timeStr.Substring(0, 10);
                            string LogTime = timeStr.Substring(11, 8);
                            data += no + " " + emp_id + " " + LogDate + " " + LogTime + "\r\n";
                            //run++;
                            Application.DoEvents();
                        }
                        //string activeFol = Application.UserAppDataPath.ToString()+"\\" + DeviceIp;
                        //string activeFol = Application.LocalUserAppDataPath+".\\Logs\\" + DeviceIp;
                        string activeFol = Application.StartupPath + "\\Logs\\" + DeviceIp;
                        try
                        {
                            // Create the subfolder
                            System.IO.Directory.CreateDirectory(activeFol);
                        }
                        catch { }
                        //string filename = "./Logs/" + DeviceIp + "/" + DeviceIp + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".txt";
                        //string filename = Application.StartupPath + "/Logs/" + DeviceIp + "/" + DeviceIp + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".txt";
                        string filename = Application.StartupPath + "\\Logs\\"+DeviceIp+"\\"+DeviceIp+"_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".txt";
                        txtFileName = filename;
                        FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine(data);
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                    }
                    axCZKEM1.ClearGLog(no);
                    axCZKEM1.Disconnect();
                }
        }
    
        public bool fnGetDBValues(string webPath)
        {
            bool validURL = false;
            try
            {
                string strURL = webPath + "auto_db_read_kanaily.php";
                byte[] buffer = Encoding.ASCII.GetBytes("SECODE=ranjeetkumarkanaily&DBSETTINGS=autosynchronization");
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(strURL);
                WebReq.Timeout = 108000000;
                WebReq.Method = "POST";
                WebReq.ContentType = "application/x-www-form-urlencoded";
                WebReq.ContentLength = buffer.Length;
                Stream PostData = WebReq.GetRequestStream();
                PostData.Write(buffer, 0, buffer.Length);
                PostData.Close();
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
                Stream Answer = WebResp.GetResponseStream();
                StreamReader _Answer = new StreamReader(Answer);
                string msg = _Answer.ReadToEnd().ToString();
                _Answer.Dispose();
                msg = msg.Trim();
                //CreateLog.fnCreateLog("Return MSG from autoLeaveApproveRejectedfunction--> " + msg);
                string[] arrDB = msg.Split(new char[] { ',' });
                //if (CNull(arrDB[1]) == "")
                //{
                //    strHost = CNull(arrDB[0]);
                //}
                //else
                //{
                    strHost = CNull(arrDB[1]);
                //}
                strUsr = CNull(arrDB[2]);
                strPWD = CNull(arrDB[3]);
                strDB = CNull(arrDB[4]);
                WebReq.Abort();
                PostData.Dispose();
                Answer.Dispose();
                validURL = true;
            }
            catch (WebException web)
            {
                validURL = false;
                MessageBox.Show("Invalid URL" + web.Message);
            }
            catch (UriFormatException uriex)
            {
                MessageBox.Show("Invalid URL" + uriex.Message);
                validURL = false;
            }
            catch (Exception ex)
            {
                validURL = false;
                MessageBox.Show("Invalid URL" + ex.Message);
            }
            return validURL;
        }

        private string CNull(string strValue)
        {
            try
            {
                if (string.IsNullOrEmpty(strValue))
                    return "";
                else
                    return strValue;
            }
            catch
            {
                return "";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            //fnGetEmpRefCard();
            //fnInsertIntoDbs();
            lbTimer.Text = "Timer Stopped";
            pnlSettings.Enabled = false;
            pnlButtons.Enabled = false;
            button2.Enabled = false;
            Application.DoEvents();
            notifyIcon1.ShowBalloonTip(10, "Relyon BM Device Reader", "Started reading device records", ToolTipIcon.Info);
            fnReadData1();
            notifyIcon1.ShowBalloonTip(10, "Relyon BM Device Reader", "Read and saved Successfully", ToolTipIcon.Info);
            Application.DoEvents();
            TimeToWait = timer - 1;
            now = DateTime.Now;
            pnlSettings.Enabled = true;
            pnlButtons.Enabled = true;
            button2.Enabled = true;
            timer1.Start();
        }

        //not used
        private void btnTest_Click(object sender, EventArgs e)
        {
            //timer1.Stop();
            //if (axCZKEM1.Connect_Net("192.168.3.101", 4370))
            //    MessageBox.Show("Mechine Connected");
            //else
            //    MessageBox.Show("Mechine not Connected");
        }

        private void frmBMDeviceMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeVal != true)
            {
                if (FormWindowState.Normal == this.WindowState || FormWindowState.Minimized == this.WindowState)
                {
                    e.Cancel = true;
                    this.WindowState = FormWindowState.Minimized;
                    this.Hide();
                    notifyIcon1.ShowBalloonTip(10, "Relyon BM Device Reader", "Your application has been minimized to the taskbar.", ToolTipIcon.Info);
                }
            }
            else
            {
                notifyIcon1.Dispose();
            }
        }

        private void frmBMDeviceMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(10, "Relyon BM Device Reader", "Your application has been minimized to the taskbar.", ToolTipIcon.Info);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeVal = true;
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.ShowDialog();
        }

        //not used
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            frmStoreRecords frm = new frmStoreRecords();
            frm.ShowDialog();
            fnCheckVal();
        }
    }
}
