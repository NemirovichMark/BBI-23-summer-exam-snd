using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Variant_2
{
    public class Task1
    {
        public struct Point
        {
            private double x;
            private double y;
            public double X { get { return x; } }
            public double Y { get { return y; } }
            public Point(double[] coords)
            {
                if (coords.Length == 2)
                {
                    x = coords[0];
                    y = coords[1];
                }
            }
            public override string ToString()
            {
                return $"x = {x}, y = {y}";
            }
            public double Length(Point p)
            {
                return Math.Sqrt(Math.Pow(x - p.X, 2) + Math.Pow(y - p.Y, 2));
            }
            public static string TwoDots(Point p1, Point p2)
            {
                return $"Первая точка:\nx = {p1.X}, y = {p1.Y}\nВторая точка:\nx = {p2.X}, y = {p2.Y}\nРасстояние между точками: {p1.Length(p2)}";
            }
        }
        private Point[] points;
        public Point[] Points { get { return points; } }
        public Task1(Point[] points)
        {
            this.points = points;
        }
        public override string ToString()
        {
            string res = "";
            foreach (Point p in Points) { res += p.ToString() + "\n"; }
            return res;
        }
        public void Sorting()
        {
            Point O = new Point(new double[] { 0, 0 });
            int n = points.Length;
            for (int i = 1; i < n; i++)
            {
                Point val = points[i];
                for (int j = i - 1; j >= 0;)
                {
                    if (val.Length(O) < points[j].Length(O))
                    {
                        points[j + 1] = points[j];
                        j--;
                        points[j + 1] = val;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}