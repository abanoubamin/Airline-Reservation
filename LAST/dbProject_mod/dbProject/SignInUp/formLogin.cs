using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace dbProject
{
    public partial class formLogin : Form
    {
        string conStr = "data source=orcl; user id=hr; password=hr;";
        OracleConnection con;
        public formLogin()
        {
            InitializeComponent();
            con = new OracleConnection(conStr);
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void formLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

       

        private void formLogin_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)    ////SIGN IN BUTTON////
        {

            if (txtboxName.Text == "" || txtboxPassword.Text == "")
            {
                
                errorLabel.Show();
            }
            else
            {
                errorLabel.Hide();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "select SSN from ACCOUNT where F_NAME=:FN and PASSWORD=:P";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("FN", txtboxName.Text);
                cmd.Parameters.Add("P", txtboxPassword.Text);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    int SSN = Convert.ToInt32(dr["SSN"].ToString());
                    dr.Close();
                    cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select SSN from admin";
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader r = cmd.ExecuteReader();
                    int count = 0;
                    while (r.Read())
                    {
                        if (r[0].ToString() == SSN.ToString())
                            count++;
                    }
                    r.Close();
                    if (count == 0)
                    {
                        formUser f = new formUser(SSN);
                        f.Closed += (s, args) => this.Close();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        formAdmin f = new formAdmin();
                        f.Closed += (s, args) => this.Close();
                        f.Show();
                        this.Hide();
                    }

                }
                else
                {
                    errorLabel.Show();
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            }

        private void bunifuFlatButton4_Click(object sender, EventArgs e) ////SIGN UP BUTTON////
        {

            OracleCommand cmdAccount = new OracleCommand();
            OracleCommand cmdCustomer = new OracleCommand();
            cmdAccount.Connection = con;
            cmdCustomer.Connection = con;
            cmdAccount.CommandType = CommandType.Text;
            cmdCustomer.CommandType = CommandType.Text;
            cmdAccount.CommandText = "insert into ACCOUNT values(:ssn,:fname,:lname,:bdate,:nationality,:pass,:phone,:gender)";
            cmdCustomer.CommandText = "insert into CUSTOMER values(:ssn,:credit,:rdate,:passport)";
            cmdAccount.Parameters.Add("ssn", textBoxSSN.Text);
            cmdAccount.Parameters.Add("fname", textBoxFN.Text);
            cmdAccount.Parameters.Add("lname", textBoxLN.Text);
            cmdAccount.Parameters.Add("bdate", textBoxBD.Text);
            cmdAccount.Parameters.Add("nationality", textBoxNat.Text);
            cmdAccount.Parameters.Add("pass", textBoxPassword.Text);
            cmdAccount.Parameters.Add("phone", textBoxPhone.Text);
            cmdAccount.Parameters.Add("gender", textBoxGender.Text);
            cmdCustomer.Parameters.Add("ssn", textBoxSSN.Text);
            cmdCustomer.Parameters.Add("credit", textBoxCredit.Text);
            cmdCustomer.Parameters.Add("rdate", DateTime.Now);
            cmdCustomer.Parameters.Add("passport", textBoxPassport.Text);
            int retAcc = cmdAccount.ExecuteNonQuery();
            int retCus = cmdCustomer.ExecuteNonQuery();
            if (retAcc != -1 && retCus != -1)
            {
                AccountSignupSuccessLabel.Show();
                
            }
    }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            SignUpPanel.Hide();
            SignInPanel.Show();
            SignInselected.Show();
            SignUpselected.Hide();
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            SignUpPanel.Show();
            SignInPanel.Hide();
            SignInselected.Hide();
            SignUpselected.Show();
        }
    }
}
