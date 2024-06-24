using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Variant_5
{
    public class Task3
    {
        public class Statistic
        {
            private string input;
            private double output;
            public string Input
            {
                get { return input; }
            }
            public double Output
            {
                get { return output; }
            }
            public Statistic(string text)
            {
                input = text;
                output = Slogi(text);
            }

            private double Slogi(string text)
            {
                if (string.IsNullOrEmpty(input))
                {
                    return 0;
                }

                string[] words = text.Split(" ");

                if (words.Length == 0)
                {
                    return 0;
                }


                double total = 0;
                foreach (var word in words)
                {
                    total += Count(word);
                }

                return total / words.Length;
            }

            private static int Count(string word)
            {
                word = word.ToLower();
                int k = 0;
                char[] glasnie = new char[] { 'у', 'е', 'ё', 'ы', 'а', 'о', 'э', 'я', 'и', 'ю' };
                for (int i = 0; i < word.Length; i++)
                {
                    for (int j = 0; j < glasnie.Length; j++)
                    {
                        if (word[i] == glasnie[j])
                        {
                            k++;
                        }
                    }
                }
                return k;
            }

            public override string ToString()
            {
                if (string.IsNullOrEmpty(input) || output == 0)
                {
                    return string.Empty;
                }
                return $"{output:f2}";
            }
        }
    }
}
