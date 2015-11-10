using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    class Polynomial
    {
        protected double[] coefficients;
        protected int n;

        public int N { get { return this.n; } }
        public double[] Coefficients { get { return this.coefficients; } }

        public Polynomial(double[] coefficients, int n)
        {
            this.coefficients = coefficients;
            this.n = n;
        }
        public Polynomial() : this(new double[] { }, 0) { }

        public Polynomial(double[] coefficients) : this(coefficients, coefficients.Length) { }

        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            double[] coefficients = new double[Math.Max(p1.N, p2.N)];

            for (int i = 0; i < Math.Min(p1.n, p2.n); i++)
            {
                coefficients[i] = p1.coefficients[i] + p2.coefficients[i];
            }

            for (int i = Math.Min(p1.n, p2.n); i < Math.Max(p1.n, p2.n); i++)
            {
                coefficients[i] = (p1.n > p2.n) ? p1.coefficients[i] : p2.coefficients[i];
            }

            return new Polynomial(coefficients);
        }

        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            double[] coefficients = new double[Math.Max(p1.n, p2.n)];

            for (int i = 0; i < Math.Min(p1.n, p2.n); i++)
            {
                coefficients[i] = p1.coefficients[i] - p2.coefficients[i];
            }

            for (int i = Math.Min(p1.n, p2.n); i < Math.Max(p1.n, p2.n); i++)
            {
                coefficients[i] = (p1.n > p2.n) ? p1.coefficients[i] : p2.coefficients[i];
            }

            return new Polynomial(GetCoefficientsWithoutNulls(coefficients));
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            double[] coefficients = new double[2 * Math.Max(p1.n, p2.n)];

            for (int i = 0; i < p1.n; i++)
            {
                for (int j = 0; j < p2.n; j++)
                {
                    coefficients[i + j] += p1.coefficients[i] * p2.coefficients[j];
                }
            }

            return new Polynomial(GetCoefficientsWithoutNulls(coefficients));
        }

        public static Polynomial operator +(Polynomial p, double num)
        {
            double[] coefficients = p.coefficients;
            coefficients[0] += num;
            return new Polynomial(coefficients);
        }

        public static Polynomial operator -(Polynomial p, double num)
        {
            return p + (-num);
        }

        public static Polynomial operator *(Polynomial p, double num)
        {
            double[] coefficients = p.coefficients;
            for (int i = 0; i < p.n; i++)
            {
                coefficients[i] = p.coefficients[i] * num;
            }
            return new Polynomial(coefficients);
        }

        public static Polynomial operator /(Polynomial p, double num)
        {
            return p * (1 / num);
        }

        public double Calc(double x)
        {
            double ans = 0;

            for (int i = 0; i < this.n; i++)
            {
                ans += this.coefficients[i] * Math.Pow(x, i);
            }

            return ans;
        }

        public override string ToString()
        {
            string ans = this.coefficients[this.n - 1].ToString();
            if (n - 1 > 0)
            {
                ans += " * x";
            }
            if (n - 1 > 1)
            {
                ans += "^" + (n - 1).ToString();
            }

            for (int i = this.n - 2; i >= 0; i--)
            {
                if (this.coefficients[i] != 0)
                {
                    if (this.coefficients[i] > 0)
                    {
                        ans += " + " + this.coefficients[i];
                    }
                    else
                    {
                        ans += " - " + (-1) * this.coefficients[i];
                    }
                    if (i > 0)
                    {
                        ans += " * x";
                    }
                    if (i > 1)
                    {
                        ans += "^" + i.ToString();
                    }

                }
            }
            if (ans == "")
            {
                ans = "0";
            }
            return ans;
        }

        protected static double[] GetCoefficientsWithoutNulls(double[] arr)
        {
            int length = arr.Length;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] != 0)
                {
                    length = i + 1;
                    break;
                }
            }

            double[] arrAnswer = new double[length];
            Array.Copy(arr, 0, arrAnswer, 0, length);

            return arrAnswer;
        }

    }

    class LagrangePolynomial : Polynomial
    {

        public LagrangePolynomial() : base() { }
        public LagrangePolynomial(Tuple<double, double>[] nodes, int n)
        {
            Polynomial L = new Polynomial();
            for (int i = 0; i < n; i++)
            {
                Polynomial li = new Polynomial(new double[] { 1 });
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        continue;

                    li *= (new Polynomial(new double[] { 0, 1 }) - nodes[j].Item1) / (nodes[i].Item1 - nodes[j].Item1);
                }
                L += li * nodes[i].Item2;

            }
            this.coefficients = GetCoefficientsWithoutNulls(L.Coefficients);
            this.n = this.coefficients.Length;
        }

        public LagrangePolynomial(Tuple<double, double>[] nodes) : this(nodes, nodes.Length) { }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial p1 = new Polynomial(new double[] { 1, 2, 3, 4 });
            Polynomial p2 = new Polynomial(new double[] { 1, 2 });
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p1 + p2);
            Console.WriteLine(p1 - p2);
            Console.WriteLine(p1 * p2);
            Console.WriteLine(p1 + 100);
            Console.WriteLine(p1 - 100);
            Console.WriteLine(p1 * 100);
            Console.WriteLine(p1 / 100);

            LagrangePolynomial lp1 = new LagrangePolynomial(new Tuple<double, double>[] { new Tuple<double, double>(-1.5, -14.1014), new Tuple<double, double>(-0.75, -0.931596), new Tuple<double, double>(0, 0), new Tuple<double, double>(0.75, 0.931596), new Tuple<double, double>(1.5, 14.1014) });

            Console.WriteLine(lp1);
        }
    }
}
