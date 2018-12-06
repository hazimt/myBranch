using System;
using System.Windows.Forms;

namespace StatisticsLibraryTest
{
    public partial class MainForm : Form
    {
        AnalysisForm af;
        DistributionForm df;
        FDistributionParamForm fdpf;
        FunctionForm ff;
        XYScatterForm xysf;

        public MainForm()
        {
            InitializeComponent();
        }

        private void TestXYScatter()
        {
            int n = 50;
            double x0 = 0.0;
            double x1 = 1.0;
            double deltaX = (x1 - x0) / (n - 1);
            double[] x = new double[n];
            double[,] y = new double[2, n];

            for (int i = 0; i < n; i++)
            {
                x[i] = x0 + i * deltaX;
                y[0, i] = x[i];
                y[1, i] = x[i] * x[i];
            }

            xysf = new XYScatterForm("Testing", "x", "y", x, y);
            xysf.Show();
        }

        private void analysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] seq = { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1,
                1, 1, 2, 3, 3, 3, 3, 5, 6, 5, 7, 6, 9, 8, 8, 10, 12, 12,
                12, 13, 16, 19, 17, 19, 20, 30, 39, 55, 69, 96, 104, 131,
                166, 189, 223, 331, 302, 555, 832, 1263, 1762, 2407 };
            double[] par = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1,
                1, 1, 1, 2, 3, 3, 3, 5, 5, 5, 6, 6, 7, 7, 8, 11, 12, 12,
                12, 13, 15, 16, 17, 18, 20, 28, 38, 51, 69, 84, 106, 130,
                157, 189, 224, 263, 307, 534, 837, 1252, 1779, 2444 };
            double[] x = new double[seq.Length];
            int k = 0;

            for (int i = 5; i <= 200; i += 5)
                x[k++] = i;

            for (int i = 225; i <= 500; i += 25)
                x[k++] = i;

            for (int i = 600; i <= 1000; i += 100)
                x[k++] = i;

            af = new AnalysisForm(seq, par);
            af.Show();

            double[,] y = new double[2, seq.Length];

            for (int i = 0; i < seq.Length; i++)
            {
                y[0, i] = seq[i];
                y[1, i] = par[i];
            }

            xysf = new XYScatterForm("Seq and Par Gaussian Elimination", "n", "t (Sec)", x, y);
            xysf.Show();
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            df = new DistributionForm(0, "Binomial Distribution", 0, 0, 0, 0);
            df.Show();
        }

        private void chiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            df = new DistributionForm(1, "ChiSquare Distribution", 0, 0, 0, 0);
            df.Show();
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fdpf = new FDistributionParamForm();

            if (fdpf.ShowDialog() == DialogResult.OK)
            {
                double Q0 = fdpf.Q0;
                int iPoints = fdpf.IPoints;
                int nu1Max = fdpf.Nu1Max, nu2Max = fdpf.Nu2Max;

                df = new DistributionForm(2, "F-Distribution",
                    Q0, nu1Max, nu2Max, iPoints);
                df.Show();
            }
        }

        private void hypergeometricToolStripMenuItem_Click(object sender, EventArgs e)
        {
            df = new DistributionForm(3, "Hypergeometric Distribution", 0, 0, 0, 0);
            df.Show();
        }

        private void negativeBinomialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            df = new DistributionForm(4, "Negative Binomial Distribution", 0, 0, 0, 0);
            df.Show();
        }

        private void normalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            df = new DistributionForm(5, "Normal Distribution", 0, 0, 0, 0);
            df.Show();
        }

        private void poissonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            df = new DistributionForm(6, "Poisson Distribution", 0, 0, 0, 0);
            df.Show();
        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            df = new DistributionForm(7, "Student's t-Distribution", 0, 0, 0, 0);
            df.Show();
        }

        private void AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ff = new FunctionForm(0, "A(t|nu)");
            ff.Show();
        }

        private void binomialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ff = new FunctionForm(1, "B(m, n)");
            ff.Show();
        }

        private void ErrortoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ff = new FunctionForm(2, "erf(x) and erfc(x)");
            ff.Show();
        }

        private void factorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ff = new FunctionForm(3, "n!");
            ff.Show();
        }

        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ff = new FunctionForm(4, "Gamma(x)");
            ff.Show();
        }

        private void incompleteBetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ff = new FunctionForm(5, "Incompelete Beta Function");
            ff.Show();
        }

        private void xYScatterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestXYScatter();
        }

        private void incompleteGammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ff = new FunctionForm(6, "Incompelete Gamma Function");
            ff.Show();
        }
    }
}