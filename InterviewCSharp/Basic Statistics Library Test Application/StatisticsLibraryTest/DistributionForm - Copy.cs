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
    public partial class DistributionForm : Form
    {
        private Distributions dis = new Distributions();
        private Functions f = new Functions();
        private ProbabilityFunctions pf = new ProbabilityFunctions();

        public DistributionForm(int number, string dstr)
        {
            InitializeComponent();
            textBox1.Text += "Testing " + dstr + ":\r\n\r\n";
            Test(number);
        }

        public double HypergeometricSeries(double b, double a, double c, double x)
        {
            double sum = 0, term = 0, z = 1;
            int n = 0;

            while (true)
            {
                term = f.Gamma(a + n) * f.Gamma(b + n) * z / (f.Gamma(c + n) * f.Factorial(n));

                if (Math.Abs(term) < 1.0e-20)
                    break;

                sum += term;
                z *= x;
                n++;
            }

            return f.Gamma(c) * sum / (f.Gamma(a) * f.Gamma(b));
        }

        public double HyperIncompleteBeta(double x, double a, double b)
        {
            return Math.Pow(x, a) * HypergeometricSeries(a, 1 - b, a + 1, x) / (a * f.Beta(a, b));
        }

        private double A(double theta, int nu)
        {
            double cos = Math.Cos(theta), sin = Math.Sin(theta);
            double cos2 = cos * cos, sum = 0;

            if (nu == 1)
                return 2.0 * theta / Math.PI;

            double pcos = cos;

            for (int i = 1; i <= nu - 2; i += 2)
            {
                double denom = 1, numer = 1;

                for (int j = 1; j <= (i - 1) / 2; j++)
                    numer *= 2 * j;

                for (int j = 1; j <= (i - 1) / 2; j++)
                    denom *= 2 * j + 1;

                sum += numer * pcos / denom;
                pcos *= cos2;
            }

            return 2.0 * (theta + sin * sum) / Math.PI;
        }

        public double DADt(double t, double theta, int nu1, int nu2)
        {
            double sum1 = 0, sum2 = 0;
            double cos = Math.Cos(theta), sin = Math.Sin(theta);
            double cos2 = cos * cos;
            double thetap = 1.0 / ((1.0 + t * t / nu2) * Math.Sqrt(nu2));

            if (nu2 == 1)
                return 2.0 * thetap / Math.PI;

            double pcos = cos;

            for (int i = 1; i <= nu2 - 2; i += 2)
            {
                double denom = 1, numer = 1;

                for (int j = 1; j <= (i - 1) / 2; j++)
                    numer *= 2 * j;

                for (int j = 1; j <= (i - 1) / 2; j++)
                    denom *= 2 * j + 1;

                sum1 += numer * pcos / denom;
                pcos *= cos2;
            }

            sum1 = 2.0 * thetap * (1.0 + cos * sum1) / Math.PI;

            pcos = 1.0;

            for (int i = 1; i <= nu2 - 2; i += 2)
            {
                double denom = 1, numer = 1;

                for (int j = 1; j <= (i - 1) / 2; j++)
                    numer *= 2 * j;

                for (int j = 1; j <= (i - 1) / 2; j++)
                    denom *= 2 * j + 1;

                sum2 += i * numer * pcos / denom;
                pcos *= cos2;
            }

            sum1 += -2.0 * thetap * sin * sin * sum2 / Math.PI;

            return sum1;
        }

        private double Beta(double theta, int nu1, int nu2)
        {
            if (nu1 == 1 || nu2 == 1)
                return 0;

            double beta = 1.0, cos = Math.Cos(theta), sin = Math.Sin(theta);
            double sin2 = sin * sin, psin = sin2;

            for (int i = 1; i <= (nu1 - 3) / 2; i++)
            {
                double denom = 1, numer = 1;

                for (int j = 1; j <= i; j++)
                    numer *= nu2 + j;

                for (int j = 1; j <= i; j++)
                    denom *= 2 * j + 1;

                beta += numer * psin / denom;
                psin *= sin2;
            }

            beta *= 2.0 * f.Gamma((nu2 - 1) / 2 + 1)
                / (Math.Sqrt(Math.PI) * f.Gamma((nu2 - 2) / 2 + 1));
            beta *= sin * Math.Pow(cos, nu2);
            return beta;
        }

        private double DBetaDt(double t, double theta, int nu1, int nu2)
        {
            if (nu1 == 1 || nu2 == 1)
                return 0;

            double beta1 = 1, beta2 = 0, cos = Math.Cos(theta), sin = Math.Sin(theta);
            double sin2 = sin * sin, psin = sin2;
            double thetap = 1.0 / ((1.0 + t * t / nu2) * Math.Sqrt(nu2));
            double dprod = cos * Math.Pow(cos, nu2) - nu2 * sin2 * Math.Pow(cos, nu2 - 1);

            for (int i = 1; i <= (nu1 - 3) / 2; i++)
            {
                double denom = 1, numer = 1;

                for (int j = 1; j <= i; j++)
                    numer *= nu2 + j;

                for (int j = 1; j <= i; j++)
                    denom *= 2 * j + 1;

                beta1 += numer * psin / denom;
                psin *= sin2;
            }

            beta1 *= 2.0 * f.Gamma((nu2 - 1) / 2 + 1)
                / (Math.Sqrt(Math.PI) * f.Gamma((nu2 - 2) / 2 + 1));
            beta1 *= thetap * dprod;
            psin = sin;

            for (int i = 1; i <= (nu1 - 3) / 2; i++)
            {
                double denom = 1, numer = 1;

                for (int j = 1; j <= i; j++)
                    numer *= nu2 + j;

                for (int j = 1; j <= i; j++)
                    denom *= 2 * j + 1;

                beta2 += 2 * i * numer * psin / denom;
                psin *= sin2;
            }

            beta2 *= 2.0 * f.Gamma((nu2 - 1) / 2 + 1)
                / (Math.Sqrt(Math.PI) * f.Gamma((nu2 - 2) / 2 + 1));
            beta2 *= thetap * cos * sin * Math.Pow(cos, nu2);
            beta1 += beta2;
            return beta1;
        }

        private double QNu1Even(double x, double x1, int nu1, int nu2)
        {
            double sum = 0, x2 = x1 / x, z = 1;
            int nu12 = nu1 + nu2;

            for (int n = 0; n <= (nu1 - 2) / 2; n++)
            {
                double denom = 1, numer = 1;

                for (int i = 1; i <= n; i++)
                    denom *= 2 * i;

                for (int i = 1; i <= n; i++)
                    numer *= nu12 - 2 * i;

                sum += numer * z / denom;
                z *= x2;
            }

            return Math.Pow(x, (nu12 - 2) / 2) * sum;
        }

        private double DQNu1EvenDx(double x, double x1, int nu1, int nu2)
        {
            double sum1 = 0, sum2 = 0, x2 = x1 / x, z = 1;
            double dx2 = -1.0 - x1 / (x * x);
            int nu12 = nu1 + nu2;

            for (int n = 0; n <= (nu1 - 2) / 2; n++)
            {
                double denom = 1, numer = 1;

                for (int i = 1; i <= n; i++)
                    denom *= 2 * i;

                for (int i = 1; i <= n; i++)
                    numer *= nu12 - 2 * i;

                sum1 += numer * z / denom;
                z *= x2;
            }

            sum1 = Math.Pow(x, (nu12 - 2) / 2 - 1) * sum1;

            for (int n = 1; n <= (nu1 - 2) / 2; n++)
            {
                double denom = 1, numer = 1;

                for (int i = 1; i <= n; i++)
                    denom *= 2 * i;

                for (int i = 1; i <= n; i++)
                    numer *= nu12 - 2 * i;

                sum2 += numer * z / denom;
                z *= dx2;
            }

            sum2 = Math.Pow(x, (nu12 - 2) / 2) * sum2;
            return sum1 + sum1;
        }

        private double QNu2Even(double x, double x1, int nu1, int nu2)
        {
            double sum = 0, x2 = x / x1, z = 1;
            int nu12 = nu1 + nu2;

            for (int n = 0; n <= (nu2 - 2) / 2; n++)
            {
                double denom = 1, numer = 1;

                for (int i = 1; i <= n; i++)
                    denom *= 2 * i;

                for (int i = 1; i <= n; i++)
                    numer *= nu12 - 2 * i;

                sum += numer * z / denom;
                z *= x2;
            }

            return 1.0 - Math.Pow(x1, (nu12 - 2) / 2) * sum;
        }

        private double DQNu2EvenDx(double x, double x1, int nu1, int nu2)
        {
            double sum1 = 0, sum2 = 0, x2 = x / x1, z = 1;
            double dx2 = 1.0 / x1 + x / (x1 * x1);
            int nu12 = nu1 + nu2;

            for (int n = 0; n <= (nu2 - 2) / 2; n++)
            {
                double denom = 1, numer = 1;

                for (int i = 1; i <= n; i++)
                    denom *= 2 * i;

                for (int i = 1; i <= n; i++)
                    numer *= nu12 - 2 * i;

                sum1 += numer * z / denom;
                z *= x2;
            }

            sum1 = (nu12 - 2) / 2 * Math.Pow(x1, (nu12 - 2) / 2 - 1) * sum1;
            z = dx2;

            for (int n = 1; n <= (nu2 - 2) / 2; n++)
            {
                double denom = 1, numer = 1;

                for (int i = 1; i <= n; i++)
                    denom *= 2 * i;

                for (int i = 1; i <= n; i++)
                    numer *= nu12 - 2 * i;

                sum2 += (2 * n - 1) * numer * z / denom;
                z *= dx2;
            }

            return sum1 - Math.Pow(x1, (nu12 - 2) / 2) * sum2;
        }

        private double FDistribution11(double F, int nu1, int nu2)
        {
            // converges for nu1 == 1 && nu2 % 2 == 1
            double t = Math.Sqrt(nu1 * F);
            double theta = Math.Atan(t / Math.Sqrt(nu2));

            return 1.0 - A(theta, nu2);
        }

        private double DFDistributionDF11(double F, int nu1, int nu2)
        {
            // converges for nu1 == 1 && nu2 % 2 == 1
            double t = Math.Sqrt(nu1 * F); 
            double theta = Math.Atan(t / Math.Sqrt(nu2));

            return -DADt(t, theta, nu1, nu2);
        }

        private double FDistribution152(double x, int nu1, int nu2)
        {
            // converges for nu1 >= 1 && nu1 <= 15 && nu2 <= 2
            return f.IncompleteBeta(x, 0.5 * nu2, 0.5 * nu1, 1.0e-20);
        }

        private double DFDistributionDx152(double x, int nu1, int nu2)
        {
            // converges for nu1 >= 1 && nu1 <= 15 && nu1 <= 2
            return f.DIncompleteBetaDx(x, 0.5 * nu2, 0.5 * nu1);
        }

        private double FDistribution15Up(double x, int nu1, int nu2)
        {
            double p, q = 0.5 * nu1;
            double[] i;
            int delta = 2, lover, nmax, steps;

            if (nu2 % 2 == 0)
            {
                nmax = nu2 / 2;
                p = 1;
            }

            else
            {
                nmax = (nu2 + 1) / 2;
                p = 0.5;
            }

            steps = nmax / delta;
            lover = (int)(0.5 * nu2 - (p + steps));

            f.IncompleteBetaPPlusN(x, p + steps, q, delta, 1.0e-20, out i);
            return i[lover];
        }

        private double DFDistributionDx15Up(double x, int nu1, int nu2)
        {
            return f.DIncompleteBetaDx(x, 0.5 * nu2, 0.5 * nu1);
        }

        public double InverseFDistribution11(double F0, int nu1, int nu2)
        {
            double F = 0.00001, term = 0;

            while (true)
            {
                double ff = F0 - FDistribution11(F, nu1, nu2);
                double df = -DFDistributionDF11(F, nu1, nu2);

                if (Math.Abs(ff) < 1.0e-10)
                    return F;

                term = ff / df;

                if (Math.Abs(term) < 1.0e-10)
                    return F;

                F -= term;
            }
        }

        private double Convertx(double x, int nu1, int nu2)
        {
            double F = (nu2 / x - nu2) / nu1;

            return F;
        }

        public double InverseFDistribution152(double F0, int nu1, int nu2)
        { 
            double x = 0.00001, term = 0;

            while (true)
            {
                double ff = F0 - FDistribution152(x, nu1, nu2);
                double df = -DFDistributionDx152(x, nu1, nu2);

                if (Math.Abs(ff) < 1.0e-10)
                    return Convertx(x, nu1, nu2);

                term = ff / df;

                if (Math.Abs(term) < 1.0e-10)
                    return Convertx(x, nu1, nu2);

                x -= term;

                if (Math.Abs(x) < 1.0e-10)
                    return Convertx(0, nu1, nu2);

                if (Math.Abs(1 - x) < 1.0e-10)
                    return Convertx(1, nu1, nu2);
            }
        }

        public double InverseFDistribution15Up(double F0, int nu1, int nu2)
        {
            double x = (double)nu2 / (nu2 + nu1 * F0), term = 0;

            while (true)
            {
                double ff = F0 - FDistribution15Up(x, nu1, nu2);
                double df = -DFDistributionDx15Up(x, nu1, nu2);

                if (Math.Abs(ff) < 1.0e-10)
                    return Convertx(x, nu1, nu2);

                term = ff / df;

                if (Math.Abs(term) < 1.0e-10)
                    return Convertx(x, nu1, nu2);

                x -= term;

                if (Math.Abs(x) < 1.0e-10)
                    return Convertx(0, nu1, nu2);

                if (Math.Abs(1 - x) < 1.0e-10)
                    return Convertx(1, nu1, nu2);
            }
        }

        public double InverseFDistributionNu1Even(double F0, int nu1, int nu2)
        {
            double x = 0.00001, term = 0;

            while (true)
            {
                double ff = F0 - QNu1Even(x, 1 - x, nu1, nu2);
                double df = -DQNu1EvenDx(x, 1 - x, nu1, nu2);

                if (Math.Abs(ff) < 1.0e-10)
                    return Convertx(x, nu1, nu2);

                term = ff / df;

                if (Math.Abs(term) < 1.0e-10)
                    return Convertx(x, nu1, nu2);

                x -= term;

                if (Math.Abs(x) < 1.0e-10)
                    return Convertx(0, nu1, nu2);

                if (Math.Abs(1 - x) < 1.0e-10)
                    return Convertx(1, nu1, nu2);
            }
        }

        public double InverseFDistributionNu2Even(double F0, int nu1, int nu2)
        {
            double x = 0.00001, term = 0;

            while (true)
            {
                double ff = F0 - QNu2Even(x, 1 - x, nu1, nu2);
                double df = -DQNu2EvenDx(x, 1 - x, nu1, nu2);

                if (Math.Abs(ff) < 1.0e-5)
                    return Convertx(x, nu1, nu2);

                term = ff / df;

                if (Math.Abs(term) < 1.0e-5)
                    return Convertx(x, nu1, nu2);

                x -= term;

                if (Math.Abs(x) < 1.0e-5)
                    return Convertx(0, nu1, nu2);

                if (Math.Abs(1 - x) < 1.0e-5)
                    return Convertx(1, nu1, nu2);
            }
        }

        public double InverseFDistribution(double F0, int nu1, int nu2)
        {
            /*if (nu1 == 1 && nu2 % 2 == 1)
                return InverseFDistribution11(F0, nu1, nu2);*/

            if (nu1 <= 15 && nu2 <= 2)
               return InverseFDistribution152(F0, nu1, nu2);

            if (nu1 <= 15 && nu2 >= 3 && nu2 <= 9)
                return InverseFDistribution15Up(F0, nu1, nu2);

            /*if (nu1 % 2 == 0 && nu2 % 2 == 0 && nu2 > 2 && nu2 <= 6)
                 return InverseFDistributionNu1Even(F0, nu1, nu2);*/

            /*if (nu2 % 2 == 0 && nu1 % 2 == 0 && nu2 > 6 && nu2 <= 10)
                return InverseFDistributionNu2Even(F0, nu1, nu2);*/

            return 0.0;
        }

        private void Test(int number)
        {
            double x = 0;
            List<double> xl = new List<double>();
            List<double> fl = new List<double>();

            switch (number)
            {
                case 0: // testing Binomial
                    break;
                case 1: // testing ChiSquare
                    textBox1.Text += "nu\t5.0\t5.2\t5.4\t5.6\t5.8\t6.0\r\n";

                    for (int nu = 1; nu <= 20; nu++)
                    {
                        double chi2 = 5.0;

                        textBox1.Text += nu.ToString("D2") + "\t";

                        while (chi2 <= 6.1)
                        {
                            textBox1.Text += dis.ChiSquare(chi2, nu).ToString("F5") + "\t";
                            chi2 += 0.2;
                        }

                        textBox1.Text += "\r\n";
                    }
                    break;
                case 2: // testing F-Distribution
                    int[] nu1 = { 1, 2, 3, 4, 5, 6, 8, 12, 15 };
                    double F0 = 0.5;

                    textBox1.Text += "nu2/nu1\t1\t2\t3\t4\t5\t6\t8\t12\t15\r\n";
                     
                    for (int nu2 = 1; nu2 <= 25; nu2++)
                    {
                        textBox1.Text += nu2.ToString("D2") + "\t";

                        for (int i = 0; i < nu1.Length; i++)
                            textBox1.Text += InverseFDistribution(F0, nu1[i], nu2).ToString("F3") + "\t";

                        textBox1.Text += "\r\n";
                    }
                    break;
                case 3: // testing Hypergeometric
                    break;
                case 4: // testing Negative Binomial
                    break;
                case 5: // testing Normal
                    textBox1.Text += "x\tP(x)\r\n";

                    while (x <= 2.02)
                    {
                        textBox1.Text += x.ToString("F2") + "\t" + pf.Normal(x).ToString("F15") + "\r\n";
                        x += 0.1;
                    }
                    break;
                case 6: // testing Poisson
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