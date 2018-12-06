using System;
using System.Windows.Forms;

namespace StatisticsLibraryTest
{
    public partial class FDistributionParamForm : Form
    {
        private double q0 = 0.0;
        private int iPoints, nu1Max = 0, nu2Max = 0;

        public double Q0
        {
            get
            {
                return q0;
            }
        }

        public int Nu1Max
        {
            get
            {
                return nu1Max;
            }
        }

        public int Nu2Max
        {
            get
            {
                return nu2Max;
            }
        }

        public int IPoints
        {
            get
            {
                return iPoints;
            }
        }

        public FDistributionParamForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            q0 = double.Parse((string)comboBox1.SelectedItem);
            nu1Max = int.Parse((string)comboBox2.SelectedItem);
            nu2Max = int.Parse((string)comboBox3.SelectedItem);
            iPoints = (int)numericUpDown1.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}