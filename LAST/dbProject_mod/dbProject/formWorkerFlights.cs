using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace dbProject
{
    public partial class formWorkerFlights : Form
    {
        reportWorkerFlights r;
        public formWorkerFlights()
        {
            InitializeComponent();
            r = new reportWorkerFlights();
        }

        private void formWorkerFlights_Load(object sender, EventArgs e)
        {
            foreach (ParameterDiscreteValue val in r.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(val.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            r.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = r;
        }
    }
}
