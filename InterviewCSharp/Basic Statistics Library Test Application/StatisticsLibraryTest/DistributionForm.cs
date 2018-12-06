using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using StatisticsLibrary;

namespace StatisticsLibraryTest
{
    public partial class DistributionForm : Form
    {  
        private Distributions dis = new Distributions();
        private FDistribution fd = new FDistribution();
        private Functions f = new Functions(128);
        private ProbabilityFunctions pf = new ProbabilityFunctions();
        private Stopwatch sw = new Stopwatch();

        public DistributionForm(int number, string dstr,
            double Q0, int nu1Max, int nu2Max, int iPoints)
        {
            InitializeComponent();
            textBox1.Text += "Testing " + dstr + ":\r\n\r\n";
            Test(number, Q0, nu1Max, nu2Max, iPoints);
        }

        private void Test(
            int number, double Q0, int nu1Max, int nu2Max, int iPoints)
        {
            double x = 0, p = 0, q = 0, failureRate;
            int n = 0, valuesRequested, valuesFound;
            List<double> xl = new List<double>();
            List<double> fl = new List<double>();
            
            switch (number)
            {
                case 0: // testing Binomial
                    n = 7;
                    p = 0.05;
                    textBox1.Text += "n = " + n + "\r\n";
                    textBox1.Text += "p\t0\t1\t2\t3\t4\t5\t6\t7\r\n";
                    
                    while (p <= 0.9505)
                    {
                        textBox1.Text += p.ToString("F2") + "\t";

                        for (int a = 0; a <= n; a++)
                            textBox1.Text += dis.Binomial(p, a, n).ToString("F5") + "\t";

                        textBox1.Text += "\r\n";
                        p += 0.05;
                    }
                    break;
                case 1: // testing ChiSquare
                    textBox1.Text += "nu\t4.2\t4.4\t4.6\t4.8\t5.0\t5.2\t5.4\t5.6\r\n";

                    for (int nu = 1; nu <= 20; nu++)
                    {
                        double chi2 = 4.2;

                        textBox1.Text += nu.ToString("D2") + "\t";

                        while (chi2 <= 5.605)
                        {
                            textBox1.Text += dis.ChiSquare(chi2, nu, 1.0e-8).ToString("F5") + "\t";
                            chi2 += 0.2;
                        }

                        textBox1.Text += "\r\n";
                    }
                    break;
                case 2: // testing F-Distribution
                    sw.Start();
                    double[,] table = fd.BuildInverseFDistributionTable(
                        Q0, nu1Max, nu2Max, iPoints, out valuesRequested, out valuesFound);
                    int[] nu1 = { 1, 2, 3, 4, 5, 6, 8, 12, 15, 20, 30, 60, 80 };

                    textBox1.Text += "Q0 = " + Q0 + "\r\n";
                    textBox1.Text += "nu2/nu1\t1\t2\t3\t4\t5\t6\t8\t12\t15\t20\t30\t60\t80\r\n";
                   
                    for (int nu2 = 1; nu2 <= nu2Max; nu2++)
                    {
                        textBox1.Text += nu2.ToString("D2") + "\t";

                        for (int i = 0; i < nu1.Length; i++)
                        {
                            if (nu1[i] <= nu1Max)
                            {
                                double t = table[nu1[i], nu2];

                                if (t != 0 && !double.IsNaN(t))
                                    textBox1.Text += t.ToString("F3") + "\t";
                                else
                                    textBox1.Text += "Fail\t";
                            }

                            else
                                textBox1.Text += "Fail\t";
                        }

                        textBox1.Text += "\r\n";
                    }

                    sw.Stop();
                    failureRate = 100.0 * (valuesRequested - valuesFound) / valuesRequested;
                    textBox1.Text += "\r\n";
                    textBox1.Text += "Total Elapsed Seconds:\t" 
                        + (sw.ElapsedMilliseconds / 1000.0).ToString("F3") + "\r\n";
                    textBox1.Text += "Total Values Requested:\t" + valuesRequested + "\r\n";
                    textBox1.Text += "Total Values Found:\t\t" + valuesFound + "\r\n";
                    textBox1.Text += "Percent Failure Rate:\t" + failureRate.ToString("F2") + "\r\n"; 
                    break;
                case 3: // testing Hypergeometric
                    x = 0.5;
                    n = 8;
                    p = 0.05;
                    q = 0.1;
                    textBox1.Text += "x = " + x + "\r\n";
                    textBox1.Text += "p/q\t0.1\t0.2\t0.3\t0.4\t0.5\t0.6\t0.7\t0.8\t0.9\r\n";

                    while (p <= 0.9505)
                    {
                        textBox1.Text += p.ToString("F2") + "\t";

                        for (int a = 0; a <= n; a++)
                            textBox1.Text += 
                                f.HyperIncompleteBeta(
                                    x, p, q + a * 0.1, 1.0e-8).ToString("F5") + "\t";

                        textBox1.Text += "\r\n";
                        p += 0.05;
                    }
                    break;
                case 4: // testing Negative Binomial
                    n = 7;
                    p = 0.05;
                    q = 0.1;
                    textBox1.Text += "n = " + n + "\tq = " + q + "\r\n";
                    textBox1.Text += "p\t0\t1\t2\t3\t4\t5\t6\t7\r\n";

                    while (p <= 0.9505)
                    {
                        textBox1.Text += p.ToString("F2") + "\t";

                        for (int a = 0; a <= n; a++)
                            textBox1.Text += dis.NegativeBinomial(p, q, a, n).ToString("F5") + "\t";

                        textBox1.Text += "\r\n";
                        p += 0.05;
                    }
                    break;
                case 5: // testing Normal
                    textBox1.Text += "x\tP(x)\r\n";

                    while (x <= 2.02)
                    {
                        textBox1.Text += x.ToString("F2") + "\t" + pf.Normal(x, 1.0e-16).ToString("F15") + "\r\n";
                        x += 0.1;
                    }
                    break;
                case 6: // testing Poisson
                    textBox1.Text += "nu\t2.1\t2.2\t2.3\t2.4\t2.5\t2.6\t2.7\t2.8\r\n";

                    for (int nu = 1; nu <= 20; nu++)
                    {
                        double m = 2.1;

                        textBox1.Text += nu.ToString("D2") + "\t";

                        while (m <= 2.805)
                        {
                            textBox1.Text += dis.Poisson(m, nu).ToString("F5") + "\t";
                            m += 0.1;
                        }

                        textBox1.Text += "\r\n";
                    }
                    break;
                case 7: // testing Student's t
                    double[] A0 = { 0.2, 0.5, 0.8, 0.9, 0.95, 0.98, 0.99 };

                    textBox1.Text += "nu\t0.2\t0.5\t0.8\t0.9\t0.95\t0.98\t0.99\r\n";

                    for (int nu = 1; nu <= 30; nu++)
                    {
                        textBox1.Text += nu + "\t";
         
                        for (int i = 0; i < A0.Length; i++)
                        {
                            double t = dis.InversetDistribution(A0[i], nu);

                            textBox1.Text += t.ToString("F3") + "\t";
                        }

                        textBox1.Text += "\r\n";
                    }
                    break;
            }
        }
    }
}