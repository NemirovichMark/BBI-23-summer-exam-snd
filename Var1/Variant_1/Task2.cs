using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Variant_1
{
    public class Task2
    {
        public class Number
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

        public class ComplexNumber : Number
        {
            private double imagine;

            public ComplexNumber(double real, double imagine) : base(real)
            {
                this.imagine = imagine;
            }

            public double Imagine
            {
                get { return imagine; }
            }

            public ComplexNumber Add(ComplexNumber other)
            {
                return new ComplexNumber(this.Real + other.Real, this.imagine + other.imagine);
            }

            public ComplexNumber Sub(ComplexNumber other)
            {
                return new ComplexNumber(this.Real - other.Real, this.imagine - other.imagine);
            }

            public ComplexNumber Mul(ComplexNumber other)
            {
                double realPart = this.Real * other.Real - this.imagine * other.imagine;
                double imaginePart = this.Real * other.imagine + this.imagine * other.Real;
                return new ComplexNumber(realPart, imaginePart);
            }

            public ComplexNumber Div(ComplexNumber other)
            {
                double denominator = other.Real * other.Real + other.imagine * other.imagine;
                if (denominator == 0)
                    throw new DivideByZeroException("Cannot divide by zero.");

                double realPart = (this.Real * other.Real + this.imagine * other.imagine) / denominator;
                double imaginePart = (this.imagine * other.Real - this.Real * other.imagine) / denominator;
                return new ComplexNumber(realPart, imaginePart);
            }

            public override string ToString()
            {
                return $"Number = {Real} {(imagine >= 0 ? "+" : "-")} {Math.Abs(imagine)}i";
            }
        }

        private ComplexNumber[] numbers;

        public Task2(ComplexNumber[] initialNumbers)
        {
            this.numbers = initialNumbers;
        }

        public ComplexNumber[] Numbers
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
                    double modulusJ = GetModulus(numbers[j]);
                    double modulusJ1 = GetModulus(numbers[j + 1]);

                    if (modulusJ > modulusJ1)
                    {
                        Number temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
        }

        private double GetModulus(Number number)
        {
            if (number is ComplexNumber complexNumber)
            {
                return Math.Sqrt(complexNumber.Real * complexNumber.Real + complexNumber.Imagine * complexNumber.Imagine);
            }
            else
            {
                return Math.Abs(number.Real);
            }
        }
    }

//    class Program
//    {
//        static void Main()
//        {
//            var numbersArray = new Task2.Number[]
//            {


//new Task2.Number(5.5),
//            new Task2.Number(3.2),
//            new Task2.ComplexNumber(4, 3),
//            new Task2.ComplexNumber(1, -1),
//            new Task2.Number(7.1)
//            };

//            Task2 task = new Task2(numbersArray);

//            Console.WriteLine("Original array:");
//            Console.WriteLine(task.ToString());

//            task.Sorting();

//            Console.WriteLine("Sorted array:");
//            Console.WriteLine(task.ToString());
//        }
//    }
}

   
