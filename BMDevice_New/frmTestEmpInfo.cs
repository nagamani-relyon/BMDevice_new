using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMDevice_New
{
    public partial class frmTestEmpInfo : Form
    {
        public frmTestEmpInfo()
        {
            InitializeComponent();
        }

        private void btnGetEmpInfo_Click(object sender, EventArgs e)
        {
            if (axCZKEM1.Connect_Net("192.168.3.101", 4370))
            {
                if (axCZKEM1.Connect_Net("192.168.3.101", 4370))
                {
                    int dwEnrollNumber = 0;
                    string name = ""; ;
                    string password = "";
                    int privilege = 0;
                    bool enabled = false;
                    string data = "";
                    int i = 1;
                    //while (axCZKEM1.GetAllUserInfo(1, ref dwEnrollNumber, ref name, ref password, ref privilege, ref enabled))
                    //{
                    //    data += i.ToString() + "        " + dwEnrollNumber.ToString() + "        " + name + "          " + password + "          " + privilege.ToString() + "         " + enabled.ToString() + "\r\n";
                    //    i++;
                    //}
                    //lbuserInfo.Text = data;


                    while (axCZKEM1.GetAllUserInfo(1, ref dwEnrollNumber, ref name, ref password, ref privilege, ref enabled))
                    {
                        data += i.ToString() + "        " + dwEnrollNumber.ToString() + "        " + name + "          " + password + "          " + privilege.ToString() + "         " + enabled.ToString() + "\r\n";
                        cmbUserId.Items.Add(dwEnrollNumber.ToString());
                        i++;
                    }
                    lbuserInfo.Text = data;

                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (axCZKEM1.Connect_Net("192.168.3.101", 4370))
            {
                if (axCZKEM1.Connect_Net("192.168.3.101", 4370))
                {
                    if (axCZKEM1.SetUserInfo(1, Convert.ToInt32(txtEmpid.Text), txtName.Text, txtPass.Text, 0, true))
                    {
                        lbInsert.Text = "Employee Registered";
                    }
                }
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            //DeleteUserInfoEx(
             if (axCZKEM1.Connect_Net("192.168.3.101", 4370))
            {
                if (axCZKEM1.Connect_Net("192.168.3.101", 4370))
                {
                    //int empid = Convert.ToInt32(cmbUserId.SelectedItem.ToString());

                    //if (axCZKEM1.SaveTheDataToFile(1,@"F:\Nagamani\file.txt",1))
                    //    lbDeleted.Text = "File saved";
                    //if (axCZKEM1.RefreshData(1))
                    //{
                    //}
                    //if (axCZKEM1.DeleteUserInfoEx(1, empid))
                    //{
                    //    if (axCZKEM1.RefreshData(1))
                    //        lbDeleted.Text = "Employee Info Deleted";
                    //}

                    //zkemkeeper.CZKEMClass CZKEM1 = new zkemkeeper.CZKEMClass();
                    //if (CZKEM1.Connect_Net("192.168.3.101", 4370))
                    //{
                    ////    CZKEM1.DelUserTmp(1, empid, 1);
                    ////    if (CZKEM1.DeleteEnrollData(1, empid, 1, 0))//.DelUserTmp(1, empid, 1)
                    ////    {
                    ////    }
                    //    if(CZKEM1.SaveTheDataToFile(1,@"F:\Nagamani\file.txt",1))
                    //        lbDeleted.Text = "File saved";
                    //}

                    //zkemkeeper.CZKEM CZKEM2 = new zkemkeeper.CZKEM();
                    //if (CZKEM2.Connect_Net("192.168.3.101", 4370))
                    //{
                    //    if (CZKEM2.DelUserTmp(1, empid, 0))
                    //        lbDeleted.Text = "User Info deleted";
                    //}
                }
             }
        }
    }
}
