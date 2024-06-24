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
            public double X { get; }
            public double Y { get; }

            public Point(double[] coordinates)
            {
                if (coordinates.Length == 2)
                {
                    X = coordinates[0];
                    Y = coordinates[1];
                }
            }

            public override string ToString()
            {
                return $"x = {X}, y = {Y}";
            }

            public double Length(Point other)
            {
                double distance = Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
                return Math.Round(distance, 2);
            }

            public static string DistanceInfo(Point p1, Point p2)
            {
                double distance = p1.Length(p2);
                return $"{p1}\n{p2}\nDistance = {distance}";
            }
        }

        private Point[] P;

        public Point[] Points => P;

        public Task1(Point[] points)
        {
            P = points;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var point in P)
            {
                result += point.ToString() + "\n";
            }
            return result.TrimEnd();
        }


        private void QuickSort(Point[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high);
                QuickSort(array, low, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, high);
            }
        }

        private int Partition(Point[] array, int low, int high)
        {
            Point pivot = array[high];
            double pivotDistance = pivot.Length(new Point(new double[] { 0, 0 }));
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j].Length(new Point(new double[] { 0, 0 })) <= pivotDistance)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, high);
            return i + 1;
        }

        private void Swap(Point[] array, int i, int j)
        {
            Point temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        public void Sorting()
        {
            QuickSort(P, 0, P.Length - 1);
        }
    }
}
