using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatisticsLibrary;

namespace StatisticsLibraryTest
{
    public class IxPoint
    {
        private double ix, x;
        private int nu1, nu2;

        public double Ix
        {
            get
            {
                return ix;
            }
        }

        public double X
        {
            get
            {
                return x;
            }
        }

        public int Nu1
        {
            get
            {
                return nu1;
            }
        }

        public int Nu2
        {
            get
            {
                return nu2;
            }
        }

        public IxPoint(double ix, double x, int nu1, int nu2)
        {
            this.ix = ix;
            this.x = x;
            this.nu1 = nu1;
            this.nu2 = nu2;
        }

    }

    class IXPointComparerIx : IComparer<IxPoint>
    { 
        public int Compare(IxPoint i1, IxPoint i2)
        {
            if (i1.Ix < i2.Ix)
                return -1;

            else if (i1.Ix > i2.Ix)
                return +1;

            return 0;
        }
    }

    class IXPointComparerNu1Nu2 : IComparer<IxPoint>
    {
        public int Compare(IxPoint i1, IxPoint i2)
        {
            if (i1.Nu1 < i2.Nu1)
                return -1;

            else if (i1.Nu1 > i2.Nu1)
                return +1;

            if (i1.Nu2 < i2.Nu2)
                return -1;

            else if (i1.Nu2 > i2.Nu2)
                return +1;

            return 0;
        }
    }
    class FDistribution
    {
        Functions f = new Functions();
        ProbabilityFunctions pf = new ProbabilityFunctions();

        public double[] QPPlus(double x, int nu1, int nu2, int nmax)
        {
            double p, q = 0.5 * nu1;
            double[] i;

            if (nu2 % 2 == 1)
                p = 0.5;

            else
                p = 1.0;

            f.IncompleteBetaPPlusN(x, p, q, nmax, 1.0e-5, out i);
            return i;
        }

        public double[] QQPlus(double x, int nu1, int nu2, int nmax)
        {
            double p = 0.5 * nu2, q;
            double[] i;

            if (nu1 % 2 == 1)
                q = 0.5;

            else
                q = 1.0;

            f.IncompleteBetaQPlusN(x, p, q, nmax, 1.0e-5, out i);
            return i;
        }

        public double[] DQPPlusDx(double x, int nu1, int nu2, int nmax)
        {
            double p, q = 0.5 * nu1;
            double[] didx = new double[nmax + 1];

            if (nu2 % 2 == 1)
                p = 0.5;

            else
                p = 1.0;

            for (int n = 0; n <= nmax; n++)
                didx[n] = f.DIncompleteBetaDx(x, p + n, q);

            return didx;
        }

        public double[] DQQPlusDx(double x, int nu1, int nu2, int nmax)
        {
            double p = 0.5 * nu2, q;
            double[] didx = new double[nmax + 1];

            if (nu1 % 2 == 1)
                q = 0.5;

            else
                q = 1.0;

            for (int n = 0; n <= nmax; n++)
                didx[n] = f.DIncompleteBetaDx(x, p, q + n);

            return didx;
        }

        private double Convertx(double x, int nu1, int nu2)
        {
            double F = (nu2 / x - nu2) / nu1;

            return F;
        }

        public double InverseQPPlus(double F0, int nu1, int nu2, int nmax)
        {
            double x0 = nu2 / (nu2 + nu1 * F0), x = x0;
            int count = 0;
            
            if (nu2 <= 2)
                x0 = x = 0.00001;
               
            while (true)
            {
                double p;
                double[] Q = QPPlus(x, nu1, nu2, nmax);
                double[] DQDx = DQPPlusDx(x, nu1, nu2, nmax);
                int index;

                if (nu2 % 2 == 1)
                    p = 0.5;

                else
                    p = 1.0;

                index = (int)(0.5 * nu2 - p);

                double Q0 = F0 - Q[index];
                double DQ0Dx0 = -DQDx[index];
                double term = Q0 / DQ0Dx0;

                if (Math.Abs(Q0) < 1.0e-5)
                    return Convertx(x, nu1, nu2);

                if (Math.Abs(term) < 1.0e-5)
                    return Convertx(x, nu1, nu2);

                x -= term;

                if (double.IsNaN(x))
                {
                    if (count < 4)
                    {
                        x0 /= 2;

                        if (x0 <= 0)
                            x0 = 0.0001;

                        x = x0;
                    }

                    else
                        return 0;

                    count++;
                }

                if (x < 0 || Math.Abs(x) < 1.0e-5)
                    return Convertx(0, nu1, nu2);

                if (Math.Abs(1 - x) < 1.0e-10)
                    return Convertx(1, nu1, nu2);
            }
        }

        public double InverseQQPlus(double F0, int nu1, int nu2, int nmax)
        {
            double x0 = (double)nu2 / (nu2 + nu1 * F0), x = x0;
            int count = 0;

            if (nu1 <= 2)
                x0 = x = 0.00001;

            while (true)
            {
                double q;
                double[] Q = QQPlus(x, nu1, nu2, nmax);
                double[] DQDx = DQQPlusDx(x, nu1, nu2, nmax);
                int index;

                if (nu1 % 2 == 1)
                    q = 0.5;

                else
                    q = 1.0;

                index = (int)(0.5 * nu1 - q);

                double Q0 = F0 - Q[index];
                double DQ0Dx0 = -DQDx[index];
                double term = Q0 / DQ0Dx0;

                if (Math.Abs(Q0) < 1.0e-5)
                    return Convertx(x, nu1, nu2);

                if (Math.Abs(term) < 1.0e-5)
                    return Convertx(x, nu1, nu2);

                x -= term;

                if (double.IsNaN(x))
                {
                    if (count < 4)
                    {
                        x0 *= 10.0;

                        if (x0 > 1.0)
                            x0 /= 2;

                        x = x0;
                    }

                    else
                        return 0;

                    count++;
                }

                if (x < 0 || Math.Abs(x) < 1.0e-5)
                    return Convertx(0, nu1, nu2);

                if (Math.Abs(1 - x) < 1.0e-5)
                    return Convertx(1, nu1, nu2);
            }
        }

        private List<IxPoint> BuildQPointList(
            double Q0, double[,] table, int nu1Max, int nu2Max)
        {
            double x;
            double[] i; 
            List<IxPoint> list = new List<IxPoint>();

            for (int nu1 = 1; nu1 <= nu1Max; nu1++)
            {
                double q = 0.5 * nu1;

                for (int nu2 = 1; nu2 <= nu2Max; nu2++)
                {
                    double p, t = table[nu1, nu2];

                    if (t == 0 || double.IsInfinity(t))
                    {
                        if (nu2 % 2 == 1)
                            p = 0.5;
                        else
                            p = 1.0;

                        for (int k = 1; k < 10000; k++)
                        {
                            x = 0.0001 * k;

                            try
                            {
                                f.IncompleteBetaPPlusN(x, p, q, nu2Max, 1.0e-8, out i);
                                int index = (int)(0.5 * nu2 - p);
                                double I0 = i[index];

                                if (Math.Abs(I0 - Q0) < 1.0e-4)
                                {
                                    IxPoint ixp = new IxPoint(I0, Convertx(x, nu1, nu2), nu1, nu2);
                                    list.Add(ixp);
                                }
                            }
                            catch (Exception)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            IXPointComparerIx pc = new IXPointComparerIx();

            list.Sort(pc);
            return list;
        }

        public double[,] BuildInverseFDistributionTable(
            double Q0, int nu1Max, int nu2Max,
            out int count1, out int count2, out int count3)
        {
            double[,] table = new double[nu1Max + 1, nu2Max + 1];

            count1 = count2 = count3 = 0;

            for (int nu1 = 1; nu1 <= nu1Max; nu1++)
            {
                for (int nu2 = 1; nu2 <= nu2Max; nu2++)
                {
                    try
                    {
                        table[nu1, nu2] = InverseQPPlus(Q0, nu1, nu2, nu2Max);

                        if (table[nu1, nu2] != 0 && !double.IsInfinity(table[nu1, nu2]))
                            count1++;
                    }
                    catch (Exception)
                    { }
                }
            }

            for (int nu1 = 1; nu1 <= nu1Max; nu1++)
            {
                for (int nu2 = 1; nu2 <= nu2Max; nu2++)
                {
                    try
                    {
                        double t = table[nu1, nu2];

                        if (double.IsInfinity(t) || t == 0)
                        {
                            table[nu1, nu2] = InverseQQPlus(Q0, nu1, nu2, nu1Max);

                            if (table[nu1, nu2] != 0 && !double.IsInfinity(table[nu1, nu2]))
                                count2++;
                        }
                    }
                    catch (Exception)
                    { }
                }
            }

            List<IxPoint> list0 = BuildQPointList(Q0, table, nu1Max, nu2Max);
            List<IxPoint> list1 = new List<IxPoint>();

            for (int i = 0; i < list0.Count; i++)
                if (!double.IsInfinity(list0[i].Ix))
                    list1.Add(list0[i]);

            IXPointComparerNu1Nu2 ic = new IXPointComparerNu1Nu2();

            list1.Sort(ic);

            for (int i = 0; i < list1.Count; i++)
            {
                IxPoint ixp = list1[i];
                table[ixp.Nu1, ixp.Nu2] = ixp.X;
            }

            count3 = list1.Count;
            return table;
        }
    }
}