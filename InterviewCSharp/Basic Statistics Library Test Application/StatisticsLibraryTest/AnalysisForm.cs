using System.Windows.Forms;
using StatisticsLibrary;

namespace StatisticsLibraryTest
{
    public partial class AnalysisForm : Form
    {
        Analysis anal = new Analysis();

        public AnalysisForm(double[] x, double[] y)
        {
            InitializeComponent();
            string text = anal.DataAnalysis(x, y);
            textBox1.Text += text;
        }
    }
}