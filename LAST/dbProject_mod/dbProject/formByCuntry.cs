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
    public partial class formByCuntry : Form
    {
        reportCuntries r;
        public formByCuntry()
        {
            InitializeComponent();
            r = new reportCuntries();
        }

        private void formByCuntry_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = r;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
