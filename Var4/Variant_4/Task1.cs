using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Variant_4
{
    public class Task1
    {
        public Triangle[] Triangles { get; set; }

        public Task1(Triangle[] triangles)
        {
            Triangles = triangles;
        }

        public override string ToString()
        {
            string ans = "";
            foreach (Triangle triangle in Triangles)
            {
                ans += triangle + "\n";
            }

            return ans;
        }

        public void Sorting()
        {
            if (Triangles == null || Triangles.Length == 0)
                return;
            QuickSort(0, Triangles.Length - 1);
        }

        private void QuickSort(int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(low, high);
                QuickSort(low, pivotIndex - 1);
                QuickSort(pivotIndex + 1, high);
            }
        }

        private int Partition(int low, int high)
        {
            Triangle pivot = Triangles[high];
            double pivotArea = pivot.Area();
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (Triangles[j].Area() <= pivotArea)
                {
                    i++;
                    Swap(ref Triangles[i], ref Triangles[j]);
                }
            }

            Swap(ref Triangles[i + 1], ref Triangles[high]);
            return i + 1;
        }

        private void Swap(ref Triangle a, ref Triangle b)
        {
            Triangle temp = a;
            a = b;
            b = temp;
        }

        public struct Triangle
        {
            public int[] abc { get; private set; } = new int[3];
            public int A { get; private set; }
            public int B { get; private set; }
            public int C { get; private set; }

            public Triangle(int[] abc)
            {
                if (abc.Length == 3)
                {
                    A = abc[0];
                    B = abc[1];
                    C = abc[2];
                    this.abc = abc;
                    CheckTriangle();
                }
            }

            private void CheckTriangle()
            {
                if (A + B <= C || A + C <= B || B + C <= A || A < 0 || B < 0 || C < 0)
                {
                    abc = new int[] { 0, 0, 0 };
                }
            }

            public double Area()
            {
                double p = (abc[0] + abc[1] + abc[2]) / 2.0;
                return Math.Round(Math.Sqrt(p * (p - abc[0]) * (p - abc[1]) * (p - abc[2])), 2);
            }

            public string Distinct()
            {
                if (A == B && B == C && C == A)
                {
                    return "равносторонний";
                }

                if (A == B || B == C || C == A)
                {
                    return "равнобедренный";
                }

                return "разносторонний";
            }

            public override string ToString()
            {
                return
                    $"Type = Triangle, subtype = {Distinct()}, a = {abc[0]}, b = {abc[1]}, c = {abc[2]}, with S = {Area()}";
            }
        }
    }
}