using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbProject
{
    public partial class formSalaries : Form
    {
        reportSalaries r;
        public formSalaries()
        {
            InitializeComponent();
            r = new reportSalaries();
        }

        private void formSalaries_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = r;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
