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
    public partial class formUser : Form
    {
        int SSN;
        string conStr = "data source=orcl; user id=hr; password=hr;";
        OracleConnection con;


        public formUser(int number)
        {
            InitializeComponent();
            SSN = number;
            con = new OracleConnection(conStr);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from ACCOUNT where SSN=:SSN";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("SSN", SSN);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Columns.Add("SSN");
            table.Columns.Add("F_NAME");
            table.Columns.Add("L_NAME");
            table.Columns.Add("B_DATE");
            table.Columns.Add("NATIONALITY");
            table.Columns.Add("PHONE");
            table.Columns.Add("GENDER");
            DataRow row;
            dr.Read();
            row = table.NewRow();
            row["SSN"] = dr["SSN"];
            row["F_NAME"] = dr["F_NAME"];
            row["L_NAME"] = dr["L_NAME"];
            row["B_DATE"] = dr["B_DATE"];
            row["NATIONALITY"] = dr["NATIONALITY"];
            row["PHONE"] = dr["PHONE"];
            row["GENDER"] = dr["GENDER"];
            table.Rows.Add(row);
            dataGridViewInfo.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void formUser_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            this.SSN = SSN;
            lblSSN.Text = SSN.ToString();
            con = new OracleConnection(conStr);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_customer_info";
            cmd.Parameters.Add("Needed_ssn", SSN);
            cmd.Parameters.Add("CreditNumber", OracleDbType.Int32, ParameterDirection.Output);
            cmd.Parameters.Add("passport_number", OracleDbType.Varchar2, 20, null, ParameterDirection.Output);
            cmd.Parameters.Add("Of_name", OracleDbType.Varchar2, 20, null, ParameterDirection.Output);
            cmd.Parameters.Add("Ol_name", OracleDbType.Varchar2, 20, null, ParameterDirection.Output);
            cmd.Parameters.Add("OBdate", OracleDbType.Date, 20, null, ParameterDirection.Output);
            cmd.Parameters.Add("Onationality", OracleDbType.Varchar2, 20, null, ParameterDirection.Output);
            cmd.Parameters.Add("Opass", OracleDbType.Varchar2, 20, null, ParameterDirection.Output);
            cmd.Parameters.Add("Ophone", OracleDbType.Varchar2, 20, null, ParameterDirection.Output);
            cmd.Parameters.Add("Ogender", OracleDbType.Varchar2, 20, null, ParameterDirection.Output);
            cmd.ExecuteNonQuery();

            textBoxCredit.Text = cmd.Parameters["CreditNumber"].Value.ToString();
            textBoxPassport.Text = cmd.Parameters["passport_number"].Value.ToString();
            textBoxFN.Text = cmd.Parameters["Of_name"].Value.ToString();
            textBoxLN.Text = cmd.Parameters["Ol_name"].Value.ToString();
            textBoxBD.Text = cmd.Parameters["OBdate"].Value.ToString();
            textBoxNat.Text = cmd.Parameters["Onationality"].Value.ToString();
            textBoxPassword.Text = cmd.Parameters["Opass"].Value.ToString();
            textBoxPhone.Text = cmd.Parameters["Ophone"].Value.ToString();
            textBoxGender.Text = cmd.Parameters["Ogender"].Value.ToString();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            con = new OracleConnection(conStr);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select AIRLINENAME from AIRLINE";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxAirlines.Items.Add(dr[0]);
            }
            comboBoxAirlines.SelectedIndex = 0;
            dr.Close();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update CUSTOMER set CREDIT_CARD_NUM=:credit,PASSPORT_NUM=:p_number where SSN=:ssn";
            cmd.Parameters.Add("credit", textBoxCredit.Text);
            cmd.Parameters.Add("p_number", textBoxPassport.Text);
            cmd.Parameters.Add("ssn", SSN);
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = con;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "update account set F_NAME = :fname ,L_NAME=:lname,B_DATE = :bdate ,NATIONALITY=:nat,PASSWORD=:password,PHONE=:phone,GENDER=:gender  where SSN=:ssn";
            cmd2.Parameters.Add("fname", textBoxFN.Text);
            cmd2.Parameters.Add("lname", textBoxLN.Text);
            cmd2.Parameters.Add("bdate", textBoxBD.Text);
            cmd2.Parameters.Add("nat", textBoxNat.Text);
            cmd2.Parameters.Add("password", textBoxPassword.Text);
            cmd2.Parameters.Add("phone", textBoxPhone.Text);
            cmd2.Parameters.Add("gender", textBoxGender.Text);
            cmd2.Parameters.Add("ssn", SSN);
            int ret = cmd.ExecuteNonQuery();
            int ret2 = cmd2.ExecuteNonQuery();
            if (ret != -1 && ret2 != -1)
            {
                MessageBox.Show("Account has been updated !");
               
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from customer where SSN=:SSN";
            cmd.Parameters.Add("SSN", SSN);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from account where SSN=:SSN";
            cmd.ExecuteNonQuery();
            int ret = cmd.ExecuteNonQuery();
            if (ret != -1)
            {
                MessageBox.Show("The Account has been Deleted !");
                formLogin f = new formLogin();
                f.Closed += (s, args) => this.Close();
                f.Show();
                this.Hide();
            }
        }

        private void comboBoxAirlines_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = false;
            dataGridView2.DataSource = false;
            con = new OracleConnection(conStr);
            con.Open();
            string id = "";
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "select AIRLINEID from airline where AIRLINENAME=:fd";
            cmd1.Parameters.Add("fd", comboBoxAirlines.Text);
            OracleDataReader rdr = cmd1.ExecuteReader();
            if (rdr.Read())
            {
                id = rdr[0].ToString();
            }
            rdr.Close();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select flight_ID,DEPARTURE_AIRPORT,ARRIVAL_AIRPORT,DEPARTURE_TIME,ARRIVAL_TIME from flight where AIRLINEID=:fd";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("fd", id);
            OracleDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                DataTable t = new DataTable();
                t.Load(r);
                dataGridView1.DataSource = t;
            }
            con.Close();
            r.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells[0].ColumnIndex == 0)
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "get_seat";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("id", dataGridView1.SelectedCells[0].Value.ToString());
                    cmd.Parameters.Add("seats", OracleDbType.RefCursor, ParameterDirection.Output);
                    con.Open();
                    OracleDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        DataTable d = new DataTable();
                        d.Load(rdr);
                        dataGridView2.DataSource = d;
                    }
                    rdr.Close();
                    con.Close();

                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
