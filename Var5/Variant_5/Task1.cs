using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Variant_5
{
    public class Task1
    {
        public struct Rectangle
        {
            private int length;
            private int width;
            public Rectangle(int length, int width)
            {
                if (length > 0) this.length = length;
                else this.length = 0;
                if (width > 0) this.width = width;
                else this.width = 0;
            }
            public int A
            {
                get { return length; }
            }
            public int B
            {
                get { return width; }
            }
            public int Length()
            {
                return (length + width) * 2;
            }
            public int Area()
            {
                return length * width;
            }
            public int Compare(Rectangle second)
            {
                int firstS = this.Area();
                int secondS = second.Area();

                if (firstS > secondS) return 1;
                else if (firstS < secondS) return -1;
                else return 0;
            }
            public override string ToString()
            {
                return $"a = {length}, b = {width}, p = {Length()}, s = {Area()}";
            }
        }
        private Rectangle[] rectangles;
        public Rectangle[] Rectangles
        {
            get { return rectangles; }
        }
        public Task1(Rectangle[] rectangles)
        {
            this.rectangles = rectangles;
        }
        public override string ToString()
        {
            string result = "";
            foreach (var rectangle in rectangles)
            {
                result += rectangle.ToString() + "\n";
            }
            return result;
        }
        public void Sorting()
        {
            int d = rectangles.Length / 2;
            while (d >= 1)
            {
                for (int i = d; i < rectangles.Length; i += d)
                {
                    Rectangle k = rectangles[i];
                    int j = i - d;

                    while (j >= 0 && rectangles[j].Length() > k.Length())
                    {
                        rectangles[j + d] = rectangles[j];
                        j -= d;
                    }
                    rectangles[j + d] = k;
                }

                d = d / 2;
            }
        }
    }
}
