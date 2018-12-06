using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StatisticsLibrary;

namespace StatisticsLibraryTest
{
    public partial class XYScatterForm : Form
    {
        private XYScatter xys;

        public XYScatterForm(string title, string xAxisTitle, string yAxisTitle,
            double[] x, double[,] y)
        {
            InitializeComponent();
            panel1.Width = ClientSize.Width;
            panel1.Height = ClientSize.Height;
            xys = new XYScatter(false, x, y, title, xAxisTitle, yAxisTitle, panel1);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            panel1.Width = ClientSize.Width;
            panel1.Height = ClientSize.Height;
            panel1.Invalidate();
        }
    }
}
