using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using StatisticsLibrary;

namespace StatisticsLibraryTest
{
    public partial class FunctionForm : Form
    {
        private Functions f;
        private Stopwatch sw0, sw1;
        private XYScatterForm xyf;

        public FunctionForm(int number, string fstr)
        {
            InitializeComponent();
            textBox1.Text += "Testing " + fstr + ":\r\n\r\n";
            sw0 = new Stopwatch();
            sw1 = new Stopwatch();
            sw0.Start();
            f = new Functions(256);
            sw0.Stop();
            Test(number);
        }

        private void TestIncompleteBetaFunction(double x0, string title,
            Func<double, double, double, double, double> IncompleteBeta)
        {
            double x = x0;
            textBox1.Text += title + "\r\n";
            textBox1.Text += "x = " + x0 + "\tIx(nu2 / 2, nu1 / 2)\r\n";
            textBox1.Text += "nu2/nu1\t1\t2\t3\t4\t5\r\n";

            for (int nu2 = 1; nu2 <= 5; nu2++)
            {
                textBox1.Text += nu2.ToString("D1") + "\t";

                for (int nu1 = 1; nu1 <= 5; nu1++)
                    textBox1.Text += IncompleteBeta(x, 0.5 * nu2, 0.5 * nu1, 1e-10).ToString("F3") + "\t";

                textBox1.Text += "\r\n";
            }

            textBox1.Text += "\r\n";
        }

        private void Test(int number)
        {
            double a = 0, x = 0, chi2 = 0;
            List<double> xl = new List<double>();
            List<double> fl = new List<double>();

            switch (number)
            {
                case 0: // testing A(t|nu)
                    for (int nu = 1; nu <= 20; nu++)
                    {
                        double t = 0.1;

                        textBox1.Text += nu.ToString("D2") + "\t";

                        while (t <= 0.4)
                        {
                            textBox1.Text += f.A(t, nu).ToString("F3") + "\t";
                            t += 0.1;
                        }

                        textBox1.Text += "\r\n";
                    }
                    break;
                case 1: // testing Binomial(m, n)
                    for (int m = 0; m <= 8; m++)
                    {
                        for (int n = 0; n <= m; n++)
                        {
                            textBox1.Text += f.BinomialCoefficient(m, n).ToString("F0") + " ";
                        }

                        textBox1.Text += "\r\n";
                    }
                    break;
                case 2: // testing erf and erfc
                    while (x <= 1.04)
                    {
                        double erf, erfc;

                        f.ErrorFunction(x, out erf, out erfc);
                        textBox1.Text += x.ToString("F2") + "\t" + erf.ToString("F10") + "\t" + erfc.ToString("F10") + "\r\n";
                        xl.Add(x);
                        fl.Add(erfc);
                        x += 0.05;
                    }

                    double[,] y = new double[1, fl.Count];

                    for (int i = 0; i < fl.Count; i++)
                        y[0, i] = fl[i];

                    xyf = new XYScatterForm("Error Function", "x", "erf(x)", xl.ToArray(), y);
                    xyf.Show();
                    break;
                case 3: // testing n!
                    for (int n = 0; n <= 10; n++)
                        textBox1.Text += n.ToString("D2") + "\t" + f.Factorial(n).ToString() + "\r\n";
                    break;
                case 4: // testing Gamma(x)
                    textBox1.Text += "x\tGamma(x)\r\n";

                    x = 1.0;
                    while (x <= 1.104)
                    {
                        double gamma = f.Gamma(x);

                        textBox1.Text += x.ToString("F3") + "\t" + gamma.ToString("F10") + "\r\n";
                        xl.Add(x);
                        fl.Add(gamma);
                        x += 0.005;
                    }

                    double[,] z = new double[1, fl.Count];

                    for (int i = 0; i < fl.Count; i++)
                        z[0, i] = fl[i];

                    xyf = new XYScatterForm("Gamma Function", "x", "Gamma(x)", xl.ToArray(), z);
                    xyf.Show();
                    break;
                case 5: // testing incomplete beta function
                    double[] x0 = { 0.05, 0.25, 0.5, 0.75, 0.95 };

                    for (int i = 0; i < x0.Length; i++)
                    {
                        TestIncompleteBetaFunction(x0[i], "Via Continued Fraction Function #0",
                            f.IncompleteBeta);
                        TestIncompleteBetaFunction(x0[i], "Via Continued Fraction Function #1",
                            f.IncompleteBetaFunctionCF1);
                        TestIncompleteBetaFunction(x0[i], "Via Continued Fraction Function #2",
                            f.IncompleteBetaFunctionCF2);
                        TestIncompleteBetaFunction(x0[i], "Via the Integration Function",
                            f.IncompleteBetaFunctionIntegration);
                        TestIncompleteBetaFunction(x0[i], "Via the Hypergeometric Series Function",
                            f.HyperIncompleteBeta);
                    }
                    break;
                case 6: // testing incomplete gamma functions
                    textBox1.Text += "Via the Continued Fraction Function\r\n";
                    textBox1.Text += "nu/2x\t4.2\t4.4\t4.6\t4.8\t5.0\t5.2\r\n";
                    sw1.Start();

                    for (int nu = 1; nu <= 20; nu++)
                    {
                        a = 0.5 * nu;
                        chi2 = 4.2;
                        textBox1.Text += nu.ToString("D2") + "\t";

                        while (chi2 <= 5.21)
                        {
                            x = 0.5 * chi2;
                            double ig = f.IncompleteGammaCF(a, x, 1.0e-20) / f.Gamma(a);

                            textBox1.Text += ig.ToString("F5") + "\t";
                            chi2 += 0.2;
                        }

                        textBox1.Text += "\r\n";
                    }

                    sw1.Stop();
                    textBox1.Text += "Milliseconds to generate table: "
                        + sw1.ElapsedMilliseconds + "\r\n";
                    textBox1.Text += "\r\nVia the Integration Function\r\n";
                    textBox1.Text += "nu/2x\t4.2\t4.4\t4.6\t4.8\t5.0\t5.2\r\n";
                    sw1.Restart();

                    for (int nu = 1; nu <= 20; nu++)
                    {
                        a = 0.5 * nu;
                        chi2 = 4.2;
                        textBox1.Text += nu.ToString("D2") + "\t";

                        while (chi2 <= 5.21)
                        {
                            x = 0.5 * chi2;
                            double ig = f.IncompleteGammaIntegration(a, x, 1000.0) / f.Gamma(a);

                            textBox1.Text += ig.ToString("F5") + "\t";
                            chi2 += 0.2;
                        }

                        textBox1.Text += "\r\n";
                    }

                    sw1.Stop();
                    textBox1.Text += "Milliseconds to generate table: "
                        + sw1.ElapsedMilliseconds + "\r\n";
                    textBox1.Text += "Milliseconds to generate integration weights: "
                        + sw0.ElapsedMilliseconds + "\r\n";
                    break;
            }
        }
    }
}