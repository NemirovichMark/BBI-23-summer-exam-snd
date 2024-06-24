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

            public double Real
            {
                get { return real; }
            }

            public Number(double realPart)
            {
                real = realPart;
            }

            public Number Add(Number n)
            {
                return new Number(real + n.Real);
            }

            public Number Sub(Number n)
            {
                return new Number(real - n.Real);
            }

            public Number Mul(Number n)
            {
                return new Number(real * n.Real);
            }

            public Number Div(Number n)
            {
                if (n.Real != 0)
                {
                    return new Number(real / n.Real);
                }
                else
                {
                    return new Number(0);
                }

            }
        }
        private Number[] numbers;

        public Number[] Numbers
        {
            get { return numbers; }
        }

        public Task1(Number[] nums)
        {
            numbers = nums;
        }


        public void Sorting()
        {
            bool swap;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                swap = false;
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j].Real > numbers[j + 1].Real)
                    {
                        Number temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                        swap = true;
                    }
                }

                if (!swap)
                {
                    break;
                }
            }
        }


        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                result += "Number = " + numbers[i].Real;
                if (i < numbers.Length - 1)
                {
                    result += "\n";
                }
            }
            return result;
        }
    }
}