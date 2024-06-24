using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Variant_1
{
    public class Task1
    {
        public struct Number
        {
            private double real;

            public Number(double real)
            {
                this.real = real;
            }

            public double Real
            {
                get { return real; }
            }

            public Number Add(Number other)
            {
                return new Number(this.real + other.real);
            }

            public Number Sub(Number other)
            {
                return new Number(this.real - other.real);
            }

            public Number Mul(Number other)
            {
                return new Number(this.real * other.real);
            }

            public Number Div(Number other)
            {
                if (other.real == 0)
                    throw new DivideByZeroException("Cannot divide by zero.");
                return new Number(this.real / other.real);
            }

            public override string ToString()
            {
                return $"Number = {real}";
            }
        }

        private Number[] numbers;

        public Task1(Number[] initialNumbers)
        {
            this.numbers = initialNumbers;
        }

        public Number[] Numbers
        {
            get { return numbers; }
        }

        public override string ToString()
        {
            string result = "";
            foreach (var number in numbers)
            {
                result += number.ToString() + Environment.NewLine;
            }
            return result;
        }

        public void Sorting()
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (numbers[j].Real > numbers[j + 1].Real)
                    {
                        Number temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
        }
    }

    //class Program
    //{
    //    static void Main()
    //    {
    //        var numbersArray = new Task1.Number[]
    //        {
    //        new Task1.Number(5.5),
    //        new Task1.Number(3.2),
    //        new Task1.Number(9.8),
    //        new Task1.Number(1.5),
    //        new Task1.Number(7.1)
    //        };

    //        Task1 task = new Task1(numbersArray);

    //        Console.WriteLine("Original array:");
    //        Console.WriteLine(task.ToString());

    //        task.Sorting();

    //        Console.WriteLine("Sorted array:");
    //        Console.WriteLine(task.ToString());
    //    }
    //}
}

   
