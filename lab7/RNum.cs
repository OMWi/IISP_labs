using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace lab7
{
    class RNum : IEquatable<RNum>, IComparable<RNum>
    {
        int n;
        int m;
        public RNum(int n, int m)
        {
            if (m <= 0)
            {
                throw new ArgumentException(m.ToString(), "Wrong denominator");
            }
            this.m = m;
            this.n = n;
        }
        private static int NOD(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }
        public static bool operator >(RNum a, RNum b)
        {
            int denominator = a.m * b.m / NOD(a.m, b.m);
            int numeratorA = denominator / a.m * a.n;
            int numeratorB = denominator / b.m * b.n;
            return numeratorA > numeratorB;
        }
        public static bool operator <(RNum a, RNum b)
        {
            int denominator = a.m * b.m / NOD(a.m, b.m);
            int numeratorA = denominator / a.m * a.n;
            int numeratorB = denominator / b.m * b.n;
            return numeratorA < numeratorB;
        }
        public static bool operator <=(RNum a, RNum b)
        {
            int denominator = a.m * b.m / NOD(a.m, b.m);
            int numeratorA = denominator / a.m * a.n;
            int numeratorB = denominator / b.m * b.n;
            return numeratorA <= numeratorB;
        }
        public static bool operator >=(RNum a, RNum b)
        {
            int denominator = a.m * b.m / NOD(a.m, b.m);
            int numeratorA = denominator / a.m * a.n;
            int numeratorB = denominator / b.m * b.n;
            return numeratorA >= numeratorB;
        }
        public static RNum operator +(RNum a, RNum b)
        {
            int denominator = a.m * b.m / NOD(a.m, b.m);
            int numeratorA = denominator / a.m * a.n;
            int numeratorB = denominator / b.m * b.n;
            return new RNum(numeratorA + numeratorB, denominator);
        }
        public static RNum operator -(RNum a, RNum b)
        {
            int denominator = a.m * b.m / NOD(a.m, b.m);
            int numeratorA = denominator / a.m * a.n;
            int numeratorB = denominator / b.m * b.n;
            return new RNum(numeratorA - numeratorB, denominator);
        }
        public static RNum operator *(RNum a, RNum b)
        {
            return new RNum(a.n * b.n, a.m * b.m);
        }
        public static RNum operator /(RNum a, RNum b)
        {
            return new RNum(a.n * b.m, a.m * b.n);
        }
        public static bool operator ==(RNum a, RNum b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(RNum a, RNum b)
        {

            return !a.Equals(b);
        }
        public bool Equals(RNum num)
        {
            int denominator = this.n * num.n / NOD(this.m, num.m);
            int numeratorA = denominator / this.m * this.n;
            int numeratorB = denominator / num.m * num.n;
            if (numeratorA == numeratorB)
            {
                return true;
            }
            return false;
        }
        public int CompareTo(RNum num)
        {
            RNum number = (RNum)num;
            if (number == null)
            {
                throw new ArgumentException("Not comparable");
            }
            return this == number ? 0 : this > number ? 1 : -1;

        }
        public static explicit operator double(RNum num)
        {
            return (double)num.n / num.m;
        }        
        public static explicit operator int(RNum num)
        {
            return num.n / num.m;
        }
        public static implicit operator RNum(int num)
        {
            return new RNum(num, 1);
        }
        public static RNum Parse(string num)
        {
            if (Regex.IsMatch(num, @"\d+\s?/|:\s?\d+"))
            {
                List<int> numList = new List<int>();
                var numbers = Regex.Matches(num, @"\d+");
                foreach (Match match in numbers)
                {
                    numList.Add(int.Parse(match.Value));
                }
                return new RNum(numList[0], numList[1]);
            }
            throw new ArgumentException("No matching format");
        }
        public string ToString(char option)
        {
            if (option == 'c')
            {
                return n.ToString() + "/" + m.ToString();
            }
            else if (option == 'd')
            {
                return (n.ToString() + ':' + m.ToString());
            }
            throw new ArgumentException(option.ToString(), " is not existing");
        }
    }
}