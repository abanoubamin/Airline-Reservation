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
using Oracle.DataAccess.Types;

namespace dbProject
{
    public partial class formAdmin : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        OracleConnection conn;
        OracleCommand cmd;
        string con = "data source=orcl;user id=hr;password=hr;";

        public formAdmin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            (new formSalaries()).ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            (new formByCuntry()).ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            (new formWorkerFlights()).ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e) ////Airlines Button////
        {
            tabControl1.SelectedIndex = 0;

            string constr = "Data Source=orcl; User Id=hr; Password=hr;";
            DataSet ds = new DataSet();

            OracleDataAdapter adapter1 = new OracleDataAdapter("select * from airline", constr);
            adapter1.Fill(ds, "Airline");

            OracleDataAdapter adapter2 = new OracleDataAdapter("select * from flight", constr);
            adapter2.Fill(ds, "Flight");

            DataRelation r = new DataRelation("fk", ds.Tables[0].Columns["AIRLINEID"], ds.Tables[1].Columns["AIRLINEID"]);
            ds.Relations.Add(r);

            BindingSource bs_Master = new BindingSource(ds, "Airline");
            BindingSource bs_Child = new BindingSource(bs_Master, "fk");

            dataGridView1.DataSource = bs_Master;
            dataGridView2.DataSource = bs_Child;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)   ////Flights Button////
        {
            tabControl1.SelectedIndex = 1;
            string constr = "Data Source=orcl; User Id=hr; Password=hr;";

            string cmdstr = "select * from flight";

            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)   ////Cutomer Flights Button////
        {
            tabControl1.SelectedIndex = 2;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)  ////Workers Button////
        {
            tabControl1.SelectedIndex = 3;
            conn = new OracleConnection(con);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select SSN from account where SSN in (select SSN from worker)";
            cmd.CommandType = CommandType.Text;
            OracleDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                comboBox1.Items.Add(r[0]);
            }
            r.Close();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)  ////Reports Button////
        {
            tabControl1.SelectedIndex = 4;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("Saved !");
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("Saved !");
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=orcl; User Id=hr; Password=hr;";
            string cmdstr = "select * from reservation where CUSTOMER_ID = :id";

            OracleDataAdapter adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("id", textBox1.Text);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(con);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert_worker_account";
            cmd.CommandType = CommandType.StoredProcedure;
            string s = "";
            if (radioButton1.Checked)
                s = "male";
            else if (radioButton2.Checked)
                s = "female";
            cmd.Parameters.Add("ss", comboBox1.Text);
            cmd.Parameters.Add("name1", textBox2.Text);
            cmd.Parameters.Add("name2", textBox3.Text);
            cmd.Parameters.Add("birthdate", Convert.ToDateTime(textBox4.Text));
            cmd.Parameters.Add("nationality1", textBox5.Text);
            cmd.Parameters.Add("pass", textBox6.Text);
            cmd.Parameters.Add("phone_number", textBox7.Text);
            cmd.Parameters.Add("gender1", s);
            cmd.Parameters.Add("type1", textBox9.Text);
            cmd.Parameters.Add("salary1", textBox10.Text);
            cmd.Parameters.Add("s", Convert.ToDateTime(textBox11.Text));
            cmd.Parameters.Add("airplane1", textBox12.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Insert is done successfully");
            comboBox1.Items.Add(comboBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn = new OracleConnection(con);
            conn.Open();
            comboBox1.Items.Clear();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from account where SSN=:s";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("s", comboBox1.Text);
            OracleDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                textBox2.Text = r[1].ToString();
                textBox3.Text = r[2].ToString();
                textBox4.Text = r[3].ToString();
                textBox5.Text = r[4].ToString();
                textBox6.Text = r[5].ToString();
                textBox7.Text = r[6].ToString();
                if (r[7].ToString() == "Male")
                    radioButton1.Checked = true;
                else if (r[7].ToString() == "Female")
                    radioButton2.Checked = true;
            }
            r.Close();
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            ///////////////////////////////////////////////////////////////////////////////////////
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from worker where SSN=:s";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("s", comboBox1.Text);
            OracleDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                textBox9.Text = rd[1].ToString();
                textBox10.Text = rd[2].ToString();
                textBox11.Text = rd[3].ToString();
                textBox12.Text = rd[4].ToString();
            }
            rd.Close();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            conn = new OracleConnection(con);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update_worker_account";
            cmd.CommandType = CommandType.StoredProcedure;
            string s = "";
            if (radioButton1.Checked)
                s = "male";
            else if (radioButton2.Checked)
                s = "female";
            cmd.Parameters.Add("ss", comboBox1.Text);
            cmd.Parameters.Add("name1", textBox2.Text.ToString());
            cmd.Parameters.Add("name2", textBox3.Text);
            cmd.Parameters.Add("birthdate", Convert.ToDateTime(textBox4.Text));
            cmd.Parameters.Add("nationality1", textBox5.Text);
            cmd.Parameters.Add("pass", textBox6.Text);
            cmd.Parameters.Add("phone_number", textBox7.Text);
            cmd.Parameters.Add("gender1", s);
            cmd.Parameters.Add("type1", textBox9.Text);
            cmd.Parameters.Add("salary1", textBox10.Text);
            cmd.Parameters.Add("s", Convert.ToDateTime(textBox11.Text));
            cmd.Parameters.Add("airplane1", textBox12.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Update is done successfully");
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(con);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete_worker_account";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("ss", comboBox1.Text.ToString());
            cmd.ExecuteNonQuery();
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            MessageBox.Show("Delete is done successfully!");
        }
    }
}
