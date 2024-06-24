using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Variant_1
{
    public class Task2
    {
        public Task2(ComplexNumber[] _numbers)
        {
            numbers = _numbers;
        }
        private ComplexNumber[] numbers;
        public ComplexNumber[] Numbers { get { return Numbers; } }

        public void Sorting()
        {
            throw new NotImplementedException();
        }

        public class Number
        {
            private double real;

            public double Real
            {
                get { return real; }
            }

            public Number(double realPart)
            {
                real = realPart;
            }

            public Number Add(Number num)
            {
                return new Number(real + num.Real);
            }

            public Number Sub(Number num)
            {
                return new Number(real - num.Real);
            }

            public Number Mul(Number num)
            {
                return new Number(real * num.Real);
            }

            public Number Div(Number num)
            {
                if (num.Real != 0)
                {
                    return new Number(real / num.Real);
                }
                else
                {
                    return new Number(0);
                }

            }

            private ComplexNumber[] complexNumbers;

            public ComplexNumber[] ComplexNumbers { get { return complexNumbers; } }

            public void Task2(ComplexNumber[] nums)
            {
                complexNumbers = nums;
            }

            public void Sorting()
            {
                bool swapped;
                for (int i = 0; i < complexNumbers.Length - 1; i++)
                {
                    swapped = false;
                    for (int j = 0; j < complexNumbers.Length - i - 1; j++)
                    {
                        if (Math.Sqrt(complexNumbers[j].Real * complexNumbers[j].Real + complexNumbers[j].Imagine * complexNumbers[j].Imagine) > Math.Sqrt(complexNumbers[j + 1].Real * complexNumbers[j + 1].Real) + complexNumbers[j + 1].Imagine * complexNumbers[j + 1].Imagine)
                        {
                            ComplexNumber temp = complexNumbers[j];
                            complexNumbers[j] = complexNumbers[j + 1];
                            complexNumbers[j + 1] = temp;
                            swapped = true;
                        }
                    }

                    if (!swapped)
                    {
                        break;
                    }
                }
            }
            public override string ToString()
            {
                string result = "";
                foreach (var num in complexNumbers)
                {
                    result += Math.Sqrt(num.Real * num.Real + num.Imagine * num.Imagine).ToString() + "\n";
                }
                return result;
            }
        }

        public class ComplexNumber : Number
        {
            private double real;

            public double Real
            {
                get { return real; }
            }

            private double imaginary;

            public double Imagine { get { return imaginary; } }

            public ComplexNumber(double realPart, double imaginaryPart) : base(realPart)
            {
                this.real = realPart;
                imaginary = imaginaryPart;
            }
            public ComplexNumber Add(ComplexNumber num)
            {
                return new ComplexNumber(Real + num.Real, Imagine + num.Imagine);
            }

            public ComplexNumber Sub(ComplexNumber num)
            {
                return new ComplexNumber(Real - num.Real, Imagine - num.Imagine);
            }

            public ComplexNumber Mul(ComplexNumber num)
            {
                double resultReal = Real * num.Real - Imagine * num.Imagine;
                double resultImagine = Real * num.Imagine + Imagine * num.Real;
                return new ComplexNumber(resultReal, resultImagine);
            }

            public ComplexNumber Div(ComplexNumber num)
            {
                double divisor = num.Real * num.Real + num.Imagine * num.Imagine;
                if (divisor != 0)
                {
                    double resultReal = (Real * num.Real + Imagine * num.Imagine) / divisor;
                    double resultImagine = (Imagine * num.Real - Real * num.Imagine) / divisor;
                    return new ComplexNumber(resultReal, resultImagine);
                }
                else
                {
                    return new ComplexNumber(0, 0);
                }
            }
            public override string ToString()
            {
                return $"Число = {Real} ± {Imagine}i";
            }

        }

    }
}